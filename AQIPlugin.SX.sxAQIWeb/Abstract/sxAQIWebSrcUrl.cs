using System;
using System.Collections.Generic;
using AQI.Abstract;

namespace sxAQIWeb.Abstract
{
    /// <summary>
    /// 陕西数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class sxAQIWebSrcUrl : ABaseSrcUrl
    {

        #region 属性

        /// <summary>
        /// 使用GET方式
        /// </summary>
        public override AQI.AqiConstant.HttpType HT
        {
            get
            {
                return AQI.AqiConstant.HttpType.GET;
            }
        }

        #endregion

    }
}
