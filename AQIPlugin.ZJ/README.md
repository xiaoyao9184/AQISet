#说明

请求数据为AMF方式
数据接口地址为http://218.108.43.220:8099/aqi/messagebroker/amf
由于接口单一，故按请求方法不同划分不同的虚拟接口


以下为接口列表
名称							解释				数据类型		请求方式
============================================================
getOneAndTwoLevelDivision		城市列表			JSON(AMF)			POST
getAreaUsedToDayReport			城市24小时列表		JSON(AMF)			POST
getAreaUsedToRealTime			城市1小时列表		JSON(AMF)			POST

getAreaDayReprotData			城市24小时AQI&浓度	JSON(AMF)			POST
getAreaRealTimeReportData		城市1小时AQI&浓度	JSON(AMF)			POST
								城市24小时历史AQI

getHourlyDataForAllSites		站点1小时AQI&浓度	JSON(AMF)			POST
								站点24小时历史AQI

_5								DSId请求			JSON(AMF)			POST




##待定
getAreaRealTimeReportData是3重复合接口
getHourlyDataForAllSites是2重复合接口




##特殊说明
由于服务器启用了Cookie与DSId成对性验证，所以必须通过 _5 请求获取DSId与Cookie；
故所有接口都继承自semcSrcUrl：
重写ICacheParam相关方法：会在LoadParams时会通过 _5 获取DSId加入参数，Cookie根据返回的Header是否有Set-Cookie判断，会加入参数Header；
重写IParseSrcUrlParam相关方法：用于自定义从 _5 的结果中提取DSId与Cookie；
重写IMakeParam相关方法：用于替换DSId


###DSId替换方式
在字节数组基础上的，会在MakeRequestBody完毕后进行替换；
不管参数使用什么格式，都要在AqiParam中添加一个replaceDSId参数用于指定参数中的数据原有的DSId


###stationCode、cityCode、pollutantCode替换方式
在字节数组基础上的，会在MakeRequestBody完毕后进行替换；
如果接口需要cityCode与stationCode参数，则需要在参数中添加一个replaceCityCode、replaceStationCode参数用于指定参数中的数据原有的数据
如果接口需要cityCode参数，则需要在参数中添加一个replaceCityCode参数用于指定参数中的数据原有的数据
如果接口需要pollutantCode参数，则需要在参数中添加一个pollutantCode参数用于指定参数中的数据原有的数据

