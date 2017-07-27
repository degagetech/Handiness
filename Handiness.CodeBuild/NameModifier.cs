using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/21 15:30:13
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：在将数据库原有名称修改为更符合编程规范的名称
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 默认名称修改器
    /// </summary>
    public class NameModifier : INameModifier
    {
        private const String NameModifierExplain = "Pascal";
        public String Explain { get => NameModifierExplain; }

        public String ModifyColumnNameOfField(String columnName)
        {
            String result = null;
            result = this.ModifyColumnNameOfProperty(columnName);
            if (result != null)
            {
                result = this.FirstCharUpper(result, false);
                result = result.Insert(0, "_");
            }
            return result;
        }

        public String ModifyColumnNameOfProperty(String columnName)
        {
            String result = null;
            if (this.Check(columnName))
            {
                String[] split = this.Participle(columnName);
                foreach (String str in split)
                {
                    result += this.FirstCharUpper(str);
                }
            }
            return result;
        }
        public String ModifyTableName(String tableName)
        {
            String result = null;
            if (this.Check(tableName))
            {
                String[] split = this.Participle(tableName);
                foreach (String str in split)
                {
                    result += this.FirstCharUpper(str);
                }
            }
            return result;
        }
        protected String FirstCharUpper(String str, Boolean toUpper = true)
        {
            String result = str;
            if (result.Length < 1)
            {
                return String.Empty;
            }
            if (toUpper)
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1);
            }
            else
            {
                result = result.Substring(0, 1).ToLower() + result.Substring(1);
            }
            return result;
        }
        protected Boolean Check(String str)
        {
            return !String.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 分词操作
        /// </summary>
        /// <param name="symbol">分词符</param>
        protected String[] Participle(String str, Char symbol = '_')
        {
            String[] result = null;
            str = str.Replace(" ", "");
            result = str.Split(symbol);
            return result;
        }
    }
}
