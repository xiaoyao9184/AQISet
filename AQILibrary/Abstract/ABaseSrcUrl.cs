using System;
using System.Collections.Generic;
using System.Text;
using AQI.Interface;
using Helper.Util.HTTP;

namespace AQI.Abstract
{
    /// <summary>
    /// 无参数基本的数据接口
    ///     抽象类
    /// </summary>
    public abstract class ABaseSrcUrl : ISrcUrl
    {

        #region 字段

        private IAqiWeb iaw;

        #endregion

        #region 属性

        public abstract string TAG { get; }
        public abstract string NAME { get; }
        public abstract string URL { get; }

        public bool USEPARAM
        {
            get
            {
                return false;
            }
        }
        public IAqiWeb IAW
        {
            get
            {
                return iaw;
            }
            set
            {
                iaw = value;
            }
        }
        public double UDI
        {
            get
            {
                switch (SUI)
                {
                    case AqiConstant.SourceUpdataInterval.DAY7:
                        return AqiConstant.DAY7;
                    case AqiConstant.SourceUpdataInterval.DAY:
                        return AqiConstant.DAY;
                    case AqiConstant.SourceUpdataInterval.HOUR12:
                        return AqiConstant.HOUR12;
                    case AqiConstant.SourceUpdataInterval.HOUR:
                        return AqiConstant.HOUR;
                    case AqiConstant.SourceUpdataInterval.MINUTE30:
                        return AqiConstant.MINUTE30;
                    case AqiConstant.SourceUpdataInterval.MINUTE:
                        return AqiConstant.MINUTE;
                    default:
                        return -1;
                }
            }
        }

        /// <summary>
        /// 常用更新间隔
        /// </summary>
        public abstract AQI.AqiConstant.SourceUpdataInterval SUI { get; }
        /// <summary>
        /// HTTP获取方式
        /// </summary>
        public abstract AQI.AqiConstant.HttpType HT { get; }

        #endregion

        #region 方法

        #region ISrcUrl接口

        /// <summary>
        /// 获取响应体
        ///     可以重写
        /// </summary>
        /// <returns></returns>
        public virtual byte[] getDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if (HT == AqiConstant.HttpType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(URL, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(URL);
            }

            return responsebody;
        }

        /// <summary>
        /// 获取内容
        ///     无效
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        public byte[] getDate(Dictionary<string, string> dictParam)
        {
            return null;
        }

        #endregion

        #endregion

    }
}
