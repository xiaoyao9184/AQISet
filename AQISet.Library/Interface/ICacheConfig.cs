using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AQI.Interface
{
    /// <summary>
    /// 缓存配置 接口
    ///     扩展IAqiWeb
    ///     需要保证线程安全
    /// </summary>
    public interface ICacheConfig
    {
        /// <summary>
        /// 配置缓存
        /// </summary>
        List<AQI.AqiConfig> ConfigCache { get; }
        /// <summary>
        /// JSON配置文件路径
        /// </summary>
        /// <returns></returns>
        string GetJsonFile();
        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns>true过期；false未过期</returns>
        bool IsConfigsExpired();
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns>是否成功</returns>
        bool LoadConfigs();
        /// <summary>
        /// 是否开启
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true开启；false关闭</returns>
        bool IsSrcUrlEnabled(string name);
    }
}
