using System;
using System.Reflection;
using AQISet.Control;
using AQISet.Collection;
using System.Collections;
using System.Threading;
using AQISet.Interface;

namespace AQISet
{
    class Program
    {
        private static AqiManage am;
        private static Stack stack = new Stack();

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "ConsoleMainThread";
            am = new AqiManage();
            stack.Push(am);
            Console.Write(getString());
            Console.WriteLine("自动开启运行");
            am.ManageEvent += new AqiManage.ManageEventHandler(Program.Log_Event);
            am.RunAll();
            loop();
            Environment.Exit(0);
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
                string str = Console.ReadLine();
            }
        }

        /// <summary>
        /// 循环读取命令
        /// </summary>
        static void loop()
        {
            bool flag = false;
            string com = null;
            while (!flag)
            {
                Console.WriteLine(getString());
                com = Console.ReadLine();
                if (com.EndsWith("exit", StringComparison.OrdinalIgnoreCase))
                {
                    if (stack.Count == 1)
                    {
                        flag = true;
                        continue;
                    }
                    stack.Pop();
                }
                else
                {
                    object obj2;
                    if (com.EndsWith("sub", StringComparison.OrdinalIgnoreCase))
                    {
                        obj2 = stack.Peek();
                        if (obj2.GetType().GetInterface(typeof(ISubObject).Name) != null)
                        {
                            ISubObject obj3 = obj2 as ISubObject;
                            Console.Write("请输入要选取的对象名>");
                            object subObject = obj3.GetSubObject(Console.ReadLine());
                            if (subObject != null)
                            {
                                stack.Push(subObject);
                            }
                            else
                            {
                                Console.WriteLine("不存在此对象");
                            }
                        }
                        else
                        {
                            Console.WriteLine("当期对象不支持此命令");
                        }
                    }
                    else if (com.EndsWith("info", StringComparison.OrdinalIgnoreCase))
                    {
                        obj2 = stack.Peek();
                        if (obj2.GetType().GetInterface(typeof(IStatus).Name) != null)
                        {
                            Console.WriteLine((obj2 as IStatus).GetInfo());
                        }
                        else
                        {
                            Console.WriteLine("当期对象不支持此命令");
                        }
                    }
                    else
                    {
                        command(com);
                    }
                }
            }
            Console.WriteLine(com);
        }

        /// <summary>
        /// 命令处理
        /// </summary>
        /// <param name="com"></param>
        private static object command(string com)
        {
            string[] strArray = com.Split(new char[] { ' ' });
            object obj2 = stack.Peek();
            MethodInfo[] methods = obj2.GetType().GetMethods();
            foreach (MethodInfo info in methods)
            {
                if (info.Name == strArray[0])
                {
                    object[] parameters = new object[0];
                    if (strArray.Length > 1)
                    {
                        parameters = new object[] { strArray[1] };
                    }
                    foreach (ParameterInfo info2 in info.GetParameters())
                    {
                        if (!info2.ParameterType.Equals(typeof(string)))
                        {
                            Console.WriteLine("不支持调用此方法，参数类型不为String");
                            return null;
                        }
                    }
                    object obj3 = info.Invoke(obj2, parameters);
                    if (info.ReturnType.Equals(typeof(bool)))
                    {
                        Console.WriteLine(((bool)obj3) ? "命令返回正常" : "命令返回错误");
                    }
                    else if (obj3 == null)
                    {
                        Console.WriteLine("已经调用无返回值");
                    }
                    else
                    {
                        Console.WriteLine(obj3.ToString());
                    }
                }
            }
            return obj2;
        }


        private static string getString()
        {
            string str = null;
            IEnumerator enumerator = stack.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string name = null;
                if (enumerator.Current.GetType().GetInterface(typeof(IStatus).Name) != null)
                {
                    name = (enumerator.Current as IStatus).Name;
                }
                else
                {
                    name = enumerator.Current.GetType().Name;
                }
                str = name + ">" + str;
            }
            return str;
        }
    }
}
