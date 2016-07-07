FORMAT: 1A
HOST: http://211.137.19.74:8089/




# 辽宁省空气质量实时发布系统(beta)

文档日期 2016-07-06
系统地址 http://211.137.19.74:8089/。




# GetCityDetailList [GET /Ajax/GetCityDetailList]
城市1小时AQI&浓度

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Body
            [
              {
                "IsUse":true,
                "AQIColor":"#00E400",
                "AQIDescription":"空气质量令人满意，基本无污染。",
                "PrimaryPollutantInfoList":null,
                "Id":0,
                "CityName":"沈阳",
                "TimePoint":"\/Date(1467806400000)\/",
                "AQI":48,
                "PM25":24,
                "PM10":48,
                "SO2":6,
                "NO2":22,
                "CO":0.6,
                "O3":122,
                "O38":147,
                "PrimaryPollutantName":"-",
                "Value":48,
                "PM2524":29,
                "PM1024":58,
                "Level":"一级",
                "Status":"优",
                "IAQI_PM2524":35,
                "IAQI_PM1024":48,
                "IAQI_SO2":2,
                "IAQI_NO2":11,
                "IAQI_CO":6,
                "IAQI_O3":39,
                "IAQI_O38":90,
                "SO2_24":0,
                "NO2_24":0,
                "CO_24":0,
                "O3_24":0,
                "O38_24":0
              }
            ]


# GetCityDetailByCityName [GET Home/GetCityDetailByCityName{?cityName}]
城市1小时AQI&浓度

+ Parameters

    + cityName: 沈阳 (string, required) - 城市名称

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Body
            {
              "IsUse":true,
              "AQIColor":"#00E400",
              "AQIDescription":"空气质量令人满意，基本无污染。",
              "PrimaryPollutantInfoList":null,
              "Id":0,
              "CityName":"沈阳",
              "TimePoint":"\/Date(1467806400000)\/",
              "AQI":48,
              "PM25":24,
              "PM10":48,
              "SO2":6,
              "NO2":22,
              "CO":0.6,
              "O3":122,
              "O38":147,
              "PrimaryPollutantName":"-",
              "Value":48,
              "PM2524":29,
              "PM1024":58,
              "Level":"一级",
              "Status":"优",
              "IAQI_PM2524":0,
              "IAQI_PM1024":0,
              "IAQI_SO2":0,
              "IAQI_NO2":0,
              "IAQI_CO":0,
              "IAQI_O3":0,
              "IAQI_O38":0,
              "SO2_24":0,
              "NO2_24":0,
              "CO_24":0,
              "O3_24":0,
              "O38_24":0
            }


# GetStationDetailList [GET /Ajax/GetStationDetailList{?cityName}]
城市站点1小时AQI&浓度

+ Parameters

    + cityName: 沈阳 (string, required) - 城市名称

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[LeastRain])

    + Body

            [
              {
                "AQIColor": "#FFFF00",
                "PrimaryPollutantInfoList": [
                  {
                    "SpecialName": "PM<sub>10</sub>",
                    "Unit": "μg/m³",
                    "Value": 67
                  }
                ],
                "Id": 0,
                "StationName": "裕农路",
                "StationCode": "1084A",
                "CityName": null,
                "TimePoint": "/Date(-62135596800000)/",
                "AQI": 59,
                "PM25": 32,
                "PM10": 67,
                "SO2": 9,
                "NO2": 18,
                "CO": 1,
                "O3": 135,
                "O38": 175,
                "PrimaryPollutantName": "PM10:67",
                "Value": 0,
                "PM2524": 21,
                "PM1024": 48,
                "Level": null,
                "Status": null,
                "IAQI_PM2524": 46,
                "IAQI_PM1024": 59,
                "IAQI_SO2": 3,
                "IAQI_NO2": 9,
                "IAQI_CO": 10,
                "IAQI_O3": 43,
                "IAQI_O38": 114,
                "SO2_24": 0,
                "NO2_24": 0,
                "CO_24": 0,
                "O3_24": 0,
                "O38_24": 0
              }
            ]


# GetStationDailyDataListByCityName [GET /Home/GetStationDailyDataListByCityName{?cityName}]
城市站点24小时AQI&浓度

