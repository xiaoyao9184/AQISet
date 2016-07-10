FORMAT: 1A
HOST: http://113.140.66.226:8024/




# 陕西省空气质量实时发布系统

文档日期 2016-07-09
系统地址 http://113.140.66.226:8024/sxAQIWeb。


# City [GET /sxAQIWeb/swfPage/{cityname}.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>6</CO>
                <O3>29</O3>
                <PM10>37</PM10>
                <PM25>17</PM25>
                <AQI>37</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>28</O3>
                <PM10>49</PM10>
                <PM25>18</PM25>
                <AQI>49</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>8</CO>
                <O3>26</O3>
                <PM10>38</PM10>
                <PM25>19</PM25>
                <AQI>38</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>6</NO2>
                <CO>9</CO>
                <O3>25</O3>
                <PM10>42</PM10>
                <PM25>19</PM25>
                <AQI>42</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>8</CO>
                <O3>25</O3>
                <PM10>43</PM10>
                <PM25>20</PM25>
                <AQI>43</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>4</NO2>
                <CO>12</CO>
                <O3>24</O3>
                <PM10>45</PM10>
                <PM25>21</PM25>
                <AQI>45</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>5</NO2>
                <CO>12</CO>
                <O3>23</O3>
                <PM10>32</PM10>
                <PM25>21</PM25>
                <AQI>32</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>6</NO2>
                <CO>10</CO>
                <O3>23</O3>
                <PM10>44</PM10>
                <PM25>21</PM25>
                <AQI>44</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>5</NO2>
                <CO>10</CO>
                <O3>23</O3>
                <PM10 />
                <PM25>53</PM25>
                <AQI>53</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>6</NO2>
                <CO>10</CO>
                <O3>20</O3>
                <PM10>41</PM10>
                <PM25>21</PM25>
                <AQI>41</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>7</NO2>
                <CO>11</CO>
                <O3>14</O3>
                <PM10>52</PM10>
                <PM25>23</PM25>
                <AQI>52</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>8</NO2>
                <CO>11</CO>
                <O3>6</O3>
                <PM10>56</PM10>
                <PM25>54</PM25>
                <AQI>56</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>7</NO2>
                <CO>12</CO>
                <O3>5</O3>
                <PM10>68</PM10>
                <PM25>63</PM25>
                <AQI>68</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>13</CO>
                <O3>7</O3>
                <PM10>67</PM10>
                <PM25>64</PM25>
                <AQI>67</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>7</O3>
                <PM10>47</PM10>
                <PM25>52</PM25>
                <AQI>52</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>8</O3>
                <PM10>62</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>16</O3>
                <PM10>67</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <MAININDEX>PM10PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>11</CO>
                <O3>24</O3>
                <PM10>56</PM10>
                <PM25>59</PM25>
                <AQI>59</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10>42</PM10>
                <PM25>57</PM25>
                <AQI>57</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10 />
                <PM25>53</PM25>
                <AQI>53</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>9</CO>
                <O3>28</O3>
                <PM10>40</PM10>
                <PM25>25</PM25>
                <AQI>40</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>3</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>22</O3>
                <PM10 />
                <PM25>55</PM25>
                <AQI>55</AQI>
                <MAININDEX>PM2.5 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>9</CO>
                <O3>27</O3>
                <PM10>80</PM10>
                <PM25>52</PM25>
                <AQI>80</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>8</CO>
                <O3>31</O3>
                <PM10>115</PM10>
                <PM25>23</PM25>
                <AQI>115</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>三级</Level>
                <LevelName>轻度污染</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>7</CO>
                <O3>30</O3>
                <PM10>91</PM10>
                <PM25>21</PM25>
                <AQI>91</AQI>
                <MAININDEX>PM10</MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
            </NewDataSet>




# City7Day [GET /sxAQIWeb/swfPage/{cityname}7Day.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-2</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>8</CO>
                <O3>65</O3>
                <PM10>58</PM10>
                <PM25>41</PM25>
                <AQI>65</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-3</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>8</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>55</O3>
                <PM10>46</PM10>
                <PM25>46</PM25>
                <AQI>55</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-4</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>9</SO2>
                <NO2>4</NO2>
                <CO>7</CO>
                <O3>57</O3>
                <PM10>32</PM10>
                <PM25>31</PM25>
                <AQI>57</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-5</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>6</SO2>
                <NO2>4</NO2>
                <CO>6</CO>
                <O3>61</O3>
                <PM10>33</PM10>
                <PM25>26</PM25>
                <AQI>61</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-6</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>5</SO2>
                <NO2>4</NO2>
                <CO>6</CO>
                <O3>80</O3>
                <PM10>40</PM10>
                <PM25>42</PM25>
                <AQI>80</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-7</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>9</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>62</O3>
                <PM10>44</PM10>
                <PM25>43</PM25>
                <AQI>62</AQI>
                <MAININDEX>O3 </MAININDEX>
                <Level>二级</Level>
                <LevelName>良</LevelName>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>7-8</CURDATETIME>
                <DEVID>NA</DEVID>
                <SO2>6</SO2>
                <NO2>4</NO2>
                <CO>7</CO>
                <O3>45</O3>
                <PM10>40</PM10>
                <PM25>41</PM25>
                <AQI>45</AQI>
                <MAININDEX />
                <Level>一级</Level>
                <LevelName>优</LevelName>
              </Table1>
            </NewDataSet>




