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



##特殊说明

由于服务器启用了Cookie与DSId成对性验证，所以必须通过 _5 请求获取DSId与Cookie；
故所有接口都会使用 _5 获取Cookie和DSId；
获取的Cookie会设置到请求头；DSId会在AqiParam中添加一个DSId参数，并替换原有的DSId


###DSId替换方式
在字节数组基础上的，会在MakeRequestBody完毕后进行替换；
不管参数使用什么格式，都要在AqiParam中添加一个replaceDSId参数用于指定参数中的数据原有的DSId

