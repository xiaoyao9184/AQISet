# 说明

数据方式: WebApi

数据接口: http://typhoon.zjwater.gov.cn/Api/

> 按请求方式方法不同划分不同的虚拟接口


# 接口列表

| 名称                    | 解释                   | 数据类型 | 请求方式
| ----------------------- |:---------------------- |:--------:|:--------:|
| LeastCloud              | 云图                   | JSON     | GET
| LeastRain               | 雨图                   | JSON     | GET
| TyhoonActivity          | 当前台风列表           | JSON     | GET
| TyphoonInfo             | 台风详情               | JSON     | GET
| TyphoonList             | 台风历史列表           | JSON     | GET



# 自动化接口
  + 由于TyphoonList可以查询历史数据，TyphoonList接口也会不断添加新的数据；
    故增加自动化接口用于排除不变化的历史，更新间隔变为每小时，历史数据仅会获取一次，今年的数据会不断获取
    + TyphoonList_Auto 使用ParamFilterType.OnceAgain方式过滤参数

  + TyphoonInfo会通过JSON参数会获取某些不存在的数据（台风号不存在）；
    TyphoonInfo的参数依赖于TyphoonList或TyhoonActivity中存在的台风号；
    故增加2个自动化接口，获取正确的台风号参数，更新间隔变为每小时

    + TyphoonInfo_FormActivity 参数从TyhoonActivity接口获得
    + TyphoonInfo_FormList     参数从TyphoonList_Auto接口获得