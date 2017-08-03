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
 * 本类主要用途描述：根据元数据生成对应的代码
 *  -------------------------------------------------------------------------*/
    public class CodeBuilder
    {


        protected Regex PlaceholderNameRegex = new Regex(@"(?<=\$)\w+(?=\$)");
        /// <summary>
        /// 当前在代码模板中识别并可替换的占位符名称集合
        /// </summary>
        protected virtual HashSet<String> ValidPlaceholderName { get; } = new HashSet<String>
        {
            "classname",//类名
            "namespace",//命名空间
            "fieldname",//字段名
            "propertyname",//属性名
             "columnexplain",//列描述
        };
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
        ///开始组建代码
        /// </summary>
        /// <returns>组建后的代码</returns>
        public IEnumerable<String> Building(String nameSpace = TextResources.DefaultNameSpace)
        {
            foreach (var schema in this.Schemas)
            {
                String code = this.CodeTemplate.Header;
                TableSchema tabSchema = schema.Item1;
                var tablePacketContainer = this.CreatePacketContainer(Tuple.Create("namespace", nameSpace));
                var placeholderNames = this.GetPlaceholderNames(code);


                this.PacketDataAdd(
                    tablePacketContainer,
                    Tuple.Create("classname", this.NameModifier.ModifyTableName(tabSchema.Name)));
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 获取代码中的占位符名称，小写处理
        /// </summary>
        protected IEnumerable<String> GetPlaceholderNames(String code)
        {
            foreach (Match match in this.PlaceholderNameRegex.Matches(code))
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
        #region Pakcet
        /// <summary>
        /// 生成用于存放替换占位符的数据包
        /// </summary>
        /// <returns></returns>
        protected IDictionary<String, String> CreatePacketContainer(params Tuple<String, String>[] packets)
        {
            IDictionary<String, String> container = new Dictionary<String, String>();
            this.PacketDataAdd(container, packets);
            return container;
        }
        /// <summary>
        /// 向指定数据包容器中添加数据包
        /// </summary>
        /// <param name="container">容器</param>
        /// <param name="packets">数据包</param>
        protected void PacketDataAdd(IDictionary<String, String> container, params Tuple<String, String>[] packets)
        {
            foreach (var packet in packets)
            {
                if (container.ContainsKey(packet.Item1))
                {
                    container[packet.Item1] = packet.Item2;
                    break;
                }
                container.Add(packet.Item1, packet.Item2);
            }
        }
        /// <summary>
        /// 获取指定名称数据包的数据
        /// </summary>
        /// <param name="name">名称</param>
        protected String PacketGet(IDictionary<String, String> container, String name)
        {
            String data = null;
            if (name != null && container.ContainsKey(name))
            {
                data = container[name];
            }
            return data;
        }
        #endregion
    }
}
