FORMAT: 1A
HOST: http://222.247.51.155:8025/




# 湖南空气质量实时发布系统

文档日期 2016-07-07
系统地址 http://222.247.51.155:8025/。




# AirForecast [POST /Views/Handler/AirForecast.ashx]
城市24小时AQI

+ Request 城市24小时AQI

    + Parameters
        + type: getAirForecasts (string) - ??
        + stcode: 430100 (number) - ??

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (object)
        + result: ok (string) - 数据状态
        + desc (string) - 描述
        + forecasts (array)
          + (object)
            + fldAQIRange: 99,99 (string) - AQI？？
            + fldAQIState: 良 (string) - AQI状态
            + fldCPI: PM2.5 (string) - 主要污染物
            + fldDate: /Date(1467907200000)/ (string) - 时间
            + fldSTName: 长沙市 (string) - 城市名称

    + Body

            {
                "result": "ok",
                "forecasts": [
                    {
                        "fldSTName": "长沙市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "株洲市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "湘潭市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "衡阳市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "邵阳市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "岳阳市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "常德市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "张家界市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "益阳市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "郴州市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "永州市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "优",
                        "fldCPI": "/",
                        "fldAQIRange": "49,49"
                    },
                    {
                        "fldSTName": "怀化市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "娄底市",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "良",
                        "fldCPI": "PM2.5",
                        "fldAQIRange": "99,99"
                    },
                    {
                        "fldSTName": "湘西州",
                        "fldDate": "/Date(1467907200000)/",
                        "fldAQIState": "优",
                        "fldCPI": "/",
                        "fldAQIRange": "49,49"
                    }
                ],
                "desc": ""
            }




# ChartsData [GET /Views/Handler/ChartsData.ashx]
城市24小时AQI
城市1小时历史AQI
城市1小时历史浓度


+ Request 昨日城市AQI
    + Parameters
        + type: getYesterdayCityAQI  (string) - 昨日城市AQI
        + stcode: 2016/7/7 (string) - 时间

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (object)
        + result: ok (string) - 数据状态
        + cityAQIs (array) - 城市AQI
          + (object)
            + CityName: 长沙市 (string) - 城市名称
            + AQI: 45 (string) - AQI
            + AQIColor: #68C994 (string) - AQI颜色
            + Level: 优 (string) - AQI等级

    + Body

            {
                "result": "ok",
                "cityAQIs": [
                    {
                        "CityName": "长沙市",
                        "AQI": "45",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "株洲市",
                        "AQI": "73",
                        "AQIColor": "#F1F156",
                        "Level": "良"
                    },
                    {
                        "CityName": "湘潭市",
                        "AQI": "52",
                        "AQIColor": "#F1F156",
                        "Level": "良"
                    },
                    {
                        "CityName": "衡阳市",
                        "AQI": "40",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "邵阳市",
                        "AQI": "37",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "岳阳市",
                        "AQI": "34",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "常德市",
                        "AQI": "38",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "张家界市",
                        "AQI": "37",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "益阳市",
                        "AQI": "43",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "郴州市",
                        "AQI": "31",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "永州市",
                        "AQI": "30",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "怀化市",
                        "AQI": "33",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "娄底市",
                        "AQI": "42",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    },
                    {
                        "CityName": "吉首市",
                        "AQI": "26",
                        "AQIColor": "#68C994",
                        "Level": "优"
                    }
                ]
            }


+ Request AQI趋势变化

    + Parameters
        + type: getAQIChartData (string) - 固定
        + cityCode: 430100 (string) - 城市代码
        + indexType: AQI (enum[string]) - 污染物
          + Members
              + AQI
              + PM2Dot5H1
              + O3H1
              + COH1
              + PM10H1
              + SO2H1
              + NO2H1

    + Headers

            Accept: application/json

+ Response 200 (application/json)

    + Attributes (object)
      + result: ok (string) - 描述
      + startTime: /Date(1467838800000)/ (string) - 开始时间
      + endTimeDesc: 2016年07月07日20时 (string) - 结束时间
      + dataArr (array[number]) - 趋势

    + Body

            {
                "result": "ok",
                "startTime": "/Date(1467838800000)/",
                "endTimeDesc": "2016年07月07日20时",
                "dataArr": [
                    55,
                    54,
                    54,
                    54,
                    53,
                    53,
                    50,
                    48,
                    46,
                    42,
                    40,
                    40,
                    40,
                    41,
                    53,
                    55,
                    56,
                    92,
                    118,
                    130,
                    107,
                    80,
                    57,
                    57
                ]
            }


+ Request 浓度趋势变化

    + Parameters
        + type: getConcChartData (string) - 固定
        + cityCode: 430100 (string) - 城市代码
        + indexType: PM2Dot5H1 (enum[string], required) - 污染物
          + Members
              + PM2Dot5H1
              + O3H1
              + COH1
              + PM10H1
              + SO2H1
              + NO2H1

    + Headers

            Accept: application/json

+ Response 200 (application/json)

    + Attributes (object)
      + result: ok (string) - 描述
      + startTime: /Date(1467838800000)/ (string) - 开始时间
      + endTimeDesc: 2016年07月07日20时 (string) - 结束时间
      + dataArr (array[number]) - 趋势

    + Body

            {
                "result": "ok",
                "startTime": "/Date(1467838800000)/",
                "endTimeDesc": "2016年07月07日20时",
                "dataArr": [
                    25,
                    24,
                    34,
                    34,
                    22,
                    13,
                    8,
                    6,
                    6,
                    5,
                    8,
                    11,
                    11,
                    15,
                    20,
                    21,
                    19,
                    15,
                    13,
                    12,
                    11,
                    12,
                    17,
                    22
                ]
            }




# AirIndex [GET /Views/Home/AirIndex.aspx]
城市1小时AQI

+ Request HTML

    + Headers

            Accept: text/html

