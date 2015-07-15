using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI;
using AQI.Interface;
using AQISet.Collection;
using AQISet.Interface;

namespace AQISet.Control
{
    /// <summary>
    /// 记录者
    /// </summary>
    public sealed class AqiNoter : IStatus
    {

        #region 字段

        private string name;        //名称
        private AqiManage am;       //管理者引用

        private double size;        //数据总大小
        private long count;         //获取总次数
        private DateTime starttime; //开始时间
        private DateTime endtime;   //结束时间

        private List<NoteNode> history;

        #endregion

        public AqiNoter(AqiManage manage)
        {
            name = "DefaultNoter";
            am = manage;
            starttime = DateTime.Now;
            history = new List<NoteNode>();
        }

        #region 方法

        /// <summary>
        /// 新数据
        /// </summary>
        /// <param name="isu"></param>
        /// <param name="data"></param>
        public NoteNode AddNew(ISrcUrl isu, AqiParam ap, byte[] data)
        {
            int size = 0;
            if (data != null)
            {
                size = data.Length;
            }
            string name = null;
            if (ap == null)
            {
                name = isu.Tag;
            }
            else
            {
                name = isu.Tag + ap.Name;
            }
            NoteNode item = new NoteNode(name, size);
            lock (this.history)
            {
                this.history.Add(item);
                this.endtime = DateTime.Now;
                this.size += item.dateSize;
                this.count += 1L;
            }
            return item;
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
            builder.Append("记录者信息：" + this.name);
            builder.Append("\n\t");
            builder.Append("数据保存次数：" + this.count + "次");
            builder.Append("\n\t");
            builder.Append("已接收数据量：" + this.size + "字节");
            builder.Append("\n\t");
            builder.Append("开始时间：" + this.starttime);
            builder.Append("\n\t");
            builder.Append("结束时间：" + this.endtime);
            return builder.ToString();
        }

        #endregion

    }
}
