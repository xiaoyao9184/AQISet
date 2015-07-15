using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AQI;
using AQI.Interface;
using AQISet.Control;
using System.Net;

namespace AQISet.Collection
{
    /// <summary>
    /// 重试节点
    /// </summary>
    public class RetryNode
    {

        #region 事件

        public delegate void NodeEventHandler(RunMessage m);
        public event NodeEventHandler NodeEvent;

        #endregion

        #region 常量

        public static readonly string NAME_TIMEOUT = "timeout";
        public static readonly string NAME_WEB = "web";
        public static readonly string NAME_OTHER = "other";
        public static readonly string NAME_DATA = "data";

        #endregion

        #region 字段

        private string runnerName;
        private ISrcUrl isu;        //数据接口
        private AqiParam ap;        //参数
        private int count;          //重试次数
        private Dictionary<string, int> counts;//其他次数
        private DateTime starttime; //首次重试时间
        private DateTime endtime;   //最近重试时间

        private ReaderWriterLockSlim thisLock;   //读写锁

        #endregion

        #region 属性

        public string RunnerName
        {
            get
            {
                return this.runnerName;
            }
        }
        public ISrcUrl SrcUrl
        {
            get
            {
                return isu;
            }
        }
        public AqiParam Param
        {
            get
            {
                return ap;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public string Name
        {
            get
            {
                if (ap==null)
                {
                    return isu.Tag;
                }
                return isu.Tag + ap.Name;
            }
        }

        #endregion

        public RetryNode(string arName, ISrcUrl iSrcUrl, AqiParam aqiParam)
        {
            this.runnerName = arName;
            this.ap = aqiParam;
            this.isu = iSrcUrl;
            this.starttime = DateTime.Now;
            this.endtime = DateTime.Now;
            this.count = 1;
            this.counts = new Dictionary<string, int>();
            this.thisLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        #region 方法

        /// <summary>
        /// 重置
        ///     仅循环线程调用
        /// </summary>
        public void Reset()
        {
            thisLock.EnterWriteLock();
            try
            {
                this.starttime = DateTime.MinValue;
                this.endtime = DateTime.MinValue;
                this.count = 0;
                this.counts.Clear();
            }
            finally
            {
                thisLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public bool Update(Exception ex)
        {
            if (ex is WebException)
            {
                WebException exception = ex as WebException;
                if (exception.Status == WebExceptionStatus.Timeout)
                {
                    this.AddNameCount(NAME_TIMEOUT);
                }
                else
                {
                    this.AddNameCount(NAME_WEB);
                }
            }
            else
            {
                this.AddNameCount(NAME_OTHER);
                if (this.NodeEvent != null)
                {
                    this.NodeEvent(new RunMessage(RunMessage.RunType.ERR, "不可忽略错误，数据源接口可能变更", null));
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 合并
        ///     仅定时线程调用
        /// </summary>
        /// <param name="node"></param>
        public void Concat(RetryNode node)
        {
            thisLock.EnterWriteLock();
            try
            {
                this.isu = node.isu;
                this.ap = node.ap;
                this.starttime = DateTime.Now;
                this.endtime = DateTime.Now;
                this.count = 1;

                //将NAME_DATA计数保留，其他清空
                int i = 0;
                if (this.counts.ContainsKey(NAME_DATA))
                {
                    i = this.counts[NAME_DATA];
                }
                this.counts.Clear();
                this.counts.Add(NAME_DATA, i);
                this.counts = this.counts.Concat(node.counts).ToDictionary(x => x.Key, y => y.Value);
                AddNameCount(NAME_DATA);
            }
            finally
            {
                thisLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// 增加重试计数
        /// </summary>
        /// <returns>返回重试次数</returns>
        public int AddCount()
        {
            thisLock.EnterWriteLock();
            try
            {
                endtime = DateTime.Now;
                count++;
            }
            finally
            {
                thisLock.ExitWriteLock();
            }
            return count;
        }

        /// <summary>
        /// 增加计数
        /// </summary>
        /// <param name="name"></param>
        /// <returns>返回次数</returns>
        public int AddNameCount(string name)
        {
            int iResult = 1;
            thisLock.EnterWriteLock();
            try
            {
                if (counts.ContainsKey(name))
                {
                    endtime = DateTime.Now;
                    counts[name]++;
                    iResult = counts[name];
                }
                else
                {
                    counts.Add(name, iResult);
                }
            }
            finally
            {
                thisLock.ExitWriteLock();
            }
            return iResult;
        }

        /// <summary>
        /// 获取计数
        /// </summary>
        /// <param name="name"></param>
        /// <returns>返回次数</returns>
        public int GetNameCount(string name)
        {
            int iResult = 0;
            thisLock.EnterReadLock();
            try
            {
                if (counts.ContainsKey(name))
                {
                    iResult = counts[name];
                }
            }
            finally
            {
                thisLock.ExitReadLock();
            }
            return iResult;
        }

        /// <summary>
        /// 是否超计数
        /// </summary>
        /// <returns></returns>
        public bool IsCountOut()
        {
            bool flag = false;
            this.thisLock.EnterReadLock();
            try
            {
                if (this.count >= AqiManage.Setting.Get<int>("AqiRetryer.RetryCount"))
                {
                    AqiManage.Remind.Log_Debug("重试次数太多，需要人工介入", new string[] { this.runnerName, this.isu.Name });
                    flag = true;
                }
                foreach (KeyValuePair<string, int> pair in this.counts)
                {
                    if (pair.Value >= 10)
                    {
                        AqiManage.Remind.Log_Debug("重试次数太多，需要人工介入", new string[] { this.runnerName, this.isu.Name });
                        return true;
                    }
                }
            }
            finally
            {
                this.thisLock.ExitReadLock();
            }
            return flag;
        }

        /// <summary>
        /// 是否超时
        /// </summary>
        /// <returns></returns>
        public bool IsTimeOut()
        {
            TimeSpan tsEnd;
            TimeSpan tsNow;
            this.thisLock.EnterReadLock();
            try
            {
                tsEnd = new TimeSpan(endtime.Ticks);
                tsNow = new TimeSpan(DateTime.Now.Ticks);
            }
            finally
            {
                this.thisLock.ExitReadLock();
            }
            TimeSpan ts = tsNow.Subtract(tsEnd).Duration();
            //检测是否达到时间超时
            //TEST 1小时
            if (ts.TotalHours > 1)
            {
                AqiManage.Remind.Log_Debug("历史记录超时", new string[] { this.runnerName, this.isu.Name });
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            bool bResult = true;
            thisLock.EnterReadLock();
            try
            {
                if (this.count <= 0)
                {
                    bResult = false;
                }
            }
            finally
            {
                thisLock.ExitReadLock();
            }

            if (!bResult)
            {
                return bResult;
            }

            if (IsTimeOut())
            {
                return false;
            }

            if (IsCountOut())
            {
                return false;
            }
            
            return bResult;
        }

        #endregion

    }
}