+ Response 200 (text/html)

    + Body

            <!DOCTYPE html>

            <html xmlns="http://www.w3.org/1999/xhtml">
            <head id="Head1"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" /><meta http-equiv="X-UA-Compatible" content="IE=8" />
                <title>空气质量实时发布系统</title>
            <link href="/Content/themes/base/jquery-ui.css" rel="stylesheet" /><link href="/Content/Site.css" rel="stylesheet" />
                <style type="text/css">
                    #dialogRefresh label {
                        display: block;
                        cursor: pointer;
                    }

                    #dialogRefresh div {
                        margin: 10px auto;
                    }
                </style>
                <script src="/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
                <script src="/Scripts/jquery-ui-1.8.24.min.js" type="text/javascript"></script>
                <script src="/Scripts/jquery.easing.1.3.js" type="text/javascript"></script>
                <script src="/Scripts/ClientCookieHelper.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var isRefresh = false,
                        timeInterval = parseInt('0', 10),
                        int = null;

                    if (timeInterval != 0) {
                        setInt();
                        isRefresh = true;
                    }

                    function setInt() {
                        int = setInterval(function () {
                            var href = location.href.replace("#", ""),
                                index = href.indexOf("?");
                            if (index == -1) {
                                href += "?int=" + timeInterval;
                            } else {
                                href = href.substr(0, index) + "?int=" + timeInterval;
                            }
                            document.URL = href;  // 刷新当前页面
                        }, timeInterval * 1000 * 60);
                    }

                    $(function () {
                        $('#refresh').click(function () {
                            $('#dialogRefresh').dialog('open');
                        });

                        $('#dialogRefresh').dialog({
                            width: 260,
                            height: 200,
                            autoOpen: false,
                            resizable: false,
                            modal: true,
                            open: function (event, ui) {
                                $("#isRef").attr("checked", isRefresh);
                                $("#interval").val(timeInterval);
                                if (timeInterval < 5) {
                                    $("#interval").val(5);
                                }
                            },
                            buttons: [{
                                text: "确定",
                                click: function () {
                                    isRefresh = $("#isRef").attr("checked") === "checked";
                                    if (isRefresh && !isNaN(parseInt($("#interval").val(), 10))) {
                                        timeInterval = parseInt($("#interval").val(), 10);
                                        if (timeInterval < 5) {
                                            timeInterval = 5;
                                        }
                                        setInt(); // 刷新当前页面
                                    } else {
                                        clearInterval(int);
                                        int = null;
                                    }
                                    $(this).dialog('close');
                                }
                            }]
                        });
                    });
                </script>

                <link href="/Content/HomeIndex.css" rel="stylesheet" />
                <style type="text/css">
                    div#AQI a[href^="http:"] {
                        color: black;
                        background: url(/Images/invalidExternalLink.png) no-repeat right top;
                        padding-right: 10px;
                    }

                    div#AQI a[href^="java"] {
                        color: black;
                        /*background: url(/Images/externalLink.gif) no-repeat right top;*/
                        padding-right: 10px;
                    }
                </style>
                <style type="text/css">
                 .table-head{padding-right:17px;background-color:#999;color:#000;}
                 .table-body{width:100%; height:300px;overflow-y:scroll;}
                 .table-head table,.table-body table{width:100%;}
                    .tbl-data-air1 td { border-bottom:1px solid #ABABAB
                    }
                    .forcast td {
                        border:none;
                    }
                 /*.table-body table tr:nth-child(2n+1){background-color:#f2f2f2;}   */
                </style>
            <title>

            </title></head>
            <body>
                <div id="home" class="home">


                    <div class="menu-primary-nav-container">

                        <ul class="menu" id="menu-primary-nav">






                            <li></li>


                            <li style="margin-left:500px; float: none;">

                                <img style="margin-top: 17px; margin-left: 400px; width: 600px;" src="/Images/CityTitle/430000.png" alt="home_title" />
                            </li>
                        </ul>

                    </div>
                    <div id="main-content" class="main-content">

                <div class="part-up">
                    <div class="part-up-header">
                        <ul class="nav" style="margin-top: 0px; margin-right: 440px;">
                            <li><a id="aqiData" class="selected" href="javascript:void(0)">首页</a></li>
                            <li><a href="http://222.247.51.155:8025/GISManage/" target="_blank">GIS查询</a></li>
                            <li><a id="aqiTrend" href="javascript:void(0)">AQI趋势变化</a></li>
                            <li style="width: 100px;"><a id="concTrend" href="javascript:void(0)">浓度趋势变化</a></li>
                            <li><a id="citySort" href="javascript:void(0)">城市排序</a></li>





                        </ul>
                    </div>

                    <ul class="part-up-ul">
                        <li style="width: 556px; margin-left: 13px; position: relative;">
                            <div class="part-up-air-city" style="margin-left: 280px;">
                                <br />
                                <span id="spCity" class="part-up-font-large"
                                    data-aqi_city-code="430100">
                                    长沙市</span>
                                <span class="">空气质量状况</span>
                                <span id="spTime" class="">2016 年 07 月 07 日 20 时</span>

                                <br />
                                <br />
                                <br />
                                <div class="part-up-font-large" style="float:left;">空气质量指数(AQI)：</div>
                                <div id="divAQI0" style="color: #F1F156;font-size: 45px; float: left;width: 85px;margin-top: -13px;margin-left:0px;margin-right:0px;text-align: center;">57</div>
                                <div style="float: left;width: 0px;">&nbsp;&nbsp;</div>
                                <div id="spState" style="float: left;width: 60px;">良</div>
                                <div id="spLevel" style="float: left;width: 40px;">(二级)</div>

                            </div>
                            <table cellpadding="0" cell spacing="0" style="position: absolute;top: 90px;">
                                <tr style="display:none;">
                                    <td style="width: 130px; height: 55px; text-align: right;"></td>
                                    <td id="tdAQI"></td>

                                </tr>
                                <tr class="aqi-opt">
                                    <td style="width: 130px; text-align: right;"><span class="cpi-opt">首要污染物</span>：</td>
                                    <td><span id="spCPI">PM<sub>10</sub></span></td>
                                </tr>
                                <tr class="aqi-opt">
                                    <td>对健康的影响：</td>
                                    <td><span id="spHealth">空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响</span></td>
                                </tr>
                                <tr class="aqi-opt">
                                    <td><span class="measure-opt">建议措施</span>：</td>
                                    <td><span id="spMeasure">极少数异常敏感人群应减少户外活动</span></td>
                                </tr>
                                <tr style="color: #005D98;">
                                    <td colspan="2" style="padding-left: 44px;">系统数据未经人工审核，仅供参考，不直接用于达标评价和城市排名。</td>
                                </tr>
                            </table>

                            <div id="chartAQIContainer" class="aqi-panel"></div>
                            <div class="aqi-state-level" style="display: none;">

                                <br />
                                <br />

                            </div>
                            <ul class="link-more">
                                <li><a href="/Views/Other/Knowledge.aspx" target="_blank">基本知识</a></li>

                            </ul>
                        </li>
                        <li style="width: 340px; border-left: 1px dashed #A8A8A8;">
                            <div class="part-up-air-picture" style="display:none;">
                                <span class="part-up-font-large">实景照片</span><br />
                                <img id="imgLatestAir" src="" alt="air-picture" style="margin-top: 3px; border: 8px solid white;" />
                            </div>

                        </li>

                    </ul>
                   <div id="tblCitySort" style="width:320px; text-align:center;"><div id="sortTitle" style="font-size: 13px;margin-bottom: 5px;  height: 20px; background-color: #0075BA; line-height: 20px; color:#FFF">城市空气质量排名</div></div>
                    <div id="divPhotoBrowse" style="position: absolute; z-index: 4; top: 130px; left: 180px; display: none; width: 580px; height: 507px; border: 3px solid #E0E0E0; background-color: white;">
                        <a href="#" style="color: black;" onclick="$(this).parent().css('display', 'none');">关闭</a>
                        <table cellpadding="0" cellspacing="0" style="width: 100%; height: 380px;">
                            <tr>
                                <td align="center" valign="middle">
                                    <img id="imgBig" src="" alt="imgBigAir" /></td>
                            </tr>
                        </table>
                        <div id="imgDirectionBlock" style="margin: 0px; height: 53px;"></div>
                        <img id="imgBigLeft" src="/Images/left_big.png" alt="left_big" style="display: none; position: relative; top: -210px; cursor: pointer;" title="上一张" />
                        <img id="imgBigRight" src="/Images/right_big.png" alt="right_big" style="display: none; position: relative; top: -210px; left: 545px; cursor: pointer;" title="下一张" />
                        <table cellpadding="0" cellspacing="0" style="position: relative; top: -47px; background-color: #F3F3F3;">
                            <tr>

                                <td>
                                    <div id="divImgSmall" style="width: 579px; height: 120px; padding: 0px; overflow-x: scroll; overflow-y: hidden;">
                                        <ul id="ulImgSmall" class="ul-img-small">
                                        </ul>
                                    </div>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
                <div class="part-down">
                    <div class="part-down-header">



                    </div>

                    <div id="AQI" class="div-content">
                         <div class="table-head">
                             <table id="AQI1" class="tbl-data-air" cellpadding="0" cellspacing="0" style="line-height: 18px;background-color:#EEF9FF;">
                                 <colgroup>
                                     <col style="width: 80px;" />
                                     <col />
                                 </colgroup>
                                 <thead>
                                    <tr>
                                        <td style="width:10%">城市名称</td>

                                        <td style="width:10%">AQI时报</td>
                                        <td style="width:10%">空气质量状况</td>
                                        <td style="width:10%">空气质量等级</td>
                                        <td style="width:10%">首要污染物</td>
                                        <td id="thforcast" style="width: 32%;border-right: 0px;">空气质量预报
                                        </td>
                                    </tr>
                                 </thead>
                             </table>
                        </div>
                        <div class="table-body">
                        <table id="AQI0" class="tbl-data-air1" cellpadding="0" cellspacing="0" style="line-height: 18px;background-color:#EEF9FF;">

                            <colgroup><col style="width: 80px;" /><col /></colgroup>
                            <tbody>


                            <tr style="height: 17px;" class="table-selected-tr"
                                data-aqi-city-code="430100"
                                data-aqi-city="长沙市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="50"
                                data-aqi-pm2dot5h24="49"
                                data-aqi-o3h1="30"
                                data-aqi-o3h8="89"
                                data-aqi-coh1="8"
                                data-aqi-pm10h1="57"
                                data-aqi-pm10h24="47"
                                data-aqi-so2h1="3"
                                data-aqi-no2h1="13"
                                data-aqi-value="57"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>10</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">长沙市</a></td>

                                <td style="width:10%">57</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>10</sub>" style="width:10%">PM<sub>10</sub></td>

                                <td rowspan="14" style="background-color:#EEF9FF;width: 32%;border-right: 0px; ">
                                    <table class="forcast" id="forcast" cellpadding="1px" cellspacing="1px" style=""></table>
                                </td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430200"
                                data-aqi-city="株洲市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="49"
                                data-aqi-pm2dot5h24="46"
                                data-aqi-o3h1="38"
                                data-aqi-o3h8="94"
                                data-aqi-coh1="10"
                                data-aqi-pm10h1="50"
                                data-aqi-pm10h24="52"
                                data-aqi-so2h1="4"
                                data-aqi-no2h1="13"
                                data-aqi-value="50"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">株洲市</a></td>

                                <td style="width:10%">50</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430300"
                                data-aqi-city="湘潭市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="45"
                                data-aqi-pm2dot5h24="52"
                                data-aqi-o3h1="21"
                                data-aqi-o3h8="55"
                                data-aqi-coh1="9"
                                data-aqi-pm10h1="54"
                                data-aqi-pm10h24="55"
                                data-aqi-so2h1="6"
                                data-aqi-no2h1="15"
                                data-aqi-value="54"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>10</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">湘潭市</a></td>

                                <td style="width:10%">54</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>10</sub>" style="width:10%">PM<sub>10</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430400"
                                data-aqi-city="衡阳市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="49"
                                data-aqi-pm2dot5h24="46"
                                data-aqi-o3h1="27"
                                data-aqi-o3h8="60"
                                data-aqi-coh1="8"
                                data-aqi-pm10h1="67"
                                data-aqi-pm10h24="54"
                                data-aqi-so2h1="2"
                                data-aqi-no2h1="12"
                                data-aqi-value="67"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>10</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">衡阳市</a></td>

                                <td style="width:10%">67</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>10</sub>" style="width:10%">PM<sub>10</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430500"
                                data-aqi-city="邵阳市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="49"
                                data-aqi-pm2dot5h24="500"
                                data-aqi-o3h1="17"
                                data-aqi-o3h8="53"
                                data-aqi-coh1="7"
                                data-aqi-pm10h1="51"
                                data-aqi-pm10h24="55"
                                data-aqi-so2h1="6"
                                data-aqi-no2h1="8"
                                data-aqi-value="51"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>10</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">邵阳市</a></td>

                                <td style="width:10%">51</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>10</sub>" style="width:10%">PM<sub>10</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430600"
                                data-aqi-city="岳阳市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="58"
                                data-aqi-pm2dot5h24="46"
                                data-aqi-o3h1="29"
                                data-aqi-o3h8="65"
                                data-aqi-coh1="10"
                                data-aqi-pm10h1="47"
                                data-aqi-pm10h24="44"
                                data-aqi-so2h1="6"
                                data-aqi-no2h1="13"
                                data-aqi-value="58"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>2.5</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">岳阳市</a></td>

                                <td style="width:10%">58</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>2.5</sub>" style="width:10%">PM<sub>2.5</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430700"
                                data-aqi-city="常德市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="50"
                                data-aqi-pm2dot5h24="35"
                                data-aqi-o3h1="22"
                                data-aqi-o3h8="47"
                                data-aqi-coh1="15"
                                data-aqi-pm10h1="48"
                                data-aqi-pm10h24="36"
                                data-aqi-so2h1="5"
                                data-aqi-no2h1="5"
                                data-aqi-value="50"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">常德市</a></td>

                                <td style="width:10%">50</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430800"
                                data-aqi-city="张家界市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="26"
                                data-aqi-pm2dot5h24="25"
                                data-aqi-o3h1="11"
                                data-aqi-o3h8="36"
                                data-aqi-coh1="14"
                                data-aqi-pm10h1="37"
                                data-aqi-pm10h24="27"
                                data-aqi-so2h1="2"
                                data-aqi-no2h1="14"
                                data-aqi-value="37"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">张家界市</a></td>

                                <td style="width:10%">37</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="430900"
                                data-aqi-city="益阳市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="45"
                                data-aqi-pm2dot5h24="35"
                                data-aqi-o3h1="26"
                                data-aqi-o3h8="71"
                                data-aqi-coh1="6"
                                data-aqi-pm10h1="56"
                                data-aqi-pm10h24="43"
                                data-aqi-so2h1="6"
                                data-aqi-no2h1="7"
                                data-aqi-value="56"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>10</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">益阳市</a></td>

                                <td style="width:10%">56</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>10</sub>" style="width:10%">PM<sub>10</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="431000"
                                data-aqi-city="郴州市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="38"
                                data-aqi-pm2dot5h24="26"
                                data-aqi-o3h1="17"
                                data-aqi-o3h8="47"
                                data-aqi-coh1="13"
                                data-aqi-pm10h1="46"
                                data-aqi-pm10h24="50"
                                data-aqi-so2h1="4"
                                data-aqi-no2h1="12"
                                data-aqi-value="46"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">郴州市</a></td>

                                <td style="width:10%">46</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="431100"
                                data-aqi-city="永州市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="40"
                                data-aqi-pm2dot5h24="30"
                                data-aqi-o3h1="18"
                                data-aqi-o3h8="41"
                                data-aqi-coh1="7"
                                data-aqi-pm10h1="44"
                                data-aqi-pm10h24="37"
                                data-aqi-so2h1="8"
                                data-aqi-no2h1="13"
                                data-aqi-value="44"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">永州市</a></td>

                                <td style="width:10%">44</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="431200"
                                data-aqi-city="怀化市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="30"
                                data-aqi-pm2dot5h24="25"
                                data-aqi-o3h1="17"
                                data-aqi-o3h8="47"
                                data-aqi-coh1="15"
                                data-aqi-pm10h1="43"
                                data-aqi-pm10h24="38"
                                data-aqi-so2h1="2"
                                data-aqi-no2h1="5"
                                data-aqi-value="43"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">怀化市</a></td>

                                <td style="width:10%">43</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="431300"
                                data-aqi-city="娄底市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="64"
                                data-aqi-pm2dot5h24="58"
                                data-aqi-o3h1="20"
                                data-aqi-o3h8="49"
                                data-aqi-coh1="9"
                                data-aqi-pm10h1="50"
                                data-aqi-pm10h24="51"
                                data-aqi-so2h1="5"
                                data-aqi-no2h1="11"
                                data-aqi-value="64"
                                data-aqi-color="#F1F156"
                                data-aqi-state="良"
                                data-aqi-level="二级"
                                data-aqi-cpi="PM<sub>2.5</sub>"
                                data-aqi-health="空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响"
                                data-aqi-measure="极少数异常敏感人群应减少户外活动">

                                <td style="width:10%"><a href="javascript:void(0)">娄底市</a></td>

                                <td style="width:10%">64</td>
                                <td style="background-color: #F1F156; cursor: help; width:10%"
                                    title="指数级别：良 二级对健康的影响：空气质量可接受，但某些污染物可能对极少数异常敏感人群健康有较弱影响建议措施：极少数异常敏感人群应减少户外活动">良</td>
                                <td style="width:10%">二级</td>
                                <td title="PM<sub>2.5</sub>" style="width:10%">PM<sub>2.5</sub></td>

                            </tr>

                            <tr style="height: 17px;" class=""
                                data-aqi-city-code="433100"
                                data-aqi-city="吉首市"
                                data-aqi-time="2016 年 07 月 07 日 20 时"
                                data-aqi-pm2dot5h1="20"
                                data-aqi-pm2dot5h24="25"
                                data-aqi-o3h1="5"
                                data-aqi-o3h8="25"
                                data-aqi-coh1="17"
                                data-aqi-pm10h1="26"
                                data-aqi-pm10h24="35"
                                data-aqi-so2h1="3"
                                data-aqi-no2h1="9"
                                data-aqi-value="26"
                                data-aqi-color="#68C994"
                                data-aqi-state="优"
                                data-aqi-level="一级"
                                data-aqi-cpi=""
                                data-aqi-health="空气质量令人满意，基本无空气污染"
                                data-aqi-measure="各类人群可正常活动">

                                <td style="width:10%"><a href="javascript:void(0)">吉首市</a></td>

                                <td style="width:10%">26</td>
                                <td style="background-color: #68C994; cursor: help; width:10%"
                                    title="指数级别：优 一级对健康的影响：空气质量令人满意，基本无空气污染建议措施：各类人群可正常活动">优</td>
                                <td style="width:10%">一级</td>
                                <td title="" style="width:10%"></td>

                            </tr>

                            </tbody>



                        </table>
                        </div>
                    </div>

                    <div id="RealConc" class="div-content" style="">
                        <table class="tbl-data-air" cellpadding="0" cellspacing="0">
                            <tr>
                                <td rowspan="2">城市名称</td>
                                <td>SO<sub>2</sub>&nbsp;1小时</td>
                                <td>NO<sub>2</sub>&nbsp;1小时</td>
                                <td>PM<sub>10</sub>&nbsp;1小时</td>
                                <td style="display: none;">PM<sub>10</sub>&nbsp;24小时</td>
                                <td>CO&nbsp;1小时</td>
                                <td>O<sub>3</sub>&nbsp;1小时</td>
                                <td style="display: none;">O<sub>3</sub>&nbsp;8小时</td>
                                <td>PM<sub>2.5</sub>&nbsp;1小时</td>
                                <td style="border-right: 0px; display: none;">PM<sub>2.5</sub>&nbsp;24小时</td>
                            </tr>
                            <tr>
                                <td>μg/m<sup>3</sup></td>
                                <td>μg/m<sup>3</sup></td>
                                <td>μg/m<sup>3</sup></td>
                                <td style="display: none;">μg/m<sup>3</sup></td>
                                <td>mg/m<sup>3</sup></td>
                                <td>μg/m<sup>3</sup></td>
                                <td style="display: none;">μg/m<sup>3</sup></td>
                                <td>μg/m<sup>3</sup></td>
                                <td style="border-right: 0px; display: none;">μg/m<sup>3</sup></td>
                            </tr>

                            <tr style="height: 17px;" class=" table-selected-tr"
                                data-conc-city-code="430100"
                                data-conc-pm2dot5h1="35"
                                data-conc-pm2dot524="34"
                                data-conc-o3h1="95"
                                data-conc-o3h8="146"
                                data-conc-coh1="0.7"
                                data-conc-pm10h1="63"
                                data-conc-pm10h24="47"
                                data-conc-so2h1="9"
                                data-conc-no2h1="25">
                                <td>长沙市</td>
                                <td>9</td>
                                <td>25</td>
                                <td>63</td>
                                <td style="display: none;">47</td>
                                <td>0.7</td>
                                <td>95</td>
                                <td style="display: none;">146</td>
                                <td>35</td>
                                <td style="display: none;">34</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430200"
                                data-conc-pm2dot5h1="34"
                                data-conc-pm2dot524="32"
                                data-conc-o3h1="119"
                                data-conc-o3h8="152"
                                data-conc-coh1="0.9"
                                data-conc-pm10h1="50"
                                data-conc-pm10h24="54"
                                data-conc-so2h1="10"
                                data-conc-no2h1="26">
                                <td>株洲市</td>
                                <td>10</td>
                                <td>26</td>
                                <td>50</td>
                                <td style="display: none;">54</td>
                                <td>0.9</td>
                                <td>119</td>
                                <td style="display: none;">152</td>
                                <td>34</td>
                                <td style="display: none;">32</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430300"
                                data-conc-pm2dot5h1="31"
                                data-conc-pm2dot524="36"
                                data-conc-o3h1="66"
                                data-conc-o3h8="106"
                                data-conc-coh1="0.8"
                                data-conc-pm10h1="57"
                                data-conc-pm10h24="59"
                                data-conc-so2h1="16"
                                data-conc-no2h1="29">
                                <td>湘潭市</td>
                                <td>16</td>
                                <td>29</td>
                                <td>57</td>
                                <td style="display: none;">59</td>
                                <td>0.8</td>
                                <td>66</td>
                                <td style="display: none;">106</td>
                                <td>31</td>
                                <td style="display: none;">36</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430400"
                                data-conc-pm2dot5h1="34"
                                data-conc-pm2dot524="32"
                                data-conc-o3h1="84"
                                data-conc-o3h8="112"
                                data-conc-coh1="0.7"
                                data-conc-pm10h1="83"
                                data-conc-pm10h24="58"
                                data-conc-so2h1="6"
                                data-conc-no2h1="24">
                                <td>衡阳市</td>
                                <td>6</td>
                                <td>24</td>
                                <td>83</td>
                                <td style="display: none;">58</td>
                                <td>0.7</td>
                                <td>84</td>
                                <td style="display: none;">112</td>
                                <td>34</td>
                                <td style="display: none;">32</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430500"
                                data-conc-pm2dot5h1="34"
                                data-conc-pm2dot524="1103"
                                data-conc-o3h1="53"
                                data-conc-o3h8="103"
                                data-conc-coh1="0.6"
                                data-conc-pm10h1="52"
                                data-conc-pm10h24="60"
                                data-conc-so2h1="17"
                                data-conc-no2h1="16">
                                <td>邵阳市</td>
                                <td>17</td>
                                <td>16</td>
                                <td>52</td>
                                <td style="display: none;">60</td>
                                <td>0.6</td>
                                <td>53</td>
                                <td style="display: none;">103</td>
                                <td>34</td>
                                <td style="display: none;">1103</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430600"
                                data-conc-pm2dot5h1="41"
                                data-conc-pm2dot524="32"
                                data-conc-o3h1="90"
                                data-conc-o3h8="118"
                                data-conc-coh1="0.9"
                                data-conc-pm10h1="47"
                                data-conc-pm10h24="44"
                                data-conc-so2h1="16"
                                data-conc-no2h1="26">
                                <td>岳阳市</td>
                                <td>16</td>
                                <td>26</td>
                                <td>47</td>
                                <td style="display: none;">44</td>
                                <td>0.9</td>
                                <td>90</td>
                                <td style="display: none;">118</td>
                                <td>41</td>
                                <td style="display: none;">32</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430700"
                                data-conc-pm2dot5h1="35"
                                data-conc-pm2dot524="24"
                                data-conc-o3h1="69"
                                data-conc-o3h8="94"
                                data-conc-coh1="1.4"
                                data-conc-pm10h1="48"
                                data-conc-pm10h24="36"
                                data-conc-so2h1="14"
                                data-conc-no2h1="10">
                                <td>常德市</td>
                                <td>14</td>
                                <td>10</td>
                                <td>48</td>
                                <td style="display: none;">36</td>
                                <td>1.4</td>
                                <td>69</td>
                                <td style="display: none;">94</td>
                                <td>35</td>
                                <td style="display: none;">24</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430800"
                                data-conc-pm2dot5h1="18"
                                data-conc-pm2dot524="17"
                                data-conc-o3h1="34"
                                data-conc-o3h8="72"
                                data-conc-coh1="1.3"
                                data-conc-pm10h1="37"
                                data-conc-pm10h24="27"
                                data-conc-so2h1="4"
                                data-conc-no2h1="28">
                                <td>张家界市</td>
                                <td>4</td>
                                <td>28</td>
                                <td>37</td>
                                <td style="display: none;">27</td>
                                <td>1.3</td>
                                <td>34</td>
                                <td style="display: none;">72</td>
                                <td>18</td>
                                <td style="display: none;">17</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="430900"
                                data-conc-pm2dot5h1="31"
                                data-conc-pm2dot524="24"
                                data-conc-o3h1="82"
                                data-conc-o3h8="125"
                                data-conc-coh1="0.5"
                                data-conc-pm10h1="62"
                                data-conc-pm10h24="43"
                                data-conc-so2h1="17"
                                data-conc-no2h1="14">
                                <td>益阳市</td>
                                <td>17</td>
                                <td>14</td>
                                <td>62</td>
                                <td style="display: none;">43</td>
                                <td>0.5</td>
                                <td>82</td>
                                <td style="display: none;">125</td>
                                <td>31</td>
                                <td style="display: none;">24</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="431000"
                                data-conc-pm2dot5h1="26"
                                data-conc-pm2dot524="18"
                                data-conc-o3h1="54"
                                data-conc-o3h8="94"
                                data-conc-coh1="1.2"
                                data-conc-pm10h1="46"
                                data-conc-pm10h24="50"
                                data-conc-so2h1="10"
                                data-conc-no2h1="24">
                                <td>郴州市</td>
                                <td>10</td>
                                <td>24</td>
                                <td>46</td>
                                <td style="display: none;">50</td>
                                <td>1.2</td>
                                <td>54</td>
                                <td style="display: none;">94</td>
                                <td>26</td>
                                <td style="display: none;">18</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="431100"
                                data-conc-pm2dot5h1="28"
                                data-conc-pm2dot524="21"
                                data-conc-o3h1="57"
                                data-conc-o3h8="81"
                                data-conc-coh1="0.6"
                                data-conc-pm10h1="44"
                                data-conc-pm10h24="37"
                                data-conc-so2h1="24"
                                data-conc-no2h1="25">
                                <td>永州市</td>
                                <td>24</td>
                                <td>25</td>
                                <td>44</td>
                                <td style="display: none;">37</td>
                                <td>0.6</td>
                                <td>57</td>
                                <td style="display: none;">81</td>
                                <td>28</td>
                                <td style="display: none;">21</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="431200"
                                data-conc-pm2dot5h1="21"
                                data-conc-pm2dot524="17"
                                data-conc-o3h1="53"
                                data-conc-o3h8="93"
                                data-conc-coh1="1.5"
                                data-conc-pm10h1="43"
                                data-conc-pm10h24="38"
                                data-conc-so2h1="6"
                                data-conc-no2h1="10">
                                <td>怀化市</td>
                                <td>6</td>
                                <td>10</td>
                                <td>43</td>
                                <td style="display: none;">38</td>
                                <td>1.5</td>
                                <td>53</td>
                                <td style="display: none;">93</td>
                                <td>21</td>
                                <td style="display: none;">17</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="431300"
                                data-conc-pm2dot5h1="46"
                                data-conc-pm2dot524="41"
                                data-conc-o3h1="62"
                                data-conc-o3h8="98"
                                data-conc-coh1="0.8"
                                data-conc-pm10h1="50"
                                data-conc-pm10h24="52"
                                data-conc-so2h1="14"
                                data-conc-no2h1="21">
                                <td>娄底市</td>
                                <td>14</td>
                                <td>21</td>
                                <td>50</td>
                                <td style="display: none;">52</td>
                                <td>0.8</td>
                                <td>62</td>
                                <td style="display: none;">98</td>
                                <td>46</td>
                                <td style="display: none;">41</td>
                            </tr>

                            <tr style="height: 17px;" class=""
                                data-conc-city-code="433100"
                                data-conc-pm2dot5h1="14"
                                data-conc-pm2dot524="17"
                                data-conc-o3h1="15"
                                data-conc-o3h8="50"
                                data-conc-coh1="1.6"
                                data-conc-pm10h1="26"
                                data-conc-pm10h24="35"
                                data-conc-so2h1="7"
                                data-conc-no2h1="18">
                                <td>吉首市</td>
                                <td>7</td>
                                <td>18</td>
                                <td>26</td>
                                <td style="display: none;">35</td>
                                <td>1.6</td>
                                <td>15</td>
                                <td style="display: none;">50</td>
                                <td>14</td>
                                <td style="display: none;">17</td>
                            </tr>

                        </table>
                    </div>

                    <div id="AQITrend" class="div-content">
                        <table cellpadding="0" cellspacing="0">
                            <tr>

                                <td>

                                    <ul class="ul-city-area">

                                        <li data-city-code="430100"
                                            class="ul-city-area-checked"
                                            >
                                            长沙市</li>

                                        <li data-city-code="430200"
                                            class="ul-city-area-unchecked"
                                            >
                                            株洲市</li>

                                        <li data-city-code="430300"
                                            class="ul-city-area-unchecked"
                                            >
                                            湘潭市</li>

                                        <li data-city-code="430400"
                                            class="ul-city-area-unchecked"
                                            >
                                            衡阳市</li>

                                        <li data-city-code="430500"
                                            class="ul-city-area-unchecked"
                                            >
                                            邵阳市</li>

                                        <li data-city-code="430600"
                                            class="ul-city-area-unchecked"
                                            >
                                            岳阳市</li>

                                        <li data-city-code="430700"
                                            class="ul-city-area-unchecked"
                                            >
                                            常德市</li>

                                        <li data-city-code="430800"
                                            class="ul-city-area-unchecked"
                                            >
                                            张家界市</li>

                                        <li data-city-code="430900"
                                            class="ul-city-area-unchecked"
                                            >
                                            益阳市</li>

                                        <li data-city-code="431000"
                                            class="ul-city-area-unchecked"
                                            >
                                            郴州市</li>

                                        <li data-city-code="431100"
                                            class="ul-city-area-unchecked"
                                            >
                                            永州市</li>

                                        <li data-city-code="431200"
                                            class="ul-city-area-unchecked"
                                            >
                                            怀化市</li>

                                        <li data-city-code="431300"
                                            class="ul-city-area-unchecked"
                                            >
                                            娄底市</li>

                                        <li data-city-code="433100"
                                            class="ul-city-area-unchecked"
                                            >
                                            吉首市</li>

                                    </ul>

                                </td>

                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="div-trend-left">
                                        <table class="div-trend-aqi-table" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>指标</td>
                                                <td>均值类型</td>
                                                <td>数值</td>
                                            </tr>
                                             <tr class="table-selected-tr" data-index-type="AQI" item-code-type-hour="000_1">
                                                <td class="last-tr-td">AQI</td>
                                                <td class="last-tr-td">空气质量指数</td>
                                                <td class="last-tr-td"><span id="spAQIVal">57</span></td>
                                            </tr>
                                            <tr data-index-type="PM2Dot5H1" item-code-type-hour="105_1">
                                                <td>PM<sub>2.5</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIPM2Dot5H1">50</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="PM2Dot5H24" item-code-type-hour="105_24">
                                                <td>PM<sub>2.5</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIPM2Dot5H24">49</span></td>
                                            </tr>
                                            <tr data-index-type="O3H1" item-code-type-hour="108_1">
                                                <td>O<sub>3</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIO3H1">30</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="O3H8" item-code-type-hour="108_8">
                                                <td>O<sub>3</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIO3H8">89</span></td>
                                            </tr>
                                            <tr data-index-type="COH1" item-code-type-hour="106_1">
                                                <td>CO</td>
                                                <td>分指数</td>
                                                <td><span id="spAQICOH1">8</span></td>
                                            </tr>
                                            <tr data-index-type="PM10H1" item-code-type-hour="107_1">
                                                <td>PM<sub>10</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIPM10H1">57</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="PM10H24" item-code-type-hour="107_24">
                                                <td>PM<sub>10</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQIPM10H24">47</span></td>
                                            </tr>
                                            <tr data-index-type="SO2H1" item-code-type-hour="101_1">
                                                <td>SO<sub>2</sub></td>
                                                 <td>分指数</td>
                                                <td><span id="spAQISO2H1">3</span></td>
                                            </tr>
                                            <tr data-index-type="NO2H1" item-code-type-hour="141_1">
                                                <td>NO<sub>2</sub></td>
                                                <td>分指数</td>
                                                <td><span id="spAQINO2H1">13</span></td>
                                            </tr>

                                        </table>
                                    </div>
                                </td>
                                <td>
                                    <div class="div-trend-right">
                                        <table cellpadding="0" cellspacing="0">

                                            <tr>
                                                <td colspan="2">
                                                    <div id="chartAQI" class="div-chart"></div>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="RealConcTrend" class="div-content">
                        <table cellpadding="0" cellspacing="0">
                            <tr>

                                <td>

                                    <ul class="ul-city-area conc-trend">

                                        <li data-city-code="430100"
                                            class="ul-city-area-checked"
                                            >
                                            长沙市</li>

                                        <li data-city-code="430200"
                                            class="ul-city-area-unchecked"
                                            >
                                            株洲市</li>

                                        <li data-city-code="430300"
                                            class="ul-city-area-unchecked"
                                            >
                                            湘潭市</li>

                                        <li data-city-code="430400"
                                            class="ul-city-area-unchecked"
                                            >
                                            衡阳市</li>

                                        <li data-city-code="430500"
                                            class="ul-city-area-unchecked"
                                            >
                                            邵阳市</li>

                                        <li data-city-code="430600"
                                            class="ul-city-area-unchecked"
                                            >
                                            岳阳市</li>

                                        <li data-city-code="430700"
                                            class="ul-city-area-unchecked"
                                            >
                                            常德市</li>

                                        <li data-city-code="430800"
                                            class="ul-city-area-unchecked"
                                            >
                                            张家界市</li>

                                        <li data-city-code="430900"
                                            class="ul-city-area-unchecked"
                                            >
                                            益阳市</li>

                                        <li data-city-code="431000"
                                            class="ul-city-area-unchecked"
                                            >
                                            郴州市</li>

                                        <li data-city-code="431100"
                                            class="ul-city-area-unchecked"
                                            >
                                            永州市</li>

                                        <li data-city-code="431200"
                                            class="ul-city-area-unchecked"
                                            >
                                            怀化市</li>

                                        <li data-city-code="431300"
                                            class="ul-city-area-unchecked"
                                            >
                                            娄底市</li>

                                        <li data-city-code="433100"
                                            class="ul-city-area-unchecked"
                                            >
                                            吉首市</li>

                                    </ul>

                                </td>

                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="div-trend-left">
                                        <table class="div-trend-conc-table" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>指标</td>
                                                <td>均值类型</td>
                                                <td>浓度</td>
                                            </tr>
                                            <tr class="table-selected-tr" data-index-type="PM2Dot5H1" item-code-type-hour="105_1">
                                                <td>PM<sub>2.5</sub></td>
                                                <td>1小时</td>
                                                <td><span id="spConcPM2Dot5H1">35</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="PM2Dot5H24" item-code-type-hour="105_24">
                                                <td>PM<sub>2.5</sub></td>
                                                <td>24小时</td>
                                                <td><span id="spConcPM2Dot5H24">34</span></td>
                                            </tr>
                                            <tr data-index-type="O3H1" item-code-type-hour="108_1">
                                                <td>O<sub>3</sub></td>
                                                <td>1小时</td>
                                                <td><span id="spConcO3H1">95</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="O3H8" item-code-type-hour="108_8">
                                                <td>O<sub>3</sub></td>
                                                <td>8小时</td>
                                                <td><span id="spConcO3H8">146</span></td>
                                            </tr>
                                            <tr data-index-type="COH1" item-code-type-hour="106_1">
                                                <td>CO</td>
                                                <td>1小时</td>
                                                <td><span id="spConcCOH1">0.7</span></td>
                                            </tr>
                                            <tr data-index-type="PM10H1" item-code-type-hour="107_1">
                                                <td>PM<sub>10</sub></td>
                                                <td>1小时</td>
                                                <td><span id="spConcPM10H1">63</span></td>
                                            </tr>
                                            <tr style="display: none;" data-index-type="PM10H24" item-code-type-hour="107_24">
                                                <td>PM<sub>10</sub></td>
                                                <td>24小时</td>
                                                <td><span id="spConcPM10H24">47</span></td>
                                            </tr>
                                            <tr data-index-type="SO2H1" item-code-type-hour="101_1">
                                                <td>SO<sub>2</sub></td>
                                                <td>1小时</td>
                                                <td><span id="spConcSO2H1">9</span></td>
                                            </tr>
                                            <tr data-index-type="NO2H1" item-code-type-hour="141_1">
                                                <td class="last-tr-td">NO<sub>2</sub></td>
                                                <td class="last-tr-td">1小时</td>
                                                <td class="last-tr-td"><span id="spConcNO2H1">25</span></td>
                                            </tr>
                                        </table>

                                    </div>
                                </td>
                                <td>
                                    <div class="div-trend-right">
                                        <table cellpadding="0" cellspacing="0">

                                            <tr>
                                                <td colspan="2">
                                                    <div id="chartConc" class="div-chart"></div>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="CityTrend" class="div-content">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <ul class="ul-city-option">
                                        <li id="curTimeCityAQI" class="ul-city-area-checked">AQI实报</li>
                                        <li id="yesterdayCityAQI" class="ul-city-area-unchecked">AQI日报</li>
                                        <li id="ascCityAQI" class="ul-city-area-checked">升序</li>
                                        <li id="descCityAQI" class="ul-city-area-unchecked">降序</li>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                        <div id="chartCityAQI" style="width: 900px; height: 290px; margin: 5px auto;"></div>
                    </div>
                    <div id="AirForecast" class="div-content">
                        <div class="primary">
                            <div class="primary">
                                <div class="box">
                                    <div class="box-outer">
                                        <div class="box-inner">
                                            <h2>空气质量预报</h2>
                                            <table id="ForecastTbl" class="tbl-data" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="width: 25%">时段</td>
                                                    <td style="width: 30%">空气质量</td>
                                                    <td style="width: 25%">首要污染物</td>
                                                    <td style="border-right: 0px;">AQI</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="ForecastDesc" class="secondary">
                                <div class="box">
                                    <div class="box-outer">
                                        <div class="box-inner">
                                            <h2>预报说明</h2>
                                            <p></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="ForecastTrend" class="secondary">
                            <div class="box">
                                <div class="box-outer">
                                    <div class="box-inner">
                                        <h2>图例</h2>
                                        <div id="chartForecast">
                                        </div>
                                        <table id="plotbands" style="width: 215px; height: 10px; left: 50px; margin-top: -10px; /*margin-left: 60px; margin-right: 10px; */ position: relative">
                                        </table>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="divCityMore" style="background-color: #3289BD; width: 80px; height: 17px; display: none; position: absolute;">
                        <a href="#" target="_blank">点击查看详情</a>
                    </div>
                </div>

                <script src="/Scripts/FusionCharts.js" type="text/javascript"></script>

                <script src="/Scripts/highcharts.js" type="text/javascript"></script>
                <script src="/Scripts/highcharts-more.js" type="text/javascript"></script>
                <script src="/Scripts/JScriptExpand.js" type="text/javascript"></script>
                <script src="/Scripts/Home/Common.js" type="text/javascript"></script>
                <script src="/Scripts/Home/AirIndex.js" type="text/javascript" charset="UTF-8"></script>
                <script src="/Scripts/Home/AirProvinceIndex.js" type="text/javascript"></script>
                <script type="text/javascript">
                    var pubType = 'province',
                        firstCityCode = '430100',
                        firstCityName = '长沙市',
                        curCityCode = firstCityCode,
                        curCityNameForAQITrend = firstCityName,
                        curCityNameForConcTrend = firstCityName,
                        curPointCode = '',
                        curPointName = '',
                        firstAQIVal = '57',
                        curDate = '2016/7/7',
                        FDate = '2016年7月8日';
                    checkAirForecast();
                    getCitySortTabel(getComparefn());
                </script>

                        <div id="Loading" style="width: 24px; height: 24px; position: relative; left: 590px; top: -166px; z-index: 2; display: none;">
                            <img src="/Images/loading.gif" alt="loading" />
                        </div>
                        <div id="Loading2" style="width: 24px; height: 24px; position: relative; left: 465px; top: -165px; z-index: 2; display: none;">
                            <img src="/Images/loading.gif" alt="loading" />
                        </div>
                    </div>
                    <div id="footer" class="footer">
                        <table>
                            <tr>
                                <td align="right">主管部门：湖南省环境保护厅
                                </td>
                                <td align="left">&nbsp;发布单位：湖南省环境监测中心站
                                </td>
                                <td align="left">技术支持单位：上海丽正软件技术有限公司
                                </td>
                                <td style="width:auto;">注意：建议使用IE8、9、10浏览器访问该网站</td>

                            </tr>

                        </table>
                    </div>
                </div>
                <div id="dvSelectSkins" class="skin" style="position: absolute; z-index: 3; width: 380px; height: 180px; display: none; background-image: url(/Images/bgSkin.png)">
                    <center>
                        <div id="dvSkinList" style="overflow: scroll; overflow-x: hidden; margin-top: 8px; height: 168px; width: 347px;">
                        </div>
                    </center>
                </div>
                <div id="dialogRefresh" title="自动刷新">
                    <div>
                        <label>
                            <input id="isRef" type="checkbox" />自动刷新</label>
                    </div>
                    <div>
                        <label for="interval">请输入自动刷新时间间隔，单位：分钟</label>
                        <input id="interval" type="text" />
                    </div>
                </div>
                <div id="overlay" class="overlay"></div>
            </body>
            </html>
