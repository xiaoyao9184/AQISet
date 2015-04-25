using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Interface;
using AQI;
using AQISet.Collection;
using System.Net;
using System.Threading;
using System.Collections;
using AQISet.Exceptions;
using System.Configuration;
using AQISet.Cfg;

namespace AQISet.Runner
{
    /// <summary>
    /// 重试者
    /// </summary>
    public sealed class AqiRetryer
    {

        //#region TEST

        //private static bool set_AlwayRetry;
        //private bool AlwayRetry
        //{
        //    get
        //    {
        //        return AqiRetryer.set_AlwayRetry;
        //    }
        //    set
        //    {
        //        AqiRetryer.set_AlwayRetry = value;
        //    }
        //}

        //#endregion

        #region 字段

        private string name;        //名称
        private AqiManage am;       //管理者引用
        private Thread thr;         //线程引用

        private Dictionary<string, AqiRetryNode> history;   //历史记录
        private ReaderWriterLockSlim historyLock;           //读写锁

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
            
            history = new Dictionary<string, AqiRetryNode>();
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

        #region 主队列

        /// <summary>
        /// 往队列插入元素
        /// </summary>
        private void Push(string o)
        {
            if (m_iCurrentCount >= m_iMaxCount) //如果已经达到队列容量
                m_eventWriteAsync.WaitOne(); //阻塞自己，等待别的线程唤醒
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
        /// 得到历史
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public AqiRetryNode GetHistory(string name)
        {
            AqiRetryNode nResult = null;
            historyLock.EnterReadLock();
            try
            {
                if (history.ContainsKey(name))
                {
                    nResult = history[name];
                }
            }
            finally
            {
                historyLock.ExitReadLock();
            }
            return nResult;
        }

        /// <summary>
        /// 是否存在历史
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool HasHistory(string name)
        {
            bool bResult = false;
            historyLock.EnterReadLock();
            try
            {
                bResult = history.ContainsKey(name);
            }
            finally
            {
                historyLock.ExitReadLock();
            }
            return bResult;
        }

        /// <summary>
        /// 添加历史
        /// </summary>
        /// <param name="arn"></param>
        public AqiRetryNode AddHistory(AqiRetryNode arn)
        {
            AqiRetryNode n = null;
            bool bHasHistory = false;
            historyLock.EnterUpgradeableReadLock();
            try
            {
                bHasHistory = history.ContainsKey(arn.NAME);
            
                if (bHasHistory)
                {
                    n = history[arn.NAME];
                    if (n.IsValid())
                    {
                        Console.WriteLine("上次时区数据已经丢失,此时区又出现错误");
                        //历史有效，合并数据
                        n.Concat(arn);
                    }
                    else
                    {
                        //历史无效，替换数据
                        historyLock.EnterWriteLock();
                        try
                        {
                            history[arn.NAME] = arn;
                        }
                        finally
                        {
                            historyLock.ExitWriteLock();
                        }
                    }
                }
                else
                {
                    historyLock.EnterWriteLock();
                    try
                    {
                        history.Add(arn.NAME, arn);
                    }
                    finally
                    {
                        historyLock.ExitWriteLock();
                    }
                }
                n = history[arn.NAME];
            }
            finally
            {
                //退出升级锁。
                historyLock.ExitUpgradeableReadLock();
            }
            return n;
        }

        #endregion

        #region 入队列

        /// <summary>
        /// 入重试队列
        ///     定时器线程
        /// </summary>
        /// <param name="isu"></param>
        /// <param name="ap"></param>
        /// <param name="ex"></param>
        public void PutNew(ISrcUrl isu, AqiParam ap, Exception ex)
        {
            //封装为重试节点
            AqiRetryNode arn = new AqiRetryNode(isu, ap);

            //更新计数
            if (!updateNode(arn, ex))
            {
                return;
            }

            //添加历史记录
            arn = AddHistory(arn);
            
            //入队列
            Push(arn.NAME);
        }

        /// <summary>
        /// 再次入重试队列
        ///     循环线程
        /// </summary>
        /// <param name="arn"></param>
        /// <param name="ex"></param>
        public void PutAgain(AqiRetryNode arn, Exception ex)
        {
            //更新计数
            if (!updateNode(arn, ex))
            {
                return;
            } 
            //检查有效性
            if (!arn.IsValid()) 
            {
                //读取配置
                if (AqiManage.Setting.Get<bool>("AqiRetryer.AlwayRetry"))
                {
                    //继续重试
                    Console.WriteLine("重试已经无效，仍然尝试重试");
                }
                else
                {
                    //停止重试
                    Console.WriteLine("重试已经无效，暂停");
                    return;
                }
            }

            //入队列：继续重试
            Push(arn.NAME);
            Console.WriteLine("再入重试队列");
        }

        /// <summary>
        /// 更新计数
        /// </summary>
        /// <param name="arn"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private bool updateNode(AqiRetryNode arn, Exception ex)
        {
            //初始化统计计数
            if (ex is WebException)
            {
                //可忽略错误
                WebException we = ex as WebException;

                if (we.Status == WebExceptionStatus.Timeout)
                {
                    //统计超时次数
                    arn.AddNameCount(AqiRetryNode.NAME_TIMEOUT);
                }
                else
                {
                    //统计网络错误次数
                    arn.AddNameCount(AqiRetryNode.NAME_WEB);
                }
            }
            else
            {
                //不可忽略错误
                arn.AddNameCount(AqiRetryNode.NAME_OTHER);
                Console.WriteLine("不可忽略错误，数据源接口可能变更");
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region 出队列

        /// <summary>
        /// 循环线程
        /// </summary>
        private void threadRun()
        {
            while(true)
            {
                //取队列（无数据会堵塞）
                string name = Pop();
                AqiRetryNode arn = GetHistory(name);
                retryProcess(arn);
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 重试处理
        /// </summary>
        /// <param name="arn"></param>
        private bool retryProcess(AqiRetryNode arn)
        {
            ISrcUrl isu = arn.SRCURL;
            AqiParam ap = arn.PARAM;
            byte[] data = null;
            try
            {
                if (ap != null)
                {
                    data = isu.getDate(ap);
                }
                else
                {
                    data = isu.getDate();
                }
            }
            catch (Exception ex)
            {
                //再 入重试队列
                PutAgain(arn, ex);
                return false;
            }
            am.AqiRun.saveProcess(isu, ap, data);
            //重置
            arn.Reset();
            return true;
        }

        #endregion

    }
}
