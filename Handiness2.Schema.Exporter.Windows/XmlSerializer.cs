using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Handiness2.Schema.Exporter.Windows
{
    /// <summary>
    ///对象XML的序列化与反序列化
    /// </summary>
    public sealed class XmlSerializer
    {
        /// <summary>
        /// 将文件列表反序列化成对象集合
        /// </summary>
        public static IEnumerable<T> Load<T>(params String[] files) where T : class
        {
            foreach (String file in files)
            {
                if (!File.Exists(file)) break;
                T schema = null;
                try
                {
                    schema = XmlSerializer.DeSerialize<T>(file);
                }
                catch(Exception exc)
                {
                    throw new Exception(file, exc);
                }
                if (schema != null) yield return schema;
            }
        }
        /// <summary>
        /// 搜索指定目录下符合指定格式的文件，并反序列化
        /// </summary>
        /// <param name="pattern">文件名称格式，例如 *.xml</param>
        /// <param name="directory">指定的目录</param>
        public static IEnumerable<T> Search<T>(String pattern, String directory = null) where T : class
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(directory, pattern);
            return Load<T>(files);
        }
        /// <summary>
        /// 将对象序列化到文件中，若文件不存在此函数会创建一个新的文件，若存在则会清空文件的内容
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="obj">被序列化的对象</param>
        /// <param name="file">文件路径</param>
        public static void Serialize<T>(T obj, String file) where T : class
        {
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            FileStream stream = null;
            try
            {
                if (File.Exists(file))
                {
                    stream = new FileStream(
                      file,
                      FileMode.Truncate, FileAccess.Write, FileShare.Read,
                      8096,
                      FileOptions.WriteThrough);
                }
                else
                {
                    stream = new FileStream(
                   file,
                   FileMode.Create, FileAccess.Write, FileShare.Read,
                   8096,
                   FileOptions.WriteThrough);
                }

                TextWriter writer = new StreamWriter(stream);
                xmlSerializer.Serialize(writer, obj);
            }
            finally
            {
                stream?.Dispose();
            }
       
        }
        /// <summary>
        /// 从含有类结构信息的文件中反序列化出实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="file">文件路径</param>
        /// <returns>实例</returns>
        public static T DeSerialize<T>(String file) where T : class
        {
            T obj = null;
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                obj = xmlSerializer.Deserialize(stream) as T;
            }
            return obj;
        }
        /// <summary>
        /// 将包含XML结构信息的字符串返回序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeSerializeFromString<T>(String str) where T : class
        {
            T obj = null;
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(str))
            {
                obj = xmlSerializer.Deserialize(reader) as T;
            }
            return obj;
        }
        /// <summary>
        /// 将对象XML序列化成字符串对象
        /// </summary>
        public static String SerializeToString<T>(T obj)
        {
            String str = null;
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            //StringWriter 默认编码 utf-16 反序列化时会发生异常
            //using (StringWriter writer = new StringWriter())
            //{

            //    xmlSerializer.Serialize(writer,obj);
            //    str = writer.ToString();
            //}
            using (MemoryStream stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, obj);
                str = UTF8Encoding.UTF8.GetString(stream.ToArray());
            }
            return str;
        }
    }
}
