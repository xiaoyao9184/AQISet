本软件采用GPL协议！



#概念约定
这里对一些术语进行约定，了解约定是了解此项目设计思想的的最快方式

##数据源
将每个数据源抽象为IAqiWeb，通常一个网站、一个WebService、一个WCF就是一个数据源

##数据接口
将每个数据操作抽象为ISrcUrl，通常一个WebApi方法、一个网站URL、一个WCF方法就是一个数据接口。是最小单位，是本项目的核心。




#数据源

##一般AQI按数据来源分为以下几个级别：
- 未分级
- 其他级
- 国家级
- 省级
- 市级
- 区县级

详见SourceLevel枚举

##按数据类型可分为：
- 未知类型
- 其他类型
- 2进制类型
- 纯文本类型
- XML类型
- JSON类型
- WCF类型

详见DataType枚举

##IAqiWeb接口
一个IAqiWeb接口代表一个数据源。数据源是AQI控制器与数据接口之间的桥梁。

数据源要包含配置数据，即唯一标签、名称、数据级别、数据类型以及数据接口的命名空间集合，并且要包含‘获取数据接口集合’的方法，

配置数据用于在AQI控制器中进行管理，这些配置书写比较自由，不会影响任何控制器的正常运行。

##IAqiWeb实现
通常，不直接继承IAqiWeb接口，而是继承ABaseAqiWeb类，这个类实现了根据SrcUrlNameSpace属性获‘取数据接口集合’的通用方法。
因此从ABaseAqiWeb继承的数据源，则一定要把SrcUrlNameSpace属性配置正确。

###TODO
未来将会有新的IAqiWeb抽象类，实现从配置文件中读取配置数据。







#数据接口

##ISrcUrl接口
ISrcUrl接口需要实现核心方法GetData‘获取数据’，直接实现此接口只在此方法中返回Byte数组即可。至于从哪里获取你需要自行解决，返回结果由AQI控制器进行保存处理。
数据接口需要配置属性：名称、内部标签、数据接口地址、IAqiWeb接口、更新间隔、是否使用参数。
与数据源不同的是，更新间隔、是否使用参数属性配置会影响AQI控制器的调度。

##ISrcUrl实现
通常不要直接实现此接口，而是去继承以下抽象类

抽象类
=====================
ABaseSrcUrl			基本WebApi数据接口
AParamSrcUrl		有参数的Http数据接口
AWcfSrcUrl			WCFHttpBing的数据接口
AAmfSrcUrl			FlexAMF的数据接口
AAdvSrcUrl			高级数据接口


这些抽象类目前是并列与继承关系未确定，以后可能会变更。

###ABaseSrcUrl抽象类
应对基本Http GET数据源、无参数POST数据源。只要数据源URL在浏览器中可以直接返回数据，则使用此抽象类。
- ABaseSrcUrl将更新间隔(UDI属性)扩展为SourceUpdataInterval属性，常用时间间隔设置为枚举，使用时在子类中实现SourceUpdataInterval属性即可设置更新间隔(UDI属性)。

- ABaseSrcUrl根据HTTP GET/POST扩展出属性HttpType对应GET/POST两种方式，使用时在子类中实现此属性即可。


###AParamSrcUrl抽象类
应对Http GET/POST含参数数据源、要设置Http Header(例如Cookie)的数据源。大部分情况都都可以使用此类解决。
- ABaseSrcUrl实现了ISrcUrlParam接口、ICacheParam接口、IMakeParam接口。
	- ISrcUrlParam接口扩展了ISrcUrl接口，用于支持含参数GetDate；
	- ICacheParam接口扩展了ISrcUrlParam中EnumParams方法使其支持缓存参数；
	- IMakeParam接口则扩展了ISrcUrlParam中GetData参数的拼接。

- ABaseSrcUrl将更新间隔(UDI属性)扩展为SourceUpdataInterval属性，常用时间间隔设置为枚举，使用时在子类中实现SourceUpdataInterval属性即可设置更新间隔(UDI属性)。

