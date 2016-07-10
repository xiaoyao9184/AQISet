FORMAT: 1A
HOST: http://61.166.240.109:6013/




# 云南省空气质量发布系统(试运行)

文档日期 2016-07-09
系统地址 http://61.166.240.109:6013/YNAS/index.jsp。


# citylist [GET /YNAS/data/citylist.json]
城市列表

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
            	"jsonObject" : {
            		"data" : [{
            					"area" : "全省",
            					"stat_name" : "全省"
            				}, {
            					"stat_code" : "530100",
            					"stat_name" : "昆明市",
            					"longitude" : "102.80",
            					"latitude" : "24.89",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530300",
            					"stat_name" : "曲靖市",
            					"longitude" : "103.79",
            					"latitude" : "25.51",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530400",
            					"stat_name" : "玉溪市",
            					"longitude" : "102.52",
            					"latitude" : "24.35",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530500",
            					"stat_name" : "保山市",
            					"longitude" : "99.17",
            					"latitude" : "25.12",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530600",
            					"stat_name" : "昭通市",
            					"longitude" : "103.72",
            					"latitude" : "27.33",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530700",
            					"stat_name" : "丽江市",
            					"longitude" : "100.23",
            					"latitude" : "26.88",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530800",
            					"stat_name" : "普洱市",
            					"longitude" : "100.97",
            					"latitude" : "22.85",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "530900",
            					"stat_name" : "临沧市",
            					"longitude" : "100.08",
            					"latitude" : "23.85",
            					"area" : "云南省"
            				},{
            					"stat_code" : "532900",
            					"stat_name" : "大理州",
            					"longitude" : "100.22",
            					"latitude" : "25.60",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "532600",
            					"stat_name" : "文山州",
            					"longitude" : "104.24",
            					"latitude" : "23.37",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "532500",
            					"stat_name" : "红河州",
            					"longitude" : "103.32",
            					"latitude" : "23.35",
            					"area" : "云南省"
            				},  {
            					"stat_code" : "532800",
            					"stat_name" : "西双版纳",
            					"longitude" : "100.8",
            					"latitude" : "22.02",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "532300",
            					"stat_name" : "楚雄州",
            					"longitude" : "101.55",
            					"latitude" : "25.03",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "533100",
            					"stat_name" : "德宏州",
            					"longitude" : "98.58",
            					"latitude" : "24.43",
            					"area" : "云南省"
            				},{
            					"stat_code" : "533300",
            					"stat_name" : "怒江州",
            					"longitude" : "98.85",
            					"latitude" : "25.85",
            					"area" : "云南省"
            				}, {
            					"stat_code" : "533400",
            					"stat_name" : "迪庆州",
            					"longitude" : "99.7",
            					"latitude" : "27.83",
            					"area" : "云南省"
            				}]
            	}
            }




