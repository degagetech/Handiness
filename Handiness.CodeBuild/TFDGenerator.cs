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




        public INameModifier NameModifier { get; private set; }
        public TypeMapper TypeMapper { get; private set; }
        protected DataTable _dataTable;
        private IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas;
        private string nameSpace;

        public TFDGenerator(INameModifier nameModifier, TypeMapper typeMapper)
        {
            this._dataTable = new DataTable();
            this.NameModifier = nameModifier;
            this.TypeMapper = typeMapper;

            DataColumn placeholderNameCol = new DataColumn(TFDColumnWithPlaceholderName, typeof(String));
            DataColumn tableNameCol = new DataColumn(TFDColumnWithTableName, typeof(String));
            DataColumn colNameCol = new DataColumn(TFDColumnWithColumnName, typeof(String));
            DataColumn fillDataCol = new DataColumn(TFDColumnWithData, typeof(String));

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
        public TFDGenerator(IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> schemas,
            String nameSpace,
            INameModifier nameModifier,
            TypeMapper typeMapper) : this(nameModifier, typeMapper)
        {
            this.Initialize(schemas, nameSpace);
        }

        public TFDGenerator(IEnumerable<Tuple<TableSchema, IEnumerable<ColumnSchema>>> schemas, string nameSpace, INameModifier nameModifier, TypeMapper typeMapper)
        {
            this.schemas = schemas;
            this.nameSpace = nameSpace;
            NameModifier = nameModifier;
            TypeMapper = typeMapper;
        }

        public void Initialize(IEnumerable<(TableSchema TableSchema, IEnumerable<ColumnSchema> ColumnSchemas)> schemas, String nameSpace)
        {
            this._dataTable.Rows.Clear();

 

            foreach (var schema in schemas)
            {
                //添加名称空间列
                this.CreateFillDataRow(PlaceHolderRecognizableCollection.NameSpace, nameSpace, schema.TableSchema.Name, null, true);
                this.CreateFillDataRow(
                    PlaceHolderRecognizableCollection.TableName,
                    schema.TableSchema.Name,
                    schema.TableSchema.Name, null, true);
                this.CreateFillDataRow(PlaceHolderRecognizableCollection.ClassName,
                    this.NameModifier.ModifyTableName(schema.TableSchema.Name),
                    schema.TableSchema.Name, null, true);
                this.CreateFillDataRow(PlaceHolderRecognizableCollection.TableExplain, schema.TableSchema.Explain, schema.TableSchema.Name, null, true);
                foreach (var colSchema in schema.ColumnSchemas)
                {
                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.ColumnName, colSchema.Name, schema.TableSchema.Name, colSchema.Name, true);
                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.ColumnExplain, colSchema.Explain, schema.TableSchema.Name, colSchema.Name, true);
                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.ColumnLength, colSchema.Length, schema.TableSchema.Name, colSchema.Name, true);
                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.ColumnType, colSchema.Type, schema.TableSchema.Name, colSchema.Name, true);

                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.FieldName, this.NameModifier.ModifyColumnNameOfField(colSchema.Name), schema.TableSchema.Name, colSchema.Name, true);
                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.PropertyName, this.NameModifier.ModifyColumnNameOfProperty(colSchema.Name), schema.TableSchema.Name, colSchema.Name, true);

                    this.CreateFillDataRow(PlaceHolderRecognizableCollection.MappingType, this.TypeMapper.Mapping(colSchema.Type, colSchema.Length), schema.TableSchema.Name, colSchema.Name, true);
                }
            }

        }
        /// <summary>
        /// 创建包含填充数据的行
        /// </summary>
        /// <param name="placeHolderName">占位符名称</param>
        /// <param name="fillData">数据</param>
        /// <param name="table">表名</param>
        /// <param name="col">列名</param>
        /// <param name="add">是否直接添加到表中</param>
        public DataRow CreateFillDataRow(String placeHolderName, String fillData, String table, String col, Boolean add = false)
        {
            DataRow row = null;

            fillData = fillData ?? placeHolderName;

            row = this._dataTable.NewRow();
            row[TFDColumnWithPlaceholderName] = placeHolderName;
            row[TFDColumnWithData] = fillData;
            if (table != null) row[TFDColumnWithTableName] = table;
            if (col != null) row[TFDColumnWithColumnName] = col;
            if (add) this._dataTable.Rows.Add(row);

            return row;
        }
        /// <summary>
        /// 获取指定占位符名称对应的填充数据，若无返回 null，若含有多条则只返回第一条（完整设置限制后只会对应一条）
        /// </summary>
        /// <param name="placeholderName">占位符名称</param>
        /// <param name="restrictionsOfTab">指定表限制</param>
        /// <param name="restrictionsOfCol">指定列限制</param>
        public String GetFillData(String placeholderName, String restrictionsOfCol = null, String restrictionsOfTab = null)
        {
            String fillData = null;
            String where = $"{TFDColumnWithPlaceholderName}='{placeholderName}'";
            if (restrictionsOfCol != null) where +=  $" and {TFDColumnWithColumnName}='{restrictionsOfCol}'";
            if (restrictionsOfTab != null) where += $" and {TFDColumnWithTableName}='{restrictionsOfTab}'";
            DataRow[] rows = this._dataTable.Select(where);
            if (rows.Length > 0)
            {
                fillData = rows[0][TFDColumnWithData] as String;
            }
            return fillData;
        }
    }
}
