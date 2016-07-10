FORMAT: 1A
HOST: http://111.11.241.103:9001/




# 西藏自治区环境空气质量实时发布系统

文档日期 2016-07-09
系统地址 http://111.11.241.103:9001/。


# CityShow [GET /ashx/CityShow.ashx]
城市列表

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            [
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54010000,
                    "CityName": "拉萨市",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 91.095654,
                    "Latitude": 29.651502,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 43
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54210000,
                    "CityName": "昌都市",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 97.186721,
                    "Latitude": 31.134267,
                    "MonitorTime": "2016-07-08T17:00:00",
                    "AQI": 33
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54220000,
                    "CityName": "山南地区",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 91.766703,
                    "Latitude": 29.241611,
                    "MonitorTime": "2016-07-09T17:00:00",
                    "AQI": 30
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54230000,
                    "CityName": "日喀则市",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 88.904943,
                    "Latitude": 29.253828,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 30
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54240000,
                    "CityName": "那曲地区",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 92.07362,
                    "Latitude": 31.488127,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 76
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54250000,
                    "CityName": "阿里地区",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 80.125761,
                    "Latitude": 32.503356,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 44
                },
                {
                    "RegionCode": 0,
                    "RegionName": "西藏自治区",
                    "CityCode": 54260000,
                    "CityName": "林芝市",
                    "SiteCode": 0,
                    "SiteName": null,
                    "Longitude": 94.376542,
                    "Latitude": 29.640374,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 20
                }
            ]




# GetCityInfo [GET /ashx/GetCityInfo.ashx{?cityId}]
城市1小时AQI等级

+ Parameters

    + cityId (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                'lasttime': '2016-07-0918: 00',
                'MainAQI': '50',
                'MainDj': '一级',
                'MainJb': '优',
                'MainPoll': '',
                'CityName': '拉萨市'
            }




# GetCityItemRTData [GET /ashx/GetCityItemRTData.ashx]
城市1小时AQI

+ Parameters

    + cityId (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                'status': 1,
                'data': [
                    {
                        "SiteName": null,
                        "MonTime": "2016年07月09日 18时",
                        "ItemId": "一级",
                        "ItemName": null,
                        "ItemValue": null,
                        "ItemIAQI": 50
                    }
                ]
            }




# CitySinSite [GET /ashx/CitySinSite.ashx]
城市24小时AQI历史

+ Parameters

    + type: 1 (string, required) - 类型（0为二级标准限值，1为24小时）
      + Members
        + 0
        + 1
    + itemId: 0 (string, required) - ?
    + cityId (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            [
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T18:00:00",
                    "DataValue": 59
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T19:00:00",
                    "DataValue": 58
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T20:00:00",
                    "DataValue": 56
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T21:00:00",
                    "DataValue": 54
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T22:00:00",
                    "DataValue": 62
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T23:00:00",
                    "DataValue": 63
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T00:00:00",
                    "DataValue": 57
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T01:00:00",
                    "DataValue": 61
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T02:00:00",
                    "DataValue": 79
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T03:00:00",
                    "DataValue": 51
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T04:00:00",
                    "DataValue": 23
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T05:00:00",
                    "DataValue": 22
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T06:00:00",
                    "DataValue": 22
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T07:00:00",
                    "DataValue": 21
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T08:00:00",
                    "DataValue": 20
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T09:00:00",
                    "DataValue": 32
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T10:00:00",
                    "DataValue": 47
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T11:00:00",
                    "DataValue": 55
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T12:00:00",
                    "DataValue": 52
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T13:00:00",
                    "DataValue": 55
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T14:00:00",
                    "DataValue": 49
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T15:00:00",
                    "DataValue": 51
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T16:00:00",
                    "DataValue": 52
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T17:00:00",
                    "DataValue": 51
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T18:00:00",
                    "DataValue": 50
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T18:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T19:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T20:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T21:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T22:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T23:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T00:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T01:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T02:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T03:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T04:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T05:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T06:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T07:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T08:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T09:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T10:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T11:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T12:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T13:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T14:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T15:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T16:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T17:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T18:00:00",
                    "DataValue": 100
                }
            ]




# SiteShow [GET /ashx/SiteShow.ashx]
城市站点列表(1小时AQI)

+ Parameters

    + cityId (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            [
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010001,
                    "SiteName": "区监测站",
                    "Longitude": 91.095654,
                    "Latitude": 29.651502,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 46
                },
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010002,
                    "SiteName": "区辐射站",
                    "Longitude": 90.991296,
                    "Latitude": 29.660442,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 95
                },
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010003,
                    "SiteName": "八廓街",
                    "Longitude": 91.139092,
                    "Latitude": 29.655359,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 56
                },
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010004,
                    "SiteName": "西藏大学",
                    "Longitude": 91.184979,
                    "Latitude": 29.657888,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 40
                },
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010005,
                    "SiteName": "市环保局",
                    "Longitude": 91.129976,
                    "Latitude": 29.677996,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 60
                },
                {
                    "RegionCode": 0,
                    "RegionName": "拉萨市",
                    "CityCode": 0,
                    "CityName": null,
                    "SiteCode": 54010006,
                    "SiteName": "拉萨火车站",
                    "Longitude": 91.091605,
                    "Latitude": 29.632372,
                    "MonitorTime": "2016-07-09T18:00:00",
                    "AQI": 44
                }
            ]



