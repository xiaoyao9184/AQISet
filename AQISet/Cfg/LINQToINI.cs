/* ----------------------------------------------------------
文件名称：LINQToINI.cs

作者：秦建辉

MSN：splashcn@msn.com
QQ：36748897

开发环境：
    Visual Studio V2010
    .NET Framework 4 Client Profile

版本历史：
    V1.0	2011年06月30日
			基于LINQ实现对ini文件的读写
------------------------------------------------------------ */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Splash
{
    /// <summary>
    /// 基于LINQ实现对ini文件的读写
    /// </summary>
    public class LINQToINI
    {
        /// <summary>
        /// ini文件内容结点结构
        /// </summary>
        private struct ININode
        {
            /// <summary>
            /// 分区名
            /// </summary>
            public String section;

            /// <summary>
            /// 键名
            /// </summary>
            public String keyName;

            /// <summary>
            /// 键值
            /// </summary>
            public String keyValue;
        }
        
        /// <summary>
        /// ini文件内容结点列表
        /// </summary>
        private List<ININode> INIElement = null;                    
        
        /// <summary>
        /// 读取ini文件并序列化，以供LINQ查询
        /// </summary>
        /// <param name="iniFile">ini文件名</param>
        /// <param name="isQueryOnly">是否只做查询操作。缺省为true</param>
        /// <param name="fileEncoding">文件编码，缺省为null，使用Unicode编码</param>
        /// <returns>
        ///     true：成功
        ///     false：失败
        /// </returns>     
        /// <remarks>
        /// 如果只做查询操作，则序列化时去掉空行结点和注释行结点
        /// </remarks>
        public Boolean Load(String iniFile, Boolean isQueryOnly = true, Encoding fileEncoding = null)
        {
            if (fileEncoding == null)
            {   // 默认使用Unicode编码
                fileEncoding = Encoding.Unicode;
            }

            try
            {   // 自动检测文件编码
                using (StreamReader sr = new StreamReader(iniFile, fileEncoding, true))
                {
                    if (INIElement == null)
                    {
                        INIElement = new List<ININode>();
                    }
                    else
                    {
                        INIElement.Clear();
                    }
                    
                    String Section = null;
                    while (true)
                    {
                        String Source = sr.ReadLine();
                        if (Source == null) break;

                        Source = Source.Trim();
                        if (Source == String.Empty)
                        {   // 空行
                            if (!isQueryOnly)
                            {
                                INIElement.Add(new ININode { section = "\u000A", keyName = null, keyValue = null });
                            }
                        }
                        else if (Source[0] == '#' || Source[0] == ';')
                        {   // 注释行
                            if (!isQueryOnly)
                            {
                                INIElement.Add(new ININode { section = "\u000B", keyName = null, keyValue = Source });
                            }
                        }
                        else if (Source[0] == '[')
                        {   // 分区名
                            Int32 RightSquareBracketIndex = Source.IndexOf(']');
                            if (RightSquareBracketIndex != -1)
                            {
                                Section = Source.Substring(1, RightSquareBracketIndex - 1).Trim();
                                if (Section != String.Empty)
                                {
                                    INIElement.Add(new ININode { section = Section, keyName = String.Empty, keyValue = null });
                                }
                            }
                        }
                        else
                        {   // 键名键值对
                            if (!String.IsNullOrEmpty(Section))
                            {
                                Int32 EqualsSignIndex = Source.IndexOf('=');
                                if (EqualsSignIndex != -1)
                                {   // 提取键名
                                    String KeyName = Source.Substring(0, EqualsSignIndex).Trim();
                                    if (KeyName != String.Empty)
                                    {   // 提取键值
                                        String KeyValue = Source.Substring(EqualsSignIndex + 1).Trim();
                                        if(KeyValue.Length >= 2)
                                        {   // 判断是否有双引号
                                            if (KeyValue[0] == '\u0022' && KeyValue[KeyValue.Length - 1] == '\u0022')
                                            {   
                                                KeyValue = KeyValue.Substring(1, KeyValue.Length - 2);
                                            }
                                        }

                                        INIElement.Add(new ININode { section = Section, keyName = KeyName, keyValue = KeyValue });
                                    }
                                }
                            }
                        }
                    }

                    sr.Close();

                    return true;
                }
            }

            catch (Exception)
            {
                return false;
            }            
        }

        /// <summary>
        /// 存储ini文件
        /// </summary>
        /// <param name="iniFile">要存储的文件名</param>
        /// <param name="fileEncoding">文件编码。缺省为null，使用Unicode编码</param>
        /// <returns>
        ///     true：成功
        ///     false：失败
        /// </returns>
        /// <remarks>注意：只有调用此函数，才能保存最终数据</remarks>
        public Boolean Save(String iniFile, Encoding fileEncoding = null)
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }
            
            if (fileEncoding == null)
            {   // 默认使用Unicode编码
                fileEncoding = Encoding.Unicode;
            }

            try
            {                
                using (StreamWriter sw = new StreamWriter(iniFile, false, fileEncoding))
                {
                    foreach (ININode node in INIElement)
                    {
                        if (node.keyName == null)
                        {
                            if (node.section == "\u000A")
                            {   // 空行
                                sw.WriteLine();
                            }
                            else if (node.section == "\u000B")
                            {   // 注释行
                                sw.WriteLine(node.keyValue);
                            }
                        }
                        else
                        {
                            if (node.keyName == String.Empty)
                            {   // 分区
                                sw.WriteLine("[" + node.section + "]");
                            }
                            else
                            {   // 键名键值对
                                if (node.keyValue.IndexOf(' ') == -1)
                                {   // 键值中没有空格
                                    sw.WriteLine(node.keyName + "=" + node.keyValue);
                                }
                                else
                                {   // 键值中包含空格，需在键值两端加上引号
                                    sw.WriteLine(node.keyName + "=\u0022" + node.keyValue + "\u0022");
                                }
                            }
                        }
                    }

                    sw.Close();
                    return true;
                }
            }

            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 提取键名对应的键值
        /// </summary>
        /// <param name="section">分区名。如果为null，则提取所有的分区名</param>
        /// <param name="keyName">键名。如果为null，则提取分区所有的键名键值对</param>
        /// <param name="defaultString">缺省键值</param>
        /// <returns>键值</returns>
        public String[] GetProfileString(String section, String keyName, String defaultString)
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }

            if(section == null)
            {   // 获取所有的分区名
                return (from node in INIElement where (node.keyName == String.Empty) select node.section).ToArray();
            }
            else if (keyName == null)
            {   // 获取指定分区所有的键名及键值
                return (from node in INIElement where (String.Compare(node.section, section, true) == 0 && !String.IsNullOrEmpty(node.keyName)) select (node.keyName + "=" + node.keyValue)).ToArray();
            }
            else
            {   // 获取键值
                var ValueQuery = (from node in INIElement where (String.Compare(node.section, section, true) == 0 && String.Compare(node.keyName, keyName, true) == 0) select node.keyValue).ToArray();
                if (ValueQuery.Length == 0)
                {
                    return new String[] { defaultString };
                }
                else
                {
                    return ValueQuery;
                }
            }
        }

        /// <summary>
        /// 提取键名对应的键值（整数值）
        /// </summary>
        /// <param name="section">分区名</param>
        /// <param name="keyName">键名</param>
        /// <param name="defaultValue">缺省键值</param>
        /// <returns>键值（整数值）</returns>
        public Int32 GetProfileInt(String section, String keyName, Int32 defaultValue)
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }

            if (String.IsNullOrEmpty(section) || String.IsNullOrEmpty(keyName))
            {
                return defaultValue;
            }

            // 获取键值
            var ValueQuery = (from node in INIElement where (String.Compare(node.section, section, true) == 0 && String.Compare(node.keyName, keyName, true) == 0) select node.keyValue).ToArray();
            if (ValueQuery.Length == 0)
            {
                return defaultValue;
            }
            else
            {
                if (ValueQuery[0] == String.Empty)
                {
                    return defaultValue;
                }
                else
                {   // 将字符串转换为整数值（注意：可能会抛出异常）
                    return Convert.ToInt32(ValueQuery[0]);
                }
            }
        }

        /// <summary>
        /// 获取分区所有的键名键值对
        /// </summary>
        /// <param name="section">分区名</param>
        /// <returns>键名键值对数组</returns>
        public String[] GetProfileSection(String section)
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }

            if (String.IsNullOrEmpty(section))
            {
                return null;
            }
            else
            {   // 获取指定分区所有的键名及键值
                return (from node in INIElement where (String.Compare(node.section, section, true) == 0 && !String.IsNullOrEmpty(node.keyName)) select (node.keyName + "=" + node.keyValue)).ToArray();
            }
        }

        /// <summary>
        /// 获取所有的分区名
        /// </summary>
        /// <returns>分区名数组</returns>
        public String[] GetProfileSectionNames()
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }

            // 获取所有的分区名
            return (from node in INIElement where (String.Compare(node.keyName, String.Empty, true) == 0) select node.section).ToArray();
        }

        /// <summary>
        /// 增加或更新分区名、键名或者键值
        /// </summary>
        /// <param name="section">分区名</param>
        /// <param name="keyName">键名。如果为null或者空串，则删除整个分区</param>
        /// <param name="keyValue">键值。如果为null，则删除该键</param>
        /// <returns>
        ///     true：成功
        ///     false：失败
        /// </returns>
        public Boolean WriteProfileString(String section, String keyName, String keyValue)
        {
            if (String.IsNullOrEmpty(section))
            {
                return false;
            }

            if (INIElement == null)
            {   // 初始化ini结点列表
                INIElement = new List<ININode>();
            }

            if (String.IsNullOrEmpty(keyName))
            {   // 删除整个分区（关键：要从后往前删）
                for (Int32 i = INIElement.Count - 1; i >= 0; i--)
                {
                    if (String.Compare(INIElement[i].section, section, true) == 0 && INIElement[i].keyName != null)
                    {
                        INIElement.RemoveAt(i);
                    }
                }
            }
            else
            {   // 更新键值
                Int32 InsertIndex = -1;
                for (Int32 i = INIElement.Count - 1; i >= 0; i--)
                {
                    if (String.Compare(INIElement[i].section, section, true) == 0)
                    {       
                        if (String.Compare(INIElement[i].keyName, keyName, true) == 0)
                        {   // 删除该键
                            INIElement.RemoveAt(i);
                            if (keyValue != null)
                            {   // 更新该键
                                if (keyValue.Length >= 2)
                                {   // 判断是否有双引号
                                    if (keyValue[0] == '\u0022' && keyValue[keyValue.Length - 1] == '\u0022')
                                    {
                                        keyValue = keyValue.Substring(1, keyValue.Length - 2);
                                    }
                                }

                                // 插入更新后的键名键值对
                                INIElement.Insert(i, new ININode { section = section, keyName = keyName, keyValue = keyValue });
                            }

                            // 直接返回
                            return true;
                        }

                        if (InsertIndex == -1)
                        {   // 将分区末尾做为插入点
                            InsertIndex = i + 1;
                        }
                    }
                }

                if (InsertIndex == -1)
                {   // 分区不存在，首先增加新的分区名
                    INIElement.Add(new ININode { section = section, keyName = String.Empty, keyValue = null });
                    
                    // 再增加新的键名键值对
                    INIElement.Add(new ININode { section = section, keyName = keyName, keyValue = keyValue });
                }
                else
                {   // 分区存在，在分区末尾增加新的键名键值对
                    INIElement.Insert(InsertIndex, new ININode { section = section, keyName = keyName, keyValue = keyValue });
                }
            }

            return true;
        }

        /// <summary>
        /// 替换分区的键名键值对
        /// </summary>
        /// <param name="section">分区名</param>
        /// <param name="keyValueSet">要替换的键名键值对。如果为null，则删除整个分区</param>
        /// <returns>
        ///     true：成功
        ///     false：失败
        /// </returns>
        public Boolean WriteProfileSection(String section, String[] keyValueSet)
        {
            if (String.IsNullOrEmpty(section))
            {
                return false;
            }

            if (INIElement == null)
            {   // 初始化ini结点列表
                INIElement = new List<ININode>();
            }

            // 删除整个分区
            Int32 InsertIndex = INIElement.Count;
            for (Int32 i = INIElement.Count - 1; i >= 0; i--)
            {
                if (String.Compare(INIElement[i].section, section, true) == 0 && INIElement[i].keyName != null)
                {
                    INIElement.RemoveAt(i);
                    InsertIndex = i;
                }
            }      

            if (keyValueSet != null)
            {   // 写入分区名
                INIElement.Insert(InsertIndex++, new ININode {section = section, keyName = String.Empty, keyValue = null });
                
                // 写入键名键值对
                foreach (String s in keyValueSet)
                {
                    Int32 EqualsSignIndex = s.IndexOf('=');
                    if (EqualsSignIndex != -1)
                    {
                        String KeyName = s.Substring(0, EqualsSignIndex).Trim();
                        if (KeyName != String.Empty)
                        {
                            String KeyValue = s.Substring(EqualsSignIndex + 1).Trim();
                            if (KeyValue.Length >= 2)
                            {   // 判断是否有双引号
                                if (KeyValue[0] == '\u0022' && KeyValue[KeyValue.Length - 1] == '\u0022')
                                {
                                    KeyValue = KeyValue.Substring(1, KeyValue.Length - 2);
                                }
                            }

                            INIElement.Insert(InsertIndex++, new ININode { section = section, keyName = KeyName, keyValue = KeyValue });
                        }
                    }
                }           
            }

            return true;
        }

        /// <summary>
        /// 将结构数据写入键值
        /// </summary>
        /// <param name="section">分区名</param>
        /// <param name="keyName">键名</param>
        /// <param name="data">数据</param>
        /// <returns>
        ///     true：成功
        ///     false：失败
        /// </returns>
        public Boolean WriteProfileStruct(String section, String keyName, Byte[] data)
        {
            if (String.IsNullOrEmpty(section) || String.IsNullOrEmpty(keyName))
            {
                return false;
            }

            if (data == null)
            {
                return WriteProfileString(section, keyName, null);
            }

            // 将字节数组转换成16进制字符串
            StringBuilder sb = new StringBuilder((data.Length + 1) << 1);
            Int32 CheckSum = 0;
            foreach(Byte b in data)
            {
                CheckSum += b;
                sb.Append(b.ToString("X2"));
            }

            // 写入校验和
            sb.Append(((Byte)CheckSum).ToString("X2"));

            return WriteProfileString(section, keyName, sb.ToString());
        }

        /// <summary>
        /// 提取键值，并转化为字节数组
        /// </summary>
        /// <param name="section">分区名</param>
        /// <param name="keyName">键名</param>
        /// <returns>键值对应的字节数组</returns>
        public Byte[] GetProfileStruct(String section, String keyName)
        {
            if (INIElement == null)
            {   // 抛出异常：无效的数据源
                throw new ApplicationException("Invalid Data Source!");
            }

            if (String.IsNullOrEmpty(section) || String.IsNullOrEmpty(keyName))
            {
                return null;
            }

            // 获取键值
            var ValueQuery = (from node in INIElement where (String.Compare(node.section, section, true) == 0 && String.Compare(node.keyName, keyName, true) == 0) select node.keyValue).ToArray();
            if (ValueQuery.Length != 1)
            {
                return null;
            }

            // 将16进制字符串转换成字节数组
            String s = ValueQuery[0];
            if (String.IsNullOrEmpty(s) || (s.Length % 2 != 0))
            {
                return null;
            }

            try
            {
                Int32 Num = s.Length / 2 - 1;
                Byte[] ValueArray = new Byte[Num];
                Int32 CheckSum = 0;
                for (Int32 i = 0; i < Num; i++)
                {
                    CheckSum += ValueArray[i] = Convert.ToByte(s.Substring(i << 1, 2), 16);
                }

                // 检测校验和
                if (Convert.ToByte(s.Substring(Num << 1, 2), 16) == CheckSum)
                {
                    return ValueArray;
                }
                else
                {   // 校验失败
                    return null;
                }
            }

            catch (Exception)
            {   // 无效字符串
                return null;
            }
        }
    }
}
