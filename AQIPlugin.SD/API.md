FORMAT: 1A
HOST: http://58.56.98.78:8801/




# 山东省城市环境空气质量信息发布

文档日期 2016-07-09
系统地址 http://58.56.98.78:8801/airdeploy.web。


# AirQuality [/AirDeploy.web/Ajax/AirQuality/AirQuality.ashx{?method,strCode,type,StationID}]

## GetOther [GET]
？？

+ Request GetOther

    + Parameters

      + method (enum[string], required) - 方法
        + Members
          + GetPageIsFirstLoad
          + GetShowNotice

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body


+ Request GetCityList

    + Parameters

      + method (enum[string], required) - 方法
        + Members
          + GetCityList

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body

            <ul>
               <li><a id="all" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'','');">全省</a></li>
               <li><a id="li_370100" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'济南','370100');">济南</a></li>
               <li><a id="li_370200" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'青岛','370200');">青岛</a></li>
               <li><a id="li_370300" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'淄博','370300');">淄博</a></li>
               <li><a id="li_370400" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'枣庄','370400');">枣庄</a></li>
               <li><a id="li_370500" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'东营','370500');">东营</a></li>
               <li><a id="li_370600" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'烟台','370600');">烟台</a></li>
               <li><a id="li_370700" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'潍坊','370700');">潍坊</a></li>
               <li><a id="li_370800" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'济宁','370800');">济宁</a></li>
               <li><a id="li_370900" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'泰安','370900');">泰安</a></li>
               <li><a id="li_371000" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'威海','371000');">威海</a></li>
               <li><a id="li_371100" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'日照','371100');">日照</a></li>
               <li><a id="li_371200" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'莱芜','371200');">莱芜</a></li>
               <li><a id="li_371300" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'临沂','371300');">临沂</a></li>
               <li><a id="li_371400" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'德州','371400');">德州</a></li>
               <li><a id="li_371500" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'聊城','371500');">聊城</a></li>
               <li><a id="li_371600" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'滨州','371600');">滨州</a></li>
               <li><a id="li_371700" href="javascript:void(0);" onclick="OnClickCityHandler(this.id,'菏泽','371700');">菏泽</a></li>
              </ul>


+ Request GetCityAvg

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetCityAvg
        + strCode (number, required) - 城市代码

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body


