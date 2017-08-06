using Handiness.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Handiness.CodeBuild
{
    /*-------------------------------------------------------------------------
 * 版权所有：王浪静
 * 作者：王浪静
 * 联系方式：932444208@qq.com
 * 创建时间： 2017/8/5 21:02:21
 * 版本号：v1.0
 * .NET 版本：4.0
 * 本类主要用途描述：
 *  -------------------------------------------------------------------------*/
    /// <summary>
    ///模板填充数据生成器 （Template Filled Data Generator）  用于从Schema信息中获取生成替换模板占位符的数据
    /// </summary>
    public class TFDGenerator
    {
        #region DataColumnName
        /// <summary>
        /// 模板填充数据列-占位符名称
        /// </summary>
        private const String TFDColumnWithPlaceholderName = "PlaceholderName";
        /// <summary>
        ///  模板填充数据列-表名称
        /// </summary>
        private const String TFDColumnWithTableName = "TableName";
        /// <summary>
        /// 模板填充数据列-列名称
        /// </summary>
        private const String TFDColumnWithColumnName = "ColumnName";
        /// <summary>
        /// 模板填充数据列-数据
        /// </summary>
        private const String TFDColumnWithData = "FillData";
        #endregion

        protected DataTable _dataTable;
        public TFDGenerator(IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas, String namesapce)
        {
            this._dataTable = new DataTable();

            DataColumn placeholderNameCol = new DataColumn(TFDGenerator.TFDColumnWithPlaceholderName, typeof(String));
            DataColumn tableNameCol = new DataColumn(TFDGenerator.TFDColumnWithTableName, typeof(String));
            DataColumn colNameCol = new DataColumn(TFDGenerator.TFDColumnWithColumnName, typeof(String));
            DataColumn fillDataCol = new DataColumn(TFDGenerator.TFDColumnWithData, typeof(String));

            this._dataTable.Columns.AddRange(
                        new DataColumn[]
                        {
                            placeholderNameCol,
                            tableNameCol,
                            colNameCol,
                            fillDataCol
                        }
                );


        }
        public void Initialize(IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas, String namesapce)
        {
            this._dataTable.Rows.Clear();
        }

        /// <summary>
        /// 获取指定占位符名称对应的填充数据，若无返回 null，若含有多条则只返回第一条（完整设置限制后只会对应一条）
        /// </summary>
        /// <param name="placeholderName">占位符名称</param>
        /// <param name="restrictionsOfTab">指定表限制</param>
        /// <param name="restrictionsOfCol">指定列限制</param>
        /// <returns></returns>
        public String GetFillData(String placeholderName, String restrictionsOfCol = null, String restrictionsOfTab = null)
        {
            String fillData = null;
            return fillData;
        }
    }
}