# GetCityRTData [GET /ashx/GetCityRTData.ashx]
城市站点1小时浓度

+ Parameters

    + type: 0 (enum[number], required) - 类型（0为1小时，1为24小时）
      + Members
        + 1
        + 0
    + cityId (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                'status': 1,
                'data': [
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "区监测站",
                        "SiteCode": 54010001,
                        "PM10": "11",
                        "PM2_5": "-",
                        "SO2": "5",
                        "NO2": "4",
                        "CO": "0.159",
                        "O3": "83"
                    },
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "区辐射站",
                        "SiteCode": 54010002,
                        "PM10": "94",
                        "PM2_5": "34",
                        "SO2": "9",
                        "NO2": "12",
                        "CO": "0.284",
                        "O3": "60"
                    },
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "八廓街",
                        "SiteCode": 54010003,
                        "PM10": "62",
                        "PM2_5": "17",
                        "SO2": "4",
                        "NO2": "6",
                        "CO": "0.256",
                        "O3": "102"
                    },
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "西藏大学",
                        "SiteCode": 54010004,
                        "PM10": "22",
                        "PM2_5": "13",
                        "SO2": "6",
                        "NO2": "4",
                        "CO": "0.230",
                        "O3": "92"
                    },
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "市环保局",
                        "SiteCode": 54010005,
                        "PM10": "69",
                        "PM2_5": "10",
                        "SO2": "6",
                        "NO2": "18",
                        "CO": "0.512",
                        "O3": "88"
                    },
                    {
                        "MonitorTime": "2016年07月09日 18时",
                        "SiteName": "拉萨火车站",
                        "SiteCode": 54010006,
                        "PM10": "38",
                        "PM2_5": "25",
                        "SO2": "13",
                        "NO2": "6",
                        "CO": "0.385",
                        "O3": "74"
                    }
                ]
            }




# GetItemRTData [GET /ashx/GetItemRTData.ashx]
站点1小时AQI

+ Parameters

    + itemId: 0 (string, required) - ??
    + siteId (string, required) - 站点代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                'status': 1,
                'data': [
                    {
                        "SiteName": "区监测站",
                        "MonTime": "2016年07月09日 18时",
                        "ItemId": "一级",
                        "ItemName": null,
                        "ItemValue": null,
                        "ItemIAQI": 26
                    }
                ]
            }




# SinSite [GET /ashx/SinSite.ashx]
站点24小时AQI历史

+ Parameters

    + type: 1 (string, required) - 类型
    + itemId: 0 (string, required) - ??
    + siteId (string, required) - 站点代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            [
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T18:00:00",
                    "DataValue": 26
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T17:00:00",
                    "DataValue": 34
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T16:00:00",
                    "DataValue": 35
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T15:00:00",
                    "DataValue": 31
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T14:00:00",
                    "DataValue": 32
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T13:00:00",
                    "DataValue": 29
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T12:00:00",
                    "DataValue": 24
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T11:00:00",
                    "DataValue": 21
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T10:00:00",
                    "DataValue": 19
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T09:00:00",
                    "DataValue": 18
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T08:00:00",
                    "DataValue": 19
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T07:00:00",
                    "DataValue": 20
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T06:00:00",
                    "DataValue": 20
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T05:00:00",
                    "DataValue": 23
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T04:00:00",
                    "DataValue": 24
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T03:00:00",
                    "DataValue": 19
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T02:00:00",
                    "DataValue": 15
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-09T01:00:00",
                    "DataValue": 18
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T23:00:00",
                    "DataValue": 20
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T22:00:00",
                    "DataValue": 17
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T21:00:00",
                    "DataValue": 21
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T20:00:00",
                    "DataValue": 22
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "0",
                    "ItemName": "AQI",
                    "MonitorTime": "2016-07-08T19:00:00",
                    "DataValue": 24
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T18:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T17:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T16:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T15:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T14:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T13:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T12:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T11:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T10:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T09:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T08:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T07:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T06:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T05:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T04:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T03:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T02:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-09T01:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T23:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T22:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T21:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T20:00:00",
                    "DataValue": 100
                },
                {
                    "SiteCode": 0,
                    "SiteName": null,
                    "ItemCode": "100",
                    "ItemName": "二级标准限值",
                    "MonitorTime": "2016-07-08T19:00:00",
                    "DataValue": 100
                }
            ]