+ Request GetStationMarkOnMap

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetStationMarkOnMap

    + Headers

            Accept: */*

+ Response 200 (text/html)

    + Body





## AirQuality_POST [POST]


+ Request GetCityAQI

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetCityAQI

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            [
                {
                    "CityCode": "370500",
                    "CityName": "东营",
                    "CityAQI": "69",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "371200",
                    "CityName": "莱芜",
                    "CityAQI": "58",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "371400",
                    "CityName": "德州",
                    "CityAQI": "63",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370400",
                    "CityName": "枣庄",
                    "CityAQI": "43",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "371500",
                    "CityName": "聊城",
                    "CityAQI": "55",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "371600",
                    "CityName": "滨州",
                    "CityAQI": "79",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370300",
                    "CityName": "淄博",
                    "CityAQI": "61",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370600",
                    "CityName": "烟台",
                    "CityAQI": "42",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "371100",
                    "CityName": "日照",
                    "CityAQI": "25",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "370200",
                    "CityName": "青岛",
                    "CityAQI": "27",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "370700",
                    "CityName": "潍坊",
                    "CityAQI": "53",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370800",
                    "CityName": "济宁",
                    "CityAQI": "51",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "371300",
                    "CityName": "临沂",
                    "CityAQI": "45",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "371000",
                    "CityName": "威海",
                    "CityAQI": "33",
                    "CityAQILever": "Ⅰ"
                },
                {
                    "CityCode": "371700",
                    "CityName": "菏泽",
                    "CityAQI": "92",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370100",
                    "CityName": "济南",
                    "CityAQI": "71",
                    "CityAQILever": "Ⅱ"
                },
                {
                    "CityCode": "370900",
                    "CityName": "泰安",
                    "CityAQI": "63",
                    "CityAQILever": "Ⅱ"
                }
            ]


+ Request GetAllSubStation

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetAllSubStation

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <table border="0" cellspacing="0" cellpadding="0" id="senfe">
             <thead>
              <tr style="width:40%;">
               <td>区县</td>
               <td style="width:60%;">监测点位</td>
              </tr>
             </thead>
             <tbody>
              <tr onclick="ShowHighlightSymbolById(3573);">
               <td>济南</td>
               <td><a href="javascript:void(0);">泉城广场</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(7);">
               <td>济南</td>
               <td><a href="javascript:void(0);"> 机床二厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(5);">
               <td>济南</td>
               <td><a href="javascript:void(0);">开发区 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3570);">
               <td>济南</td>
               <td><a href="javascript:void(0);">高新学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3569);">
               <td>济南</td>
               <td><a href="javascript:void(0);">山东经济学院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(2);">
               <td>济南</td>
               <td><a href="javascript:void(0);">市监测站 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4);">
               <td>济南</td>
               <td><a href="javascript:void(0);">科干所</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3832);">
               <td>济南</td>
               <td><a href="javascript:void(0);">山东鲁能</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(6);">
               <td>济南</td>
               <td><a href="javascript:void(0);">农科所</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(10470);">
               <td>济南</td>
               <td><a href="javascript:void(0);">化工厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3566);">
               <td>济南</td>
               <td><a href="javascript:void(0);">兰翔技校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3572);">
               <td>济南</td>
               <td><a href="javascript:void(0);">宝胜电缆</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(10890);">
               <td>济南</td>
               <td><a href="javascript:void(0);">跑马岭</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3571);">
               <td>济南</td>
               <td><a href="javascript:void(0);">山东建筑大学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3);">
               <td>济南</td>
               <td><a href="javascript:void(0);">省种子仓库</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12133);">
               <td>济南</td>
               <td><a href="javascript:void(0);">长清大学城(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(2987);">
               <td>济南</td>
               <td><a href="javascript:void(0);">长清区委党校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12081);">
               <td>济南</td>
               <td><a href="javascript:void(0);">商职学院(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(11);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">市南区东部子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(10);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">市北区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3867);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">李沧区南部</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3861);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">市南区西部子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(13);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">四方区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12134);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">黄岛区4号(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3871);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">黄岛区北部</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(15);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">黄岛区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3869);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">仰口</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3870);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">崂山区中部</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(14);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">崂山区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12082);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">李沧区3号(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(9);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">李沧区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3868);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">城阳区南部</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(16);">
               <td>青岛</td>
               <td><a href="javascript:void(0);">城阳区子站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3896);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">南定</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(17);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">人民公园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3894);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">新区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3897);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">凤凰山</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(20);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">淄川气象站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(18);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">东风化工厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(19);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">博山双山</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3898);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">青龙山</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(21);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">临淄莆田园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3899);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">齐鲁石化</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3895);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">职业学院 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(22);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">周村三金集团</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3893);">
               <td>淄博</td>
               <td><a href="javascript:void(0);">开发区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(23);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">市中区政府</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3919);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">污水处理厂 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3917);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">市环保局 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(27);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">薛城区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(24);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">峄城区政府</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(26);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">台儿庄环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(25);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">山亭区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3918);">
               <td>枣庄</td>
               <td><a href="javascript:void(0);">高新区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(30);">
               <td>东营</td>
               <td><a href="javascript:void(0);">市环保局 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3954);">
               <td>东营</td>
               <td><a href="javascript:void(0);">职业学院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3949);">
               <td>东营</td>
               <td><a href="javascript:void(0);">市环保公司</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3951);">
               <td>东营</td>
               <td><a href="javascript:void(0);">广南水库</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3955);">
               <td>东营</td>
               <td><a href="javascript:void(0);">现河采油厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(2080);">
               <td>东营</td>
               <td><a href="javascript:void(0);">耿井村</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3953);">
               <td>东营</td>
               <td><a href="javascript:void(0);">胜利医院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3950);">
               <td>东营</td>
               <td><a href="javascript:void(0);">河口区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3952);">
               <td>东营</td>
               <td><a href="javascript:void(0);">开发区 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3983);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">鲁东大学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(32);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">西郊化工站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(31);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">轴承厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12083);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">金沟寨(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(35);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">福山区监测站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(36);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">牟平区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(34);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">莱山区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3984);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">莱山盛泉工业园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3987);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">大季家</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3986);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">开发区B 区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3982);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">开发区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3985);">
               <td>烟台</td>
               <td><a href="javascript:void(0);">中国农业大学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4491);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">商校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(39);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">市环保局 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(40);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">市仲裁委</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4488);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">经济开发区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(41);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">刘家园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(37);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">寒亭区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4495);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">共达公司</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4489);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">鑫汇集团</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4490);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">锦程中学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12084);">
               <td>潍坊</td>
               <td><a href="javascript:void(0);">潍坊学院(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(42);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">市监测站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(44);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">电化厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(43);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">开发区火炬城</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4043);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">农业学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4040);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">任城开发区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4041);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">圣地度假村</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4039);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">污水处理厂 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12085);">
               <td>济宁</td>
               <td><a href="javascript:void(0);">兖州教体局(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4100);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">厚丰公司</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4097);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">人口学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(46);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">泰山监测站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4103);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">交通技校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4101);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">农大新校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(47);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">山东电力学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4102);">
               <td>泰安</td>
               <td><a href="javascript:void(0);">信通科技</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(48);">
               <td>威海</td>
               <td><a href="javascript:void(0);">市环境监测站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(49);">
               <td>威海</td>
               <td><a href="javascript:void(0);">高区交行</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4230);">
               <td>威海</td>
               <td><a href="javascript:void(0);">蓝天宾馆</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(50);">
               <td>威海</td>
               <td><a href="javascript:void(0);">木工机械厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4231);">
               <td>威海</td>
               <td><a href="javascript:void(0);">张村政府</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4232);">
               <td>威海</td>
               <td><a href="javascript:void(0);">华夏技校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12135);">
               <td>威海</td>
               <td><a href="javascript:void(0);">文登园林局(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(52);">
               <td>日照</td>
               <td><a href="javascript:void(0);">港务局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(53);">
               <td>日照</td>
               <td><a href="javascript:void(0);">市监测站 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4163);">
               <td>日照</td>
               <td><a href="javascript:void(0);">职业技术学院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4162);">
               <td>日照</td>
               <td><a href="javascript:void(0);">教授花园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(51);">
               <td>日照</td>
               <td><a href="javascript:void(0);">市政府广场</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4160);">
               <td>日照</td>
               <td><a href="javascript:void(0);">岚山环保分局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4161);">
               <td>日照</td>
               <td><a href="javascript:void(0);">金马工业园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(56);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">市环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4369);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">钢城区环保局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4367);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">老年公寓</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4368);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">新一中学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(54);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">植物油厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(55);">
               <td>莱芜</td>
               <td><a href="javascript:void(0);">日晟国际学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(59);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">沂河小区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(57);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">新光毛纺厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(72);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">河东保险公司</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4308);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">临沂大学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(58);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">鲁南制药厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4314);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">市环保局(南坊)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4313);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">洪福酒业</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4312);">
               <td>临沂</td>
               <td><a href="javascript:void(0);">江华汽贸</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(62);">
               <td>德州</td>
               <td><a href="javascript:void(0);">儿童乐园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(63);">
               <td>德州</td>
               <td><a href="javascript:void(0);">监测站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(61);">
               <td>德州</td>
               <td><a href="javascript:void(0);">黑马集团</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4221);">
               <td>德州</td>
               <td><a href="javascript:void(0);">华宇技校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4217);">
               <td>德州</td>
               <td><a href="javascript:void(0);">监理站</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4222);">
               <td>德州</td>
               <td><a href="javascript:void(0);">双一集团</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12137);">
               <td>德州</td>
               <td><a href="javascript:void(0);">陵城艺术中心(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(64);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">东昌区政府</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(66);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">市委党校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(65);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">二轻机械厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4277);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">海关</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4278);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">洪顺花园</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4281);">
               <td>聊城</td>
               <td><a href="javascript:void(0);">开发区 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(68);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">北中新校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(67);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">市环保局 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4582);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">碧林小区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4579);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">第二水厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4580);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">科灵化工</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4581);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">银河物流</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12138);">
               <td>滨州</td>
               <td><a href="javascript:void(0);">沾化体育中心(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4341);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">菏泽学院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4338);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">市政协</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4339);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">牡丹高新区</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(70);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">气象局</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4340);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">华润制药</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4337);">
               <td>菏泽</td>
               <td><a href="javascript:void(0);">污水处理厂 </a></td>
              </tr>
             </tbody>
            </table>


+ Request GetStationByStrCode

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetStationByStrCode
        + strCode: 370100 (number, required) - 城市代码
        + type: AirQuality

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <table border="0" cellspacing="0" cellpadding="0" id="senfe">
             <thead>
              <tr>
               <td style="width:40%;">区县</td>
               <td style="width:60%;">监测点位</td>
              </tr>
             </thead>
             <tbody>
              <tr onclick="ShowHighlightSymbolById(3573);">
               <td>历下区</td>
               <td><a href="javascript:void(0);">泉城广场</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(7);">
               <td>槐荫区</td>
               <td><a href="javascript:void(0);"> 机床二厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(5);">
               <td>高新区</td>
               <td><a href="javascript:void(0);">开发区 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3570);">
               <td>历下区</td>
               <td><a href="javascript:void(0);">高新学校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3569);">
               <td>历下区</td>
               <td><a href="javascript:void(0);">山东经济学院</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(2);">
               <td>历下区</td>
               <td><a href="javascript:void(0);">市监测站 </a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(4);">
               <td>市中区</td>
               <td><a href="javascript:void(0);">科干所</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3832);">
               <td>市中区</td>
               <td><a href="javascript:void(0);">山东鲁能</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(6);">
               <td>槐荫区</td>
               <td><a href="javascript:void(0);">农科所</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(10470);">
               <td>天桥区</td>
               <td><a href="javascript:void(0);">化工厂</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3566);">
               <td>天桥区</td>
               <td><a href="javascript:void(0);">兰翔技校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3572);">
               <td>历城区</td>
               <td><a href="javascript:void(0);">宝胜电缆</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(10890);">
               <td>历城区</td>
               <td><a href="javascript:void(0);">跑马岭</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3571);">
               <td>历城区</td>
               <td><a href="javascript:void(0);">山东建筑大学</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(3);">
               <td>历城区</td>
               <td><a href="javascript:void(0);">省种子仓库</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12133);">
               <td>长清区</td>
               <td><a href="javascript:void(0);">长清大学城(新增点位,试运行)</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(2987);">
               <td>长清区</td>
               <td><a href="javascript:void(0);">长清区委党校</a></td>
              </tr>
              <tr onclick="ShowHighlightSymbolById(12081);">
               <td>高新区</td>
               <td><a href="javascript:void(0);">商职学院(新增点位,试运行)</a></td>
              </tr>
             </tbody>
            </table>


+ Request GetStationList

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetStationList

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body


+ Request GetQualityItemsValues

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetQualityItemsValues
        + StationID (number, required) - 站点ID

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                "CityName": "省种子仓库",
                "Pname": null,
                "PM10": " 0.163",
                "PM10S": "0.150",
                "PM10_Error": null,
                "PM25": " 0.067",
                "PM25S": "0.075",
                "PM25_Error": null,
                "O3S": "0.200",
                "O3": " 0.072",
                "O3_Error": null,
                "NO2": " 0.046",
                "NO2S": "0.200",
                "NO2_Error": null,
                "SO2": " 0.024",
                "SO2S": "0.500",
                "SO2_Error": null,
                "CO": " 1.354",
                "COS": "10.000",
                "CO_Error": null,
                "AQI": "107",
                "AQI_Error": null,
                "POL": " PM10",
                "Level": "Ⅲ",
                "Quality": "轻度污染",
                "DT": "9日13时",
                "VisibleValue": null,
                "VisibleValue_Error": null,
                "VisibleImage": null,
                "VisibleImage_Error": null
            }


+ Request GetNjdValue

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetQualityItemsValues
        + StationID (number, required) - 站点ID

    + Headers

            Accept: */*

