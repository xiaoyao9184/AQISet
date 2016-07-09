FORMAT: 1A
HOST: http://111.40.0.99:8081/




# 黑龙江省城市空气质量实时发布平台

文档日期 2016-07-08
系统地址 http://111.40.0.99:8081/。




# findbystationcode [GET /hljkq/findbystationcode{?gas,stationCode,time}]
城市或站点1小时浓度

+ Parameters

    + gas: SO2 (enum[string], required) - 污染物
      + Members
        + SO2
        + NO2
        + CO
        + O3
        + PM10
        + PM2.5
    + stationCode: 230100 (string, required) - 城市代码/站点代码
    + time: 1467957556695 (string, required) - 时间

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            "<set hoverText='时间：07-07 13:00&#xA;浓度：6(µg/m³)' label='13:00' value='6' /><set hoverText='时间：07-07 14:00&#xA;浓度：7(µg/m³)' label='' value='7' /><set hoverText='时间：07-07 15:00&#xA;浓度：7(µg/m³)' label='15:00' value='7' /><set hoverText='时间：07-07 16:00&#xA;浓度：7(µg/m³)' label='' value='7' /><set hoverText='时间：07-07 17:00&#xA;浓度：7(µg/m³)' label='17:00' value='7' /><set hoverText='时间：07-07 18:00&#xA;浓度：6(µg/m³)' label='' value='6' /><set hoverText='时间：07-07 19:00&#xA;浓度：6(µg/m³)' label='19:00' value='6' /><set hoverText='时间：07-07 20:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-07 21:00&#xA;浓度：4(µg/m³)' label='21:00' value='4' /><set hoverText='时间：07-07 22:00&#xA;浓度：4(µg/m³)' label='' value='4' /><set hoverText='时间：07-07 23:00&#xA;浓度：4(µg/m³)' label='23:00' value='4' /><set hoverText='时间：07-08 00:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 01:00&#xA;浓度：4(µg/m³)' label='01:00' value='4' /><set hoverText='时间：07-08 02:00&#xA;浓度：4(µg/m³)' label='' value='4' /><set hoverText='时间：07-08 03:00&#xA;浓度：4(µg/m³)' label='03:00' value='4' /><set hoverText='时间：07-08 04:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 05:00&#xA;浓度：5(µg/m³)' label='05:00' value='5' /><set hoverText='时间：07-08 06:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 07:00&#xA;浓度：5(µg/m³)' label='07:00' value='5' /><set hoverText='时间：07-08 08:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 09:00&#xA;浓度：5(µg/m³)' label='09:00' value='5' /><set hoverText='时间：07-08 10:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 11:00&#xA;浓度：5(µg/m³)' label='11:00' value='5' /><set hoverText='时间：07-08 12:00&#xA;浓度：5(µg/m³)' label='' value='5' /><set hoverText='时间：07-08 13:00&#xA;浓度：5(µg/m³)' label='13:00' value='5' /><trendLines>  <line  thickness='2' startValue='500' color='25A0DA' displayvalue=' ' /></trendLines>"



# findfzsbystationcode [GET /hljkq/findfzsbystationcode{?cityName}]
城市或站点1小时AQI

+ Parameters

    + gas: SO2 (enum[string], required) - 污染物
      + Members
        + SO2
        + NO2
        + CO
        + O3
        + PM10
        + PM2.5
    + stationCode: 230100 (string, required) - 城市代码/站点代码
    + time: 1467957556695 (string, required) - 时间

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Body

            "<set hoverText='时间：07-07 13:00&#xA;指数：2' label='13:00' value='2' /><set hoverText='时间：07-07 14:00&#xA;指数：3' label='' value='3' /><set hoverText='时间：07-07 15:00&#xA;指数：3' label='15:00' value='3' /><set hoverText='时间：07-07 16:00&#xA;指数：3' label='' value='3' /><set hoverText='时间：07-07 17:00&#xA;指数：3' label='17:00' value='3' /><set hoverText='时间：07-07 18:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-07 19:00&#xA;指数：2' label='19:00' value='2' /><set hoverText='时间：07-07 20:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-07 21:00&#xA;指数：2' label='21:00' value='2' /><set hoverText='时间：07-07 22:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-07 23:00&#xA;指数：2' label='23:00' value='2' /><set hoverText='时间：07-08 00:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 01:00&#xA;指数：2' label='01:00' value='2' /><set hoverText='时间：07-08 02:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 03:00&#xA;指数：2' label='03:00' value='2' /><set hoverText='时间：07-08 04:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 05:00&#xA;指数：2' label='05:00' value='2' /><set hoverText='时间：07-08 06:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 07:00&#xA;指数：2' label='07:00' value='2' /><set hoverText='时间：07-08 08:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 09:00&#xA;指数：2' label='09:00' value='2' /><set hoverText='时间：07-08 10:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 11:00&#xA;指数：2' label='11:00' value='2' /><set hoverText='时间：07-08 12:00&#xA;指数：2' label='' value='2' /><set hoverText='时间：07-08 13:00&#xA;指数：2' label='13:00' value='2' /><trendLines>  <line  thickness='2' startValue='100' color='25A0DA' displayvalue=' ' /></trendLines>"