# queryStationList [GET /YNAS/stationAction!queryStationList]
站点列表

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_code": "1001A",
                            "stat_name": "关上",
                            "longitude": "102.7430",
                            "latitude": "25.0124",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1002A",
                            "stat_name": "呈贡新区",
                            "longitude": "102.8210",
                            "latitude": "24.8885",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1003A",
                            "stat_name": "西山森林公园",
                            "longitude": "102.6250",
                            "latitude": "24.9624",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1004A",
                            "stat_name": "龙泉镇",
                            "longitude": "102.7280",
                            "latitude": "25.0836",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1005A",
                            "stat_name": "东风东路",
                            "longitude": "102.7220",
                            "latitude": "25.0405",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1006A",
                            "stat_name": "金鼎山",
                            "longitude": "102.6810",
                            "latitude": "25.0670",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1007A",
                            "stat_name": "碧鸡广场",
                            "longitude": "102.6380",
                            "latitude": "25.0359",
                            "area": "昆明市"
                        },
                        {
                            "stat_code": "1008A",
                            "stat_name": "环境监测站",
                            "longitude": "103.7897",
                            "latitude": "25.5035",
                            "area": "曲靖市"
                        },
                        {
                            "stat_code": "1009A",
                            "stat_name": "烟厂办公区",
                            "longitude": "103.8000",
                            "latitude": "25.5364",
                            "area": "曲靖市"
                        },
                        {
                            "stat_code": "1010A",
                            "stat_name": "东风水库",
                            "longitude": "102.5778",
                            "latitude": "24.3694",
                            "area": "玉溪市"
                        },
                        {
                            "stat_code": "1011A",
                            "stat_name": "市监测站",
                            "longitude": "102.5433",
                            "latitude": "24.3603",
                            "area": "玉溪市"
                        },
                        {
                            "stat_code": "1012A",
                            "stat_name": "大营街镇",
                            "longitude": "102.4964",
                            "latitude": "24.3411",
                            "area": "玉溪市"
                        },
                        {
                            "stat_code": "1014A",
                            "stat_name": "市环保局",
                            "longitude": "99.171",
                            "latitude": "25.133",
                            "area": "保山市"
                        },
                        {
                            "stat_code": "1013A",
                            "stat_name": "市环境监测站",
                            "longitude": "99.168",
                            "latitude": "25.108",
                            "area": "保山市"
                        },
                        {
                            "stat_code": "1017A",
                            "stat_name": "西南郊",
                            "longitude": "100.2143",
                            "latitude": "26.8576",
                            "area": "丽江市"
                        },
                        {
                            "stat_code": "1018A",
                            "stat_name": "丽江古城",
                            "longitude": "100.2497",
                            "latitude": "26.8802",
                            "area": "丽江市"
                        },
                        {
                            "stat_code": "1019A",
                            "stat_name": "市中心",
                            "longitude": "100.2203",
                            "latitude": "26.8906",
                            "area": "丽江市"
                        },
                        {
                            "stat_code": "1020A",
                            "stat_name": "市环保局",
                            "longitude": "100.9800",
                            "latitude": "22.7633",
                            "area": "普洱市"
                        },
                        {
                            "stat_code": "1021A",
                            "stat_name": "普洱第二中学",
                            "longitude": "100.9817",
                            "latitude": "22.8322",
                            "area": "普洱市"
                        },
                        {
                            "stat_code": "1022A",
                            "stat_name": "市环保局",
                            "longitude": "100.086",
                            "latitude": "23.882",
                            "area": "临沧市"
                        },
                        {
                            "stat_code": "1023A",
                            "stat_name": "市气象局",
                            "longitude": "100.078",
                            "latitude": "23.898",
                            "area": "临沧市"
                        },
                        {
                            "stat_code": "1015A",
                            "stat_name": "监测站",
                            "longitude": "103.705",
                            "latitude": "27.339",
                            "area": "昭通市"
                        },
                        {
                            "stat_code": "1016A",
                            "stat_name": "环保局",
                            "longitude": "103.722",
                            "latitude": "27.336",
                            "area": "昭通市"
                        },
                        {
                            "stat_code": "1038A",
                            "stat_name": "州环境监测站",
                            "longitude": "101.548",
                            "latitude": "25.044",
                            "area": "楚雄彝族自治州"
                        },
                        {
                            "stat_code": "1039A",
                            "stat_name": "市经济开发区",
                            "longitude": "101.538",
                            "latitude": "25.049",
                            "area": "楚雄彝族自治州"
                        },
                        {
                            "stat_code": "1024A",
                            "stat_name": "雨过铺",
                            "longitude": "103.311",
                            "latitude": "23.462",
                            "area": "红河哈尼族彝族自治州"
                        },
                        {
                            "stat_code": "1025A",
                            "stat_name": "污水处理厂",
                            "longitude": "103.377",
                            "latitude": "23.399",
                            "area": "红河哈尼族彝族自治州"
                        },
                        {
                            "stat_code": "1026A",
                            "stat_name": "监测站",
                            "longitude": "103.386125",
                            "latitude": "23.349991666666668",
                            "area": "红河哈尼族彝族自治州"
                        },
                        {
                            "stat_code": "1043A",
                            "stat_name": "州水务局",
                            "longitude": "104.253",
                            "latitude": "23.359",
                            "area": "文山壮族苗族自治州"
                        },
                        {
                            "stat_code": "1044A",
                            "stat_name": "市便民服务中心",
                            "longitude": "104.231",
                            "latitude": "23.389",
                            "area": "文山壮族苗族自治州"
                        },
                        {
                            "stat_code": "1045A",
                            "stat_name": "景洪市江南",
                            "longitude": "100.7939",
                            "latitude": "22.0019",
                            "area": "西双版纳傣族自治州"
                        },
                        {
                            "stat_code": "1046A",
                            "stat_name": "景洪市江北",
                            "longitude": "100.8017",
                            "latitude": "22.0225",
                            "area": "西双版纳傣族自治州"
                        },
                        {
                            "stat_code": "1049A",
                            "stat_name": "德宏州监测站",
                            "longitude": "98.584",
                            "latitude": "24.428",
                            "area": "德宏傣族景颇族自治州"
                        },
                        {
                            "stat_code": "1050A",
                            "stat_name": "芒市建设局",
                            "longitude": "98.578",
                            "latitude": "24.441",
                            "area": "德宏傣族景颇族自治州"
                        },
                        {
                            "stat_code": "1051A",
                            "stat_name": "州监测站",
                            "longitude": "98.8593",
                            "latitude": "25.8507",
                            "area": "怒江傈僳族自治州"
                        },
                        {
                            "stat_code": "1052A",
                            "stat_name": "泸水一中",
                            "longitude": "98.8611",
                            "latitude": "25.8133",
                            "area": "怒江傈僳族自治州"
                        },
                        {
                            "stat_code": "1054A",
                            "stat_name": "迪庆州站",
                            "longitude": "99.7056",
                            "latitude": "27.8317",
                            "area": "迪庆藏族自治州"
                        },
                        {
                            "stat_code": "1053A",
                            "stat_name": "古城",
                            "longitude": "99.7094",
                            "latitude": "27.8147",
                            "area": "迪庆藏族自治州"
                        },
                        {
                            "stat_code": "1047A",
                            "stat_name": "大理市环境监测站",
                            "longitude": "100.216",
                            "latitude": "25.581",
                            "area": "大理白族自治州"
                        },
                        {
                            "stat_code": "1048A",
                            "stat_name": "大理古城",
                            "longitude": "100.161",
                            "latitude": "25.699",
                            "area": "大理白族自治州"
                        }
                    ]
                }
            }




