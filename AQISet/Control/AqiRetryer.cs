using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Collections;
using System.Configuration;
using AQI;
using AQI.Interface;
using AQISet.Control;
using AQISet.Cfg;
using AQISet.Collection;
using AQISet.Interface;

namespace AQISet.Control
{
    /// <summary>
    /// 重试者
    /// </summary>
    public sealed class AqiRetryer : IStatus
    {

        #region 字段

        private string name;        //名称
        private AqiManage am;       //管理者引用
        private Thread thr;         //线程引用

        private Dictionary<string, RetryNode> history;   //历史记录
        private ReaderWriterLockSlim historyLock;        //读写锁

        private Queue m_queue;                      //队列
        private AutoResetEvent m_eventReadAsync;    //读线程使用的自动事件
        private AutoResetEvent m_eventWriteAsync;   //写线程使用的自动事件
        private int m_iCurrentCount;                //队列的当前元素数目
        private int m_iMaxCount;                    //队列的最大元素数目

        #endregion

        public AqiRetryer(AqiManage manage)
        {
            name = "DefaultRetryer";
            am = manage;
            
            history = new Dictionary<string, RetryNode>();
            historyLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

            m_queue = Queue.Synchronized(new Queue());
            m_eventReadAsync = new AutoResetEvent(false);
            m_eventWriteAsync = new AutoResetEvent(false);
            m_iCurrentCount = 0;

            m_iMaxCount = int.MaxValue - 1;
            int i = AqiManage.Setting.Get<int>("AqiRetryer.MaxQueue");
            if (i > 0)
            {
                m_iMaxCount = i;
            }

            thr = new Thread(threadRun);
            thr.Start();
        }

        #region 名称队列

        /// <summary>
        /// 往队列插入元素
        /// </summary>
        private void Push(string o)
        {
            if (m_iCurrentCount >= m_iMaxCount) //如果已经达到队列容量
            {
                //TODO
                //会堵塞整个Timer线程
                AqiManage.Remind.Log_Error("重试队列已满，无法添加重试节点，线程被堵塞");
                m_eventWriteAsync.WaitOne(); //阻塞自己，等待别的线程唤醒
            }
            lock (this)
            {
                m_queue.Enqueue(o); //插入新元素
            }
            if (Interlocked.Increment(ref m_iCurrentCount) >= m_iMaxCount) //如果插入队列之后，达到队列容量
                m_eventWriteAsync.Reset(); //唤醒由于队列为空而阻塞的读线程
            m_eventReadAsync.Set();
        }

        /// <summary>
        /// 从队列弹出元素
        /// </summary>
        private string Pop()
        {
            string o;
            if (m_iCurrentCount <= 0)
                m_eventReadAsync.WaitOne();
            lock (this)
            {
                o = m_queue.Dequeue() as string;
            }
            if (Interlocked.Decrement(ref m_iCurrentCount) <= 0)
                m_eventReadAsync.Reset();
            m_eventWriteAsync.Set();
            return o;
        }

        #endregion

        #region 历史字典

