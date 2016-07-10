FORMAT: 1A
HOST: http://aqicn.org/




# aqicn

文档日期 2016-07-09
系统地址 http://aqicn.org/。


# MapStation [GET /mapi/?lurlv2{&z}&(({lonStart},{latStart}),({lonEnd},{latEnd})){bounds}&fst]
地图区域站点集合

+ Parameters

    + z: 10 (number) - 放大级别
    + lonStart (number) - 开始经度
    + latStart (number) - 开始纬度
    + lonEnd (number) - 结束经度
    + latEnd (number) - 结束纬度

+ Request JSON格式

    + Headers

            Accept: */*

+ Response 200 (application/json)

    + Body

            [
                {
                    "lat": "5.6316825",
                    "lon": "100.4696865",
                    "aqi": "80",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Bakar Arang, Sg. Petani, Kedah, Malaysia",
                    "img": "_84208k5NSczQd0rMTixScCxKzEvXUQhO11MISC1JzMsEAA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2368,
                    "x": 2582
                },
                {
                    "lat": "4.6300525",
                    "lon": "101.1158465",
                    "aqi": "39",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Jalan Tasek, Ipoh, Perak, Malaysia",
                    "img": "_8420CkgtSszW90rMScxTCEksTs3WUfAsyM8AAA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2380,
                    "lvl": 2,
                    "x": 2594
                },
                {
                    "lat": "4.8995083",
                    "lon": "100.6823033",
                    "aqi": "69",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Kg. Air Putih, Taiping, Perak, Malaysia",
                    "img": "_8420CkgtSszW907XU3DMLFIIKC3JzNBRCEnMLMjMSwcA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2381,
                    "x": 2595
                },
                {
                    "lat": "4.5533684",
                    "lon": "101.0800309",
                    "aqi": "40",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "S K Jalan Pegoh, Ipoh, Perak, Malaysia",
                    "img": "_8420CkgtSszWD1bwVvBKzEnMUwhITc_P0FHwLMjPAAA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2382,
                    "lvl": 2,
                    "x": 2596
                },
                {
                    "lat": "4.2011685",
                    "lon": "100.663029",
                    "aqi": "42",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Seri Manjung, Perak, Malaysia",
                    "img": "_8420CkgtSszWD04tylTwTczLKs1LBwA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2383,
                    "x": 2597
                },
                {
                    "lat": "5.391184",
                    "lon": "100.386575",
                    "aqi": "50",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Perai, Pulau Pinang, Malaysia",
                    "img": "_8420CijNSSxVCMjMS8xL1w9ILUrMBAA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2386,
                    "lvl": 2,
                    "x": 2600
                },
                {
                    "lat": "5.391184",
                    "lon": "100.386575",
                    "aqi": "58",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Seberang Jaya 2, Perai, Pulau Pinang, Malaysia",
                    "img": "_8420CijNSSxVCMjMS8xL1w9OTUotAjIUvBIrExWMdBQCgNxMAA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2387,
                    "lvl": 2,
                    "x": 2601
                },
                {
                    "lat": "5.3575711",
                    "lon": "100.2930184",
                    "aqi": "52",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "USM, Pulau Pinang, Malaysia",
                    "img": "_8420CijNSSxVCMjMS8xL1w8N9gUA",
                    "pol": "pm10",
                    "tz": "+0800",
                    "idx": 2388,
                    "x": 2602
                },
                {
                    "lat": "4.61175",
                    "lon": "101.113506",
                    "aqi": "39",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Ipoh",
                    "img": "Ipoh",
                    "pol": "pm25",
                    "tz": "+0800",
                    "idx": 5017,
                    "lvl": 1,
                    "x": 5777
                },
                {
                    "lat": "5.384388",
                    "lon": "100.3896169",
                    "aqi": "58",
                    "utime": " on Sunday, Jul 10th 2016, 08:00 am",
                    "stamp": 1468108800,
                    "city": "Perai",
                    "img": "Perai",
                    "pol": "pm25",
                    "tz": "+0800",
                    "idx": 5018,
                    "lvl": 1,
                    "x": 5778
                }
            ]
