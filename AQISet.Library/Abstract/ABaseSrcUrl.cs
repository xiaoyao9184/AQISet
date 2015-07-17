using System;
using System.Collections.Generic;
using System.Text;
using Helper.Util.HTTP;
using AQI.Interface;

namespace AQI.Abstract
{
    /// <summary>
    /// 无参数基本的数据接口
    ///     抽象类
    /// </summary>
    public abstract class ABaseSrcUrl : ISrcUrl
    {

        #region 字段

        /// <summary>
        /// IAqiWeb接口
        ///     ISrcUrl
        /// </summary>
        protected IAqiWeb iaw;

        #endregion

        #region 属性

        public abstract string Tag { get; }
        public abstract string Name { get; }
        public abstract string Url { get; }
        /// <summary>
        /// 是否使用参数
        ///     实现ISrcUrl
        /// </summary>
        public virtual bool UseParam
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// IAqiWeb接口
        ///     实现ISrcUrl
        /// </summary>
        public virtual IAqiWeb IAW
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
        /// <summary>
        /// 更新间隔
        ///     实现ISrcUrl
        /// </summary>
        public virtual double UDI
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
        ///     扩展ISrcUrl
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
        public virtual byte[] GetDate()
        {
            //得到responsebody
            byte[] responsebody = null;
            if (HT == AqiConstant.HttpType.POST)
            {
                responsebody = HttpUtilV2.doPostRequest(Url, null);
            }
            else
            {
                responsebody = HttpUtilV2.doGetRequest(Url);
            }

            return responsebody;
        }

        #endregion

        #endregion

    }
}
