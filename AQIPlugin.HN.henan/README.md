# 说明

数据方式: AMF

数据接口: http://222.143.24.250:100/airgis_dp/messagebroker/amf

> 由于接口单一，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                        |  解释                  | 数据类型 | 请求方式
| ----------------------------|:-----------------------|:--------:|:--------:|
| findMainCityAqiInfo         | 城市1小时AQI           | JSON(AMF)| POST
| findCityInfoDAByCityCode    | 城市24小时AQI          | JSON(AMF)| POST
| find10DaysDayAqiInfoByCode  | 城市10天历史AQI        | JSON(AMF)| POST
| 
| findAqiInfoByCityCode       | 城市站点1小时AQI       | JSON(AMF)| POST
| findNdInfoByCityCode        | 城市站点1小时浓度      | JSON(AMF)| POST
| 
| find12HourAqiInfoByCode     | 城市站点12小时历史AQI  | JSON(AMF)| POST
| find12HourNdInfoByCode      | 城市站点12小时历史浓度 | JSON(AMF)| POST
| find24HourAqiInfoByCode     | 城市站点24小时历史AQI  | JSON(AMF)| POST
| find24HourNdInfoByCode      | 城市站点24小时历史浓度 | JSON(AMF)| POST
| 
| getCityHourInfo             | 城市1小时浓度          | JSON(AMF)| POST
| _5                          | DSId请求               | JSON(AMF)| POST


# 无用接口
  + getCityHourInfo 接口目前不返回任何数据，故关闭


# 复合接口（逻辑添加）
  + find8InfoByCityCode 接口是复合消息，一次包含所有8个消息的接口；在MessageBin中可以找到被分解后的消息。


# 验证
由于服务器启用了 _Cookie_ 与 _DSId_ 成对性验证，
所以必须通过 `_5` 接口请求获取 _DSId_ 与 _Cookie_ 。

有接口都继承自 `henanSrcUrl`
 - 重写 **ICacheParam** 相关方法

			 会在 LoadParams 时会通过 `_5` 获取 _DSId_ 加入参数
			 ，_Cookie_ 根据返回的Header是否有Set-Cookie判断，会加入参数Header；

 - 重写 **IParseSrcUrlParam** 相关方法

       用于自定义从 `_5` 的结果中提取 _DSId_ 与 _Cookie_；

 - 重写 **IMakeParam** 相关方法

       用于替换DSId，替换stationCode、cityCode


# 参数替换
由于 AMF 的参数在 HTTP Body 里面，并且是二进制的，故使用参数替换。
会在 MakeRequestBody 完毕后进行替换。


> 不管二进制参数使用表现格式，都要在 AqiParam 中添加一个 _replaceDSId_ 参数用于指定二进制参数中的原始 _DSId_ 。

> 如果接口需要 _cityCode_ 、 _stationCode_ 参数，则需要在参数中添加一个 _replaceCityCode_、_replaceStationCode_ 参数用于指定二进制参数中的原始 _cityCode_ 、 _stationCode_ 、 _pollutantCode_。