+ Parameters

    + cityName: 沈阳 (string, required) - 城市名称

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[TyhoonActivity])

    + Body

            [
              {
                "AQIColor": "#FF7E00",
                "PrimaryPollutantInfo": "O<sub>3</sub>8小时",
                "Id": 0,
                "TimePoint": "/Date(1467648000000)/",
                "CityName": "沈阳",
                "AQI": 110,
                "PrimaryPollutantName": "O<sub>3</sub>8小时",
                "QualityStatus": "轻度污染",
                "QualityLevel": "三级",
                "StationName": "森林路",
                "PM25": 0,
                "PM10": 0,
                "PM2524": 0,
                "PM1024": 0,
                "SO2": 0,
                "NO2": 0,
                "CO": 0,
                "O3": 0,
                "O38": 0,
                "StationCode": null,
                "IAQI_PM2524": 0,
                "IAQI_PM1024": 0,
                "IAQI_SO2": 0,
                "IAQI_NO2": 0,
                "IAQI_CO": 0,
                "IAQI_O3": 0,
                "IAQI_O38": 0
              }
            ]


# GetCityPollutant [GET /Ajax/GetCityPollutant{?cityName,pollutantName}]
城市24小时AQI&浓度

+ Parameters

    + cityName: 沈阳 (string, required) - 城市名称
    + pollutantName: AQI (enum[string], required) - 污染物名称
        + Members
            + AQI
            + PM25
            + PM10
            + SO2
            + NO2
            + CO
            + O3
            + O38

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[TyphoonInfo])

    + Body
            {
              "chart": {
                "baseFont": "",
                "caption": "",
                "captionForHtml": "【沈阳: AQI 24小时变化】",
                "subcaption": "",
                "xaxisname": "",
                "yaxisname": "AQI",
                "numberprefix": "",
                "showlabels": "1",
                "showcolumnshadow": "1",
                "animation": "1",
                "showalternatehgridcolor": "1",
                "alternatehgridcolor": "B9C6D7",
                "divlinecolor": "005AB5",
                "divlinealpha": "20",
                "alternatehgridalpha": "10",
                "canvasbordercolor": "cccccc",
                "basefontcolor": "666666",
                "linecolor": "005AB5",
                "linealpha": "85",
                "showvalues": "1",
                "rotatevalues": "0",
                "canvaspadding": "8",
                "yAxisValuesStep": "",
                "yAxisMinValue": "0",
                "yAxisMaxValue": "150",
                "baseFontSize": "12",
                "bgColor": "ffffff",
                "labelStep": "2",
                "showBorder": "0",
                "canvasBorderThickness": "0",
                "defaultAnimation": "0",
                "showZeroPlaneValue": "1",
                "showZeroPlane": "1",
                "valuePosition": "BELOW",
                "labelPadding": "20",
                "yAxisValuesPadding": "20",
                "forceDecimals": "0",
                "decimals": "0"
              },
              "data": [
                  {
                    "label": "21:00",
                    "value": "65",
                    "toolText": "07-05 21:00\r\n65"
                  },
                  {
                    "label": "22:00",
                    "value": "77",
                    "toolText": "07-05 22:00\r\n77"
                  },
                  {
                    "label": "23:00",
                    "value": "69",
                    "toolText": "07-05 23:00\r\n69"
                  },
                  {
                    "label": "00:00",
                    "value": "54",
                    "toolText": "07-06 00:00\r\n54"
                  },
                  {
                    "label": "01:00",
                    "value": "46",
                    "toolText": "07-06 01:00\r\n46"
                  },
                  {
                    "label": "02:00",
                    "value": "47",
                    "toolText": "07-06 02:00\r\n47"
                  },
                  {
                    "label": "03:00",
                    "value": "50",
                    "toolText": "07-06 03:00\r\n50"
                  },
                  {
                    "label": "04:00",
                    "value": "52",
                    "toolText": "07-06 04:00\r\n52"
                  },
                  {
                    "label": "05:00",
                    "value": "52",
                    "toolText": "07-06 05:00\r\n52"
                  },
                  {
                    "label": "06:00",
                    "value": "53",
                    "toolText": "07-06 06:00\r\n53"
                  },
                  {
                    "label": "07:00",
                    "value": "52",
                    "toolText": "07-06 07:00\r\n52"
                  },
                  {
                    "label": "08:00",
                    "value": "50",
                    "toolText": "07-06 08:00\r\n50"
                  },
                  {
                    "label": "09:00",
                    "value": "48",
                    "toolText": "07-06 09:00\r\n48"
                  },
                  {
                    "label": "10:00",
                    "value": "48",
                    "toolText": "07-06 10:00\r\n48"
                  },
                  {
                    "label": "11:00",
                    "value": "52",
                    "toolText": "07-06 11:00\r\n52"
                  },
                  {
                    "label": "12:00",
                    "value": "57",
                    "toolText": "07-06 12:00\r\n57"
                  },
                  {
                    "label": "13:00",
                    "value": "63",
                    "toolText": "07-06 13:00\r\n63"
                  },
                  {
                    "label": "14:00",
                    "value": "63",
                    "toolText": "07-06 14:00\r\n63"
                  },
                  {
                    "label": "15:00",
                    "value": "59",
                    "toolText": "07-06 15:00\r\n59"
                  },
                  {
                    "label": "16:00",
                    "value": "55",
                    "toolText": "07-06 16:00\r\n55"
                  },
                  {
                    "label": "17:00",
                    "value": "48",
                    "toolText": "07-06 17:00\r\n48"
                  },
                  {
                    "label": "18:00",
                    "value": "46",
                    "toolText": "07-06 18:00\r\n46"
                  },
                  {
                    "label": "19:00",
                    "value": "50",
                    "toolText": "07-06 19:00\r\n50"
                  },
                  {
                    "label": "20:00",
                    "value": "48",
                    "toolText": "07-06 20:00\r\n48"
                  }
              ],
              "styles": {
                "definition": [
                  {
                    "name": "Animation_0",
                    "type": "ANIMATION",
                    "duration": "1",
                    "start": "0",
                    "param": "_xScale"
                  },
                  {
                    "name": "Animation_1",
                    "type": "ANIMATION",
                    "duration": "1",
                    "start": "70",
                    "param": "_x"
                  }
                ],
                "application": [
                  {
                    "toobject": "DATAPLOT",
                    "styles": "Animation_0"
                  },
                  {
                    "toobject": "DATAPLOT",
                    "styles": "Animation_1"
                  }
                ]
              }
            }


