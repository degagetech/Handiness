using System;
using System.Collections.Generic;
using System.Text;

namespace Handiness2.Schema.Exporter
{
    /// <summary>
    /// 命令参数特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CommandArgsAttribute : Attribute
    {
        /// <summary>
        /// 命令的名称，例如  version ,move
        /// </summary>
        /// <exception cref="CommandSettingExpcetion">命令在同一级别中不唯一时</exception>
        public String Name { get; set; }

        /// <summary>
        /// 命令的简称 ,例如  version-> v , info->v 等
        /// </summary>
        /// <exception cref="CommandSettingExpcetion">命令在同一级别中不唯一时</exception>
        public String Short { get; set; }

        /// <summary>
        /// 参数是否是必需的，默认 false
        /// </summary>
        public Boolean Required { get; set; }

        /// <summary>
        /// 参数的帮助说明
        /// </summary>
        public String HelpText { get; set; }

        public CommandArgsAttribute(String name, String shortName) : base()
        {
            this.Name = name;
            this.Short = shortName;
        }


    }
}
