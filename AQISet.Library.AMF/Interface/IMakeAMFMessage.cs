using FluorineFx.IO;

namespace AQI.Interface
{
    /// <summary>
    /// IMakeAMFMessage
    /// AAmfSrcUrl 扩展接口
    /// </summary>
    interface IMakeAMFMessage
    {
        AMFMessage MakeAMFMsg(AqiParam param);
    }
}
