FORMAT: 1A
HOST: http://www.scnewair.cn:3389/




# 四川省空气质量发布系统

文档日期 2016-07-09
系统地址 http://www.scnewair.cn:3389/。




# getInfo [GET /publish/getInfo]
？？

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body






# getState [GET /publish/getState]
？？

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            false




# getUpperLimit [GET /publish/getUpperLimit]
四川城市列表

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "result": true,
                "state": true,
                "data": [
                    {
                        "columns": {
                            "CITYCODE": 5101,
                            "CITYNAME": "成都市",
                            "CO": -99,
                            "ID": 1,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5103,
                            "CITYNAME": "自贡市",
                            "CO": -99,
                            "ID": 95,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5104,
                            "CITYNAME": "攀枝花市",
                            "CO": -99,
                            "ID": 96,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5105,
                            "CITYNAME": "泸州市",
                            "CO": 20,
                            "ID": 97,
                            "NO2": 100,
                            "O3": 500,
                            "PM10": 200,
                            "PM2_5": 200,
                            "SO2": 100
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5106,
                            "CITYNAME": "德阳市",
                            "CO": -99,
                            "ID": 98,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5107,
                            "CITYNAME": "绵阳市",
                            "CO": -99,
                            "ID": 99,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5113,
                            "CITYNAME": "南充市",
                            "CO": -99,
                            "ID": 100,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5115,
                            "CITYNAME": "宜宾市",
                            "CO": -99,
                            "ID": 101,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5110,
                            "CITYNAME": "内江市",
                            "CO": 10,
                            "ID": 111,
                            "NO2": 400,
                            "O3": 400,
                            "PM10": 500,
                            "PM2_5": 500,
                            "SO2": 400
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5114,
                            "CITYNAME": "眉山市",
                            "CO": 5,
                            "ID": 112,
                            "NO2": 150,
                            "O3": 300,
                            "PM10": 500,
                            "PM2_5": 350,
                            "SO2": 100
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5109,
                            "CITYNAME": "遂宁市",
                            "CO": 3,
                            "ID": 113,
                            "NO2": 100,
                            "O3": 250,
                            "PM10": 250,
                            "PM2_5": 200,
                            "SO2": 100
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5117,
                            "CITYNAME": "达州市",
                            "CO": -99,
                            "ID": 114,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5116,
                            "CITYNAME": "广安市",
                            "CO": -99,
                            "ID": 115,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5120,
                            "CITYNAME": "资阳市",
                            "CO": -99,
                            "ID": 116,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5111,
                            "CITYNAME": "乐山市",
                            "CO": -99,
                            "ID": 117,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5118,
                            "CITYNAME": "雅安市",
                            "CO": -99,
                            "ID": 118,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5133,
                            "CITYNAME": "康定市",
                            "CO": -99,
                            "ID": 119,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5108,
                            "CITYNAME": "广元市",
                            "CO": -99,
                            "ID": 120,
                            "NO2": 800,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5119,
                            "CITYNAME": "巴中市",
                            "CO": -99,
                            "ID": 121,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5132,
                            "CITYNAME": "马尔康市",
                            "CO": -99,
                            "ID": 122,
                            "NO2": -99,
                            "O3": -99,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 800
                        }
                    },
                    {
                        "columns": {
                            "CITYCODE": 5134,
                            "CITYNAME": "西昌市",
                            "CO": 10,
                            "ID": 123,
                            "NO2": 100,
                            "O3": 400,
                            "PM10": -99,
                            "PM2_5": -99,
                            "SO2": 400
                        }
                    }
                ]
            }




