# 说明

数据方式: WebApi

数据接口: http://111.11.241.103:9001/ashx/

> 由于接口单一，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                    | 解释                   | 数据类型 | 请求方式
| ----------------------- |:---------------------- |:--------:|:--------:|
| CityShow                | 城市列表               | JSON     | GET
| GetCityInfo             | 城市1小时AQI等级       | JSON	  | GET
| GetCityItemRTData       | 城市1小时AQI           | JSON     | POST(可用GET替换)
| CitySinSite             | 城市24小时AQI历史      | JSON	  | GET
| SiteShow                | 城市站点列表(1小时AQI) | JSON	  | GET
| GetCityRTData           | 城市站点1小时浓度      | JSON	  | GET
| GetItemRTData           | 站点1小时AQI           | JSON     | POST(可用GET替换)
| SinSite                 | 站点24小时AQI历史      | JSON     | GET
|
| GetCityRTData_24        | 城市站点24小时浓度     | JSON     | GET


# 泛型接口（逻辑增加）
  + 接口相同，参数不同模型不同
    - GetCityRTData 参数type为0时，更新间隔1小时
    - GetCityRTData_24 参数type为1时，更新间隔24小时

# 无用接口
  + CitySinSite 接口中的参数type为0时，将返回二级标准限值，无用
