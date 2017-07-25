using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.Redis
{
    class Program
    {
        static String ConnectionString = "192.168.0.105:6379";
        /// <summary>
        /// 向Redis写入
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">值</param>
        /// <param name="date">过期日期</param>
        public static void SetString(string key, string value, DateTime? date = null)
        {
            //ConnectionMultiplexer.Connect("Localhost:6379,password=123456"))
            using (var redis = ConnectionMultiplexer.Connect(ConnectionString))
            {
                //写入
                var db = redis.GetDatabase();
                db.StringSet(key, value);
                //设置过期日期
                //if (date != null)
                //{
                //    DateTime time = DateTime.Now.AddSeconds(20);
                //    db.KeyExpire("key", time);
                //}
            //    var result = db.StringGet("key");
            }
        }
        /// <summary>
        /// 读取redis的内容
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            using (var redis = ConnectionMultiplexer.Connect(ConnectionString))
            {
                //读取
                var db = redis.GetDatabase();
                var result = db.StringGet(key);
                return result;
            }
        }
        static void Main(string[] args)
        {
            SetString("Key1","mR212");
            Console.WriteLine(GetString("Key1"));
        }
    }
}
