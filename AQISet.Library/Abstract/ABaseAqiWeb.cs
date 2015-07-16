using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using AQI.Interface;
using AQI.Exception;
using System.Threading;


namespace AQI.Abstract
{
    public abstract class ABaseAqiWeb : IAqiWeb, ICacheConfig
    {

        #region 字段

        /// <summary>
        /// 所有ISrcUrl类名称
        ///     IAqiWeb
        /// </summary>
        protected List<string> allSrcNames;
        /// <summary>
        /// 所有ISrcUrl
        ///     IAqiWeb
        /// </summary>
        protected Dictionary<string, ISrcUrl> allSrcUrls;
        /// <summary>
        /// 所有配置
        ///     ICacheConfig
        /// </summary>
        protected Dictionary<string, AqiConfig> allConfig;
        /// <summary>
        /// 参数缓存时间戳
        ///     ICacheConfig
        /// </summary>
        protected DateTime dtConfigCacheTime = DateTime.MinValue;

        private ReaderWriterLockSlim thisLock;        //读写锁

        #endregion

        #region 属性

        public abstract string Name{ get; }
        public abstract string Tag { get; }
        public abstract string Url { get; }
        public abstract string[] SrcUrlNameSpace { get; }
        public abstract AQI.AqiConstant.SourceLevel SRC { get; }
        public abstract AQI.AqiConstant.DataType DAT { get; }

        /// <summary>
        /// 配置缓存
        ///     实现ICacheConfig
        /// </summary>
        public List<AqiConfig> ConfigCache
        {
            get
            {
                return allConfig.Values.ToList<AqiConfig>();
            }
        }

        #endregion

        public ABaseAqiWeb()
        {
            allSrcNames = new List<string>();
            foreach (string ns in SrcUrlNameSpace)
            {
                allSrcNames.AddRange(getAllClass(ns));
            }
            allSrcNames.Sort();

            thisLock = new ReaderWriterLockSlim();
            LoadConfigs();
        }

        #region 内部函数

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

        #region IAqiWeb接口

        /// <summary>
        /// 获得所有数据源
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

        #endregion

        #region ICacheConfig接口

        /// <summary>
        /// 读取 JSON配置文件 路径
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
        /// 过期检查
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConfigsExpired()
        {
            DateTime dtNewWriteTime = AqiConfig.ReadWriteTimeFormJson(this);
            if (dtNewWriteTime > this.dtConfigCacheTime)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public virtual bool LoadConfigs() 
        {
            thisLock.EnterWriteLock();

            List<AqiConfig> list = AqiConfig.CreateListFormJson(this);

            this.allConfig = list.ToDictionary<AqiConfig, string>(ac => ac.Name);
            this.dtConfigCacheTime = AqiConfig.ReadWriteTimeFormJson(this);

            thisLock.ExitWriteLock();
            return true;
        }

        /// <summary>
        /// 是否开启
        ///     实现线程安全
        /// </summary>
        /// <param name="name"></param>
        /// <returns>没有配置的文件默认开启</returns>
        public virtual bool IsSrcUrlEnabled(string name)
        {
            if (IsConfigsExpired())
            {
                LoadConfigs();
            }

            if(this.allConfig.ContainsKey(name))
            {
                return this.allConfig[name].Enabled;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}
