using System;
using System.Collections.Generic;
using System.Reflection;
using AQI.Interface;

namespace AQI.Abstract
{
    public abstract class ABaseAqiWeb
    {

        #region 字段

        protected List<string> allSrcNames;
        protected Dictionary<string, ISrcUrl> allSrcUrls;

        #endregion

        #region 属性

        public abstract string NAME{ get; }
        public abstract string TAG { get; }
        public abstract string URL { get; }
        public abstract AQI.AqiConstant.SourceLevel SRC { get; }
        public abstract AQI.AqiConstant.DataType DAT { get; }
        
        #endregion

        #region 方法

        /// <summary>
        /// 读取 JSON配置文件 路径
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual string getJsonFile()
        {
            //JSON文件
            string exeFile = this.GetType().Assembly.Location;
            int p = exeFile.LastIndexOf('\\');
            string dllPath = exeFile.Substring(0, p);
            string jsonFile = dllPath + "\\JSON\\" + this.TAG + ".json";

            return jsonFile;
        }

        /// <summary>
        /// 获得所有数据源
        ///      可以重写
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, ISrcUrl> getAllSrcUrl()
        {
            Assembly asm = this.GetType().Assembly;
            if (allSrcUrls == null)
            {
                allSrcUrls = new Dictionary<string, ISrcUrl>();
                foreach (string classname in allSrcNames)
                {
                    Type t = asm.GetType(classname);
                    ISrcUrl src = (ISrcUrl)Activator.CreateInstance(t);
                    src.IAW = this as IAqiWeb;
                    allSrcUrls.Add(classname, src);
                }
            }
            return allSrcUrls;
        }

        /// <summary>
        /// 获得指定命名空间下的所有类名称
        ///     可以重写
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        protected virtual List<string> getAllClass(string nameSpace)
        {
            Assembly asm = Assembly.GetAssembly(this.GetType());

            List<string> namespacelist = new List<string>();
            List<string> classlist = new List<string>();

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == nameSpace)
                    namespacelist.Add(type.FullName);
            }

            return namespacelist;
        }

        #endregion

    }
}
