using Handiness2.Schema.Exporter.Windows.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Handiness2.Schema.Exporter.Windows
{
    public partial class SchemaCompareForm : BaseForm
    {
        public List<SchemaInfoTuple> SourceSchemaInfos { get; private set; }
        public List<SchemaInfoTuple> TargetSchemaInfos { get; private set; }

        public Dictionary<IObjectSchema, SchemaDifferenceType> ObjectSchemaDifferenceTable { get; private set; }

        public Dictionary<IObjectSchema, SchemaInfoTuple> TopObjectSchemaInfoTupleTable { get; private set; }

        public Dictionary<IObjectSchema, TreeNode> SourceSchemaTreeNodeTable { get; private set; }

        public Dictionary<IObjectSchema, TreeNode> TargetSchemaTreeNodeTable { get; private set; }

        public Image[] DifferenceTypeImages { get; private set; }
        public Color[] DifferenceTypeColors { get; private set; }

        private SchemaCompareForm()
        {
            InitializeComponent();
            this.Shown += SchemaCompareForm_Shown;
            this.ObjectSchemaDifferenceTable = new Dictionary<IObjectSchema, SchemaDifferenceType>();
            this.TopObjectSchemaInfoTupleTable = new Dictionary<IObjectSchema, SchemaInfoTuple>();
            this.SourceSchemaTreeNodeTable = new Dictionary<IObjectSchema, TreeNode>();
            this.TargetSchemaTreeNodeTable = new Dictionary<IObjectSchema, TreeNode>();

        }

        private void ShowTipInformation(String text = null)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = Color.White;
        }

        public SchemaCompareForm(List<SchemaInfoTuple> source, List<SchemaInfoTuple> target) : this()
        {
            this.SourceSchemaInfos = source;
            this.TargetSchemaInfos = target;
        }



        private async void SchemaCompareForm_Shown(Object sender, EventArgs e)
        {
            _imageListSourceSchemaTree.Images.Add("tree_selected", Resources.selected);
            _imageListSourceSchemaTree.Images.Add("tree_table", Resources.table);
            _imageListSourceSchemaTree.Images.Add("tree_view", Resources.view);
            _imageListSourceSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _imageListSourceSchemaTree.Images.Add("tree_function", Resources.function);


            _imageListTargetSchemaTree.Images.Add("tree_selected", Resources.selected);
            _imageListTargetSchemaTree.Images.Add("tree_table", Resources.table);
            _imageListTargetSchemaTree.Images.Add("tree_view", Resources.view);
            _imageListTargetSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _imageListTargetSchemaTree.Images.Add("tree_function", Resources.function);

            this.DifferenceTypeImages = new Image[]
            {
                Resources.difference_none,
                Resources.difference_add,
                Resources.difference_modify,
                Resources.difference_delete
            };

            this.DifferenceTypeColors = new Color[] {
                Color.FromArgb(0,180,0),
                Color.FromArgb(0,22,220),
                Color.FromArgb(216,26,0),
                Color.FromArgb(200,200,200)
            };

            /****源*****/
            this._dgvColumnSchema.AutoGenerateColumns = false;
            this._colName.DataPropertyName = nameof(ColumnSchemaExtend.Name);
            this._colPrimary.DataPropertyName = nameof(ColumnSchemaExtend.IsPrimaryKey);
            this._colType.DataPropertyName = nameof(ColumnSchemaExtend.DbTypeString);
            this._colLength.DataPropertyName = nameof(ColumnSchemaExtend.Length);
            this._colNullable.DataPropertyName = nameof(ColumnSchemaExtend.IsNullable);
            this._colExplain.DataPropertyName = nameof(ColumnSchemaExtend.Explain);

            this._dgvIndexColumnSchema.AutoGenerateColumns = false;
            this._colIndexName.DataPropertyName = nameof(IndexSchema.Name);
            this._colIndexColumnNames.DataPropertyName = nameof(IndexSchema.ColumnNames);
            this._colIndexDesc.DataPropertyName = nameof(IndexSchema.Explain);

            /****目标*****/
            this._dgvTargetColumnSchema.AutoGenerateColumns = false;
            this._colTargetName.DataPropertyName = nameof(ColumnSchemaExtend.Name);
            this._colTargetPrimary.DataPropertyName = nameof(ColumnSchemaExtend.IsPrimaryKey);
            this._colTargetType.DataPropertyName = nameof(ColumnSchemaExtend.DbTypeString);
            this._colTargetLength.DataPropertyName = nameof(ColumnSchemaExtend.Length);
            this._colTargetNullable.DataPropertyName = nameof(ColumnSchemaExtend.IsNullable);
            this._colTargetExplain.DataPropertyName = nameof(ColumnSchemaExtend.Explain);

            this._dgvTargetIndexColumnSchema.AutoGenerateColumns = false;
            this._colTargetIndexName.DataPropertyName = nameof(IndexSchema.Name);
            this._colTargetIndexColumnNames.DataPropertyName = nameof(IndexSchema.ColumnNames);
            this._colTargetIndexDesc.DataPropertyName = nameof(IndexSchema.Explain);

            //   this._dgvTargetColumnSchema.cell

            await this.CompareSchema();

        }
        public void VisibleSchemaShowInfo(Boolean isTarget = false)
        {
            if (isTarget)
            {
                this._pnlTargetColumnSchema.Visible = false;
                this._pnlTargetSchemaDefine.Visible = false;
            }
            else
            {
                this._pnlColumnSchema.Visible = false;
                this._pnlSchemaDefine.Visible = false;
            }
        }



        private SchemaDifferenceType GetSchemaDifferenceType(IObjectSchema schemaObj)
        {
            return this.ObjectSchemaDifferenceTable[schemaObj];
        }
        private async Task CompareSchema()
        {
            this.ShowTipInformation("正在比较结构的差异...");
            try
            {
                List<SchemaDifferenceInfo> differenceInfos = null;
                try
                {
                    differenceInfos = await TaskEx.Run(() => SchemaAssistor.CompareSchemaInfo(this.SourceSchemaInfos, this.TargetSchemaInfos));
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, "获取信息差异时发生错误！" + exc.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                this.ShowTipInformation("正在准备差异数据...");

                this.ObjectSchemaDifferenceTable = differenceInfos.ToDictionary(t => t.Schema, t => t.DifferenceType);

                foreach (var schema in this.SourceSchemaInfos)
                {
                    var diffenenceType = this.GetSchemaDifferenceType(schema.ObjectSchema);
                    switch (diffenenceType)
                    {
                        case SchemaDifferenceType.Delete:
                            {
                                this.TargetSchemaInfos.Add(schema);
                            }
                            break;
                    }
                }


                try
                {
                    this.RenderingSchemaTree(this.SourceSchemaInfos, this._tvSourceSchema, false);
                    this.RenderingSchemaTree(this.TargetSchemaInfos, this._tvTargetSchema, true);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, "绘制差异时发生错误！" + exc.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(this, "比较差异信息时发生错误！" + exc.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                this.ShowTipInformation();
            }
        }
        private TreeNode CreateTreeNode(IObjectSchema objectSchema)
        {
            TreeNode node = new TreeNode(objectSchema.Name);
            node.ToolTipText = objectSchema.Explain;
            node.Tag = objectSchema;
            return node;
        }

        private void AddTopSchemaTupleItem(IObjectSchema schema, SchemaInfoTuple schemaInfo)
        {
            if (!this.TopObjectSchemaInfoTupleTable.ContainsKey(schema))
            {
                this.TopObjectSchemaInfoTupleTable.Add(schema, schemaInfo);
            }
        }

        private void RenderingSchemaTree(List<SchemaInfoTuple> schemaInfos, TreeView treeView, Boolean isTarget = false)
        {

            var schemaGroups = schemaInfos.GroupBy(t => t.SchemaType);
            foreach (var group in schemaGroups)
            {
                var schemaInfoList = group.ToList();
                Int32 imageIndex = (Int32)group.Key;
                switch (group.Key)
                {
                    case SchemaType.Table:
                        {
                            TreeNode tableNodeHead = new TreeNode(Resources.SchemaExportForm_TableNodeHead);
                            tableNodeHead.ImageIndex = imageIndex;
                            treeView.Nodes.Add(tableNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                tableNodeHead.Nodes.Add(node);
                                this.AddTopSchemaTupleItem(schemaInfo.ObjectSchema, schemaInfo);
                                (isTarget ? this.TargetSchemaTreeNodeTable : this.SourceSchemaTreeNodeTable).Add(schemaInfo.ObjectSchema, node);
                            }
                        }
                        break;
                    case SchemaType.View:
                        {
                            TreeNode viewNodeHead = new TreeNode(Resources.SchemaExportForm_ViewNodeHead);
                            viewNodeHead.ImageIndex = imageIndex;
                            treeView.Nodes.Add(viewNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                viewNodeHead.Nodes.Add(node);
                                this.AddTopSchemaTupleItem(schemaInfo.ObjectSchema, schemaInfo);
                                (isTarget ? this.TargetSchemaTreeNodeTable : this.SourceSchemaTreeNodeTable).Add(schemaInfo.ObjectSchema, node);
                            }
                        }
                        break;
                    case SchemaType.Procedure:
                        {
                            TreeNode procedureNodeHead = new TreeNode(Resources.SchemaExportForm_ProcedureNodeHead);
                            procedureNodeHead.ImageIndex = imageIndex;
                            treeView.Nodes.Add(procedureNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                procedureNodeHead.Nodes.Add(node);
                                this.AddTopSchemaTupleItem(schemaInfo.ObjectSchema, schemaInfo);
                                (isTarget ? this.TargetSchemaTreeNodeTable : this.SourceSchemaTreeNodeTable).Add(schemaInfo.ObjectSchema, node);
                            }
                        }
                        break;
                    case SchemaType.Function:
                        {
                            TreeNode functionNodeHead = new TreeNode(Resources.SchemaExportForm_FunctionNodeHead);
                            functionNodeHead.ImageIndex = imageIndex;
                            treeView.Nodes.Add(functionNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                functionNodeHead.Nodes.Add(node);
                                this.AddTopSchemaTupleItem(schemaInfo.ObjectSchema, schemaInfo);
                                (isTarget ? this.TargetSchemaTreeNodeTable : this.SourceSchemaTreeNodeTable).Add(schemaInfo.ObjectSchema, node);
                            }
                        }
                        break;
                }
            }
        }

        private void _tvTargetSchema_DrawNode(Object sender, DrawTreeNodeEventArgs e)
        {
            var schema = e.Node.Tag as IObjectSchema;
            if (schema == null)
            {
                e.DrawDefault = true;
            }
            else
            {

                Graphics g = e.Graphics;
                e.DrawDefault = false;
                var differenceType = this.GetSchemaDifferenceType(schema);
                Int32 differenceTypeIndex = (Int32)differenceType;
                Font font = this._tvSourceSchema.Font;
                if (differenceType == SchemaDifferenceType.Delete)
                {
                    font = new Font(font, FontStyle.Strikeout);
                }
                Color foreColor = this.DifferenceTypeColors[differenceTypeIndex];

                var image = this.DifferenceTypeImages[differenceTypeIndex];


                RectangleF imageRect = new RectangleF(e.Bounds.X, e.Bounds.Y + (e.Bounds.Height - image.Height) / 2, image.Width, image.Height);
                Brush brush = new SolidBrush(foreColor);

                String text = schema.Name.Trim();
                SizeF textSize = g.MeasureString(text, font);
                RectangleF textRectangle = new RectangleF(imageRect.X + imageRect.Width + 2, e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2, textSize.Width, textSize.Height);

                g.DrawImage(image, imageRect);
                g.DrawString(text, font, brush, textRectangle);

                brush.Dispose();

            }
        }



        private void _tvSourceSchema_NodeMouseClick(Object sender, TreeNodeMouseClickEventArgs e)
        {
            var schemaData = e.Node.Tag as IObjectSchema;
            this.ShowSourceTopSchema(schemaData);
            //尝试获取目标结构对应的节点
            if (schemaData != null)
            {
                var targetSchemaObject = this.TargetSchemaTreeNodeTable.Keys.Where(t => t.Name == schemaData.Name).FirstOrDefault();
                if (targetSchemaObject != null)
                {
                    this._tvTargetSchema.SelectedNode = TargetSchemaTreeNodeTable[targetSchemaObject];
                    var targetSchemaData = this._tvTargetSchema.SelectedNode.Tag as IObjectSchema;
                    this.ShowTargetTopSchema(targetSchemaData);
                }
            }
            else
            {
                this.VisibleSchemaShowInfo(true);
            }

        }



        private void _tvTargetSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var schemaData = e.Node.Tag as IObjectSchema;
            this.ShowTargetTopSchema(schemaData);
            //尝试获取源结构对应的节点
            if (schemaData != null)
            {
                var sourceSchemaObject = this.SourceSchemaTreeNodeTable.Keys.Where(t => t.Name == schemaData.Name).FirstOrDefault();
                if (sourceSchemaObject != null)
                {
                    this._tvSourceSchema.SelectedNode = SourceSchemaTreeNodeTable[sourceSchemaObject];
                    var sourceSchemaData = this._tvSourceSchema.SelectedNode.Tag as IObjectSchema;
                    this.ShowSourceTopSchema(sourceSchemaData);
                }
                else
                {
                    this.VisibleSchemaShowInfo();
                }
            }
            else
            {
                this.VisibleSchemaShowInfo();
            }
        }

        private void ShowTargetTopSchema(IObjectSchema schemaData)
        {
            if (schemaData != null)
            {
                var schemaInfo = this.TopObjectSchemaInfoTupleTable[schemaData];

                switch (schemaInfo.SchemaType)
                {
                    case SchemaType.Table:
                        {
                            this._tabTargetSchemaShow.SelectedTab = this._pageTargetColumnSchema;
                            this._pnlTargetSchemaDefine.Visible = false;
                            this._pnlTargetColumnSchema.Visible = true;
                            this._dgvTargetColumnSchema.DataSource = schemaInfo.ColumnSchemas;
                            this._dgvTargetIndexColumnSchema.DataSource = schemaInfo.IndexColumnSchemas;
                        }
                        break;
                    case SchemaType.View:
                        {
                            this._pnlTargetColumnSchema.Visible = true;
                            this._pnlTargetSchemaDefine.Visible = false;
                            this._tabTargetSchemaShow.SelectedTab = this._pageTargetColumnSchema;
                            this._dgvTargetColumnSchema.DataSource = schemaInfo.ColumnSchemas;
                            this._dgvTargetIndexColumnSchema.DataSource = null;
                        }
                        break;
                    case SchemaType.Procedure:
                        {
                            this._pnlTargetColumnSchema.Visible = false;
                            this._pnlTargetSchemaDefine.Visible = true;
                            this._tabTargetSchemaShow.SelectedTab = this._pageTargetDefine;
                            this._richTbTargetSchemaDefine.Text = ((ProcedureSchema)schemaData).Definition;
                            var differenceType = this.GetSchemaDifferenceType(schemaData);
                            Int32 differenceTypeIndex = (Int32)differenceType;
                            Color foreColor = this.DifferenceTypeColors[differenceTypeIndex];
                            this._richTbTargetSchemaDefine.ForeColor = foreColor;
                            if (differenceType == SchemaDifferenceType.Delete)
                            {
                                this._richTbTargetSchemaDefine.Font = new Font(
                                    this._richTbTargetSchemaDefine.Font.FontFamily,
                                      this._richTbTargetSchemaDefine.Font.Size,
                                       FontStyle.Strikeout
                                    );
                            }
                        }
                        break;
                    case SchemaType.Function:
                        {
                            this._pnlTargetColumnSchema.Visible = false;
                            this._pnlTargetSchemaDefine.Visible = true;
                            this._tabTargetSchemaShow.SelectedTab = this._pageTargetDefine;
                            this._richTbTargetSchemaDefine.Text = ((FunctionSchema)schemaData).Definition;

                            var differenceType = this.GetSchemaDifferenceType(schemaData);
                            Int32 differenceTypeIndex = (Int32)differenceType;
                            Color foreColor = this.DifferenceTypeColors[differenceTypeIndex];
                            this._richTbTargetSchemaDefine.ForeColor = foreColor;
                            if (differenceType == SchemaDifferenceType.Delete)
                            {
                                this._richTbTargetSchemaDefine.Font = new Font(
                                    this._richTbTargetSchemaDefine.Font.FontFamily,
                                      this._richTbTargetSchemaDefine.Font.Size,
                                       FontStyle.Strikeout
                                    );
                            }
                        }
                        break;
                }
            }
            else
            {
                this.VisibleSchemaShowInfo(true);
            }
        }
        private void ShowSourceTopSchema(IObjectSchema schemaData)
        {
            if (schemaData != null)
            {

                var schemaInfo = this.TopObjectSchemaInfoTupleTable[schemaData];

                switch (schemaInfo.SchemaType)
                {
                    case SchemaType.Table:
                        {
                            this._tabSchemaShow.SelectedTab = this._pageColumnSchema;
                            this._pnlSchemaDefine.Visible = false;
                            this._pnlColumnSchema.Visible = true;
                            this._dgvColumnSchema.DataSource = schemaInfo.ColumnSchemas;
                            this._dgvIndexColumnSchema.DataSource = schemaInfo.IndexColumnSchemas;
                        }
                        break;
                    case SchemaType.View:
                        {
                            this._pnlColumnSchema.Visible = true;
                            this._pnlSchemaDefine.Visible = false;
                            this._tabSchemaShow.SelectedTab = this._pageColumnSchema;
                            this._dgvColumnSchema.DataSource = schemaInfo.ColumnSchemas;
                            this._dgvIndexColumnSchema.DataSource = null;
                        }
                        break;
                    case SchemaType.Procedure:
                        {
                            this._pnlColumnSchema.Visible = false;
                            this._pnlSchemaDefine.Visible = true;
                            this._tabSchemaShow.SelectedTab = this._pageDefine;
                            this._richTbSchemaDefine.Text = ((ProcedureSchema)schemaData).Definition;
                        }
                        break;
                    case SchemaType.Function:
                        {
                            this._pnlColumnSchema.Visible = false;
                            this._pnlSchemaDefine.Visible = true;
                            this._tabSchemaShow.SelectedTab = this._pageDefine;
                            this._richTbSchemaDefine.Text = ((FunctionSchema)schemaData).Definition;
                        }
                        break;
                }
            }
            else
            {
                this.VisibleSchemaShowInfo();
            }
        }


        private void _dgvTargetColumnSchema_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var schema = this._dgvTargetColumnSchema.Rows[e.RowIndex].DataBoundItem as IObjectSchema;
            if (schema != null)
            {
                var differenceType = this.GetSchemaDifferenceType(schema);
                Int32 differenceTypeIndex = (Int32)differenceType;
                Color forceColor = this.DifferenceTypeColors[differenceTypeIndex];
                e.CellStyle.ForeColor = forceColor;
                if (differenceType == SchemaDifferenceType.Delete)
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
                }
                if (e.ColumnIndex == this._colDifferenceType.Index)
                {
                    e.Value = this.DifferenceTypeImages[differenceTypeIndex];
                }
            }
        }

        private void _dgvTargetIndexColumnSchema_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            var schema = this._dgvTargetIndexColumnSchema.Rows[e.RowIndex].DataBoundItem as IObjectSchema;
            if (schema != null)
            {
                var differenceType = this.GetSchemaDifferenceType(schema);
                Int32 differenceTypeIndex = (Int32)differenceType;
                Color forceColor = this.DifferenceTypeColors[differenceTypeIndex];
                e.CellStyle.ForeColor = forceColor;
                if (differenceType == SchemaDifferenceType.Delete)
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
                }
                if (e.ColumnIndex == this._colDifferenceType.Index)
                {
                    e.Value = this.DifferenceTypeImages[differenceTypeIndex];
                }
            }
        }
    }
}