+ Response 200 (text/json)

    + Body

            {
                "CityName": null,
                "Pname": "泉城广场",
                "PM10": null,
                "PM10S": null,
                "PM10_Error": null,
                "PM25": null,
                "PM25S": null,
                "PM25_Error": null,
                "O3S": null,
                "O3": null,
                "O3_Error": null,
                "NO2": null,
                "NO2S": null,
                "NO2_Error": null,
                "SO2": null,
                "SO2S": null,
                "SO2_Error": null,
                "CO": null,
                "COS": null,
                "CO_Error": null,
                "AQI": null,
                "AQI_Error": null,
                "POL": null,
                "Level": null,
                "Quality": null,
                "DT": "9日13时",
                "VisibleValue": "   13.7",
                "VisibleValue_Error": null,
                "VisibleImage": "002_20160709000050000.jpg",
                "VisibleImage_Error": null
            }


+ Request GetVisilbeRank

    + Parameters

        + method (enum[string], required) - 方法
          + Members
            + GetVisilbeRank

    + Headers

            Accept: */*

+ Response 200 (text/plain)

    + Body

            '370600','371000','370700','370500','371600','371200','370900','370300','370400','371300','370800','371100','370100','370200','371500','371700','371400'$$
            <table border="0" cellspacing="0" cellpadding="0" id="senfe">
             <thead>
              <tr>
               <td style="width:20%;">城市</td>
               <td style="width:30%;">能见度(km)</td>
               <td style="width:50%;">&quot;蓝天白云、繁星闪烁&quot;状况</td>
              </tr>
             </thead>
             <tbody>
              <tr onclick=" ">
               <td>烟台</td>
               <td>46.30</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>威海</td>
               <td>39.40</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>潍坊</td>
               <td>38.10</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>东营</td>
               <td>31.90</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>滨州</td>
               <td>21</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>莱芜</td>
               <td>19</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>泰安</td>
               <td>16.10</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>淄博</td>
               <td>16.10</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>枣庄</td>
               <td>15.70</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>临沂</td>
               <td>15.70</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>济宁</td>
               <td>15</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>日照</td>
               <td>14</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>济南</td>
               <td>11.80</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>青岛</td>
               <td>10.10</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>聊城</td>
               <td>10.10</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>菏泽</td>
               <td>8.40</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
              <tr onclick=" ">
               <td>德州</td>
               <td>7.20</td>
               <td><img src="images/Njd/yes.png" /></td>
              </tr>
             </tbody>
            </table>$2016-07-08




# Images [GET /Images]
AQI站点浓度照片

+ Request 图片

    + Headers

            Accept: */*

+ Response 200

    + Body
