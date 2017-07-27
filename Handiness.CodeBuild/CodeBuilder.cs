using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handiness.Metadata;
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
        private IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> _schemas;
        private INameModifier _nameModifier;
        private TypeMapper _typeMapper;
        private CodeTemplateXml _codeTemplate;

        public CodeBuilder(IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas,
            INameModifier nameModifier,
            TypeMapper typeMapper,
            CodeTemplateXml codeTemplate
            )
        {

        }
    }
}
