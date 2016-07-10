# 说明

数据方式: WebApi

数据接口: http://58.56.98.78:8801/AirDeploy.web/Ajax/AirQuality/AirQuality.ashx
图片接口: http://60.208.91.115:6600/Images

> 按请求方式方法不同划分不同的逻辑接口


# 接口列表

| 名称                    | 解释                   | 数据类型 | 请求方式
| ----------------------- |:---------------------- |:--------:|:--------:|
| GetOther                | 其他未知数据           | 未知     | GET
| GetCityList             | 城市列表               | XML(HTML)| GET
| GetCityAQI              | 城市AQI列表            | JSON     | POST
| GetCityAvg              | 城市浓度               | JSON     | GET
| GetStationList          | 站点列表               | XML(HTML)| POST
| GetStationMarkOnMap     | 站点位置列表           | JSON     | GET
| GetQualityItemsValues   | 站点AQI与浓度          | JSON     | POST
| GetNjdValue             | 站点能见度             | JSON     | POST
| GetVisilbeRank          | 城市能见度排行         | XML(HTML)| POST
|
| Images                  | 站点能见度照片         | JPG      | GET


> 通过列表来看，请求方式很混乱，没有任何规律。（不排除请求方式互通使用的可能，未测试）


# 流程

 + 主页
    1. GetCityList
    2. GetStationList（GetAllSubStation）
    3. GetCityAQI
    4. GetOther
    5. GetStationMarkOnMap


 + 选中城市
    1. GetCityAvg
    2. GetStationList（GetStationByStrCode）
    3. HTML页面（http://58.56.98.78:8801/AirDeploy.web/AirQuality/CityHourAvg.aspx）
    4. GetCityAvg


 + 选中站点
    1. HTM页面（http://58.56.98.78:8801/AirDeploy.web/AirQuality/InfoWindow.aspx）
    2. GetQualityItemsValues