# getAllCityRealTimeAQIC [GET /publish/getAllCityRealTimeAQIC]
城市1小时AQI

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "data": [
                    {
                        "columns": {
                            "AQI": "41",
                            "CITYCODE": 5101,
                            "CITYNAME": "成都",
                            "CO": 1.1,
                            "CODE": "5101",
                            "CO_MARK": true,
                            "ICO": "11",
                            "INDEX_MARK": true,
                            "INO2": "23",
                            "IO3": "8",
                            "IPM10": "41",
                            "IPM2_5": "40",
                            "ISO2": "3",
                            "NO2": "46",
                            "NO2_MARK": true,
                            "O3": "24",
                            "O3_MARK": true,
                            "PM10": "41",
                            "PM10_MARK": true,
                            "PM2_5": "28",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "7",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "79",
                            "CITYCODE": 5103,
                            "CITYNAME": "自贡",
                            "CO": 0.7,
                            "CODE": "5103",
                            "CO_MARK": true,
                            "ICO": "7",
                            "INDEX_MARK": true,
                            "INO2": "13",
                            "IO3": "18",
                            "IPM10": "68",
                            "IPM2_5": "79",
                            "ISO2": "7",
                            "NO2": "26",
                            "NO2_MARK": true,
                            "O3": "57",
                            "O3_MARK": true,
                            "PM10": "86",
                            "PM10_MARK": true,
                            "PM2_5": "58",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "20",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "60",
                            "CITYCODE": 5104,
                            "CITYNAME": "攀枝花",
                            "CO": 1.4,
                            "CODE": "5104",
                            "CO_MARK": true,
                            "ICO": "15",
                            "INDEX_MARK": true,
                            "INO2": "13",
                            "IO3": "13",
                            "IPM10": "60",
                            "IPM2_5": "32",
                            "ISO2": "19",
                            "NO2": "26",
                            "NO2_MARK": true,
                            "O3": "41",
                            "O3_MARK": true,
                            "PM10": "69",
                            "PM10_MARK": true,
                            "PM2_5": "22",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "55",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "92",
                            "CITYCODE": 5105,
                            "CITYNAME": "泸州",
                            "CO": 0.6,
                            "CODE": "5105",
                            "CO_MARK": true,
                            "ICO": "7",
                            "INDEX_MARK": true,
                            "INO2": "14",
                            "IO3": "34",
                            "IPM10": "65",
                            "IPM2_5": "92",
                            "ISO2": "5",
                            "NO2": "27",
                            "NO2_MARK": true,
                            "O3": "106",
                            "O3_MARK": true,
                            "PM10": "80",
                            "PM10_MARK": true,
                            "PM2_5": "68",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "15",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "17",
                            "CITYCODE": 5106,
                            "CITYNAME": "德阳",
                            "CO": 1.3,
                            "CODE": "5106",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "9",
                            "IO3": "17",
                            "IPM10": "13",
                            "IPM2_5": "12",
                            "ISO2": "2",
                            "NO2": "17",
                            "NO2_MARK": true,
                            "O3": "52",
                            "O3_MARK": true,
                            "PM10": "13",
                            "PM10_MARK": true,
                            "PM2_5": "8",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "4",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "25",
                            "CITYCODE": 5107,
                            "CITYNAME": "绵阳",
                            "CO": 0.6,
                            "CODE": "5107",
                            "CO_MARK": true,
                            "ICO": "6",
                            "INDEX_MARK": true,
                            "INO2": "15",
                            "IO3": "11",
                            "IPM10": "25",
                            "IPM2_5": "18",
                            "ISO2": "3",
                            "NO2": "29",
                            "NO2_MARK": true,
                            "O3": "34",
                            "O3_MARK": true,
                            "PM10": "25",
                            "PM10_MARK": true,
                            "PM2_5": "12",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "7",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "30",
                            "CITYCODE": 5108,
                            "CITYNAME": "广元",
                            "CO": 0.6,
                            "CODE": "5108",
                            "CO_MARK": true,
                            "ICO": "6",
                            "INDEX_MARK": true,
                            "INO2": "17",
                            "IO3": "8",
                            "IPM10": "30",
                            "IPM2_5": "18",
                            "ISO2": "6",
                            "NO2": "34",
                            "NO2_MARK": true,
                            "O3": "24",
                            "O3_MARK": true,
                            "PM10": "30",
                            "PM10_MARK": true,
                            "PM2_5": "12",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "17",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "54",
                            "CITYCODE": 5109,
                            "CITYNAME": "遂宁",
                            "CO": 0.7,
                            "CODE": "5109",
                            "CO_MARK": true,
                            "ICO": "8",
                            "INDEX_MARK": true,
                            "INO2": "6",
                            "IO3": "39",
                            "IPM10": "54",
                            "IPM2_5": "49",
                            "ISO2": "5",
                            "NO2": "11",
                            "NO2_MARK": true,
                            "O3": "124",
                            "O3_MARK": true,
                            "PM10": "57",
                            "PM10_MARK": true,
                            "PM2_5": "34",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "13",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "56",
                            "CITYCODE": 5110,
                            "CITYNAME": "内江",
                            "CO": 0.5,
                            "CODE": "5110",
                            "CO_MARK": true,
                            "ICO": "5",
                            "INDEX_MARK": true,
                            "INO2": "15",
                            "IO3": "31",
                            "IPM10": "56",
                            "IPM2_5": "46",
                            "ISO2": "9",
                            "NO2": "30",
                            "NO2_MARK": true,
                            "O3": "98",
                            "O3_MARK": true,
                            "PM10": "62",
                            "PM10_MARK": true,
                            "PM2_5": "32",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "27",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "65",
                            "CITYCODE": 5111,
                            "CITYNAME": "乐山",
                            "CO": 1.2,
                            "CODE": "5111",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "21",
                            "IO3": "8",
                            "IPM10": "63",
                            "IPM2_5": "65",
                            "ISO2": "11",
                            "NO2": "42",
                            "NO2_MARK": true,
                            "O3": "23",
                            "O3_MARK": true,
                            "PM10": "75",
                            "PM10_MARK": true,
                            "PM2_5": "47",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "33",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "57",
                            "CITYCODE": 5113,
                            "CITYNAME": "南充",
                            "CO": 0.5,
                            "CODE": "5113",
                            "CO_MARK": true,
                            "ICO": "6",
                            "INDEX_MARK": true,
                            "INO2": "9",
                            "IO3": "32",
                            "IPM10": "57",
                            "IPM2_5": "52",
                            "ISO2": "5",
                            "NO2": "18",
                            "NO2_MARK": true,
                            "O3": "102",
                            "O3_MARK": true,
                            "PM10": "63",
                            "PM10_MARK": true,
                            "PM2_5": "36",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "15",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "97",
                            "CITYCODE": 5114,
                            "CITYNAME": "眉山",
                            "CO": 1.6,
                            "CODE": "5114",
                            "CO_MARK": true,
                            "ICO": "16",
                            "INDEX_MARK": true,
                            "INO2": "26",
                            "IO3": "3",
                            "IPM10": "83",
                            "IPM2_5": "97",
                            "ISO2": "2",
                            "NO2": "51",
                            "NO2_MARK": true,
                            "O3": "8",
                            "O3_MARK": true,
                            "PM10": "116",
                            "PM10_MARK": true,
                            "PM2_5": "72",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "4",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "102",
                            "CITYCODE": 5115,
                            "CITYNAME": "宜宾",
                            "CO": 0.9,
                            "CODE": "5115",
                            "CO_MARK": true,
                            "ICO": "10",
                            "INDEX_MARK": true,
                            "INO2": "12",
                            "IO3": "29",
                            "IPM10": "69",
                            "IPM2_5": "102",
                            "ISO2": "5",
                            "NO2": "23",
                            "NO2_MARK": true,
                            "O3": "90",
                            "O3_MARK": true,
                            "PM10": "88",
                            "PM10_MARK": true,
                            "PM2_5": "76",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "13",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "51",
                            "CITYCODE": 5116,
                            "CITYNAME": "广安",
                            "CO": 0.6,
                            "CODE": "5116",
                            "CO_MARK": true,
                            "ICO": "6",
                            "INDEX_MARK": true,
                            "INO2": "7",
                            "IO3": "30",
                            "IPM10": "51",
                            "IPM2_5": "28",
                            "ISO2": "4",
                            "NO2": "14",
                            "NO2_MARK": true,
                            "O3": "94",
                            "O3_MARK": true,
                            "PM10": "51",
                            "PM10_MARK": true,
                            "PM2_5": "19",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "10",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "46",
                            "CITYCODE": 5117,
                            "CITYNAME": "达州",
                            "CO": 0.4,
                            "CODE": "5117",
                            "CO_MARK": true,
                            "ICO": "5",
                            "INDEX_MARK": true,
                            "INO2": "8",
                            "IO3": "23",
                            "IPM10": "46",
                            "IPM2_5": "26",
                            "ISO2": "2",
                            "NO2": "16",
                            "NO2_MARK": true,
                            "O3": "71",
                            "O3_MARK": true,
                            "PM10": "46",
                            "PM10_MARK": true,
                            "PM2_5": "18",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "6",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "15",
                            "CITYCODE": 5118,
                            "CITYNAME": "雅安",
                            "CO": 0.6,
                            "CODE": "5118",
                            "CO_MARK": true,
                            "ICO": "7",
                            "INDEX_MARK": true,
                            "INO2": "7",
                            "IO3": "15",
                            "IPM10": "13",
                            "IPM2_5": "2",
                            "ISO2": "8",
                            "NO2": "13",
                            "NO2_MARK": true,
                            "O3": "47",
                            "O3_MARK": true,
                            "PM10": "13",
                            "PM10_MARK": true,
                            "PM2_5": "1",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "24",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "21",
                            "CITYCODE": 5119,
                            "CITYNAME": "巴中",
                            "CO": 0.6,
                            "CODE": "5119",
                            "CO_MARK": true,
                            "ICO": "7",
                            "INDEX_MARK": true,
                            "INO2": "10",
                            "IO3": "11",
                            "IPM10": "21",
                            "IPM2_5": "15",
                            "ISO2": "1",
                            "NO2": "20",
                            "NO2_MARK": true,
                            "O3": "34",
                            "O3_MARK": true,
                            "PM10": "21",
                            "PM10_MARK": true,
                            "PM2_5": "10",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "2",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "54",
                            "CITYCODE": 5120,
                            "CITYNAME": "资阳",
                            "CO": 0.4,
                            "CODE": "5120",
                            "CO_MARK": true,
                            "ICO": "5",
                            "INDEX_MARK": true,
                            "INO2": "6",
                            "IO3": "20",
                            "IPM10": "54",
                            "IPM2_5": "36",
                            "ISO2": "9",
                            "NO2": "11",
                            "NO2_MARK": true,
                            "O3": "62",
                            "O3_MARK": true,
                            "PM10": "58",
                            "PM10_MARK": true,
                            "PM2_5": "25",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "25",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "24",
                            "CITYCODE": 5132,
                            "CITYNAME": "马尔康",
                            "CO": 0.5,
                            "CODE": "5132",
                            "CO_MARK": true,
                            "ICO": "5",
                            "INDEX_MARK": true,
                            "INO2": "5",
                            "IO3": "5",
                            "IPM10": "24",
                            "IPM2_5": "15",
                            "ISO2": "2",
                            "NO2": "10",
                            "NO2_MARK": true,
                            "O3": "16",
                            "O3_MARK": true,
                            "PM10": "24",
                            "PM10_MARK": true,
                            "PM2_5": "10",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "6",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "51",
                            "CITYCODE": 5133,
                            "CITYNAME": "康定",
                            "CO": 0.9,
                            "CODE": "5133",
                            "CO_MARK": true,
                            "ICO": "9",
                            "INDEX_MARK": true,
                            "INO2": "11",
                            "IO3": "22",
                            "IPM10": "51",
                            "IPM2_5": "29",
                            "ISO2": "10",
                            "NO2": "22",
                            "NO2_MARK": true,
                            "O3": "70",
                            "O3_MARK": true,
                            "PM10": "51",
                            "PM10_MARK": true,
                            "PM2_5": "20",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "28",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "20",
                            "CITYCODE": 5134,
                            "CITYNAME": "西昌",
                            "CO": 1.1,
                            "CODE": "5134",
                            "CO_MARK": true,
                            "ICO": "12",
                            "INDEX_MARK": true,
                            "INO2": "7",
                            "IO3": "18",
                            "IPM10": "20",
                            "IPM2_5": "15",
                            "ISO2": "12",
                            "NO2": "13",
                            "NO2_MARK": true,
                            "O3": "56",
                            "O3_MARK": true,
                            "PM10": "20",
                            "PM10_MARK": true,
                            "PM2_5": "10",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "34",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1468033200000
                        }
                    }
                ],
                "timePoint": 1468033200000
            }



