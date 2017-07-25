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
    * 创建时间： 2017/7/21 15:35:08
    * 版本号：v1.0
    * .NET 版本：4.0
    * 本接口规范描述：在将数据库原有名称修改为更符合编程规范的名称
    *  -------------------------------------------------------------------------*/
    /// <summary>
    /// 名称修改器接口
    /// </summary>
    public interface INameModifier
    {
        /// <summary>
        /// 修改器描述信息
        /// </summary>
        String Explain { get; }
        /// <summary>
        /// 修饰表名至符合类名称规则
        /// </summary>
        String ModifyTableName(String tableName);
        /// <summary>
        /// 修饰列名至符合类属性名称规则
        /// </summary>
        String ModifyColumnNameOfProperty(String columnName);
        /// <summary>
        ///  修饰列名至符合类字段名称规则
        /// </summary>
        String ModifyColumnNameOfField(String columnName);
    }
}