# queryCityNotice [GET /noticeInfoAction!queryCityNotice{?areaCode}]
城市通知

+ Parameters

    + areaCode (enum[string]) - 城市代码(不填即全部)
      + Members
        + 530100
        + 530300
        + 530400
        + 530500
        + 530600
        + 530700
        + 530800
        + 530900
        + 532900
        + 532500
        + 532600
        + 532800
        + 532300
        + 533100
        + 533300
        + 533400

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": {}
                }
            }





# dailyDataAction_queryLatestTime [GET /YNAS/dailyDataAction!queryLatestTime]
城市24小时AQI历史

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": "2016-07-08"
                }
            }




# dailyDataAction_queryCityAQIInfo [POST /YNAS/dailyDataAction!queryCityAQIInfo{?area}]
单个城市24小时AQI等级

+ Parameters

    + area (enum[string], required) - 城市代码
      + Members
        + 530100
        + 530300
        + 530400
        + 530500
        + 530600
        + 530700
        + 530800
        + 530900
        + 532900
        + 532600
        + 532500
        + 532800
        + 532300
        + 533100
        + 533300
        + 533400

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body




# dailyDataAction_queryDailyDataOfCitys [GET /YNAS/dailyDataAction!queryDailyDataOfCitys{?area}]
城市24小时AQI

+ Parameters

    + area: 530100,530300,530400,530500,530600,530700,530800,530900,532900,532500,532600,532800,532300,533100,533300,533400 (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_name": "昆明市",
                            "stat_code": "530100",
                            "longitude": "102.73",
                            "latitude": "25.04",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "33",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "曲靖市",
                            "stat_code": "530300",
                            "longitude": "103.79",
                            "latitude": "25.51",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "39",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "玉溪市",
                            "stat_code": "530400",
                            "longitude": "102.52",
                            "latitude": "24.35",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "33",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "保山市",
                            "stat_code": "530500",
                            "longitude": "99.17",
                            "latitude": "25.12",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "31",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "昭通市",
                            "stat_code": "530600",
                            "longitude": "103.72",
                            "latitude": "27.33",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "38",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "丽江市",
                            "stat_code": "530700",
                            "longitude": "100.23",
                            "latitude": "26.88",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "25",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "普洱市",
                            "stat_code": "530800",
                            "longitude": "101.03",
                            "latitude": "23.07",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "23",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "临沧市",
                            "stat_code": "530900",
                            "longitude": "100.08",
                            "latitude": "23.88",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "30",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "迪庆藏族自治州",
                            "stat_code": "533400",
                            "longitude": "99.7",
                            "latitude": "27.83",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "38",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "大理白族自治州",
                            "stat_code": "532900",
                            "longitude": "100.19",
                            "latitude": "25.69",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "20",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "楚雄彝族自治州",
                            "stat_code": "532300",
                            "longitude": "101.55",
                            "latitude": "25.03",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "21",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "红河哈尼族彝族自治州",
                            "stat_code": "532500",
                            "longitude": "102.42",
                            "latitude": "23.35",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "42",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "文山壮族苗族自治州",
                            "stat_code": "532600",
                            "longitude": "104.24",
                            "latitude": "23.37",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "35",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "西双版纳傣族自治州",
                            "stat_code": "532800",
                            "longitude": "100.8",
                            "latitude": "22.02",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "14",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "德宏傣族景颇族自治州",
                            "stat_code": "533100",
                            "longitude": "98.58",
                            "latitude": "24.43",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "30",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "怒江傈僳族自治州",
                            "stat_code": "533300",
                            "longitude": "98.85",
                            "latitude": "25.85",
                            "tv": "2016-07-08 00:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "23",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        }
                    ]
                }
            }




# dailyDataAction_queryAreaDailyData [GET /YNAS/dailyDataAction!queryAreaDailyData{?area}]
站点24小时AQI

