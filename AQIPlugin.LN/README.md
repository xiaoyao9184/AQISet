#说明

请求数据WebApi方式，WebService方式
数据接口地址为
WebApi：http://211.137.19.74:8089/Ajax/
WebApi：http://211.137.19.74:8089/Home/
WebService：http://211.137.19.74:8089/AirQualityService.asmx
由于WebApi接口即可获取所有信息，故不使用WebService，按照请求方法不同划分不同的虚拟接口


以下为接口列表
名称							解释					数据类型		请求方式
============================================================
GetCityDetailList					城市1小时AQI&浓度			JSON			GET
GetCityDetailByCityName				城市1小时AQI&浓度			JSON			GET
GetStationDetailList				城市站点1小时AQI&浓度		JSON			GET
GetStationDailyDataListByCityName	城市站点24小时AQI&浓度		JSON			GET
GetCityPollutant					城市24小时历史AQI&浓度		JSON			GET
GetAQI								站点24小时历史AQI			JSON			GET
GetPM25								站点24小时历史浓度PM25		JSON			GET
GetPM10								站点24小时历史浓度PM10		JSON			GET
GetSO2								站点24小时历史浓度SO2		JSON			GET
GetNO2								站点24小时历史浓度NO2		JSON			GET
GetCO								站点24小时历史浓度CO		JSON			GET
GetO3								站点24小时历史浓度O3		JSON			GET
GetO38								站点24小时历史浓度O38		JSON			GET