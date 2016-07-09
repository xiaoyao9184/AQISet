FORMAT: 1A
HOST: http://218.94.78.75:20001/




# 江苏省城市空气质量监测数据发布平台

文档日期 2016-07-08
系统地址 http://218.94.78.75:20001/jsair/。




# StationAQIDayNow [GET /JSAQPPSERVICES/REST/V100/STATION/{area}/AQI/DAYNOW{?token}]
江苏所有站点24小时AQI

+ Parameters

    + token (string, required) - Token
    + area: 32 (string, required) - 站点代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body

            加密的




# StationAQIDay [GET JSAQPPSERVICES/REST/V100/STATION/{area}/AQI/DAY/{time}{?token}]
江苏站点1小时AQI历史

+ Parameters

    + token (string, required) - Token
    + area: 32 (string, required) - 站点代码
    + time: 20150728090000 (number, required) - 时间(yyyyMMddhhmmss)

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            加密的




# StationNow [GET /JSAQPPSERVICES/REST/V100/STATION/{area}/{p}/NOW{?token}]
江苏所有站点1小时AQI&浓度

+ Parameters

    + token (string, required) - Token
    + area: 32 (string, required) - 站点代码
    + p (enum[string], required) - 污染物
      + Members
        + AQI
        + CO
        + NO2
        + CO31
        + CO38
        + PM10
        + PM25
        + SO2

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            加密的




# StationNow [GET /JSAQPPSERVICES/REST/V100/STATION/{pollutant}/{timestart}/{timeend}/{citycode}/{stationcode}/Histroy{?token}]
江苏所有站点1小时AQI&浓度

+ Parameters

    + token (string, required) - Token
    + area: 32 (string, required) - 站点代码
    + pollutant (enum[string], required) - 污染物
      + Members
        + AQI
        + CO
        + NO2
        + CO31
        + CO38
        + PM10
        + PM25
        + SO2
    + timestart:20150727090000 (number, required) - 开始时间(yyyyMMddhhmmss)
    + timeend:20150728090000 (number, required) - 结束时间(yyyyMMddhhmmss)
    + citycode:320700 (number, required) - 城市代码
    + stationcode:811 (number, required) - 站点代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            加密的
