using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
namespace Handiness
{
    //此文件中的工具类均以TK为前缀


    /// <summary>
    ///工具类：对象的xml序列化与反序列化
    /// </summary>
    public class TKXmlSerializer
    {
        public static IEnumerable<T> Load<T>(params String[] files) where T:class
        {
            foreach (String file in files)
            {
                if (!File.Exists(file)) break;
                T schema = null;
                try
                {
                    schema = TKXmlSerializer.DeSerialize<T>(file);
                }
                catch
                {
                    throw new Exception(file);
                }
                if (schema != null) yield return schema;
            }
        }
        public static IEnumerable<T> Search<T>(String pattern,String directory = null) where T:class
        {
            directory = directory ?? AppDomain.CurrentDomain.BaseDirectory;
            var files = Directory.GetFiles(directory, pattern);
            return Load<T>(files);
        }
        /// <summary>
        /// 将对象序列化到文件中，此函数始终会创建一个新的文件，而不是打开现有文件
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="obj">被序列化的对象</param>
        /// <param name="file">文件路径</param>
        public static void Serialize<T>(T obj, String file) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(
                  file,
                  FileMode.Create, FileAccess.Write, FileShare.Read,
                  8096,
                  FileOptions.WriteThrough))
            {
                TextWriter writer = new StreamWriter(stream);
                xmlSerializer.Serialize(writer, obj);
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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                obj = xmlSerializer.Deserialize(stream) as T;
            }
            return obj;
        }
    }
}
