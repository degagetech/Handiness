using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace Handiness2.Schema
{
    /// <summary>
    /// 引导框架加载 Schema 信息
    /// </summary>
    public static class SchemaBootmgr
    {
        /// <summary>
        /// .schema 文件所在的目录，在使用 <see cref="SchemaGetType.File"/> 方式获取 Schema 信息时，此属性需要被指定，默认为  <see cref="String.Empty"/>
        /// </summary>
        public static String SchemaFileDirectory { get; set; }

        /// <summary>
        /// 指定 Schema 信息的获取方式，默认为 <see cref="SchemaGetType.Attribute"/>
        /// </summary>
        public static SchemaGetType SchemaGetType { get; set; }

        /// <summary>
        /// 强制指定 Schema 信息，当指定 SchemaGetType  属 性为非 <see cref="SchemaGetType.AutoDeduce"/> 时，若模型类的 Schema 信息缺失，则抛出异常，若关闭此属性，则框架使用自动推断补全 Schema 信息，此属性默认关闭
        /// </summary>
        public static Boolean IsMandatory { get; set; }

        /// <summary>
        /// 设置属性的默认值
        /// </summary>
        static SchemaBootmgr()
        {
            SchemaFileDirectory = String.Empty;
            SchemaGetType = SchemaGetType.Attribute;
            IsMandatory = false;
        }

        /// <summary>
        /// 重新引导框架加载 shcema 信息，暂未支持此方法
		/// 此方法成功运行后
		/// 1.会重置框架内存中所有的 Schema 信息
		/// 2.现有的 <see cref="SQLElement"/> 缓存会全部失效
        /// </summary>
        public static void Reboot()
		{ 
            throw new NotImplementedException(); 
        }
    }
}
