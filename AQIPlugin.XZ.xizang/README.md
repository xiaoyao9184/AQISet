#说明

请求数据大部分为GET方式
数据接口地址为http://111.11.241.103:9001/ashx/
由于接口单一，故按请求方法不同划分不同的虚拟接口


以下为接口列表
名称							解释				数据类型		请求方式
============================================================
CityShow				城市列表					JSON			GET
GetCityInfo				城市1小时AQI等级			JSON			GET
GetCityItemRTData		城市1小时AQI				JSON			POST(可用GET替换)
CitySinSite				城市24小时AQI历史			JSON			GET
SiteShow				城市站点列表(1小时AQI)		JSON			GET
GetCityRTData			城市站点1小时浓度			JSON			GET
GetItemRTData			站点1小时AQI				JSON			POST(可用GET替换)
SinSite					站点24小时AQI历史			JSON			GET

GetCityRTData_24		城市站点24小时浓度			JSON			GET


一些无用的数据
CitySinSite接口中的参数type为0时，将返回二级标准限值，无用
GetCityRTData接口中的参数type为1时，将返回24小时数据，频率不同，故增加GetCityRTData_24接口