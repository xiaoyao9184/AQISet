# 说明

数据方式: WebApi

数据接口: http://61.166.240.109:6013/

> 由于接口采用 Action 方法的形式，故按请求方法不同划分不同的逻辑接口


# 接口列表

| 名称                    | 解释                    | 数据类型 | 请求方式
| ----------------------- |:----------------------- |:--------:|:--------:|
| citylist                | 城市列表                | JSON     | GET
| queryStationList        | 站点列表                | JSON     | GET
| queryCityNotice         | 城市通知                | JSON     | GET
|
| queryLatestTime         | 24小时数据时间          | JSON     | GET
| queryCityAQIInfo        | 单个城市24小时AQI等级   | JSON     | POST
| queryDailyDataOfCitys   | 城市24小时AQI           | JSON     | GET
| queryAreaDailyData      | 站点24小时AQI           | JSON     | GET
| queryAQIDetail          | 单个站点24小时AQI等级   | JSON     | GET
| queryStationDataList    | 站点24小时AQI           | JSON     | GET
|
| queryLatestTime_2       | 1小时数据时间           | JSON     | GET
| queryCityAQIInfo_2      | 单个城市1小时AQI等级    | JSON     | POST
| queryRealDataOfCitys    | 城市1小时AQI            | JSON     | GET
| queryRealData           | 站点1小时AQI            | JSON     | GET
| queryCTDetail           | 单个站点1小时AQI等级    | JSON     | GET
| queryCTDetail_HISTORY   | 单个站点1小时污染物历史 | JSON     | GET


## 1小时、24小时接口很相似，可以类比

| 24小时                  | 1小时                  | 比较      |
| ----------------------- | ---------------------- |:---------:|
| queryLatestTime         | queryLatestTime_2      | 模型一样
| queryCityAQIInfo        | queryCityAQIInfo_2     | 模型一样
| queryDailyDataOfCitys   | queryRealDataOfCitys   | 模型一样
| queryAreaDailyData      | queryRealData          | 模型基本一样，前者没有污染物参数只能获取AQI；后者有污染物参数可以获取AQI和其他污染物
| queryAQIDetail          | queryCTDetail          | 模型基本一样，前者没有污染物参数只能获取AQI；后者是泛型接口，当参数是污染物时返回污染物历史数据


# 泛型接口（逻辑增加）
  + 接口相同，参数不同模型不同
    - queryCTDetail 使用AQI参数，更新间隔1小时
    - queryCTDetail_HISTORY 使用污染物参数，更新间隔24小时


# 无用接口（默认关闭）
  + queryCityNotice 并没有发现数据返回
  + queryLatestTime 只是获取数据的时间，在其他数据中已经包含了时间
  + queryStationDataList 不如 queryAreaDailyData 数据量多,基本是重复的


# 重复接口（默认关闭）

| 名称                    | 重复项                 | 解释                              |
| ----------------------- |:---------------------- |:---------------------------------:|
| queryCityAQIInfo        | queryDailyDataOfCitys  | 前者信息不全；后者可以批量获取
| queryAQIDetail          | queryAreaDailyData     | 前者信息不全；后者可以批量获取
|                         |                        |
| queryCityAQIInfo_2      | queryRealDataOfCitys   | 前者信息不全；后者可以批量获取
| queryCTDetail           | queryRealData          | 前者的AQI等级信息有等级信息；后者可以批量获取，但是不包含等级提示