# getAllCityDayAQIC [GET /publish/getAllCityDayAQIC]
城市24小时AQI

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "data": [
                    {
                        "columns": {
                            "AQI": "56",
                            "CITYCODE": 5101,
                            "CITYNAME": "成都",
                            "CO": "0.926",
                            "CODE": "5101",
                            "CO_MARK": true,
                            "ICO": "24",
                            "INDEX_MARK": true,
                            "INO2": "43",
                            "IO3": "56",
                            "IPM10": "51",
                            "IPM2_5": "48",
                            "ISO2": "10",
                            "NO2": "34",
                            "NO2_MARK": true,
                            "O3": "107",
                            "O3_MARK": true,
                            "PM10": "52",
                            "PM10_MARK": true,
                            "PM2_5": "33",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧",
                            "SO2": "10",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "66",
                            "CITYCODE": 5103,
                            "CITYNAME": "自贡",
                            "CO": "0.779",
                            "CODE": "5103",
                            "CO_MARK": true,
                            "ICO": "19",
                            "INDEX_MARK": true,
                            "INO2": "33",
                            "IO3": "48",
                            "IPM10": "59",
                            "IPM2_5": "66",
                            "ISO2": "17",
                            "NO2": "26",
                            "NO2_MARK": true,
                            "O3": "95",
                            "O3_MARK": true,
                            "PM10": "68",
                            "PM10_MARK": true,
                            "PM2_5": "48",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "17",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "51",
                            "CITYCODE": 5104,
                            "CITYNAME": "攀枝花",
                            "CO": "1.819",
                            "CODE": "5104",
                            "CO_MARK": true,
                            "ICO": "45",
                            "INDEX_MARK": true,
                            "INO2": "44",
                            "IO3": "31",
                            "IPM10": "51",
                            "IPM2_5": "37",
                            "ISO2": "38",
                            "NO2": "35",
                            "NO2_MARK": true,
                            "O3": "62",
                            "O3_MARK": true,
                            "PM10": "52",
                            "PM10_MARK": true,
                            "PM2_5": "26",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)",
                            "SO2": "38",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "87",
                            "CITYCODE": 5105,
                            "CITYNAME": "泸州",
                            "CO": "0.519",
                            "CODE": "5105",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "31",
                            "IO3": "87",
                            "IPM10": "54",
                            "IPM2_5": "59",
                            "ISO2": "12",
                            "NO2": "25",
                            "NO2_MARK": true,
                            "O3": "144",
                            "O3_MARK": true,
                            "PM10": "57",
                            "PM10_MARK": true,
                            "PM2_5": "42",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧(O3)",
                            "SO2": "12",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "31",
                            "CITYCODE": 5106,
                            "CITYNAME": "德阳",
                            "CO": "1.195",
                            "CODE": "5106",
                            "CO_MARK": true,
                            "ICO": "30",
                            "INDEX_MARK": true,
                            "INO2": "19",
                            "IO3": "31",
                            "IPM10": "28",
                            "IPM2_5": "27",
                            "ISO2": "13",
                            "NO2": "15",
                            "NO2_MARK": true,
                            "O3": "61",
                            "O3_MARK": true,
                            "PM10": "28",
                            "PM10_MARK": true,
                            "PM2_5": "19",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "13",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "40",
                            "CITYCODE": 5107,
                            "CITYNAME": "绵阳",
                            "CO": "0.773",
                            "CODE": "5107",
                            "CO_MARK": true,
                            "ICO": "20",
                            "INDEX_MARK": true,
                            "INO2": "40",
                            "IO3": "26",
                            "IPM10": "34",
                            "IPM2_5": "29",
                            "ISO2": "9",
                            "NO2": "32",
                            "NO2_MARK": true,
                            "O3": "51",
                            "O3_MARK": true,
                            "PM10": "34",
                            "PM10_MARK": true,
                            "PM2_5": "20",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "9",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "45",
                            "CITYCODE": 5108,
                            "CITYNAME": "广元",
                            "CO": "0.595",
                            "CODE": "5108",
                            "CO_MARK": true,
                            "ICO": "15",
                            "INDEX_MARK": true,
                            "INO2": "45",
                            "IO3": "20",
                            "IPM10": "44",
                            "IPM2_5": "13",
                            "ISO2": "22",
                            "NO2": "36",
                            "NO2_MARK": true,
                            "O3": "39",
                            "O3_MARK": true,
                            "PM10": "44",
                            "PM10_MARK": true,
                            "PM2_5": "9",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "22",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "89",
                            "CITYCODE": 5109,
                            "CITYNAME": "遂宁",
                            "CO": "0.762",
                            "CODE": "5109",
                            "CO_MARK": true,
                            "ICO": "19",
                            "INDEX_MARK": true,
                            "INO2": "21",
                            "IO3": "89",
                            "IPM10": "39",
                            "IPM2_5": "31",
                            "ISO2": "14",
                            "NO2": "17",
                            "NO2_MARK": true,
                            "O3": "147",
                            "O3_MARK": true,
                            "PM10": "39",
                            "PM10_MARK": true,
                            "PM2_5": "22",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧(O3)",
                            "SO2": "14",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "97",
                            "CITYCODE": 5110,
                            "CITYNAME": "内江",
                            "CO": "0.517",
                            "CODE": "5110",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "28",
                            "IO3": "97",
                            "IPM10": "62",
                            "IPM2_5": "61",
                            "ISO2": "27",
                            "NO2": "22",
                            "NO2_MARK": true,
                            "O3": "156",
                            "O3_MARK": true,
                            "PM10": "74",
                            "PM10_MARK": true,
                            "PM2_5": "44",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧(O3)",
                            "SO2": "27",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "67",
                            "CITYCODE": 5111,
                            "CITYNAME": "乐山",
                            "CO": "0.880",
                            "CODE": "5111",
                            "CO_MARK": true,
                            "ICO": "22",
                            "INDEX_MARK": true,
                            "INO2": "32",
                            "IO3": "67",
                            "IPM10": "53",
                            "IPM2_5": "49",
                            "ISO2": "26",
                            "NO2": "25",
                            "NO2_MARK": true,
                            "O3": "120",
                            "O3_MARK": true,
                            "PM10": "55",
                            "PM10_MARK": true,
                            "PM2_5": "34",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧",
                            "SO2": "26",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "44",
                            "CITYCODE": 5113,
                            "CITYNAME": "南充",
                            "CO": "0.508",
                            "CODE": "5113",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "21",
                            "IO3": "43",
                            "IPM10": "44",
                            "IPM2_5": "40",
                            "ISO2": "11",
                            "NO2": "17",
                            "NO2_MARK": true,
                            "O3": "85",
                            "O3_MARK": true,
                            "PM10": "44",
                            "PM10_MARK": true,
                            "PM2_5": "28",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "11",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "87",
                            "CITYCODE": 5114,
                            "CITYNAME": "眉山",
                            "CO": "0.503",
                            "CODE": "5114",
                            "CO_MARK": true,
                            "ICO": "13",
                            "INDEX_MARK": true,
                            "INO2": "31",
                            "IO3": "87",
                            "IPM10": "66",
                            "IPM2_5": "84",
                            "ISO2": "4",
                            "NO2": "25",
                            "NO2_MARK": true,
                            "O3": "144",
                            "O3_MARK": true,
                            "PM10": "82",
                            "PM10_MARK": true,
                            "PM2_5": "62",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧(O3)",
                            "SO2": "4",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "67",
                            "CITYCODE": 5115,
                            "CITYNAME": "宜宾",
                            "CO": "0.853",
                            "CODE": "5115",
                            "CO_MARK": true,
                            "ICO": "22",
                            "INDEX_MARK": true,
                            "INO2": "30",
                            "IO3": "67",
                            "IPM10": "57",
                            "IPM2_5": "63",
                            "ISO2": "15",
                            "NO2": "24",
                            "NO2_MARK": true,
                            "O3": "120",
                            "O3_MARK": true,
                            "PM10": "64",
                            "PM10_MARK": true,
                            "PM2_5": "45",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "臭氧",
                            "SO2": "15",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "49",
                            "CITYCODE": 5116,
                            "CITYNAME": "广安",
                            "CO": "0.594",
                            "CODE": "5116",
                            "CO_MARK": true,
                            "ICO": "15",
                            "INDEX_MARK": true,
                            "INO2": "19",
                            "IO3": "49",
                            "IPM10": "40",
                            "IPM2_5": "26",
                            "ISO2": "12",
                            "NO2": "15",
                            "NO2_MARK": true,
                            "O3": "97",
                            "O3_MARK": true,
                            "PM10": "40",
                            "PM10_MARK": true,
                            "PM2_5": "18",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "12",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "44",
                            "CITYCODE": 5117,
                            "CITYNAME": "达州",
                            "CO": "0.555",
                            "CODE": "5117",
                            "CO_MARK": true,
                            "ICO": "14",
                            "INDEX_MARK": true,
                            "INO2": "41",
                            "IO3": "44",
                            "IPM10": "43",
                            "IPM2_5": "30",
                            "ISO2": "7",
                            "NO2": "33",
                            "NO2_MARK": true,
                            "O3": "87",
                            "O3_MARK": true,
                            "PM10": "43",
                            "PM10_MARK": true,
                            "PM2_5": "21",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "7",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "41",
                            "CITYCODE": 5118,
                            "CITYNAME": "雅安",
                            "CO": "0.585",
                            "CODE": "5118",
                            "CO_MARK": true,
                            "ICO": "15",
                            "INDEX_MARK": true,
                            "INO2": "23",
                            "IO3": "41",
                            "IPM10": "25",
                            "IPM2_5": "19",
                            "ISO2": "19",
                            "NO2": "18",
                            "NO2_MARK": true,
                            "O3": "81",
                            "O3_MARK": true,
                            "PM10": "25",
                            "PM10_MARK": true,
                            "PM2_5": "13",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "19",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "30",
                            "CITYCODE": 5119,
                            "CITYNAME": "巴中",
                            "CO": "0.670",
                            "CODE": "5119",
                            "CO_MARK": true,
                            "ICO": "17",
                            "INDEX_MARK": true,
                            "INO2": "30",
                            "IO3": "29",
                            "IPM10": "22",
                            "IPM2_5": "16",
                            "ISO2": "2",
                            "NO2": "24",
                            "NO2_MARK": true,
                            "O3": "57",
                            "O3_MARK": true,
                            "PM10": "22",
                            "PM10_MARK": true,
                            "PM2_5": "11",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "2",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "69",
                            "CITYCODE": 5120,
                            "CITYNAME": "资阳",
                            "CO": "0.660",
                            "CODE": "5120",
                            "CO_MARK": true,
                            "ICO": "17",
                            "INDEX_MARK": true,
                            "INO2": "20",
                            "IO3": "68",
                            "IPM10": "67",
                            "IPM2_5": "69",
                            "ISO2": "35",
                            "NO2": "16",
                            "NO2_MARK": true,
                            "O3": "122",
                            "O3_MARK": true,
                            "PM10": "84",
                            "PM10_MARK": true,
                            "PM2_5": "50",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)",
                            "SO2": "35",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "29",
                            "CITYCODE": 5132,
                            "CITYNAME": "马尔康",
                            "CO": "0.687",
                            "CODE": "5132",
                            "CO_MARK": true,
                            "ICO": "17",
                            "INDEX_MARK": true,
                            "INO2": "11",
                            "IO3": "22",
                            "IPM10": "29",
                            "IPM2_5": "23",
                            "ISO2": "7",
                            "NO2": "9",
                            "NO2_MARK": true,
                            "O3": "43",
                            "O3_MARK": true,
                            "PM10": "29",
                            "PM10_MARK": true,
                            "PM2_5": "16",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "7",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "35",
                            "CITYCODE": 5133,
                            "CITYNAME": "康定",
                            "CO": "0.714",
                            "CODE": "5133",
                            "CO_MARK": true,
                            "ICO": "18",
                            "INDEX_MARK": true,
                            "INO2": "24",
                            "IO3": "35",
                            "IPM10": "19",
                            "IPM2_5": "16",
                            "ISO2": "21",
                            "NO2": "19",
                            "NO2_MARK": true,
                            "O3": "69",
                            "O3_MARK": true,
                            "PM10": "19",
                            "PM10_MARK": true,
                            "PM2_5": "11",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "21",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    },
                    {
                        "columns": {
                            "AQI": "30",
                            "CITYCODE": 5134,
                            "CITYNAME": "西昌",
                            "CO": "1.126",
                            "CODE": "5134",
                            "CO_MARK": true,
                            "ICO": "28",
                            "INDEX_MARK": true,
                            "INO2": "21",
                            "IO3": "30",
                            "IPM10": "25",
                            "IPM2_5": "20",
                            "ISO2": "23",
                            "NO2": "17",
                            "NO2_MARK": true,
                            "O3": "59",
                            "O3_MARK": true,
                            "PM10": "25",
                            "PM10_MARK": true,
                            "PM2_5": "14",
                            "PM2_5_MARK": true,
                            "PRIMARYPOLLUTANT": "—",
                            "SO2": "23",
                            "SO2_MARK": true,
                            "STATE": 1,
                            "TIMEPOINT": 1467907200000
                        }
                    }
                ],
                "timePoint": 1467907200000
            }