+ Parameters

    + area (enum[string], required) - 城市代码
      + Members
        + 530100
        + 530300
        + 530400
        + 530500
        + 530600
        + 530700
        + 530800
        + 530900
        + 532900
        + 532600
        + 532500
        + 532800
        + 532300
        + 533100
        + 533300
        + 533400

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_code": "1001A",
                            "stat_name": "关上",
                            "longitude": "102.7430",
                            "latitude": "25.0124",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "37"
                        },
                        {
                            "stat_code": "1002A",
                            "stat_name": "呈贡新区",
                            "longitude": "102.8210",
                            "latitude": "24.8885",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "34"
                        },
                        {
                            "stat_code": "1003A",
                            "stat_name": "西山森林公园",
                            "longitude": "102.6250",
                            "latitude": "24.9624",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "24"
                        },
                        {
                            "stat_code": "1004A",
                            "stat_name": "龙泉镇",
                            "longitude": "102.7280",
                            "latitude": "25.0836",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "36"
                        },
                        {
                            "stat_code": "1005A",
                            "stat_name": "东风东路",
                            "longitude": "102.7220",
                            "latitude": "25.0405",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "41"
                        },
                        {
                            "stat_code": "1006A",
                            "stat_name": "金鼎山",
                            "longitude": "102.6810",
                            "latitude": "25.0670",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "31"
                        },
                        {
                            "stat_code": "1007A",
                            "stat_name": "碧鸡广场",
                            "longitude": "102.6380",
                            "latitude": "25.0359",
                            "area": "昆明市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "36"
                        },
                        {
                            "stat_code": "1008A",
                            "stat_name": "环境监测站",
                            "longitude": "103.7897",
                            "latitude": "25.5035",
                            "area": "曲靖市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "38"
                        },
                        {
                            "stat_code": "1009A",
                            "stat_name": "烟厂办公区",
                            "longitude": "103.8000",
                            "latitude": "25.5364",
                            "area": "曲靖市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "40"
                        },
                        {
                            "stat_code": "1010A",
                            "stat_name": "东风水库",
                            "longitude": "102.5778",
                            "latitude": "24.3694",
                            "area": "玉溪市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "35"
                        },
                        {
                            "stat_code": "1011A",
                            "stat_name": "市监测站",
                            "longitude": "102.5433",
                            "latitude": "24.3603",
                            "area": "玉溪市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "40"
                        },
                        {
                            "stat_code": "1012A",
                            "stat_name": "大营街镇",
                            "longitude": "102.4964",
                            "latitude": "24.3411",
                            "area": "玉溪市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "31"
                        },
                        {
                            "stat_code": "1014A",
                            "stat_name": "市环保局",
                            "longitude": "99.171",
                            "latitude": "25.133",
                            "area": "保山市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "27"
                        },
                        {
                            "stat_code": "1013A",
                            "stat_name": "市环境监测站",
                            "longitude": "99.168",
                            "latitude": "25.108",
                            "area": "保山市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "34"
                        },
                        {
                            "stat_code": "1017A",
                            "stat_name": "西南郊",
                            "longitude": "100.2143",
                            "latitude": "26.8576",
                            "area": "丽江市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "26"
                        },
                        {
                            "stat_code": "1018A",
                            "stat_name": "丽江古城",
                            "longitude": "100.2497",
                            "latitude": "26.8802",
                            "area": "丽江市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "24"
                        },
                        {
                            "stat_code": "1019A",
                            "stat_name": "市中心",
                            "longitude": "100.2203",
                            "latitude": "26.8906",
                            "area": "丽江市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "26"
                        },
                        {
                            "stat_code": "1020A",
                            "stat_name": "市环保局",
                            "longitude": "100.9800",
                            "latitude": "22.7633",
                            "area": "普洱市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "25"
                        },
                        {
                            "stat_code": "1021A",
                            "stat_name": "普洱第二中学",
                            "longitude": "100.9817",
                            "latitude": "22.8322",
                            "area": "普洱市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "22"
                        },
                        {
                            "stat_code": "1022A",
                            "stat_name": "市环保局",
                            "longitude": "100.086",
                            "latitude": "23.882",
                            "area": "临沧市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "39"
                        },
                        {
                            "stat_code": "1023A",
                            "stat_name": "市气象局",
                            "longitude": "100.078",
                            "latitude": "23.898",
                            "area": "临沧市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "25"
                        },
                        {
                            "stat_code": "1015A",
                            "stat_name": "监测站",
                            "longitude": "103.705",
                            "latitude": "27.339",
                            "area": "昭通市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "32"
                        },
                        {
                            "stat_code": "1016A",
                            "stat_name": "环保局",
                            "longitude": "103.722",
                            "latitude": "27.336",
                            "area": "昭通市",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "45"
                        },
                        {
                            "stat_code": "1038A",
                            "stat_name": "州环境监测站",
                            "longitude": "101.548",
                            "latitude": "25.044",
                            "area": "楚雄彝族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "21"
                        },
                        {
                            "stat_code": "1039A",
                            "stat_name": "市经济开发区",
                            "longitude": "101.538",
                            "latitude": "25.049",
                            "area": "楚雄彝族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "21"
                        },
                        {
                            "stat_code": "1024A",
                            "stat_name": "雨过铺",
                            "longitude": "103.311",
                            "latitude": "23.462",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "AQI": "52"
                        },
                        {
                            "stat_code": "1025A",
                            "stat_name": "污水处理厂",
                            "longitude": "103.377",
                            "latitude": "23.399",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "28"
                        },
                        {
                            "stat_code": "1026A",
                            "stat_name": "监测站",
                            "longitude": "103.386125",
                            "latitude": "23.349991666666668",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "50"
                        },
                        {
                            "stat_code": "1043A",
                            "stat_name": "州水务局",
                            "longitude": "104.253",
                            "latitude": "23.359",
                            "area": "文山壮族苗族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "35"
                        },
                        {
                            "stat_code": "1044A",
                            "stat_name": "市便民服务中心",
                            "longitude": "104.231",
                            "latitude": "23.389",
                            "area": "文山壮族苗族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "35"
                        },
                        {
                            "stat_code": "1045A",
                            "stat_name": "景洪市江南",
                            "longitude": "100.7939",
                            "latitude": "22.0019",
                            "area": "西双版纳傣族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "16"
                        },
                        {
                            "stat_code": "1046A",
                            "stat_name": "景洪市江北",
                            "longitude": "100.8017",
                            "latitude": "22.0225",
                            "area": "西双版纳傣族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "20"
                        },
                        {
                            "stat_code": "1049A",
                            "stat_name": "德宏州监测站",
                            "longitude": "98.584",
                            "latitude": "24.428",
                            "area": "德宏傣族景颇族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "30"
                        },
                        {
                            "stat_code": "1051A",
                            "stat_name": "州监测站",
                            "longitude": "98.8593",
                            "latitude": "25.8507",
                            "area": "怒江傈僳族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "30"
                        },
                        {
                            "stat_code": "1052A",
                            "stat_name": "泸水一中",
                            "longitude": "98.8611",
                            "latitude": "25.8133",
                            "area": "怒江傈僳族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "20"
                        },
                        {
                            "stat_code": "1054A",
                            "stat_name": "迪庆州站",
                            "longitude": "99.7056",
                            "latitude": "27.8317",
                            "area": "迪庆藏族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "20"
                        },
                        {
                            "stat_code": "1053A",
                            "stat_name": "古城",
                            "longitude": "99.7094",
                            "latitude": "27.8147",
                            "area": "迪庆藏族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "38"
                        },
                        {
                            "stat_code": "1047A",
                            "stat_name": "大理市环境监测站",
                            "longitude": "100.216",
                            "latitude": "25.581",
                            "area": "大理白族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "19"
                        },
                        {
                            "stat_code": "1048A",
                            "stat_name": "大理古城",
                            "longitude": "100.161",
                            "latitude": "25.699",
                            "area": "大理白族自治州",
                            "tv": "2016-07-08 00:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "20"
                        },
                        {
                            "stat_code": "1050A",
                            "stat_name": "芒市建设局",
                            "longitude": "98.578",
                            "latitude": "24.441",
                            "area": "德宏傣族景颇族自治州",
                            "tv": "-",
                            "kind": "-",
                            "fw": "-",
                            "AQI": "-"
                        }
                    ]
                }
            }




