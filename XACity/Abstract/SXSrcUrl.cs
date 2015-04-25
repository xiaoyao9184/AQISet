using System;
using System.Collections.Generic;
using AQI.Abstract;
using SX.Abstract;

namespace SX.Abstract
{
    /// <summary>
    /// 陕西数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class SXSrcUrl : ABaseSrcUrl
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
