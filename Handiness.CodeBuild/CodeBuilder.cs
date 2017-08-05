using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
using System.Text.RegularExpressions;
namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/7/25 20:38:13
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：根据元数据和代码模板生成对应的代码字符串
 *  -------------------------------------------------------------------------*/
    public class CodeBuilder
    {
        protected static String PlaceholderSymbol = "$";
        protected static String LoopGroupPlaceholderSymbol = "#";

        /// <summary>
        /// 普通占位符提取正则  例如 从 $name$  中提取 name
        /// </summary>
        protected Regex PlaceholderExtractRegex = new Regex($"(?<=\\{PlaceholderSymbol})\\w+(?=\\{PlaceholderSymbol})");
        /// <summary>
        /// 循环组占位符提取正则
        /// </summary>
        protected Regex LoopGroupPlaceholderExtractRegex = new Regex($"(?<=\\{LoopGroupPlaceholderSymbol})\\w+(?=\\{LoopGroupPlaceholderSymbol})");
        /// <summary>
        /// 普通占位符匹配正则  例如 匹配 $name$ 
        /// </summary>
        protected Regex PlaceholderMatchRegex = new Regex($"(\\{PlaceholderSymbol}\\w+\\{PlaceholderSymbol}");
        /// <summary>
        /// 循环组占位符匹配正则
        /// </summary>
        protected Regex LoopGroupPlaceholderMatchRegex = new Regex($"\\{LoopGroupPlaceholderSymbol}\\w+\\{LoopGroupPlaceholderSymbol}");


        public IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> Schemas { get; set; }
        public INameModifier NameModifier { get; set; }
        public TypeMapper TypeMapper { get; set; }
        public CodeTemplateXml CodeTemplate { get; set; }

        public CodeBuilder(IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas,
            INameModifier nameModifier,
            TypeMapper typeMapper,
            CodeTemplateXml codeTemplate
            )
        {
            this.Schemas = schemas;
            this.NameModifier = nameModifier ?? new NameModifier();
            this.TypeMapper = typeMapper;
            this.CodeTemplate = codeTemplate;
        }
        /// <summary>
        ///组建代码
        /// </summary>
        /// <returns>组建后的代码</returns>
        public IEnumerable<String> Building(String nameSpace = TextResources.DefaultNameSpace)
        {
            foreach (var schema in this.Schemas)
            {
                String code = this.CodeTemplate.Header;
                IEnumerable<ColumnSchema> colSchema = schema.Item2;
                yield return code;
            }
        }
        private String BuildingTableCode(String nameSpace,
            Tuple<TableSchema, IEnumerable<ColumnSchema>> schema)
        {
            return null;
        }
        /// <summary>
        /// 生成循环组的代码
        /// </summary>
        /// <returns></returns>
        private String LoopGroupCode(LoopGroupXml loopGroup, IEnumerable<ColumnSchema> columnSchemas)
        {
            //TODO:循环组代码生成 待完成
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取代码中的占位符名称，小写处理
        /// </summary>
        protected IEnumerable<String> GetPlaceholderNames(String code)
        {
            foreach (Match match in this.PlaceholderMatchRegex.Matches(code))
            {
                yield return match.Value.Trim().ToLower();
            }
        }

        /// <summary>
        /// 拼接代码字符串
        /// </summary>
        /// <returns>拼接后的代码字符串</returns>
        protected String ConcatCodeString(String str1, String str2)
        {
            return str1 + Environment.NewLine + str1;
        }
   
    }
}
