using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    public class CommandSerializer<T> where T : class
    {
        // -h test -v 12.32 -s
        /// <summary>
        /// 获取命令说明列表
        /// </summary>
        /// <returns></returns>
        public static IList<String> GetCommandExplainList()
        {
            List<String> explains = new List<String>();
            return explains;
        }

        /// <summary>
        /// 序列化指定的命令对象  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回序列化后的命令字符串</returns>
        /// <exception cref="CommandSerializeException">命令对象无可序列化的属性，或序列化失败时</exception>
        public static String Serialize(T obj) 
        {
            String str = null;
            return str;
        }
        /// <summary>
        /// 反序列化命令字符串为指定类型的命令对象
        /// </summary>
        /// <param name="commandStr">包含命令的字符串</param>
        ///<exception cref="CommandSerializeException">反序列化失败时</exception>
        public static T DeSerialize(String commandStr) 
        {
            T obj = null;
            return obj;
        }
    }
}
