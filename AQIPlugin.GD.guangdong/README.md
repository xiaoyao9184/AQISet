# 说明

数据方式: WCF

数据接口: http://113.108.142.147:20011/GDPublishWCF/EnvGDService.svc

> 由于接口单一，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                        | 解释                 | 数据类型 | 请求方式
| ----------------------------|:-------------------- |:--------:|:--------:|
| GetAllAQILayerURL           | 1小时AQI分布图       | XML(WCF) | POST
| GetAllAQIPublish            | 所有站点1小时AQI     | XML(WCF) | POST
| GetAllStationInfo           | 所有站点信息         | XML(WCF) | POST
| GetCityStationContained     | 城市站点列表         | XML(WCF) | POST