# dailyDataAction_queryAQIDetail [GET /YNAS/dailyDataAction!queryAQIDetail{?stat_code}]
单个站点24小时AQI等级

+ Parameters

    + stat_code (string, required) - 站点代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body




# dailyDataAction_queryStationDataList [GET /YNAS/dailyDataAction!queryStationDataList]
站点24小时AQI

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body



# realDataAction_queryLatestTime [GET /YNAS/realDataAction!queryLatestTime]
1小时数据时间

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": "2016-07-09 20:00:00"
                }
            }




# realDataAction_queryCityAQIInfo [POST /YNAS/realDataAction!queryCityAQIInfo{?area}]
单个城市1小时AQI等级

+ Parameters

    + area (enum[string], required) - 城市代码
      + Members
        + 530100
        + 530300
        + 530400
        + 530500
        + 530600
        + 530700
        + 530800
        + 530900
        + 532900
        + 532600
        + 532500
        + 532800
        + 532300
        + 533100
        + 533300
        + 533400

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body




# realDataAction_queryRealDataOfCitys [POST /YNAS/realDataAction!queryRealDataOfCitys{?area}]
城市1小时AQI

+ Parameters

    + area: 530100,530300,530400,530500,530600,530700,530800,530900,532900,532500,532600,532800,532300,533100,533300,533400 (string, required) - 城市代码

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_name": "昆明市",
                            "stat_code": "530100",
                            "longitude": "102.73",
                            "latitude": "25.04",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "36",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "曲靖市",
                            "stat_code": "530300",
                            "longitude": "103.79",
                            "latitude": "25.51",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "42",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "玉溪市",
                            "stat_code": "530400",
                            "longitude": "102.52",
                            "latitude": "24.35",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "26",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "保山市",
                            "stat_code": "530500",
                            "longitude": "99.17",
                            "latitude": "25.12",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "26",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "昭通市",
                            "stat_code": "530600",
                            "longitude": "103.72",
                            "latitude": "27.33",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "46",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "丽江市",
                            "stat_code": "530700",
                            "longitude": "100.23",
                            "latitude": "26.88",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "25",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "普洱市",
                            "stat_code": "530800",
                            "longitude": "101.03",
                            "latitude": "23.07",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "17",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "临沧市",
                            "stat_code": "530900",
                            "longitude": "100.08",
                            "latitude": "23.88",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "29",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "迪庆藏族自治州",
                            "stat_code": "533400",
                            "longitude": "99.7",
                            "latitude": "27.83",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "38",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "大理白族自治州",
                            "stat_code": "532900",
                            "longitude": "100.19",
                            "latitude": "25.69",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "21",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "楚雄彝族自治州",
                            "stat_code": "532300",
                            "longitude": "101.55",
                            "latitude": "25.03",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "22",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "红河哈尼族彝族自治州",
                            "stat_code": "532500",
                            "longitude": "102.42",
                            "latitude": "23.35",
                            "tv": "2016-07-09 19:00:00",
                            "level": "二级",
                            "kind": "良",
                            "fw": "PM10",
                            "AQI": "66",
                            "advice": "极少数异常敏感人群应减少户外活动。",
                            "warning": "空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响。"
                        },
                        {
                            "stat_name": "文山壮族苗族自治州",
                            "stat_code": "532600",
                            "longitude": "104.24",
                            "latitude": "23.37",
                            "tv": "2016-07-09 19:00:00",
                            "level": "二级",
                            "kind": "良",
                            "fw": "PM10",
                            "AQI": "58",
                            "advice": "极少数异常敏感人群应减少户外活动。",
                            "warning": "空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响。"
                        },
                        {
                            "stat_name": "西双版纳傣族自治州",
                            "stat_code": "532800",
                            "longitude": "100.8",
                            "latitude": "22.02",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "22",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "德宏傣族景颇族自治州",
                            "stat_code": "533100",
                            "longitude": "98.58",
                            "latitude": "24.43",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "22",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        },
                        {
                            "stat_name": "怒江傈僳族自治州",
                            "stat_code": "533300",
                            "longitude": "98.85",
                            "latitude": "25.85",
                            "tv": "2016-07-09 19:00:00",
                            "level": "一级",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "29",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        }
                    ]
                }
            }




