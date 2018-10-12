using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace Handiness2.Schema.Exporter.Windows
{
    /// <summary>
    /// 对象的二进制序列化与反序列化
    /// </summary>
   public sealed class BinarySerializer
    {
        /// <summary>
        /// 将T类型的对象序列化成一个二进制数组
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>若序列化失败返回一个Null数组对象</returns>
        public static Byte[] Serialize<T>
            (T obj) where T : class
        {
            Byte[] serializeReuslt = null;
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                binFormat.Serialize(stream, obj);
                serializeReuslt = new Byte[stream.Length];
                stream.Position = 0;
                stream.Read(serializeReuslt, 0, serializeReuslt.Length);
            }
            return serializeReuslt;
        }
        /// <summary>
        /// 将一个二进制数组序列化成T 类型的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="buffer">对象的二进制数组</param>
        /// <returns>序列化后得到的对象</returns>
        public static T Deserialize<T>
            (Byte[] buffer) where T : class
        {
            T resultObj = default(T);
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                stream.Write(buffer, 0, buffer.Length);
                stream.Position = 0;
                resultObj = binFormat.Deserialize(stream) as T;
            }
            return resultObj;
        }
        /// <summary>
        /// 将制定类型序列化为Binary文件
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="savePath">文件保存的路径</param>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>是否序列化成功，如果失败跑出异常</returns>
        public static Boolean SerializeToFile<T>
            (string savePath, T obj) where T : class
        {
            using (Stream writeStream = new FileStream(savePath,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read,
                8192,
                FileOptions.WriteThrough))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                binFormat.Serialize(writeStream, obj);
            }
            return true;
        }
        /// <summary>
        /// 将指定文件反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="savePath">文件保存的路径</param>
        /// <returns>序列化后得到的对象</returns>
        public static T DeserializeFromFile<T>
            (string savePath) where T : class
        {
            T obj = default(T);
            if (!File.Exists(savePath))
                return obj;
            using (Stream readStream = new FileStream(savePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                obj = binFormat.Deserialize(readStream) as T;
            }
            return obj;
        }
    }
}
