# 说明

数据方式: WCF

数据接口: http://61.133.239.78:82/ClientBin/Env-Publish-Province-RiaService-ProvincePublishDomainService.svc

> 由于接口单一，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                        | 解释                 | 数据类型 | 请求方式
| ----------------------------|:-------------------- |:--------:|:--------:|
| GetAQICityStations          | 站点列表             | XML(WCF) | GET
| GetAQIDataPublishLives      | 站点1小时溶度        | XML(WCF) | GET
| GetIAQIDataPublishLives     | 站点1小时AQI         | XML(WCF) | GET
| GetAQIDays                  | 站点24小时AQI等级    | XML(WCF) | GET
| GetCityAqiPublish           | 城市1小时AQI         | XML(WCF) | GET
| GetCityDayAqiPublish        | 城市24小时AQI        | XML(WCF) | GET
| GetAQITips                  | 等级提示             | XML(WCF) | GET
| GetSystemConfigs            | 系统设置             | XML(WCF) | GET


# 类比
其他WCF的站点

| 本站点                      | 其他站点                     | 比较      |
| --------------------------- | ---------------------------- |:---------:|
| GetAQICityStations          | GetAqiCityStation
| GetAQIDataPublishLives      | GetAQIDataByCityName
| GetIAQIDataPublishLives     | GetIaqiPublishEtyByCityName
| GetAQIDays                  | GetAQIDay
| GetCityAqiPublish           | GetCityAqiByCityName
| GetCityDayAqiPublish        | GetCityDayAqiByCityName
| GetAQITips                  | GetAQITips
| GetSystemConfigs            | GetSystemConfigs
