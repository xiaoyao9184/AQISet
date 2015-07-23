#说明

请求数据大部分为GET方式
数据接口地址为http://61.166.240.109:6013/YNAS/index.jsp
由于接口采用Action方法的形式，故按请求方法不同划分不同的虚拟接口


以下为接口列表
名称							解释					数据类型		请求方式
============================================================
citylist						城市列表				JSON			GET
queryStationList				站点列表				JSON			GET
queryCityNotice					城市通知				JSON			GET

queryLatestTime					24小时数据时间			JSON			GET
queryDailyDataOfCitys			城市24小时AQI			JSON			GET
queryCityAQIInfo				单个城市24小时AQI等级	JSON			POST
queryAreaDailyData				站点24小时AQI			JSON			GET
queryAQIDetail					单个站点24小时AQI等级	JSON			GET
queryStationDataList			站点24小时AQI			JSON			GET

queryLatestTime_2				1小时数据时间			JSON			GET
queryRealDataOfCitys			城市1小时AQI			JSON			GET
queryCityAQIInfo_2				单个城市1小时AQI等级	JSON			POST
queryRealData					站点1小时AQI			JSON			GET
queryCTDetail					单个站点1小时AQI等级	JSON			GET
queryCTDetail_HISTORY			单个站点1小时污染物历史	JSON			GET



1小时和24小时可以类比，比较列表如下

1小时							24小时						比较
============================================================
queryLatestTime					queryLatestTime_2			一样
queryDailyDataOfCitys			queryRealDataOfCitys		基本一样
queryCityAQIInfo				queryCityAQIInfo_2			基本一样
queryAreaDailyData				queryRealData				后者增加了污染物数据参数，前者不可获取污染物
queryAQIDetail					queryCTDetail				后者增加了污染物历史数据参数，前者不可获取污染物




有些接口是重复的
queryCTDetail和queryCTDetail_HISTORY接口相同，数据周期不同：每小时、每天




有些数据是无用的
queryLatestTime、queryLatestTime_2这个只是获取数据的时间，在其他数据中已经包含了时间
queryCityNotice并没有发现数据返回
queryStationDataList不如queryAreaDailyData数据量多,基本是重复的




由于某些数据是重复的，故列出

名称							重复项					解释
============================================================
queryCityAQIInfo				queryDailyDataOfCitys	后者可以批量获取，前者信息不全
queryAQIDetail					queryAreaDailyData		后者可以批量获取

queryCityAQIInfo_2				queryRealDataOfCitys	后者可以批量获取
queryCTDetail					queryRealData			后者可以批量获取，但是不包含等级提示