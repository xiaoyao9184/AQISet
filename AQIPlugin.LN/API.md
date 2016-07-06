FORMAT: 1A
HOST: http://typhoon.zjwater.gov.cn/Api/




# 浙江台风路径实时发布系统

文档日期 2016-07-05
系统地址 http://typhoon.zjwater.gov.cn/。




# LeastCloud [GET /LeastCloud]
云图


+ Attributes (object)

    + cloud1h: 201607041930.png (string) - 1小时前图片
    + cloud3h: 201607041700.png (string) - 3小时前图片
    + cloud6h: 201607041400.png (string) - 6小时前图片
    + cloudFullPath: http://taifeng.oss-cn-hangzhou.aliyuncs.com/cloud (string) - 图片服务地址
    + cloudname: 201607042000.png (string) - 30分钟图片
    + cloudtime: 2016/7/4 20:00:00 (string) - 时间
    + maxLat: 50 (number) - 最大经度
    + maxLng: 140 (number) - 最大纬度
    + minLat: 4 (number) - 最小经度
    + minLng: 80 (number) - 最小纬度

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[LeastCloud])

    + Body

            [
              {
                "cloud1h":"201607041930.png",
                "cloud3h":"201607041700.png",
                "cloud6h":"201607041400.png",
                "cloudFullPath":"http://taifeng.oss-cn-hangzhou.aliyuncs.com/cloud",
                "cloudname":"201607042000.png",
                "cloudtime":"2016/7/4 20:00:00",
                "maxLat":"50",
                "maxLng":"140",
                "minLat":"4",
                "minLng":"80"
              }
            ]


+ Request XML格式

    + Headers

            Accept: application/xml

+ Response 200 (text/html)

    + Attributes (array[LeastCloud])

    + Body

            <ArrayOfCloudModel
              xmlns="http://schemas.datacontract.org/2004/07/Typhoon"
              xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <CloudModel>
                <cloud1h>201607041930.png</cloud1h>
                <cloud3h>201607041700.png</cloud3h>
                <cloud6h>201607041400.png</cloud6h>
                <cloudFullPath>http://taifeng.oss-cn-hangzhou.aliyuncs.com/cloud</cloudFullPath>
                <cloudname>201607042000.png</cloudname>
                <cloudtime>2016/7/4 20:00:00</cloudtime>
                <maxLat>50</maxLat>
                <maxLng>140</maxLng>
                <minLat>4</minLat>
                <minLng>80</minLng>
              </CloudModel>
            </ArrayOfCloudModel>




# LeastRain [GET /LeastRain/{hour}]
雨图

+ Parameters

    + hour: 6 (enum[number], required) - 小时
        + Members
            + 6
            + 12
            + 24
            + 48

+ Attributes (object)

    + name: 20160704180000_6.PNG (string) - 图片
    + time: 2016-07-04 18:00:00 (string) - 时间

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[LeastRain])

    + Body

            [
              {
                "name":"20160704180000_6.PNG",
                "time":"2016-07-04 18:00:00"
              }
            ]

+ Request XML格式

    + Headers

            Accept: application/xml

+ Response 200 (text/html)

    + Attributes (array[LeastRain])

    + Body

            <ArrayOfRainImgModel
              xmlns="http://schemas.datacontract.org/2004/07/Typhoon"
              xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <RainImgModel>
              <name>20160704180000_6.PNG</name>
              <time>2016-07-04 18:00:00</time>
              </RainImgModel>
            </ArrayOfRainImgModel>



# TyhoonActivity [GET /TyhoonActivity]
当前台风列表

