本软件采用GPL协议！






#数据源
将每个数据源抽象为IAqiWeb，通常一个网站、一个WebService、一个WCF就是一个数据源

#数据接口
将每个数据操作抽象为ISrcUrl，通常一个WebApi方法、一个网站URL、一个WCF方法就是一个数据接口


##数据源分类

###一般AQI按数据来源分为以下几个级别：
未分级
其他级
国家级
省级
市级
区县级

详见SourceLevel枚举

###按数据类型可分为：
未知类型
其他类型
2进制类型
纯文本类型
XML类型
JSON类型
WCF类型

详见DataType枚举



数据源要包含配置数据，即唯一标签、名称、数据级别、数据类型以及数据接口的命名空间集合，并且要包含‘获取数据接口集合’的方法，

配置数据用于在AQI控制器中进行管理，这些配置书写比较自由，不会影响任何控制器的正常运行。

通常，不直接继承IAqiWeb接口，而是继承ABaseAqiWeb类，这个类实现了根据SrcUrlNameSpace属性获‘取数据接口集合’的通用方法。
因此从ABaseAqiWeb继承的数据源，则一定要把SrcUrlNameSpace属性配置正确。
//TODO 未来将会有新的IAqiWeb抽象类，实现从配置文件中读取配置数据。









##数据接口
数据接口需要实现核心方法‘获取数据’，直接实现此接口只在此方法中返回Byte数组即可。至于参数你需要自行解决，返回结果由AQI控制器处理。
与数据源一样，多余的属性可以自由配置。

通常不要直接实现此接口，而是去继承以下抽象类

抽象类				
=====================
ABaseSrcUrl			基本WebApi数据接口
AParamSrcUrl		有参数的Http数据接口
AWcfSrcUrl			WCFHttpBing的数据接口
AAdvSrcUrl			高级数据接口


这些抽象类目前是并列的无继承关系
//TODO 是否应该变为树状继承关系，有待确定

ABaseSrcUrl应对基本Http GET数据源
	只要数据源URL在浏览器中可以直接返回数据，则可以直接无重写继承此抽象类。


AParamSrcUrl应对Http GET/POST含参数数据源
	GET方法中参数在URL中，基本的?号后面的键值对参数，MVC的用路径做参数；
	POST方法键值对FORM表单参数。
	都可以直接无重写使用此类。参数具体设置见后。


AWcfSrcUrl对应使用WCF HTTP传输的数据源
	WCF基本上都要有参数的所以基本上都是POST方法发送，在HTTP中的表现形式是WCFMessage的二进制形式。
	其发送的WCFMessage是XML格式，有一定的格式要求。
	这个格式目前无法抽象，所以如果你要继承此类，则需要实现MakeWCFMsg方法，将Map自行转换为WCFMessage；
	不过这个类最重要的是对二进制WCFMessage的处理，所以返回的结果将自动还原为XML格式的WCFMessage。
	通常的银光都可以使用此数据源。


AAdvSrcUrl对应完全自定义的数据源
	这个实现了大部分接口，需要自行实现其中的抽象方法。









##几个常用的接口
ISrcUrlParam
ICacheConfig
ICacheParam
IMakeParam
IExtractData


ISrcUrlParam与ISrcUrl接口在逻辑上属于并列关系，但是一般就算是有参数也应该实现ISrcUrl，因为ISrcUrl包含数据接口的描述信息。

ICacheConfig接口是对于IAqiWeb接口的扩展，此接口用于动态检测IAqiWeb下面的的数据接口是否被配置为关闭状态，从而影响AQI控制器是否处理此数据接口。
		//TODO 目前此实现此接口的仅仅是ABaseSrcUrl，这个接口目前是复合接口，还实现缓存配置的功能

ICacheParam接口是对ISrcUrlParam接口的的加强，只有在检测到参数过期是才会加载参数

IMakeParam接口用于AParamSrcUrl、AWcfSrcUrl、AAdvSrcUrl的扩展，不会影响AQI控制器

IExtractData接口是对AWcfSrcUrl、AAdvSrcUrl的扩展，不会影响AQI控制器

IParseSrcUrlParam接口是随AParamSrcUrl、AWcfSrcUrl的扩展，不会影响AQI控制器