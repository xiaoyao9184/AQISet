using System;
using System.Reflection;
using AQISet.Control;
using AQISet.Collection;

namespace AQISet
{
    class Program
    {
        static AqiManage am;

        static void Main(string[] args)
        {
            am = new AqiManage();
            am.ManageEvent += new AqiManage.ManageEventHandler(Log_Event);
            am.RunAll();
            loop();
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        /// <param name="m"></param>
        static void Log_Event(RunMessage m)
        {
            Console.WriteLine(m.TimeString + " " + m.SenderMessage);
            if (m.Type == RunMessage.RunType.WAIT)
            {
                string input = Console.ReadLine();
            }
        }

        /// <summary>
        /// 循环读取命令
        /// </summary>
        static void loop()
        {
            bool isExit = false;
            string s = null;
            while (!isExit)
            {
                s = Console.ReadLine();

                if (s.EndsWith("exit",StringComparison.OrdinalIgnoreCase))
                {
                    isExit = true;
                    continue;
                }
                else
                {
                    command(s);
                }
            }
            Console.WriteLine(s);
        }

        /// <summary>
        /// 命令处理
        /// </summary>
        /// <param name="com"></param>
        static void command(string com)
        {
            Type t = am.GetType();
            string[] strMP = com.Split(' ');
            
            MethodInfo[] methods = t.GetMethods(); //获取MyClass的所有方法列表  

            foreach (MethodInfo nextMethod in methods) //枚举所有方法  
            {
                if (nextMethod.Name == strMP[0]) //方法m1  
                {
                    object[] p  = new object[]{};
                    if (strMP.Length > 1)
                    {
                        p = new object[] { strMP[1] };
                    }
                    nextMethod.Invoke(am, p);  
                }  
            }
        }
    }
}