- ABaseSrcUrl扩展出属性ParamSendType用于配置数据源使用的Http方法：
	- GET
	参数在URL中，扩展ParamUrlType属性目前支持两种拼接URL方式，：
  		Url ? 号后面跟键值对方式
  		MVC REST风格的全路径方式
	- POST
	参数在HTTP Body中，扩展ParamBodyType属性目前支持：
  		键值对FORM表单参数
  		纯文本参数
  		二进制(从Base64取得)参数。

Http GET/POST两种类型的方法都支持设置HTTP Header。
默认的参数来源是json文件(与同名数据源tag同名)，从文件读取生成 AqiParam 列表，之后由Aqi控制器调用。

以下依赖必须保证 AqiParam 中包含

	名称       是否必须        格式                条件
	header     可选           JsonObject文本
	body       条件可选       依据ParamBodyType    ParamSendType=POST是必选


###AWcfSrcUrl抽象类
对应使用WCF HTTP传输的数据源，通常的银光都可以使用此数据源。
WCF大部分是需要参数的所以使用POST方法发送的站大多数，少量的无参数仍然可以使用GET方法。前者在HTTP中的表现形式是WCFMessage的二进制形式。

WCFMessage是一种有个事要求的XML文本。
这个格式目前无法抽象，所以如果你要继承此类，则需要实现MakeWCFMsg方法，将Map参数自行转换为WCFMessage；
这个类最重要的是对二进制WCFMessage的处理，所以返回的结果是可以自动还原为XML格式的WCFMessage。

- AWcfSrcUrl继承AParamSrcUrl抽象类。重写了AParamSrcUrl中的MakeRequestBody；重写了ISrcUrl中的GetData：
	- 重写GetData确保支持无参数WCF数据源
	- 重写MakeRequestBody从参数子类MakeWCFMsg方法实现中获取发送的WCFMessage

- AWcfSrcUrl实现IExtractData接口，将二进制的WCFMessage转为XML字符串，根据ExtractWCFContent属性判断提取整个WCFMessage还是仅仅提取WCFContent。


###AAmfSrcUrl抽象类
一些Flex RIA使用AMF协议传输数据，使用HTTP POST绑定方式，所以AAmfSrcUrl是含参数的。
AMF在HTTP中的表现形式是AMFMessage的二进制形式。

AMFMessage属于二进制对象消息，目前还没有办法用XML或JSON形容这种数据，AMFMessage参数值支持二进制形式。

- AAmfSrcUrl继承AParamSrcUrl抽象类。ParamSendType属性默认为POST；重写了AParamSrcUrl中的MakeRequestHeader、MakeRequestBody：
	- 重写MakeRequestHeader在HTTP header中加入‘Content-Type=application/x-amf’
	- 重写MakeRequestBody从参数messageType、message中获取发送的AMFMessage
- AAmfSrcUrl实现IExtractData接口，将二进制的AMFMessage转为JSON字符串。


###AAdvSrcUrl抽象类
对应完全自定义的数据源
实现了大部分接口，需要自行实现其中的抽象方法。





#几个常用的接口
- ISrcUrlParam
- ICacheConfig
- ICacheParam
- IMakeParam
- IExtractData


##ISrcUrlParam接口
与ISrcUrl接口在逻辑上属于并列关系，但是一般就算是有参数也应该实现ISrcUrl，因为ISrcUrl包含数据接口的描述信息。

##ICacheConfig接口
是对于IAqiWeb接口的扩展，此接口用于动态检测IAqiWeb下面的的数据接口是否被配置为关闭状态，从而影响AQI控制器是否处理此数据接口。
###TODO
目前此实现此接口的仅仅是ABaseSrcUrl，这个接口目前是复合接口，还实现缓存配置的功能

##ICacheParam接口
是对ISrcUrlParam接口的的加强，只有在检测到参数过期是才会加载参数

##IMakeParam接口
用于AParamSrcUrl、AWcfSrcUrl、AAdvSrcUrl的扩展，不会影响AQI控制器

##IExtractData接口
是对AWcfSrcUrl、AAmfSrcUrl、AAdvSrcUrl的扩展，不会影响AQI控制器

##IParseSrcUrlParam接口
是随AParamSrcUrl、AWcfSrcUrl的扩展，不会影响AQI控制器