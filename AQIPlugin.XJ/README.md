# 说明

数据方式: WCF

数据接口: http://124.88.62.18:82/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc

> 由于接口单一，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                        | 解释                 | 数据类型 | 请求方式
| ----------------------------|:-------------------- |:--------:|:--------:|
| GetAqiCity                  | 城市列表             | XML(WCF) | GET
| GetAqiCityStation           | 城市站点列表         | XML(WCF) | GET
| GetAQIDataByCityName        | 城市站点1小时浓度    | XML(WCF) | GET
| GetIaqiPublishEtyByCityName | 城市站点1小时AQI     | XML(WCF) | GET
| GetAQIDay                   | 城市站点24小时AQI    | XML(WCF) | GET
| GetCityAqiByCityName        | 城市1小时AQI         | XML(WCF) | GET
| GetCityDayAqiByCityName     | 城市24小时AQI        | XML(WCF) | GET
| GetAqiHistoryByCondition    | 站点24小时历史浓度   | XML(WCF) | GET
| GetIaqiHistoryByCondition   | 站点24小时历史AQI    | XML(WCF) | GET
| GetAQITips                  | 等级提示             | XML(WCF) | GET
| GetSystemConfigs            | 系统设置             | XML(WCF) | GET
| GetServerTime               | 系统时间             | XML(WCF) | POST


# 自动化接口（逻辑增加）

  + GetAqiHistoryByCondition_Auto 参数从GetAqiCityStation接口获得
  + GetIaqiHistoryByCondition_Auto 参数从GetAqiCityStation接口获得

