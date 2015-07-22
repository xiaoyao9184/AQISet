using System;
using System.Collections.Generic;
using AQI.Abstract;
using AQI;

namespace GS.Abstract
{
    /// <summary>
    /// 甘肃数据接口
    ///     通用抽象类
    /// </summary>
    public abstract class GSSrcUrl_Param : AWcfSrcUrl
    {

        #region 属性

        /// <summary>
        /// 不使用参数
        /// </summary>
        public override bool UseParam
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 使用GET方式
        /// </summary>
        public override AQI.AqiConstant.HttpType HttpType
        {
            get
            {
                return AQI.AqiConstant.HttpType.GET;
            }
        }

        /// <summary>
        /// 无参数
        /// </summary>
        public override List<string> ParamName
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// 使用GET方式
        /// </summary>
        public override AQI.AqiConstant.ParamSendType ParamSendType
        {
            get
            {
                return AQI.AqiConstant.ParamSendType.GET;
            }
        }

        /// <summary>
        /// 仅提取WCF内容
        /// </summary>
        public override bool ExtractWCFContent
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 不单独操作WCF内容
        /// </summary>
        public override Helper.WCFbin.WCFMessageUtil.WCFContentFormat WCFContentFormat
        {
            get
            {
                return Helper.WCFbin.WCFMessageUtil.WCFContentFormat.NONE;
            }
        }

        #endregion

        #region 重写方法

        /// <summary>
        /// 不制作WCFMessage
        /// </summary>
        /// <param name="dictParam"></param>
        /// <returns></returns>
        public override string MakeWCFMsg(Dictionary<string, string> dictParam)
        {
            return null;
        }

        #endregion

    }
}
