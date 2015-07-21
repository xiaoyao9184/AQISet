#说明

请求数据分为2种，HTTP GET方式、POST方式
数据接口地址为http://58.56.98.78:8801/AirDeploy.web/Ajax/AirQuality/AirQuality.ashx
由于接口单一，故按请求方式不同划分不同的虚拟接口


一下为接口列表
名称					解释				数据类型		请求方式
============================================================
GetOther				其他未知数据		未知			GET
GetCityList				城市列表			XML(HTML)		GET
GetCityAQI				城市AQI列表			JSON			POST
GetCityAvg				城市浓度			JSON			GET
GetStationList			站点列表			XML(HTML)		POST
GetStationMarkOnMap		站点位置列表		JSON			GET
GetQualityItemsValues	站点AQI与浓度		JSON			POST
GetNjdValue				站点能见度			JSON			POST
GetVisilbeRank			城市能见度排行		XML(HTML)		POST
Images					站点能见度照片		JPG				GET


通过列表来看，请求方式很混乱，没有任何规律。（不排除请求方式互通使用的可能，未测试）


流程

1、主页
GetCityList
GetStationList（GetAllSubStation）
GetCityAQI
GetOther
GetStationMarkOnMap


2、选中城市
GetCityAvg
GetStationList（GetStationByStrCode）
HTML页面（http://58.56.98.78:8801/AirDeploy.web/AirQuality/CityHourAvg.aspx）
GetCityAvg


3、选中站点
HTM页面（http://58.56.98.78:8801/AirDeploy.web/AirQuality/InfoWindow.aspx）
GetQualityItemsValues