# realDataAction_queryRealData [GET /YNAS/realDataAction!queryRealData{?fact_code,area}]
站点1小时AQI

+ Parameters

    + fact_code (enum[string], required) - 污染物
      + Members
        + AQI
        + SO2
        + NO2
        + O3
        + CO
        + PM25
        + PM10
    + area (enum[string]) - 城市代码（不填即全部）
      + Members
        + 530100
        + 530300
        + 530400
        + 530500
        + 530600
        + 530700
        + 530800
        + 530900
        + 532900
        + 532600
        + 532500
        + 532800
        + 532300
        + 533100
        + 533300
        + 533400

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_code": "1001A",
                            "stat_name": "关上",
                            "longitude": "102.7430",
                            "latitude": "25.0124",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "14"
                        },
                        {
                            "stat_code": "1002A",
                            "stat_name": "呈贡新区",
                            "longitude": "102.8210",
                            "latitude": "24.8885",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "8"
                        },
                        {
                            "stat_code": "1003A",
                            "stat_name": "西山森林公园",
                            "longitude": "102.6250",
                            "latitude": "24.9624",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "16"
                        },
                        {
                            "stat_code": "1004A",
                            "stat_name": "龙泉镇",
                            "longitude": "102.7280",
                            "latitude": "25.0836",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "10"
                        },
                        {
                            "stat_code": "1005A",
                            "stat_name": "东风东路",
                            "longitude": "102.7220",
                            "latitude": "25.0405",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "32"
                        },
                        {
                            "stat_code": "1006A",
                            "stat_name": "金鼎山",
                            "longitude": "102.6810",
                            "latitude": "25.0670",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "14"
                        },
                        {
                            "stat_code": "1007A",
                            "stat_name": "碧鸡广场",
                            "longitude": "102.6380",
                            "latitude": "25.0359",
                            "area": "昆明市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "13"
                        },
                        {
                            "stat_code": "1008A",
                            "stat_name": "环境监测站",
                            "longitude": "103.7897",
                            "latitude": "25.5035",
                            "area": "曲靖市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "SO2": "18"
                        },
                        {
                            "stat_code": "1009A",
                            "stat_name": "烟厂办公区",
                            "longitude": "103.8000",
                            "latitude": "25.5364",
                            "area": "曲靖市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "34"
                        },
                        {
                            "stat_code": "1010A",
                            "stat_name": "东风水库",
                            "longitude": "102.5778",
                            "latitude": "24.3694",
                            "area": "玉溪市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "15"
                        },
                        {
                            "stat_code": "1011A",
                            "stat_name": "市监测站",
                            "longitude": "102.5433",
                            "latitude": "24.3603",
                            "area": "玉溪市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "12"
                        },
                        {
                            "stat_code": "1012A",
                            "stat_name": "大营街镇",
                            "longitude": "102.4964",
                            "latitude": "24.3411",
                            "area": "玉溪市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "14"
                        },
                        {
                            "stat_code": "1014A",
                            "stat_name": "市环保局",
                            "longitude": "99.171",
                            "latitude": "25.133",
                            "area": "保山市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "4"
                        },
                        {
                            "stat_code": "1013A",
                            "stat_name": "市环境监测站",
                            "longitude": "99.168",
                            "latitude": "25.108",
                            "area": "保山市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "2"
                        },
                        {
                            "stat_code": "1017A",
                            "stat_name": "西南郊",
                            "longitude": "100.2143",
                            "latitude": "26.8576",
                            "area": "丽江市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "25"
                        },
                        {
                            "stat_code": "1018A",
                            "stat_name": "丽江古城",
                            "longitude": "100.2497",
                            "latitude": "26.8802",
                            "area": "丽江市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "8"
                        },
                        {
                            "stat_code": "1019A",
                            "stat_name": "市中心",
                            "longitude": "100.2203",
                            "latitude": "26.8906",
                            "area": "丽江市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "6"
                        },
                        {
                            "stat_code": "1020A",
                            "stat_name": "市环保局",
                            "longitude": "100.9800",
                            "latitude": "22.7633",
                            "area": "普洱市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "6"
                        },
                        {
                            "stat_code": "1021A",
                            "stat_name": "普洱第二中学",
                            "longitude": "100.9817",
                            "latitude": "22.8322",
                            "area": "普洱市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "3"
                        },
                        {
                            "stat_code": "1022A",
                            "stat_name": "市环保局",
                            "longitude": "100.086",
                            "latitude": "23.882",
                            "area": "临沧市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "5"
                        },
                        {
                            "stat_code": "1023A",
                            "stat_name": "市气象局",
                            "longitude": "100.078",
                            "latitude": "23.898",
                            "area": "临沧市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "2"
                        },
                        {
                            "stat_code": "1015A",
                            "stat_name": "监测站",
                            "longitude": "103.705",
                            "latitude": "27.339",
                            "area": "昭通市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "8"
                        },
                        {
                            "stat_code": "1016A",
                            "stat_name": "环保局",
                            "longitude": "103.722",
                            "latitude": "27.336",
                            "area": "昭通市",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "SO2": "20"
                        },
                        {
                            "stat_code": "1038A",
                            "stat_name": "州环境监测站",
                            "longitude": "101.548",
                            "latitude": "25.044",
                            "area": "楚雄彝族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "14"
                        },
                        {
                            "stat_code": "1039A",
                            "stat_name": "市经济开发区",
                            "longitude": "101.538",
                            "latitude": "25.049",
                            "area": "楚雄彝族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "18"
                        },
                        {
                            "stat_code": "1024A",
                            "stat_name": "雨过铺",
                            "longitude": "103.311",
                            "latitude": "23.462",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "SO2": "36"
                        },
                        {
                            "stat_code": "1025A",
                            "stat_name": "污水处理厂",
                            "longitude": "103.377",
                            "latitude": "23.399",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "13"
                        },
                        {
                            "stat_code": "1026A",
                            "stat_name": "监测站",
                            "longitude": "103.386125",
                            "latitude": "23.349991666666668",
                            "area": "红河哈尼族彝族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "SO2": "22"
                        },
                        {
                            "stat_code": "1043A",
                            "stat_name": "州水务局",
                            "longitude": "104.253",
                            "latitude": "23.359",
                            "area": "文山壮族苗族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "良",
                            "fw": "PM10",
                            "SO2": "15"
                        },
                        {
                            "stat_code": "1044A",
                            "stat_name": "市便民服务中心",
                            "longitude": "104.231",
                            "latitude": "23.389",
                            "area": "文山壮族苗族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "8"
                        },
                        {
                            "stat_code": "1045A",
                            "stat_name": "景洪市江南",
                            "longitude": "100.7939",
                            "latitude": "22.0019",
                            "area": "西双版纳傣族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "5"
                        },
                        {
                            "stat_code": "1049A",
                            "stat_name": "德宏州监测站",
                            "longitude": "98.584",
                            "latitude": "24.428",
                            "area": "德宏傣族景颇族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "13"
                        },
                        {
                            "stat_code": "1050A",
                            "stat_name": "芒市建设局",
                            "longitude": "98.578",
                            "latitude": "24.441",
                            "area": "德宏傣族景颇族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "3"
                        },
                        {
                            "stat_code": "1052A",
                            "stat_name": "泸水一中",
                            "longitude": "98.8611",
                            "latitude": "25.8133",
                            "area": "怒江傈僳族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "5"
                        },
                        {
                            "stat_code": "1054A",
                            "stat_name": "迪庆州站",
                            "longitude": "99.7056",
                            "latitude": "27.8317",
                            "area": "迪庆藏族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "3"
                        },
                        {
                            "stat_code": "1053A",
                            "stat_name": "古城",
                            "longitude": "99.7094",
                            "latitude": "27.8147",
                            "area": "迪庆藏族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "2"
                        },
                        {
                            "stat_code": "1047A",
                            "stat_name": "大理市环境监测站",
                            "longitude": "100.216",
                            "latitude": "25.581",
                            "area": "大理白族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "3"
                        },
                        {
                            "stat_code": "1048A",
                            "stat_name": "大理古城",
                            "longitude": "100.161",
                            "latitude": "25.699",
                            "area": "大理白族自治州",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "SO2": "4"
                        },
                        {
                            "stat_code": "1046A",
                            "stat_name": "景洪市江北",
                            "longitude": "100.8017",
                            "latitude": "22.0225",
                            "area": "西双版纳傣族自治州",
                            "tv": "-",
                            "kind": "-",
                            "fw": "-",
                            "SO2": "-"
                        },
                        {
                            "stat_code": "1051A",
                            "stat_name": "州监测站",
                            "longitude": "98.8593",
                            "latitude": "25.8507",
                            "area": "怒江傈僳族自治州",
                            "tv": "-",
                            "kind": "-",
                            "fw": "-",
                            "SO2": "-"
                        }
                    ]
                }
            }




