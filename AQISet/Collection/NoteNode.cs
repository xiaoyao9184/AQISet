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

        public readonly string Name;    //名称
        public readonly int DateSize;   //数据大小

        private bool saved;

        #endregion

        #region 属性

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
            this.DateSize = size;
            this.Name = name;
        }
    
    }
}
