using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper.Util.IO;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace aqicnMapStationReader
{
    class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
            if (args.Length==0)
            {
                args = new string[1];
            }
            args[0] = "D:\\AQI\\aqicn\\MapStation\\";
#endif
            while( String.IsNullOrEmpty(args[0]) || !Directory.Exists(args[0]))
            {
                Console.WriteLine("请输入路径");
                args[0] = Console.ReadLine();
            }

            string path = args[0];

            AllFile(path);

            mergeFile(path);

            Console.WriteLine("转换完毕,任意键退出");
            Console.ReadKey();
        }


        /// <summary>
        /// 遍历文件
        /// </summary>
        /// <param name="path"></param>
        public static void AllFile(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (DirectoryInfo d in di.EnumerateDirectories())
            {
                AllFile(d.FullName);
            }
            foreach (FileInfo f in di.EnumerateFiles("*.json"))
            {
                Console.Write(di.Name + ":" + f.Name + ":");
                OneFile(f.FullName);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool OneFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string str = sr.ReadToEnd();

            JArray ja = (JArray)JsonConvert.DeserializeObject(str);

            if (ja.Count==0)
            {
                return false;
            }
            StringBuilder sb = new StringBuilder();
            foreach (JToken jt in ja)
            {
                sb.Append(jt["lat"].ToString());
                sb.Append("\t");
                sb.Append(jt["lon"].ToString());
                sb.Append("\t");
                sb.Append(jt["city"].ToString());
                sb.Append("\r\n");
            }
            string strOK = sb.ToString();

            FileReadSaveUtil.Save(strOK, path + ".txt");

            Console.WriteLine("包含数量:" + ja.Count);

            return true;
        }



        public static void mergeFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo f in di.EnumerateFiles("*.txt",SearchOption.AllDirectories))
            {
                StreamReader sr = new StreamReader(f.FullName);
                string str = sr.ReadToEnd();
                sb.Append(str);
            }
            FileReadSaveUtil.Save(sb.ToString(), path + "all.txt");
        }

    }
}
