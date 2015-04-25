using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI.Interface;
using AQI;
using AQISet.Collection;

namespace AQISet.Runner
{
    /// <summary>
    /// 记录者
    /// </summary>
    public sealed class AqiNoter
    {

        #region 字段

        private string name;        //名称
        private AqiManage am;       //管理者引用

        private double size;        //数据总大小
        private long count;         //获取总次数
        private DateTime starttime; //开始时间
        private DateTime endtime;   //结束时间

        private Dictionary<string, AqiNoteNode> history;

        #endregion

        public AqiNoter(AqiManage manage)
        {
            name = "DefaultNoter";
            am = manage;
            starttime = DateTime.Now;
            history = new Dictionary<string, AqiNoteNode>();
        }

        #region 方法

        /// <summary>
        /// 新数据
        /// </summary>
        /// <param name="isu"></param>
        /// <param name="data"></param>
        public AqiNoteNode AddNew(ISrcUrl isu, AqiParam ap, byte[] data)
        {
            int nSize = data.Length;
            string nName = null;
            if(ap == null)
            {
                nName = isu.TAG;
            }
            else
            {
                nName = isu.TAG + ap.Name;
            }
            AqiNoteNode n = new AqiNoteNode(nName, nSize);

            lock(history)
            {
                history.Add(n.Name, n);

                endtime = DateTime.Now;
                size = size + n.DateSize;
                count++;
            }

            return n;
        }

        /// <summary>
        /// 生成日志
        /// </summary>
        /// <returns></returns>
        public string ToLog()
        {
            return null;
        }

        #endregion

    }
}
