using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQISet.Collection
{
    /// <summary>
    /// 记录节点
    /// </summary>
    public class NoteNode
    {

        #region 字段

        public readonly string name;    //名称
        public readonly int dateSize;   //数据大小

        private byte[] data;
        private bool saved;

        #endregion

        #region 属性

        /// <summary>
        /// 数据
        /// </summary>
        public byte[] Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        /// <summary>
        /// 是否保存成功
        /// </summary>
        public bool Saved
        {
            set
            {
                saved = value;
            }
            get
            {
                return saved;
            }
        }

        #endregion

        public NoteNode(string name, int size)
        {
            this.dateSize = size;
            this.name = name;
        }
    
    }
}