        /// <summary>
        /// 复位
        /// </summary>
        public void ResetHistory()
        {
            this.historyLock.EnterUpgradeableReadLock();
            try
            {
                this.m_queue.Clear();
                this.history.Clear();
            }
            finally
            {
                this.historyLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// 得到历史
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RetryNode GetHistory(string name)
        {
            RetryNode node = null;
            this.historyLock.EnterReadLock();
            try
            {
                if (this.history.ContainsKey(name))
                {
                    node = this.history[name];
                }
            }
            finally
            {
                this.historyLock.ExitReadLock();
            }
            return node;
        }

        /// <summary>
        /// 是否存在历史
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasHistory(string name)
        {
            bool flag = false;
            this.historyLock.EnterReadLock();
            try
            {
                flag = this.history.ContainsKey(name);
            }
            finally
            {
                this.historyLock.ExitReadLock();
            }
            return flag;
        }

        /// <summary>
        /// 添加历史
        /// </summary>
        /// <param name="arn"></param>
        public RetryNode AddHistory(RetryNode arn)
        {
            RetryNode node = null;
            this.historyLock.EnterUpgradeableReadLock();
            try
            {
                if (this.history.ContainsKey(arn.Name))
                {
                    node = this.history[arn.Name];
                    if (node.IsValid())
                    {
                        AqiManage.Remind.Log_Debug("上次时区数据已经丢失,此时区又出现错误", new string[] { this.name, arn.RunnerName });
                        node.Concat(arn);
                    }
                    else
                    {
                        this.historyLock.EnterWriteLock();
                        try
                        {
                            this.history[arn.Name] = arn;
                        }
                        finally
                        {
                            this.historyLock.ExitWriteLock();
                        }
                    }
                }
                else
                {
                    this.historyLock.EnterWriteLock();
                    try
                    {
                        this.history.Add(arn.Name, arn);
                    }
                    finally
                    {
                        this.historyLock.ExitWriteLock();
                    }
                }
                node = this.history[arn.Name];
            }
            finally
            {
                this.historyLock.ExitUpgradeableReadLock();
            }
            return node;
        }

        #endregion

        #region 控制方法

        /// <summary>
        /// 入重试队列
        ///     定时器线程
        /// </summary>
        /// <param name="arName"></param>
        /// <param name="isu"></param>
        /// <param name="ap"></param>
        /// <param name="ex"></param>
        public void PutNew(string arName, ISrcUrl isu, AqiParam ap, Exception ex)
        {
            //封装为重试节点
            RetryNode arn = new RetryNode(arName, isu, ap);
            arn.NodeEvent += new RetryNode.NodeEventHandler(this.node_RunEvent);
            //更新计数
            arn.Update(ex);
            //添加历史记录
            arn = this.AddHistory(arn);
            //入队列
            this.Push(arn.Name);
            AqiManage.Remind.Log_Info("已添加到重试队列", new string[] { this.name, arn.RunnerName, arn.Name });
        }

        /// <summary>
        /// 再次入重试队列
        ///     循环线程
        /// </summary>
        /// <param name="arn"></param>
        /// <param name="ex"></param>
        public void PutAgain(RetryNode arn, Exception ex)
        {
            //更新计数
            arn.Update(ex);
            //检查有效性
            if (!arn.IsValid())
            {
                //读取配置
                if (AqiManage.Setting.Get<bool>("AqiRetryer.AlwayRetry"))
                {
                    //继续重试
                    AqiManage.Remind.Log_Debug("重试已经无效，仍然尝试重试", new string[] { this.name, arn.RunnerName });
                }
                else
                {
                    //停止重试
                    AqiManage.Remind.Log_Error("重试已经无效，暂停", new string[] { this.name, arn.RunnerName });
                    return;
                }
            }
            //入队列：继续重试
            this.Push(arn.Name);
            AqiManage.Remind.Log_Info("已添加到重试队列", new string[] { this.name, arn.RunnerName, arn.Name });
        }

        #endregion

        #region 事件接收

        /// <summary>
        /// 循环线程
        /// </summary>
        private void threadRun()
        {
            while(true)
            {
                //取队列（无数据会堵塞）
                string name = Pop();
                RetryNode arn = GetHistory(name);
                this.am[arn.RunnerName].RetryProcess(arn);
                Thread.Sleep(500);
            }
        }

        private void node_RunEvent(RunMessage m)
        {
            AqiManage.Remind.Log_RunMessage(m);
        }

        #endregion

        #region IStatus接口

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("重试者信息：" + this.name);
            builder.Append("\n\t");
            builder.Append("历史：" + this.history.Count + "次");
            builder.Append("\n\t");
            builder.Append("当前队列数量：" + this.m_queue.Count + "个");
            return builder.ToString();
        }

        #endregion

    }
}
