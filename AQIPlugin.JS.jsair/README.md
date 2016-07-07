#说明

请求数据GET方式
数据接口地址为http://218.94.78.75:20001/jsair/
由于接口单一，故按请求方法不同划分不同的虚拟接口



以下为接口列表
名称					解释				数据类型		请求方式
============================================================
StationAQIDayNow		24小时AQI			JSON			GET
StationAQINow			1小时AQI			JSON			GET
StationCONow			1小时CO				JSON			GET
StationNO2Now			1小时NO2			JSON			GET
StationO31Now			1小时O3				JSON			GET
StationO38Now			8小时O3				JSON			GET
StationPM10Now			1小时PM10			JSON			GET
StationPM25Now			1小时PM25			JSON			GET
StationSO2Now			1小时SO2			JSON			GET

StationAQIDay			未知				JSON			GET
LSZDSB					污染物历史			JSON			GET




由于 LSZDSB 接口可以按照时间查询历史数据；
故增加自动化接口，更新间隔变为24小时，参数从JSON和StationAQIDayNow获取（时间范围为当前小时向前推24小时，6个污染物从JSON获取，城市、站点代码从StationAQIDayNow获取）

名称						解释
============================================================
LSZDSB_Auto					
