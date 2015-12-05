#说明

请求数据为WCF方式
数据接口地址为http://222.247.51.155:8025/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc
由于接口单一，故按请求方法不同划分不同的虚拟接口


以下为接口列表
名称							解释				数据类型		请求方式
============================================================
GetAqiCity						城市列表			XML(WCF)			GET
GetAqiCityStation				城市站点列表		XML(WCF)			GET
GetAQIDataByCityName			城市站点1小时浓度	XML(WCF)			GET
GetIaqiPublishEtyByCityName		城市站点1小时AQI	XML(WCF)			GET
GetAQIDay						城市站点24小时AQI	XML(WCF)			GET
GetCityAqiByCityName			城市1小时AQI		XML(WCF)			GET
GetCityDayAqiByCityName			城市24小时AQI		XML(WCF)			GET
GetAqiHistoryByCondition		站点24小时历史浓度	XML(WCF)			GET
GetIaqiHistoryByCondition		站点24小时历史AQI	XML(WCF)			GET
GetAQITips						等级提示			XML(WCF)			GET
GetSystemConfigs				系统设置			XML(WCF)			GET
GetServerTime					系统时间			XML(WCF)			POST




由于与站点相关的数据参数太多，故增加自动化接口自动获取站点参数

名称									解释
============================================================
GetAqiHistoryByCondition_Auto			参数从GetAqiCityStation接口获得
GetIaqiHistoryByCondition_Auto			参数从GetAqiCityStation接口获得