# getAllCity24HRealTimeAQIC [GET /publish/getAllCity24HRealTimeAQIC]
城市24小时AQI历史

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body



# getUpperLimitByCityCode [GET /publish/getUpperLimitByCityCode]
城市信息

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body



# getCityInfoC [GET /publish/getCityInfoC]
城市&城市站点24小时&1小时AQI

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body


# getAllStation24HRealTimeAQIC [GET /publish/getAllStation24HRealTimeAQIC]
城市站点24小时AQI历史

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body



# showAreaData [GET /smartadmin/forecast/showAreaData]
区域2天预报

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "data": {
                    "TIMEPOINT": "1467907200000",
                    "FORECASTRESULT": "全省未来三天区域环境空气质量预报：\n07月09日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。\n07月10日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。\n07月11日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。"
                },
                "data2": {
                    "TIMEPOINT": "1467820800000",
                    "FORECASTRESULT": "全省未来三天区域环境空气质量预报：\n07月08日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。\n07月09日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。\n07月10日\n盆地大部城市为优或良；\n攀西地区和川西高原大部城市为优或良。\n全省首要污染物以O3为主。"
                }
            }



# getCityAuditResult [GET /smartadmin/forecast/getCityAuditResult{?timePoint}]
城市预报

+ Parameters

    + timePoint: 1467907200000 (string, required) - timePoint

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            {
                "result": true,
                "data": {
                    "timePoint": 1467907200000,
                    "forecast": {
                        "0": {
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)|臭氧|臭氧||",
                            "PM2_5": "45|48|56||",
                            "CITYNAME": "成都市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|良|良",
                            "AQI_REAL": "56|56|56|",
                            "PM2_5_DR": "34~57|37~61|45~69||",
                            "PM2_5_REAL": "33|33|33|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧8小时|臭氧8小时|臭氧8小时|",
                            "AQI": "48~78|53~83|62~92||",
                            "CITYCODE": 5101,
                            "CONTENT": ""
                        },
                        "1": {
                            "PRIMARYPOLLUTANT": "无|臭氧|臭氧||",
                            "PM2_5": "19|19|22||",
                            "CITYNAME": "德阳市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优|良|良",
                            "AQI_REAL": "31|31|31|",
                            "PM2_5_DR": "9~30|9~30|12~33||",
                            "PM2_5_REAL": "19|19|19|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "14~44|51~81|51~81||",
                            "CITYCODE": 5106,
                            "CONTENT": ""
                        },
                        "2": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "27|28|29||",
                            "CITYNAME": "绵阳市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "40|40|40|",
                            "PM2_5_DR": "17~38|18~39|19~41||",
                            "PM2_5_REAL": "20|20|20|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "35~65|43~73|45~75||",
                            "CITYCODE": 5107,
                            "CONTENT": ""
                        },
                        "3": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "26|26|29||",
                            "CITYNAME": "乐山市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "67|67|67|",
                            "PM2_5_DR": "16~37|16~37|19~41||",
                            "PM2_5_REAL": "34|34|34|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧8小时|臭氧8小时|臭氧8小时|",
                            "AQI": "35~65|35~65|45~75||",
                            "CITYCODE": 5111,
                            "CONTENT": ""
                        },
                        "4": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "43|43|34||",
                            "CITYNAME": "眉山市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "良|优或良|优或良",
                            "AQI_REAL": "87|87|87|",
                            "PM2_5_DR": "32~55|32~55|24~46||",
                            "PM2_5_REAL": "62|62|62|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧(O3)|臭氧(O3)|臭氧(O3)|",
                            "AQI": "60~90|47~77|35~65||",
                            "CITYCODE": 5114,
                            "CONTENT": ""
                        },
                        "5": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "15|19|14||",
                            "CITYNAME": "雅安市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "41|41|41|",
                            "PM2_5_DR": "5~26|9~30|4~25||",
                            "PM2_5_REAL": "13|13|13|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "35~65|37~67|35~65||",
                            "CITYCODE": 5118,
                            "CONTENT": ""
                        },
                        "6": {
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)|颗粒物(PM10)|臭氧||",
                            "PM2_5": "39|36|38||",
                            "CITYNAME": "资阳市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "69|69|69|",
                            "PM2_5_DR": "28~51|26~49|27~50||",
                            "PM2_5_REAL": "50|50|50|",
                            "PRIMARYPOLLUTANT_REAL": "细颗粒物(PM2.5)|细颗粒物(PM2.5)|细颗粒物(PM2.5)|",
                            "AQI": "48~78|40~70|50~80||",
                            "CITYCODE": 5120,
                            "CONTENT": ""
                        },
                        "7": {
                            "PRIMARYPOLLUTANT": "臭氧|细颗粒物(PM2.5)|细颗粒物(PM2.5)||",
                            "PM2_5": "45|40|42||",
                            "CITYNAME": "自贡市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "66|66|66|",
                            "PM2_5_DR": "34~57|29~53|31~54||",
                            "PM2_5_REAL": "48|48|48|",
                            "PRIMARYPOLLUTANT_REAL": "细颗粒物(PM2.5)|细颗粒物(PM2.5)|细颗粒物(PM2.5)|",
                            "AQI": "48~78|42~72|44~74||",
                            "CITYCODE": 5103,
                            "CONTENT": ""
                        },
                        "8": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "41|48|50||",
                            "CITYNAME": "泸州市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|良|良",
                            "AQI_REAL": "87|87|87|",
                            "PM2_5_DR": "30~53|37~61|38~62||",
                            "PM2_5_REAL": "42|42|42|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧(O3)|臭氧(O3)|臭氧(O3)|",
                            "AQI": "50~80|60~90|65~95||",
                            "CITYCODE": 5105,
                            "CONTENT": ""
                        },
                        "9": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "34|34|36||",
                            "CITYNAME": "内江市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "良|良|良",
                            "AQI_REAL": "97|97|97|",
                            "PM2_5_DR": "24~46|24~46|26~49||",
                            "PM2_5_REAL": "44|44|44|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧(O3)|臭氧(O3)|臭氧(O3)|",
                            "AQI": "65~95|60~90|70~100||",
                            "CITYCODE": 5110,
                            "CONTENT": ""
                        },
                        "10": {
                            "PRIMARYPOLLUTANT": "细颗粒物(PM2.5)|臭氧|臭氧||",
                            "PM2_5": "61|28|35||",
                            "CITYNAME": "宜宾市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "良|优或良|优或良",
                            "AQI_REAL": "67|67|67|",
                            "PM2_5_DR": "49~73|18~39|25~47||",
                            "PM2_5_REAL": "45|45|45|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧8小时|臭氧8小时|臭氧8小时|",
                            "AQI": "68~98|46~76|50~80||",
                            "CITYCODE": 5115,
                            "CONTENT": ""
                        },
                        "11": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "12|13|12||",
                            "CITYNAME": "广元市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "45|45|45|",
                            "PM2_5_DR": "2~23|3~24|2~23||",
                            "PM2_5_REAL": "9|9|9|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "38~68|45~75|50~80||",
                            "CITYCODE": 5108,
                            "CONTENT": ""
                        },
                        "12": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "26|24|24||",
                            "CITYNAME": "遂宁市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "良|良|良",
                            "AQI_REAL": "89|89|89|",
                            "PM2_5_DR": "16~37|14~35|14~35||",
                            "PM2_5_REAL": "22|22|22|",
                            "PRIMARYPOLLUTANT_REAL": "臭氧(O3)|臭氧(O3)|臭氧(O3)|",
                            "AQI": "60~90|63~93|67~97||",
                            "CITYCODE": 5109,
                            "CONTENT": ""
                        },
                        "13": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "34|35|40||",
                            "CITYNAME": "南充市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "44|44|44|",
                            "PM2_5_DR": "24~46|25~47|29~53||",
                            "PM2_5_REAL": "28|28|28|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "34~64|35~65|43~73||",
                            "CITYCODE": 5113,
                            "CONTENT": ""
                        },
                        "14": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "23|24|24||",
                            "CITYNAME": "广安市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "49|49|49|",
                            "PM2_5_DR": "13~34|14~35|14~35||",
                            "PM2_5_REAL": "18|18|18|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "50~80|45~75|35~65||",
                            "CITYCODE": 5116,
                            "CONTENT": ""
                        },
                        "15": {
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)|颗粒物(PM10)|颗粒物(PM10)||",
                            "PM2_5": "23|26|27||",
                            "CITYNAME": "达州市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "44|44|44|",
                            "PM2_5_DR": "13~34|16~37|17~38||",
                            "PM2_5_REAL": "21|21|21|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "34~64|39~69|41~71||",
                            "CITYCODE": 5117,
                            "CONTENT": ""
                        },
                        "16": {
                            "PRIMARYPOLLUTANT": "无|无|无||",
                            "PM2_5": "20|20|22||",
                            "CITYNAME": "巴中市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优|优|优",
                            "AQI_REAL": "30|30|30|",
                            "PM2_5_DR": "10~31|10~31|12~33||",
                            "PM2_5_REAL": "11|11|11|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "14~44|14~44|17~47||",
                            "CITYCODE": 5119,
                            "CONTENT": ""
                        },
                        "17": {
                            "PRIMARYPOLLUTANT": "颗粒物(PM10)|颗粒物(PM10)|颗粒物(PM10)||",
                            "PM2_5": "24|24|24||",
                            "CITYNAME": "攀枝花市",
                            "QUALITY_REAL": "良|良|良|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "51|51|51|",
                            "PM2_5_DR": "14~35|14~35|14~35||",
                            "PM2_5_REAL": "26|26|26|",
                            "PRIMARYPOLLUTANT_REAL": "颗粒物(PM10)|颗粒物(PM10)|颗粒物(PM10)|",
                            "AQI": "30~60|32~62|35~65||",
                            "CITYCODE": 5104,
                            "CONTENT": ""
                        },
                        "18": {
                            "PRIMARYPOLLUTANT": "臭氧|臭氧|臭氧||",
                            "PM2_5": "18|22|23||",
                            "CITYNAME": "西昌市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优或良|优或良|优或良",
                            "AQI_REAL": "30|30|30|",
                            "PM2_5_DR": "8~29|12~33|13~34||",
                            "PM2_5_REAL": "14|14|14|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "30~60|35~65|40~70||",
                            "CITYCODE": 5134,
                            "CONTENT": ""
                        },
                        "19": {
                            "PRIMARYPOLLUTANT": "无|无|臭氧||",
                            "PM2_5": "18|19|19||",
                            "CITYNAME": "马尔康市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优|优|优或良",
                            "AQI_REAL": "29|29|29|",
                            "PM2_5_DR": "8~29|9~30|9~30||",
                            "PM2_5_REAL": "16|16|16|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "20~50|20~50|25~55||",
                            "CITYCODE": 5132,
                            "CONTENT": ""
                        },
                        "20": {
                            "PRIMARYPOLLUTANT": "无|无|无||",
                            "PM2_5": "21|22|20||",
                            "CITYNAME": "康定市",
                            "QUALITY_REAL": "优|优|优|",
                            "QUALITY": "优|优|优",
                            "AQI_REAL": "35|35|35|",
                            "PM2_5_DR": "11~32|12~33|10~31||",
                            "PM2_5_REAL": "11|11|11|",
                            "PRIMARYPOLLUTANT_REAL": "—|—|—|",
                            "AQI": "21~45|22~47|20~44||",
                            "CITYCODE": 5133,
                            "CONTENT": ""
                        }
                    }
                }
            }