# Get [GET /Ajax/Get{pollutantName}{?stationCode]
站点24小时历史AQI&浓度

+ Parameters

    + pollutantName: AQI (enum[string], required) - 污染物名称
        + Members
            + AQI
            + PM25
            + PM10
            + SO2
            + NO2
            + CO
            + O3
            + O38
    + stationCode (enum[string], required) - 站点编号
        + Members
            + 1001A
            + 1002A
            + 1003A
            + 1005A
            + 1006A
            + 1007A
            + 1008A
            + 1009A
            + 1011A
            + 1012A
            + 1013A
            + 1014A
            + 1015A
            + 1016A
            + 1017A
            + 1018A
            + 1019A
            + 1020A
            + 1021A
            + 1022A
            + 1023A
            + 1024A
            + 1025A
            + 1026A
            + 1027A
            + 1028A
            + 1029A
            + 1030A
            + 1031A
            + 1032A
            + 1033A
            + 1034A
            + 1035A
            + 1036A
            + 1037A
            + 1038A
            + 1039A
            + 1040A
            + 1041A
            + 1042A
            + 1043A
            + 1044A
            + 1045A
            + 1046A
            + 1047A
            + 1048A
            + 1049A
            + 1050A
            + 1051A
            + 1052A
            + 1053A
            + 1054A
            + 1055A
            + 1056A
            + 1057A
            + 1058A
            + 1059A
            + 1060A
            + 1061A
            + 1062A
            + 1063A
            + 1064A
            + 1065A
            + 1066A
            + 1067A
            + 1068A
            + 1069A
            + 1070A
            + 1071A
            + 1072A
            + 1073A
            + 1074A
            + 1077A
            + 1078A
            + 1079A

