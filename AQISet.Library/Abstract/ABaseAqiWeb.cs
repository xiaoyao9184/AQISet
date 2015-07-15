using System;
using System.Collections.Generic;
using System.Reflection;
using AQI.Interface;

namespace AQI.Abstract
{
    public abstract class ABaseAqiWeb : IAqiWeb
    {

        #region 字段

        /// <summary>
        /// 所有ISrcUrl类名称
        /// </summary>
        protected List<string> allSrcNames;
        /// <summary>
        /// 所有ISrcUrl
        /// </summary>
        protected Dictionary<string, ISrcUrl> allSrcUrls;

        #endregion

        #region 属性

        public abstract string Name{ get; }
        public abstract string Tag { get; }
        public abstract string Url { get; }
        public abstract string[] SrcUrlNameSpace { get; }
        public abstract AQI.AqiConstant.SourceLevel SRC { get; }
        public abstract AQI.AqiConstant.DataType DAT { get; }
        
        #endregion

        public ABaseAqiWeb()
        {
            allSrcNames = new List<string>();
            foreach (string ns in SrcUrlNameSpace)
            {
                allSrcNames.AddRange(getAllClass(ns));
            }
            allSrcNames.Sort();
        }

        #region 方法

        /// <summary>
        /// 读取 JSON配置文件 路径
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual string GetJsonFile()
        {
            //JSON文件
            string exeFile = this.GetType().Assembly.Location;
            int p = exeFile.LastIndexOf('\\');
            string dllPath = exeFile.Substring(0, p);
            string jsonFile = dllPath + "\\JSON\\" + this.Tag + ".json";

            return jsonFile;
        }

        /// <summary>
        /// 获得所有数据源
        ///      可以重写
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, ISrcUrl> GetAllSrcUrl()
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
                {
                    if (type.GetInterface("ISrcUrl") != null)
                    {
                        namespacelist.Add(type.FullName);
                    }
                }  
            }

            return namespacelist;
        }

        #endregion

    }
}