# aqiReport [GET /aqiReport{?_,cityName}]
城市站点24小时AQI

+ Parameters

    + _: 1467966655844 (number, required) - 时间
    + cityName: 哈尔滨 (enum[string], required) - 城市
      + Members
        + 哈尔滨
        + 齐齐哈尔
        + 鸡西
        + 鹤岗
        + 双鸭山
        + 大庆
        + 伊春
        + 佳木斯
        + 七台河
        + 牡丹江
        + 黑河
        + 绥化
        + 大兴安岭

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body

            <div class="information" id="aqiReport" style="top: 120px;">
              <a class="label" onclick="showTag('aqiReport');">AQI日报</a>
              <div class="info_content">
                <!-- 前一天点击城市的时候显示此城市下的所有监测点的信息 -->
                <div id="aqiReportTable" style="border: 1px solid white;">

            <table id="element" class="data_grid">
            <thead>
            <tr>
            <th>监测点名称</th>
            <th>AQI指数</th>
            <th>首要污染物</th>
            <th>空气质量等级</th>
            <th>日期</th></tr></thead>
            <tbody>
            <tr class="odd">
            <td>岭北</td>
            <td>54</td>
            <td>PM<img src="/app/hljkq/images/sub10.png" style="margin-bottom:-2px;"/></td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>松北商大</td>
            <td>41</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>优</td>
            <td>2016-07-07</td></tr>
            <tr class="odd">
            <td>阿城会宁</td>
            <td>56</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>南岗学府路</td>
            <td>0</td>
            <td>SO<img src="/app/hljkq/images/sub2.png" style="margin-bottom:-2px;"/>,NO<img src="/app/hljkq/images/sub2.png" style="margin-bottom:-2px;"/>,CO,O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>,O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时),PM<img src="/app/hljkq/images/sub2_5.png" style="margin-bottom:-2px;"/>,PM<img src="/app/hljkq/images/sub10.png" style="margin-bottom:-2px;"/></td>
            <td>—</td>
            <td>2016-07-07</td></tr>
            <tr class="odd">
            <td>太平宏伟公园</td>
            <td>74</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>道外承德广场</td>
            <td>55</td>
            <td>PM<img src="/app/hljkq/images/sub10.png" style="margin-bottom:-2px;"/></td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="odd">
            <td>香坊红旗大街</td>
            <td>62</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>动力和平路</td>
            <td>202</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>重度污染</td>
            <td>2016-07-07</td></tr>
            <tr class="odd">
            <td>道里建国路</td>
            <td>54</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>平房东轻厂</td>
            <td>65</td>
            <td>O<img src="/app/hljkq/images/sub3.png" style="margin-bottom:-2px;"/>(8小时)</td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="odd">
            <td>呼兰师专</td>
            <td>63</td>
            <td>PM<img src="/app/hljkq/images/sub2_5.png" style="margin-bottom:-2px;"/></td>
            <td>良</td>
            <td>2016-07-07</td></tr>
            <tr class="even">
            <td>省农科院</td>
            <td>49</td>
            <td>CO</td>
            <td>优</td>
            <td>2016-07-07</td></tr></tbody></table><div class="pageupdown" baseurl="?cityName=%E5%93%88%E5%B0%94%E6%BB%A8&amp;d-1332698-p=1"><span class="l leftc1">共找到12条记录</span></div>
                </div>
                <div id="allCityDayAQI">
                  <c:if test="false">
                    <c:forEach items="" var="cityDayAQI">

                      <div class="hidden" id="cityDayReport_" style="font-size: 14px;font-family: 'Microsoft Yahei','微软雅黑','幼圆'; line-height: 30px; overflow: hidden;">
                       <span style="padding:0px 10px; float: left;"></span><span style="padding:0px 15px; float: left;"><fmt:formatDate pattern="yyyy-MM-dd" value=""/></span>

                       <span style="padding:0px 15px; float: left;">AQI: </span>
                       <span style="padding:0px 15px; float: left;">首要污染物: </span>
                       <span style="padding-left:15px; float: left;">空气质量: </span>
                       <div class="middle_square  cl_0" style="float: left; margin-top: 8px;"></div>
                       <span style="padding:0px 15px; float: left;"></span>
                      </div>

                      </c:forEach>
                  </c:if>
                </div>
              </div>
            </div>