# realDataAction_queryCTDetail [GET /YNAS/realDataAction!queryCTDetail{?fact_code,stat_code}]
站点1小时AQI

+ Request JSON格式

    + Parameters

        + fact_code (enum[string], required) - 污染物
          + Members
            + AQI
        + stat_code (string, required) - 站点代码

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "stat_code": "1001A",
                            "stat_name": "关上",
                            "tv": "2016-07-09 19:00:00.0",
                            "kind": "优",
                            "fw": "-",
                            "AQI": "39",
                            "advice": "各类人群可正常活动。",
                            "warning": "空气质量令人满意，基本无空气污染。"
                        }
                    ]
                }
            }


+ Request JSON格式

    + Parameters

        + fact_code (enum[string], required) - 污染物
          + Members
            + SO2
            + NO2
            + O3
            + CO
            + PM25
            + PM10
        + stat_code (string, required) - 站点代码

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "jsonObject": {
                    "data": [
                        {
                            "tv": "2016-07-08 22:00:00.0",
                            "CO": "0.541"
                        },
                        {
                            "tv": "2016-07-08 23:00:00.0",
                            "CO": "0.562"
                        },
                        {
                            "tv": "2016-07-09 00:00:00.0",
                            "CO": "0.506"
                        },
                        {
                            "tv": "2016-07-09 01:00:00.0",
                            "CO": "0.452"
                        },
                        {
                            "tv": "2016-07-09 02:00:00.0",
                            "CO": "0.339"
                        },
                        {
                            "tv": "2016-07-09 03:00:00.0",
                            "CO": "0.158"
                        },
                        {
                            "tv": "2016-07-09 04:00:00.0",
                            "CO": "0.322"
                        },
                        {
                            "tv": "2016-07-09 05:00:00.0",
                            "CO": "0.231"
                        },
                        {
                            "tv": "2016-07-09 06:00:00.0",
                            "CO": "0.292"
                        },
                        {
                            "tv": "2016-07-09 07:00:00.0",
                            "CO": "0.264"
                        },
                        {
                            "tv": "2016-07-09 08:00:00.0",
                            "CO": "0.351"
                        },
                        {
                            "tv": "2016-07-09 09:00:00.0",
                            "CO": "0.620"
                        },
                        {
                            "tv": "2016-07-09 10:00:00.0",
                            "CO": "0.377"
                        },
                        {
                            "tv": "2016-07-09 11:00:00.0",
                            "CO": "0.337"
                        },
                        {
                            "tv": "2016-07-09 12:00:00.0",
                            "CO": "0.330"
                        },
                        {
                            "tv": "2016-07-09 13:00:00.0",
                            "CO": "0.298"
                        },
                        {
                            "tv": "2016-07-09 14:00:00.0",
                            "CO": "0.244"
                        },
                        {
                            "tv": "2016-07-09 15:00:00.0",
                            "CO": "0.403"
                        },
                        {
                            "tv": "2016-07-09 16:00:00.0",
                            "CO": "0.428"
                        },
                        {
                            "tv": "2016-07-09 17:00:00.0",
                            "CO": "0.505"
                        },
                        {
                            "tv": "2016-07-09 18:00:00.0",
                            "CO": "0.510"
                        },
                        {
                            "tv": "2016-07-09 19:00:00.0",
                            "CO": "0.500"
                        },
                        {
                            "tv": "2016-07-09 20:00:00.0",
                            "CO": "0.345"
                        },
                        {
                            "tv": "2016-07-09 21:00:00.0",
                            "CO": "0.495"
                        }
                    ]
                }
            }