# CityAVGND [GET /sxAQIWeb/swfPage/{cityname}AVGND.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>9</SO2>
                <NO2>5</NO2>
                <CO>0.60</CO>
                <O3>92</O3>
                <PM10>37</PM10>
                <PM25>24</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>9</NO2>
                <CO>0.70</CO>
                <O3>88</O3>
                <PM10>49</PM10>
                <PM25>25</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>10</NO2>
                <CO>0.80</CO>
                <O3>82</O3>
                <PM10>38</PM10>
                <PM25>26</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>11</NO2>
                <CO>0.90</CO>
                <O3>77</O3>
                <PM10>42</PM10>
                <PM25>26</PM25>
                <PM1024>40</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>8</NO2>
                <CO>0.80</CO>
                <O3>78</O3>
                <PM10>43</PM10>
                <PM25>28</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>1.20</CO>
                <O3>74</O3>
                <PM10>45</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>10</NO2>
                <CO>1.20</CO>
                <O3>73</O3>
                <PM10>32</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>11</NO2>
                <CO>1</CO>
                <O3>73</O3>
                <PM10>44</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>9</NO2>
                <CO>1</CO>
                <O3>72</O3>
                <PM10>NULL</PM10>
                <PM25>37</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>12</NO2>
                <CO>1</CO>
                <O3>63</O3>
                <PM10>41</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>13</NO2>
                <CO>1.10</CO>
                <O3>44</O3>
                <PM10>54</PM10>
                <PM25>32</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>15</NO2>
                <CO>1.10</CO>
                <O3>18</O3>
                <PM10>62</PM10>
                <PM25>38</PM25>
                <PM1024>41</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>14</SO2>
                <NO2>14</NO2>
                <CO>1.20</CO>
                <O3>16</O3>
                <PM10>86</PM10>
                <PM25>45</PM25>
                <PM1024>42</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>17</SO2>
                <NO2>12</NO2>
                <CO>1.30</CO>
                <O3>20</O3>
                <PM10>83</PM10>
                <PM25>46</PM25>
                <PM1024>43</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>9</NO2>
                <CO>0.70</CO>
                <O3>21</O3>
                <PM10>47</PM10>
                <PM25>36</PM25>
                <PM1024>44</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.40</CO>
                <O3>25</O3>
                <PM10>73</PM10>
                <PM25>48</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.40</CO>
                <O3>49</O3>
                <PM10>84</PM10>
                <PM25>48</PM25>
                <PM1024>46</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>8</NO2>
                <CO>1.10</CO>
                <O3>76</O3>
                <PM10>62</PM10>
                <PM25>42</PM25>
                <PM1024>46</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>1</CO>
                <O3>89</O3>
                <PM10>42</PM10>
                <PM25>40</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>1</CO>
                <O3>88</O3>
                <PM10>NULL</PM10>
                <PM25>37</PM25>
                <PM1024>44</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>0.90</CO>
                <O3>88</O3>
                <PM10>40</PM10>
                <PM25>35</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>9</SO2>
                <NO2>4</NO2>
                <CO>0.90</CO>
                <O3>69</O3>
                <PM10>NULL</PM10>
                <PM25>39</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.90</CO>
                <O3>85</O3>
                <PM10>109</PM10>
                <PM25>36</PM25>
                <PM1024>49</PM1024>
                <PM2524>32</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.80</CO>
                <O3>99</O3>
                <PM10>180</PM10>
                <PM25>32</PM25>
                <PM1024>58</PM1024>
                <PM2524>33</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.70</CO>
                <O3>95</O3>
                <PM10>131</PM10>
                <PM25>30</PM25>
                <PM1024>65</PM1024>
                <PM2524>33</PM2524>
              </Table1>
            </NewDataSet>




# StationAQI [GET /sxAQIWeb/swfPage/{cityname}AQI.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>2</CO>
                <O3>31</O3>
                <PM10>—</PM10>
                <PM25>22</PM25>
                <AQI>31</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>O3</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>28</O3>
                <PM10>—</PM10>
                <PM25>36</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>7</CO>
                <O3>32</O3>
                <PM10>91</PM10>
                <PM25>50</PM25>
                <AQI>91</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>7</CO>
                <O3>30</O3>
                <PM10>91</PM10>
                <PM25>21</PM25>
                <AQI>91</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
            </NewDataSet>