+ Attributes (object)

    + enname: Nepartak (string) - 英文名称
    + lat: 12.80 (number) - 经度
    + lng: 141.30 (number) - 纬度
    + movedirection: 北西 (string) - 移动方向
    + movespeed: 30 (number) - 移动速度
    + name: 尼伯特 (string) - 名称
    + power: 8 (number) - 级别
    + pressure: 995 (number) - ？
    + radius10: 0 (number) - ？
    + radius7: 300 (number) - ？
    + speed: 20 (number) - 速度
    + strong: 热带风暴 (string) - 强度
    + tfid: 201601 (number) - 编号
    + time: 2016-07-04 14:00:00 (string) - 时间
    + timeformate: 7月4日14时 (string) - 中文时间

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[TyhoonActivity])

    + Body

            [
              {
                "enname":"Nepartak",
                "lat":"12.80",
                "lng":"141.30",
                "movedirection":"北西",
                "movespeed":"30",
                "name":"尼伯特",
                "power":"8",
                "pressure":"995",
                "radius10":"0",
                "radius7":"300",
                "speed":"20",
                "strong":"热带风暴",
                "tfid":"201601",
                "time":"2016-07-04 14:00:00",
                "timeformate":"7月4日14时"
              }
            ]

+ Request XML格式

    + Headers

            Accept: application/xml

+ Response 200 (text/html)

    + Attributes (array[TyhoonActivity])

    + Body

            <ArrayOfTyphoonScrollModel
              xmlns="http://schemas.datacontract.org/2004/07/Typhoon"
              xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <TyphoonScrollModel>
                <enname>Nepartak</enname>
                <lat>13.50</lat>
                <lng>139.50</lng>
                <movedirection>北西</movedirection>
                <movespeed>20</movespeed>
                <name>尼伯特</name>
                <power>9</power>
                <pressure>990</pressure>
                <radius10>0</radius10>
                <radius7>300</radius7>
                <speed>23</speed>
                <strong>热带风暴</strong>
                <tfid>201601</tfid>
                <time>2016-07-04 20:00:00</time>
                <timeformate>7月4日20时</timeformate>
              </TyphoonScrollModel>
            </ArrayOfTyphoonScrollModel>



# TyphoonInfo [GET /TyphoonInfo/{yearmonth}]
台风详情

+ Parameters

    + year: 201601 (number, required) - 年月份

+ Attributes (object)

    + centerlat: 15.800000 (number) - 中心经度
    + centerlng: 143.150000 (number) - 中心纬度
    + endtime: 2016/7/4 14:00:00 (string) - 结束时间
    + enname: Nepartak (string) - 英文名称
    + isactive: 1 (number) - 是否存活(1不存活)
    + land (array) - ？
    + name: 尼伯特 (string) - 名称
    + points (object)
          + forecast (array)
              + (object)
                + forecastpoints (array)
                    + (object)
                      + lat: 8.80 (number) - 经度
                      + lng: 145.00 (number) - 纬度
                      + power: 8 (number) - 强度
                      + pressure: 1000 (number) - ？
                      + speed: 18  (number) - 速度
                      + strong: 热带风暴 (string) - 强度
                      + time: 2016/7/3 8:00:00 (string) - 时间
                + tm: 美国 (string) - 移动方向
          + lat: 12.80 (number) - 经度
          + lng: 141.30 (number) - 纬度
          + movedirection: 北西 (string) - 移动方向
          + movespeed: 30 (number) - 移动速度
          + power: 8 (number) - 是否存活(1不存活)
          + pressure: 995 (number) - ？
          + radius10: 0 (number) - ？
          + radius7: 300 (number) - ？
          + speed: 20 (number) - 速度
          + strong: 热带风暴 (string) - 强度
          + time: 2016/7/4 14:00:00 (string) - 时间
    + starttime: 2016/7/3 8:00:00 (string) - 开始时间
    + tfid: 201601 (number) - 编号
    + warnlevel: white (string) - ?级别

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[TyphoonInfo])

    + Body

            [
              {
                "centerlat":"15.800000",
                "centerlng":"143.150000",
                "endtime":"2016/7/4 14:00:00",
                "enname":"Nepartak",
                "isactive":"1",
                "land":[],
                "name":"尼伯特",
                "points":
                [
                  {
                    "forecast":
                    [
                      {
                        "forecastpoints":
                          [
                            {
                            "lat":"8.80",
                            "lng":"145.00",
                            "power":"8",
                            "pressure":"1000",
                            "speed":"18",
                            "strong":"热带风暴",
                            "time":"2016/7/3 8:00:00"
                            }
                          ],
                        "tm":"美国"
                      }
                    ],
                    "lat":"12.80",
                    "lng":"141.30",
                    "movedirection":"北西",
                    "movespeed":"30",
                    "power":"8",
                    "pressure":"995",
                    "radius10":"0",
                    "radius7":"300",
                    "speed":"20",
                    "strong":"热带风暴",
                    "time":"2016/7/4 14:00:00"
                  }
                ]
                "starttime":"2016/7/3 8:00:00",
                "tfid":"201601",
                "warnlevel":"white"
              }
            ]

