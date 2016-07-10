# 说明

数据方式: WebApi

数据接口: http://www.scnewair.cn:3389/

> 由于接口单一，故按请求方法不同划分不同的虚拟接口


# 接口列表

| 名称                         | 解释                          | 数据类型 | 请求方式
| ---------------------------- |:----------------------------- |:--------:|:--------:|
| getInfo                      | ??                            | JSON     | GET
| getState                     | ??                            | JSON     | GET
| getUpperLimit                | 城市列表                      | JSON     | GET
| getAllCityRealTimeAQIC       | 城市1小时AQI                  | JSON     | GET
| getAllCityDayAQIC            | 城市24小时AQI                 | JSON     | GET
| getAllCity24HRealTimeAQIC    | 城市24小时AQI历史             | JSON     | GET
|
| getUpperLimitByCityCode      | 城市信息                      | JSON     | GET
| getCityInfoC                 | 城市&城市站点24小时&1小时AQI  | JSON     | GET
| getAllStation24HRealTimeAQIC | 城市站点24小时AQI历史         | JSON     | GET
|
| getCityAuditResult           | 区域2天预报                   | JSON     | GET
| showAreaData                 | 城市预报                      | JSON     | GET


> 返回数据的时间戳为毫秒级Unix timestamp，需要去除后3位000后才可转为秒级Unix timestamp


# 无用的数据
http://www.scnewair.cn:3389/publish/toCity?type=0&cityCode=5134
并未返回任何数据