+ Attributes (object)

    + chart (object) - ?
    + data (array) - ?
    + styles (object) - ?

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[LeastCloud])

    + Body

            {
              "chart":
              {
                "baseFont":"",
                "caption":"",
                "captionForHtml":"【鞍山:铁西工业园区 O₃-8小时 24小时变化】",
                "subcaption":"",
                "xaxisname":"",
                "yaxisname":"浓度μg/m³",
                "numberprefix":"",
                "showlabels":"1",
                "showcolumnshadow":"1",
                "animation":"1",
                "showalternatehgridcolor":"1",
                "alternatehgridcolor":"B9C6D7",
                "divlinecolor":"005AB5",
                "divlinealpha":"20",
                "alternatehgridalpha":"10",
                "canvasbordercolor":"cccccc",
                "basefontcolor":"666666",
                "linecolor":"005AB5",
                "linealpha":"85",
                "showvalues":"1",
                "rotatevalues":"0",
                "canvaspadding":"8",
                "yAxisValuesStep":"",
                "yAxisMinValue":"0",
                "yAxisMaxValue":"150",
                "baseFontSize":"12",
                "bgColor":"ffffff",
                "labelStep":"2",
                "showBorder":"0",
                "canvasBorderThickness":"0",
                "defaultAnimation":"0",
                "showZeroPlaneValue":"1",
                "showZeroPlane":"1",
                "valuePosition":"BELOW",
                "labelPadding":"20",
                "yAxisValuesPadding":"20",
                "forceDecimals":"0",
                "decimals":"0"
              },
              "data":
              [
                {
                  "label":"21:00",
                  "value":"171",
                  "toolText":"07-05 21:00\r\n8小时滑动均值：171μg/m³\r\nIAQI：110"
                },
                {
                  "label":"22:00",
                  "value":"158",
                  "toolText":"07-05 22:00\r\n8小时滑动均值：158μg/m³\r\nIAQI：99"
                },
                {
                  "label":"23:00",
                  "value":"144",
                  "toolText":"07-05 23:00\r\n8小时滑动均值：144μg/m³\r\nIAQI：87"
                },
                {
                  "label":"00:00",
                  "value":"129",
                  "toolText":"07-06 00:00\r\n8小时滑动均值：129μg/m³\r\nIAQI：75"
                },
                {
                  "label":"01:00",
                  "value":"111",
                  "toolText":"07-06 01:00\r\n8小时滑动均值：111μg/m³\r\nIAQI：60"
                },
                {
                  "label":"02:00",
                  "value":"92",
                  "toolText":"07-06 02:00\r\n8小时滑动均值：92μg/m³\r\nIAQI：46"
                },
                {
                  "label":"03:00",
                  "value":"73",
                  "toolText":"07-06 03:00\r\n8小时滑动均值：73μg/m³\r\nIAQI：37"
                },
                {
                  "label":"04:00",
                  "value":"62",
                  "toolText":"07-06 04:00\r\n8小时滑动均值：62μg/m³\r\nIAQI：31"
                },
                {
                  "label":"05:00",
                  "value":"55",
                  "toolText":"07-06 05:00\r\n8小时滑动均值：55μg/m³\r\nIAQI：28"
                },
                {
                  "label":"06:00",
                  "value":"48",
                  "toolText":"07-06 06:00\r\n8小时滑动均值：48μg/m³\r\nIAQI：24"
                },
                {
                  "label":"07:00",
                  "value":"45",
                  "toolText":"07-06 07:00\r\n8小时滑动均值：45μg/m³\r\nIAQI：23"
                },
                {
                  "label":"08:00",
                  "value":"45",
                  "toolText":"07-06 08:00\r\n8小时滑动均值：45μg/m³\r\nIAQI：23"
                },
                {
                  "label":"09:00",
                  "value":"48",
                  "toolText":"07-06 09:00\r\n8小时滑动均值：48μg/m³\r\nIAQI：24"
                },
                {
                  "label":"10:00",
                  "value":"51",
                  "toolText":"07-06 10:00\r\n8小时滑动均值：51μg/m³\r\nIAQI：26"},
                {
                  "label":"11:00",
                  "value":"58",
                  "toolText":"07-06 11:00\r\n8小时滑动均值：58μg/m³\r\nIAQI：29"},
                {
                  "label":"12:00",
                  "value":"68",
                  "toolText":"07-06 12:00\r\n8小时滑动均值：68μg/m³\r\nIAQI：34"},
                {
                  "label":"13:00",
                  "value":"83",
                  "toolText":"07-06 13:00\r\n8小时滑动均值：83μg/m³\r\nIAQI：42"},
                {
                  "label":"14:00",
                  "value":"99",
                  "toolText":"07-06 14:00\r\n8小时滑动均值：99μg/m³\r\nIAQI：50"},
                {
                  "label":"15:00",
                  "value":"109",
                  "toolText":"07-06 15:00\r\n8小时滑动均值：109μg/m³\r\nIAQI：58"},
                {
                  "label":"16:00",
                  "value":"117",
                  "toolText":"07-06 16:00\r\n8小时滑动均值：117μg/m³\r\nIAQI：65"},
                {
                  "label":"17:00",
                  "value":"124",
                  "toolText":"07-06 17:00\r\n8小时滑动均值：124μg/m³\r\nIAQI：70"},
                {
                  "label":"18:00",
                  "value":"131",
                  "toolText":"07-06 18:00\r\n8小时滑动均值：131μg/m³\r\nIAQI：76"},
                {
                  "label":"19:00",
                  "value":"136",
                  "toolText":"07-06 19:00\r\n8小时滑动均值：136μg/m³\r\nIAQI：80"},
                {
                  "label":"20:00",
                  "value":"138",
                  "toolText":"07-06 20:00\r\n8小时滑动均值：138μg/m³\r\nIAQI：82"
                }
              ],
              "styles":
              {
                "definition":
                [
                  {
                    "name":"Animation_0",
                    "type":"ANIMATION",
                    "duration":"1",
                    "start":"0",
                    "param":"_xScale"
                  },
                  {
                    "name":"Animation_1",
                    "type":"ANIMATION",
                    "duration":"1",
                    "start":"70",
                    "param":"_x"
                  }
                ],
                "application":
                [
                  {
                    "toobject":"DATAPLOT",
                    "styles":"Animation_0"
                  },
                  {
                    "toobject":"DATAPLOT",
                    "styles":"Animation_1"
                  }
                ]
              }
            }
