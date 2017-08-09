using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness;
using Handiness.Metadata;
using Handiness.CodeBuild;

namespace Handiness.VSIX
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/8/7 20:27:40
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 代码组建辅助数据包
    /// </summary>
    public class BuildAssistPacket
    {
        public IMetadataProvider MetadataProvider { get; set; }
        public TypeMapper TypeMapper { get; set; }
        public IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> Schemas { get; set; }
        public CodeTemplateXml CodeTemplate { get; set; }
        public INameModifier NameModifier { get; set; }
        public String NameSpace { get; set; }
        public String ConnectionString { get; set; }
    }
}