+ Request XML格式

    + Headers

            Accept: application/xml

+ Response 200 (text/html)

    + Attributes (array[TyphoonInfo])

    + Body

            <ArrayOfTyphoonModel
              xmlns="http://schemas.datacontract.org/2004/07/Typhoon"
              xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <TyphoonModel>
                <centerlat>16.150000</centerlat>
                <centerlng>142.250000</centerlng>
                <endtime>2016/7/4 20:00:00</endtime>
                <enname>Nepartak</enname>
                <isactive>1</isactive>
                <land/>
                <name>尼伯特</name>
                <points>
                <TyphoonPointModel>
                  <forecast>
                    <ForecastModel>
                      <forecastpoints>
                      <PointModel>
                        <lat>8.80</lat>
                        <lng>145.00</lng>
                        <power>8</power>
                        <pressure>1000</pressure>
                        <speed>18</speed>
                        <strong>热带风暴</strong>
                        <time>2016/7/3 8:00:00</time>
                      </PointModel>
                      </forecastpoints>
                      <tm>中国</tm>
                    </ForecastModel>
                  </forecast>
                  <lat>8.80</lat>
                  <lng>145.00</lng>
                  <movedirection>北西</movedirection>
                  <movespeed>30</movespeed>
                  <power>8</power>
                  <pressure>995</pressure>
                  <radius10>0</radius10>
                  <radius7>300</radius7>
                  <speed>20</speed>
                  <strong>热带风暴</strong>
                  <time>2016/7/4 14:00:00</time>
                </TyphoonPointModel>
                </points>
                <starttime>2016/7/3 8:00:00</starttime>
                <tfid>201601</tfid>
                <warnlevel>white</warnlevel>
              </TyphoonModel>
            </ArrayOfTyphoonModel>


# TyphoonList [GET /TyphoonList/{year}]
台风历史列表

+ Parameters

    + year: 2016 (number, required) - 年份

+ Attributes (object)

    + endtime: 2016/7/4 14:00:00 (string) - 结束时间
    + enname: Nepartak (string) - 英文名称
    + isactive: 1 (number) - 是否存活(1不存活)
    + name: 尼伯特 (string) - 名称
    + starttime: 2016/7/3 8:00:00 (string) - 开始时间
    + tfid: 201601 (number) - 编号
    + warnlevel: white (string) - ？级别

+ Request JSON格式

    + Headers

            Accept: application/javascript

+ Response 200 (application/json)

    + Attributes (array[TyphoonList])

    + Body

            [
              {
                "endtime":"2016/7/4 14:00:00",
                "enname":"Nepartak",
                "isactive":"1",
                "name":"尼伯特",
                "starttime":"2016/7/3 8:00:00",
                "tfid":"201601",
                "warnlevel":""
              }
            ]

+ Request XML格式

    + Headers

            Accept: application/xml

+ Response 200 (text/html)

    + Attributes (array[TyphoonList])

    + Body

            <ArrayOfTyphoonListModel
              xmlns="http://schemas.datacontract.org/2004/07/Typhoon"
              xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
              <TyphoonListModel>
                <endtime>2016/7/4 14:00:00</endtime>
                <enname>Nepartak</enname>
                <isactive>1</isactive>
                <name>尼伯特</name>
                <starttime>2016/7/3 8:00:00</starttime>
                <tfid>201601</tfid>
                <warnlevel/>
              </TyphoonListModel>
            </ArrayOfTyphoonListModel>
