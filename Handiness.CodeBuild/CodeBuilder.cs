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
        /// <summary>
        /// 类型映射信息文件的名称格式
        /// </summary>
        public const String TypeMappingFileNamePattern = "*.mc";
        /// <summary>
        /// 模板文件的名称格式
        /// </summary>
        public const String CodeTemplateFileNamePattern = "*.ct";


        protected const String PlaceholderSymbol = "$";
        protected const String LoopGroupPlaceholderSymbol = "#";



        /// <summary>
        /// 代码生成所需的元数据信息
        /// </summary>
        public IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> Schemas { get; private set; }
        /// <summary>
        /// 名称修改器
        /// </summary>
        public INameModifier NameModifier { get; private set; }
        /// <summary>
        /// 类型映射信息
        /// </summary>
        public TypeMapper TypeMapper { get; private set; }
        /// <summary>
        /// 模板信息
        /// </summary>
        public CodeTemplateXml CodeTemplate { get; private set; }
        /// <summary>
        /// 实体类所属的命名空间
        /// </summary>
        public String NameSpace { get; private set; }

        protected TFDGenerator TFDGenerator { get; private set; }
        public CodeBuilder(IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> schemas,
             CodeTemplateXml codeTemplate,
             TypeMapper typeMapper,
             INameModifier nameModifier,
             String namesapce
            )
        {
            this.Schemas = schemas;
            //若无使用默认帕斯卡名称修改器
            this.NameModifier = nameModifier ?? new PascalNameModifier();
            this.TypeMapper = typeMapper;
            this.CodeTemplate = codeTemplate;
            this.NameSpace = String.IsNullOrWhiteSpace(namesapce) ? TextResources.DefaultNameSpace : namesapce;
            this.TFDGenerator = new TFDGenerator(this.Schemas, this.NameSpace, this.NameModifier, this.TypeMapper);

        }
        /// <summary>
        ///组建代码
        /// </summary>
        /// <returns>返回元组（名称，代码）集合</returns>
        public IEnumerable<(String Name, String Code)> Building()
        {
            foreach (var schema in this.Schemas)
            {
                String code = String.Empty;
                code = this.BuildingTableCode(this.CodeTemplate, schema);
                yield return (
                    $"{this.NameModifier.ModifyTableName(schema.TableSchema.Name)}.{this.CodeTemplate.Postfix.Trim()}",
                   this.EmbellishCode(code));
            }
        }
        /// <summary>
        /// 修饰代码，例如去除一些空行
        /// </summary>
        public String EmbellishCode(String code)
        {
            String modifiedCode = code;
            //TODO:去除代码中的空白行
            //Regex spaceLineRegex = new Regex(@"^\s*$");
            //modifiedCode=spaceLineRegex.Replace(code,String.Empty);
            return modifiedCode;
        }
        private String BuildingTableCode(CodeTemplateXml codeTemplate,
            (TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas) schema)
        {
            String tableCode = codeTemplate.Body;
            HashSet<String> placeHolders = this.GetPlaceholderNames(codeTemplate.Body, PlaceholderSymbol);
            foreach (String placeHolder in placeHolders)
            {
                String fillData = this.TFDGenerator.GetFillData(placeHolder.Trim().ToLower());
                tableCode = tableCode.Replace($"{PlaceholderSymbol}{placeHolder}{PlaceholderSymbol}", fillData);
            }
            foreach (var loopGroup in codeTemplate.LoopGroups)
            {
                var loopGroupCodeTuple = this.BuildingLoopGroupCode(loopGroup, schema);
                tableCode = tableCode.
                    Replace($"{LoopGroupPlaceholderSymbol}{loopGroupCodeTuple.Key}{LoopGroupPlaceholderSymbol}",
                    loopGroupCodeTuple.Code);
            }
            return tableCode;
        }
        /// <summary>
        /// 生成循环组的代码，返回一个元组（Key，Code）
        /// </summary>
        private (String Key, String Code) BuildingLoopGroupCode(LoopGroupXml loopGroup, (TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas) schema)
        {
            String loopGroupCode = String.Empty;
            HashSet<String> placeHolderNames = this.GetPlaceholderNames(loopGroup.Format, CodeBuilder.PlaceholderSymbol);

            foreach (var colSchema in schema.ColumnSchemas)
            {
                String code = loopGroup.Format;
                foreach (String placeHolder in placeHolderNames)
                {
                    String fillData = this.TFDGenerator.GetFillData(placeHolder.Trim().ToLower(), colSchema.Name, schema.TableSchema.Name);
                    code = code.Replace($"{PlaceholderSymbol}{placeHolder}{PlaceholderSymbol}", fillData);
                }
                loopGroupCode += code;
            }
            return (loopGroup.Key, loopGroupCode);
        }
        /// <summary>
        /// 获取代码中的占位符名称集合
        /// </summary>
        protected HashSet<String> GetPlaceholderNames(String code, String symbol)
        {
            //占位符名称提取正则  例如 从 $name$  中提取 name
            Regex placeholderExtractRegex = new Regex($"(?<=\\{symbol})\\w+(?=\\{symbol})");
            HashSet<String> hashset = new HashSet<String>();
            foreach (Match match in placeholderExtractRegex.Matches(code))
            {
                String placeHolderName = null;
                placeHolderName = match.Value;
                if (!hashset.Contains(placeHolderName)) hashset.Add(placeHolderName);
            }
            return hashset;
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