# StationAllAQI [GET /sxAQIWeb/swfPage/{cityname}AllAQI.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body


            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>25</O3>
                <PM10>36</PM10>
                <PM25>29</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>27</O3>
                <PM10>38</PM10>
                <PM25>38</PM25>
                <AQI>38</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>2</CO>
                <O3>31</O3>
                <PM10>36</PM10>
                <PM25>30</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>3</CO>
                <O3>30</O3>
                <PM10>40</PM10>
                <PM25>32</PM25>
                <AQI>40</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>3</NO2>
                <CO>4</CO>
                <O3>25</O3>
                <PM10>49</PM10>
                <PM25>32</PM25>
                <AQI>49</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>3</SO2>
                <NO2>5</NO2>
                <CO>13</CO>
                <O3>25</O3>
                <PM10>54</PM10>
                <PM25>39</PM25>
                <AQI>54</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>3</CO>
                <O3>28</O3>
                <PM10>38</PM10>
                <PM25>33</PM25>
                <AQI>38</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>4</CO>
                <O3>23</O3>
                <PM10>41</PM10>
                <PM25>33</PM25>
                <AQI>41</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>14</CO>
                <O3>24</O3>
                <PM10>37</PM10>
                <PM25>40</PM25>
                <AQI>40</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>6</NO2>
                <CO>14</CO>
                <O3>22</O3>
                <PM10>47</PM10>
                <PM25>40</PM25>
                <AQI>47</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>4</CO>
                <O3>22</O3>
                <PM10>39</PM10>
                <PM25>35</PM25>
                <AQI>39</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>3</SO2>
                <NO2>5</NO2>
                <CO>4</CO>
                <O3>27</O3>
                <PM10>36</PM10>
                <PM25>35</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>15</CO>
                <O3>23</O3>
                <PM10>45</PM10>
                <PM25>42</PM25>
                <AQI>45</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>3</CO>
                <O3>25</O3>
                <PM10>38</PM10>
                <PM25>38</PM25>
                <AQI>38</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>3</CO>
                <O3>27</O3>
                <PM10>40</PM10>
                <PM25>38</PM25>
                <AQI>40</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>13</CO>
                <O3>24</O3>
                <PM10>45</PM10>
                <PM25>42</PM25>
                <AQI>45</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>25</O3>
                <PM10>34</PM10>
                <PM25>38</PM25>
                <AQI>38</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>26</O3>
                <PM10>38</PM10>
                <PM25>39</PM25>
                <AQI>39</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>12</CO>
                <O3>23</O3>
                <PM10>32</PM10>
                <PM25>42</PM25>
                <AQI>42</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>6</NO2>
                <CO>11</CO>
                <O3>23</O3>
                <PM10>44</PM10>
                <PM25>42</PM25>
                <AQI>44</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>27</O3>
                <PM10>37</PM10>
                <PM25>40</PM25>
                <AQI>40</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>28</O3>
                <PM10>46</PM10>
                <PM25>39</PM25>
                <AQI>46</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>10</CO>
                <O3>23</O3>
                <PM10>0</PM10>
                <PM25>53</PM25>
                <AQI>53</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>6</NO2>
                <CO>10</CO>
                <O3>20</O3>
                <PM10>41</PM10>
                <PM25>42</PM25>
                <AQI>42</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>27</O3>
                <PM10>39</PM10>
                <PM25>40</PM25>
                <AQI>40</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>3</SO2>
                <NO2>7</NO2>
                <CO>11</CO>
                <O3>14</O3>
                <PM10>52</PM10>
                <PM25>46</PM25>
                <AQI>52</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>27</O3>
                <PM10>43</PM10>
                <PM25>40</PM25>
                <AQI>43</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>8</NO2>
                <CO>12</CO>
                <O3>6</O3>
                <PM10>56</PM10>
                <PM25>54</PM25>
                <AQI>56</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>26</O3>
                <PM10>44</PM10>
                <PM25>40</PM25>
                <AQI>44</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>7</NO2>
                <CO>13</CO>
                <O3>5</O3>
                <PM10>68</PM10>
                <PM25>63</PM25>
                <AQI>68</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>25</O3>
                <PM10>47</PM10>
                <PM25>43</PM25>
                <AQI>47</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>13</CO>
                <O3>7</O3>
                <PM10>67</PM10>
                <PM25>64</PM25>
                <AQI>67</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>20</O3>
                <PM10>48</PM10>
                <PM25>43</PM25>
                <AQI>48</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>1</SO2>
                <NO2>3</NO2>
                <CO>2</CO>
                <O3>7</O3>
                <PM10>26</PM10>
                <PM25>36</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>20</O3>
                <PM10>42</PM10>
                <PM25>43</PM25>
                <AQI>43</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>6</NO2>
                <CO>13</CO>
                <O3>7</O3>
                <PM10>59</PM10>
                <PM25>65</PM25>
                <AQI>65</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>8</O3>
                <PM10>62</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>3</NO2>
                <CO>4</CO>
                <O3>13</O3>
                <PM10>35</PM10>
                <PM25>46</PM25>
                <AQI>46</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>3</NO2>
                <CO>4</CO>
                <O3>15</O3>
                <PM10>51</PM10>
                <PM25>45</PM25>
                <AQI>51</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>16</O3>
                <PM10>67</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>12</CO>
                <O3>24</O3>
                <PM10>56</PM10>
                <PM25>59</PM25>
                <AQI>59</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>21</O3>
                <PM10>41</PM10>
                <PM25>40</PM25>
                <AQI>41</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>22</O3>
                <PM10>31</PM10>
                <PM25>39</PM25>
                <AQI>39</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>11</CO>
                <O3>28</O3>
                <PM10>42</PM10>
                <PM25>57</PM25>
                <AQI>57</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>11</CO>
                <O3>28</O3>
                <PM10>0</PM10>
                <PM25>53</PM25>
                <AQI>53</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>25</O3>
                <PM10>41</PM10>
                <PM25>39</PM25>
                <AQI>41</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>27</O3>
                <PM10>29</PM10>
                <PM25>33</PM25>
                <AQI>33</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10>40</PM10>
                <PM25>50</PM25>
                <AQI>50</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <AQI>0</AQI>
                <Level>NULL</Level>
                <LevelName>NULL</LevelName>
                <MainIndex>NULL</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10>0</PM10>
                <PM25>46</PM25>
                <AQI>46</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>1</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>30</O3>
                <PM10>24</PM10>
                <PM25>32</PM25>
                <AQI>32</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>5</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>16</O3>
                <PM10>0</PM10>
                <PM25>64</PM25>
                <AQI>64</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>30</O3>
                <PM10>0</PM10>
                <PM25>42</PM25>
                <AQI>42</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0</CO>
                <O3>24</O3>
                <PM10>80</PM10>
                <PM25>59</PM25>
                <AQI>80</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>3</CO>
                <O3>29</O3>
                <PM10>0</PM10>
                <PM25>28</PM25>
                <AQI>29</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>O3</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>2</CO>
                <O3>30</O3>
                <PM10>24</PM10>
                <PM25>23</PM25>
                <AQI>30</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>O3</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>7</CO>
                <O3>34</O3>
                <PM10>115</PM10>
                <PM25>53</PM25>
                <AQI>115</AQI>
                <Level>三级</Level>
                <LevelName>轻度污染</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>29</O3>
                <PM10>0</PM10>
                <PM25>38</PM25>
                <AQI>38</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>28</O3>
                <PM10>0</PM10>
                <PM25>36</PM25>
                <AQI>36</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>PM2.5</MainIndex>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>7</CO>
                <O3>32</O3>
                <PM10>91</PM10>
                <PM25>50</PM25>
                <AQI>91</AQI>
                <Level>二级</Level>
                <LevelName>良</LevelName>
                <MainIndex>PM10</MainIndex>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>2</NO2>
                <CO>2</CO>
                <O3>31</O3>
                <PM10>0</PM10>
                <PM25>22</PM25>
                <AQI>31</AQI>
                <Level>一级</Level>
                <LevelName>优</LevelName>
                <MainIndex>O3</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>6</CO>
                <O3>29</O3>
                <PM10>37</PM10>
                <PM25>17</PM25>
                <AQI>37</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>28</O3>
                <PM10>49</PM10>
                <PM25>18</PM25>
                <AQI>49</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>8</CO>
                <O3>26</O3>
                <PM10>38</PM10>
                <PM25>19</PM25>
                <AQI>38</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>6</NO2>
                <CO>9</CO>
                <O3>25</O3>
                <PM10>42</PM10>
                <PM25>19</PM25>
                <AQI>42</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>8</CO>
                <O3>25</O3>
                <PM10>43</PM10>
                <PM25>20</PM25>
                <AQI>43</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>4</NO2>
                <CO>12</CO>
                <O3>24</O3>
                <PM10>45</PM10>
                <PM25>21</PM25>
                <AQI>45</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>5</NO2>
                <CO>12</CO>
                <O3>23</O3>
                <PM10>32</PM10>
                <PM25>21</PM25>
                <AQI>32</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>6</NO2>
                <CO>10</CO>
                <O3>23</O3>
                <PM10>44</PM10>
                <PM25>21</PM25>
                <AQI>44</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>1</SO2>
                <NO2>5</NO2>
                <CO>10</CO>
                <O3>23</O3>
                <PM10>NULL</PM10>
                <PM25>53</PM25>
                <AQI>53</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>6</NO2>
                <CO>10</CO>
                <O3>20</O3>
                <PM10>41</PM10>
                <PM25>21</PM25>
                <AQI>41</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>7</NO2>
                <CO>11</CO>
                <O3>14</O3>
                <PM10>52</PM10>
                <PM25>23</PM25>
                <AQI>52</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>8</NO2>
                <CO>11</CO>
                <O3>6</O3>
                <PM10>56</PM10>
                <PM25>54</PM25>
                <AQI>56</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>7</NO2>
                <CO>12</CO>
                <O3>5</O3>
                <PM10>68</PM10>
                <PM25>63</PM25>
                <AQI>68</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>13</CO>
                <O3>7</O3>
                <PM10>67</PM10>
                <PM25>64</PM25>
                <AQI>67</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>7</CO>
                <O3>7</O3>
                <PM10>47</PM10>
                <PM25>52</PM25>
                <AQI>52</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>8</O3>
                <PM10>62</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>14</CO>
                <O3>16</O3>
                <PM10>67</PM10>
                <PM25>67</PM25>
                <AQI>67</AQI>
                <Level>PM10PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>11</CO>
                <O3>24</O3>
                <PM10>56</PM10>
                <PM25>59</PM25>
                <AQI>59</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10>42</PM10>
                <PM25>57</PM25>
                <AQI>57</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>10</CO>
                <O3>28</O3>
                <PM10>NULL</PM10>
                <PM25>53</PM25>
                <AQI>53</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>9</CO>
                <O3>28</O3>
                <PM10>40</PM10>
                <PM25>25</PM25>
                <AQI>40</AQI>
                <Level>NULL</Level>
                <LevelName>一级</LevelName>
                <MainIndex>优</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>3</SO2>
                <NO2>2</NO2>
                <CO>9</CO>
                <O3>22</O3>
                <PM10>NULL</PM10>
                <PM25>55</PM25>
                <AQI>55</AQI>
                <Level>PM2.5 </Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>9</CO>
                <O3>27</O3>
                <PM10>80</PM10>
                <PM25>52</PM25>
                <AQI>80</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>8</CO>
                <O3>31</O3>
                <PM10>115</PM10>
                <PM25>23</PM25>
                <AQI>115</AQI>
                <Level>PM10</Level>
                <LevelName>三级</LevelName>
                <MainIndex>轻度污染</MainIndex>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>7</CO>
                <O3>30</O3>
                <PM10>91</PM10>
                <PM25>21</PM25>
                <AQI>91</AQI>
                <Level>PM10</Level>
                <LevelName>二级</LevelName>
                <MainIndex>良</MainIndex>
              </Table1>
            </NewDataSet>




# StationAllND [GET /sxAQIWeb/swfPage/{cityname}AllND.xml]

+ Parameters

  + cityname (enum[string], required) - 城市名称
    + Members
      + ankang
      + baoji
      + hancheng
      + hanzhong
      + shangluo
      + tongchuan
      + weinan
      + xian
      + xianyang
      + xixian
      + yanan
      + yangling
      + yulin

+ Request GetOther

    + Headers

            Accept: */*

+ Response 200 (text/xml)

    + Body

            <?xml version="1.0" standalone="yes"?>
            <NewDataSet>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0.279</CO>
                <O3>78</O3>
                <PM10>36</PM10>
                <PM25>20</PM25>
                <PM1024>36</PM1024>
                <PM2524>27</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>12</SO2>
                <NO2>5</NO2>
                <CO>0.972</CO>
                <O3>86</O3>
                <PM10>38</PM10>
                <PM25>26</PM25>
                <PM1024>45</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>5</SO2>
                <NO2>4</NO2>
                <CO>0.186</CO>
                <O3>98</O3>
                <PM10>36</PM10>
                <PM25>21</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>6</NO2>
                <CO>0.336</CO>
                <O3>77</O3>
                <PM10>49</PM10>
                <PM25>22</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>9</SO2>
                <NO2>9</NO2>
                <CO>1.233</CO>
                <O3>80</O3>
                <PM10>58</PM10>
                <PM25>27</PM25>
                <PM1024>45</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>5</SO2>
                <NO2>8</NO2>
                <CO>0.232</CO>
                <O3>96</O3>
                <PM10>40</PM10>
                <PM25>22</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>0.341</CO>
                <O3>71</O3>
                <PM10>41</PM10>
                <PM25>23</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>6</SO2>
                <NO2>10</NO2>
                <CO>1.307</CO>
                <O3>74</O3>
                <PM10>37</PM10>
                <PM25>28</PM25>
                <PM1024>44</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>5</SO2>
                <NO2>9</NO2>
                <CO>0.260</CO>
                <O3>89</O3>
                <PM10>38</PM10>
                <PM25>23</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>0.357</CO>
                <O3>70</O3>
                <PM10>39</PM10>
                <PM25>24</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>14</SO2>
                <NO2>11</NO2>
                <CO>1.393</CO>
                <O3>68</O3>
                <PM10>47</PM10>
                <PM25>28</PM25>
                <PM1024>44</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>7</SO2>
                <NO2>10</NO2>
                <CO>0.351</CO>
                <O3>85</O3>
                <PM10>36</PM10>
                <PM25>24</PM25>
                <PM1024>36</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>0.278</CO>
                <O3>77</O3>
                <PM10>38</PM10>
                <PM25>26</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>7</SO2>
                <NO2>8</NO2>
                <CO>1.417</CO>
                <O3>71</O3>
                <PM10>45</PM10>
                <PM25>29</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>5</SO2>
                <NO2>8</NO2>
                <CO>0.251</CO>
                <O3>84</O3>
                <PM10>40</PM10>
                <PM25>26</PM25>
                <PM1024>36</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>0.256</CO>
                <O3>79</O3>
                <PM10>34</PM10>
                <PM25>26</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>1.232</CO>
                <O3>74</O3>
                <PM10>45</PM10>
                <PM25>29</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>0.257</CO>
                <O3>83</O3>
                <PM10>38</PM10>
                <PM25>27</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>10</NO2>
                <CO>1.181</CO>
                <O3>73</O3>
                <PM10>32</PM10>
                <PM25>29</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>5</SO2>
                <NO2>4</NO2>
                <CO>0.258</CO>
                <O3>86</O3>
                <PM10>37</PM10>
                <PM25>28</PM25>
                <PM1024>37</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>11</NO2>
                <CO>1.020</CO>
                <O3>73</O3>
                <PM10>44</PM10>
                <PM25>29</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>0.258</CO>
                <O3>87</O3>
                <PM10>46</PM10>
                <PM25>27</PM25>
                <PM1024>38</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>9</NO2>
                <CO>0.973</CO>
                <O3>72</O3>
                <PM10>0</PM10>
                <PM25>37</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>4</NO2>
                <CO>0.258</CO>
                <O3>85</O3>
                <PM10>39</PM10>
                <PM25>28</PM25>
                <PM1024>38</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>12</NO2>
                <CO>0.968</CO>
                <O3>63</O3>
                <PM10>41</PM10>
                <PM25>29</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>37</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>0.258</CO>
                <O3>84</O3>
                <PM10>43</PM10>
                <PM25>28</PM25>
                <PM1024>38</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>7</SO2>
                <NO2>13</NO2>
                <CO>1.061</CO>
                <O3>44</O3>
                <PM10>54</PM10>
                <PM25>32</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>37</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>0.260</CO>
                <O3>82</O3>
                <PM10>44</PM10>
                <PM25>28</PM25>
                <PM1024>38</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>11</SO2>
                <NO2>15</NO2>
                <CO>1.103</CO>
                <O3>18</O3>
                <PM10>62</PM10>
                <PM25>38</PM25>
                <PM1024>45</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>37</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>0.261</CO>
                <O3>78</O3>
                <PM10>47</PM10>
                <PM25>30</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>14</SO2>
                <NO2>14</NO2>
                <CO>1.221</CO>
                <O3>16</O3>
                <PM10>86</PM10>
                <PM25>45</PM25>
                <PM1024>47</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>37</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>0.255</CO>
                <O3>63</O3>
                <PM10>48</PM10>
                <PM25>30</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>17</SO2>
                <NO2>12</NO2>
                <CO>1.268</CO>
                <O3>20</O3>
                <PM10>83</PM10>
                <PM25>46</PM25>
                <PM1024>48</PM1024>
                <PM2524>32</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>38</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>4</NO2>
                <CO>0.288</CO>
                <O3>64</O3>
                <PM10>42</PM10>
                <PM25>30</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>12</SO2>
                <NO2>12</NO2>
                <CO>1.284</CO>
                <O3>22</O3>
                <PM10>67</PM10>
                <PM25>47</PM25>
                <PM1024>50</PM1024>
                <PM2524>32</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>2</SO2>
                <NO2>5</NO2>
                <CO>0.150</CO>
                <O3>20</O3>
                <PM10>26</PM10>
                <PM25>25</PM25>
                <PM1024>37</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>6</NO2>
                <CO>0.366</CO>
                <O3>39</O3>
                <PM10>35</PM10>
                <PM25>32</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.364</CO>
                <O3>25</O3>
                <PM10>73</PM10>
                <PM25>48</PM25>
                <PM1024>51</PM1024>
                <PM2524>33</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>38</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>5</NO2>
                <CO>0.336</CO>
                <O3>47</O3>
                <PM10>51</PM10>
                <PM25>31</PM25>
                <PM1024>40</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.375</CO>
                <O3>49</O3>
                <PM10>84</PM10>
                <PM25>48</PM25>
                <PM1024>53</PM1024>
                <PM2524>33</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>38</PM1024>
                <PM2524>24</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0.268</CO>
                <O3>65</O3>
                <PM10>41</PM10>
                <PM25>28</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>11</SO2>
                <NO2>8</NO2>
                <CO>1.136</CO>
                <O3>76</O3>
                <PM10>62</PM10>
                <PM25>42</PM25>
                <PM1024>53</PM1024>
                <PM2524>34</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>38</PM1024>
                <PM2524>24</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>2</SO2>
                <NO2>3</NO2>
                <CO>0.271</CO>
                <O3>68</O3>
                <PM10>31</PM10>
                <PM25>27</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>1.008</CO>
                <O3>89</O3>
                <PM10>42</PM10>
                <PM25>40</PM25>
                <PM1024>53</PM1024>
                <PM2524>34</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>37</PM1024>
                <PM2524>23</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0.294</CO>
                <O3>78</O3>
                <PM10>41</PM10>
                <PM25>27</PM25>
                <PM1024>40</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>1.027</CO>
                <O3>88</O3>
                <PM10>0</PM10>
                <PM25>37</PM25>
                <PM1024>52</PM1024>
                <PM2524>34</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>23</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0.250</CO>
                <O3>84</O3>
                <PM10>29</PM10>
                <PM25>23</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>0.939</CO>
                <O3>88</O3>
                <PM10>40</PM10>
                <PM25>35</PM25>
                <PM1024>53</PM1024>
                <PM2524>35</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>0</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>0</O3>
                <PM10>0</PM10>
                <PM25>0</PM25>
                <PM1024>36</PM1024>
                <PM2524>23</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>3</SO2>
                <NO2>3</NO2>
                <CO>0.218</CO>
                <O3>93</O3>
                <PM10>24</PM10>
                <PM25>22</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>4</NO2>
                <CO>0.912</CO>
                <O3>89</O3>
                <PM10>0</PM10>
                <PM25>32</PM25>
                <PM1024>52</PM1024>
                <PM2524>35</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>13</SO2>
                <NO2>0</NO2>
                <CO>0</CO>
                <O3>49</O3>
                <PM10>0</PM10>
                <PM25>46</PM25>
                <PM1024>33</PM1024>
                <PM2524>25</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>3</NO2>
                <CO>0.204</CO>
                <O3>90</O3>
                <PM10>0</PM10>
                <PM25>19</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>0.852</CO>
                <O3>93</O3>
                <PM10>0</PM10>
                <PM25>29</PM25>
                <PM1024>52</PM1024>
                <PM2524>35</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>9</SO2>
                <NO2>6</NO2>
                <CO>0</CO>
                <O3>76</O3>
                <PM10>109</PM10>
                <PM25>42</PM25>
                <PM1024>45</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>3</NO2>
                <CO>0.174</CO>
                <O3>93</O3>
                <PM10>24</PM10>
                <PM25>16</PM25>
                <PM1024>39</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>6</SO2>
                <NO2>3</NO2>
                <CO>0.828</CO>
                <O3>91</O3>
                <PM10>0</PM10>
                <PM25>26</PM25>
                <PM1024>53</PM1024>
                <PM2524>35</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>8</SO2>
                <NO2>7</NO2>
                <CO>0.690</CO>
                <O3>106</O3>
                <PM10>180</PM10>
                <PM25>37</PM25>
                <PM1024>63</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>香溪洞</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010003</DEVID>
                <SO2>4</SO2>
                <NO2>4</NO2>
                <CO>0.173</CO>
                <O3>98</O3>
                <PM10>0</PM10>
                <PM25>15</PM25>
                <PM1024>38</PM1024>
                <PM2524>26</PM2524>
              </Table1>
              <Table1>
                <站点名称>安康市监测站</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010001</DEVID>
                <SO2>5</SO2>
                <NO2>3</NO2>
                <CO>0.820</CO>
                <O3>87</O3>
                <PM10>0</PM10>
                <PM25>25</PM25>
                <PM1024>54</PM1024>
                <PM2524>35</PM2524>
              </Table1>
              <Table1>
                <站点名称>汉滨区检察院</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>ZQ6109010002</DEVID>
                <SO2>8</SO2>
                <NO2>7</NO2>
                <CO>0.645</CO>
                <O3>102</O3>
                <PM10>131</PM10>
                <PM25>35</PM25>
                <PM1024>75</PM1024>
                <PM2524>31</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>9</SO2>
                <NO2>5</NO2>
                <CO>0.60</CO>
                <O3>92</O3>
                <PM10>37</PM10>
                <PM25>24</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 18:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>9</NO2>
                <CO>0.70</CO>
                <O3>88</O3>
                <PM10>49</PM10>
                <PM25>25</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 19:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>10</NO2>
                <CO>0.80</CO>
                <O3>82</O3>
                <PM10>38</PM10>
                <PM25>26</PM25>
                <PM1024>41</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 20:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>11</NO2>
                <CO>0.90</CO>
                <O3>77</O3>
                <PM10>42</PM10>
                <PM25>26</PM25>
                <PM1024>40</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 21:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>8</NO2>
                <CO>0.80</CO>
                <O3>78</O3>
                <PM10>43</PM10>
                <PM25>28</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 22:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>7</NO2>
                <CO>1.20</CO>
                <O3>74</O3>
                <PM10>45</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-08 23:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>10</NO2>
                <CO>1.20</CO>
                <O3>73</O3>
                <PM10>32</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 00:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>11</NO2>
                <CO>1</CO>
                <O3>73</O3>
                <PM10>44</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 01:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>4</SO2>
                <NO2>9</NO2>
                <CO>1</CO>
                <O3>72</O3>
                <PM10>NULL</PM10>
                <PM25>37</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 02:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>12</NO2>
                <CO>1</CO>
                <O3>63</O3>
                <PM10>41</PM10>
                <PM25>29</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 03:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>13</NO2>
                <CO>1.10</CO>
                <O3>44</O3>
                <PM10>54</PM10>
                <PM25>32</PM25>
                <PM1024>40</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 04:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>15</NO2>
                <CO>1.10</CO>
                <O3>18</O3>
                <PM10>62</PM10>
                <PM25>38</PM25>
                <PM1024>41</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 05:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>14</SO2>
                <NO2>14</NO2>
                <CO>1.20</CO>
                <O3>16</O3>
                <PM10>86</PM10>
                <PM25>45</PM25>
                <PM1024>42</PM1024>
                <PM2524>28</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 06:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>17</SO2>
                <NO2>12</NO2>
                <CO>1.30</CO>
                <O3>20</O3>
                <PM10>83</PM10>
                <PM25>46</PM25>
                <PM1024>43</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 07:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>9</NO2>
                <CO>0.70</CO>
                <O3>21</O3>
                <PM10>47</PM10>
                <PM25>36</PM25>
                <PM1024>44</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 08:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.40</CO>
                <O3>25</O3>
                <PM10>73</PM10>
                <PM25>48</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 09:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>12</SO2>
                <NO2>13</NO2>
                <CO>1.40</CO>
                <O3>49</O3>
                <PM10>84</PM10>
                <PM25>48</PM25>
                <PM1024>46</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 10:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>11</SO2>
                <NO2>8</NO2>
                <CO>1.10</CO>
                <O3>76</O3>
                <PM10>62</PM10>
                <PM25>42</PM25>
                <PM1024>46</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 11:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>6</SO2>
                <NO2>6</NO2>
                <CO>1</CO>
                <O3>89</O3>
                <PM10>42</PM10>
                <PM25>40</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 12:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>1</CO>
                <O3>88</O3>
                <PM10>NULL</PM10>
                <PM25>37</PM25>
                <PM1024>44</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 13:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>5</SO2>
                <NO2>5</NO2>
                <CO>0.90</CO>
                <O3>88</O3>
                <PM10>40</PM10>
                <PM25>35</PM25>
                <PM1024>45</PM1024>
                <PM2524>29</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 14:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>9</SO2>
                <NO2>4</NO2>
                <CO>0.90</CO>
                <O3>69</O3>
                <PM10>NULL</PM10>
                <PM25>39</PM25>
                <PM1024>43</PM1024>
                <PM2524>30</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 15:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.90</CO>
                <O3>85</O3>
                <PM10>109</PM10>
                <PM25>36</PM25>
                <PM1024>49</PM1024>
                <PM2524>32</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 16:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.80</CO>
                <O3>99</O3>
                <PM10>180</PM10>
                <PM25>32</PM25>
                <PM1024>58</PM1024>
                <PM2524>33</PM2524>
              </Table1>
              <Table1>
                <站点名称>全市均值</站点名称>
                <CURDATETIME>2016-07-09 17:00:00</CURDATETIME>
                <DEVID>DevID</DEVID>
                <SO2>7</SO2>
                <NO2>5</NO2>
                <CO>0.70</CO>
                <O3>95</O3>
                <PM10>131</PM10>
                <PM25>30</PM25>
                <PM1024>65</PM1024>
                <PM2524>33</PM2524>
              </Table1>
            </NewDataSet>
