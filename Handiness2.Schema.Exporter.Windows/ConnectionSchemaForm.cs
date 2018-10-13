using Handiness2.Schema.Exporter.Windows.Properties;
using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class ConnectionSchemaForm : BaseForm
    {
        /// <summary>
        /// 是否可以继续比较操作
        /// </summary>
        public Boolean CanContinue { get; set; }
        public List<SchemaInfoTuple> SchemaInfoTuples
        {
            get
            {
                return _schemaInfoTable.Values.ToList();
            }
        }
        public ISchemaProvider CurrentSchemaProvider { get; private set; }

        private Boolean _isConnectOperating = false;

        public Dictionary<Object, SchemaInfoTuple> _schemaInfoTable = new Dictionary<Object, SchemaInfoTuple>();

        private Boolean _isLoadingSchemaInfo = false;

        public ConnectionSchemaForm()
        {
            InitializeComponent();
        }


        private void ShowTipInformation(String text = null)
        {
            this._labelTipInfo.Text = text;
            this._labelTipInfo.ForeColor = Color.White;
        }

        private void _btnEditorConnectionString_Click(object sender, EventArgs e)
        {
            String connectionString = this.BuildDbConnectionString();
            if (!String.IsNullOrEmpty(connectionString))
            {
                this._tbConnectionString.Text = connectionString;
            }
        }

        private String BuildDbConnectionString()
        {
            String connectionString = null;
            using (var dialog = new DataConnectionDialog())
            {

                DataSource.AddStandardDataSources(dialog);
                dialog.DataSources.Add(DataSource.SqlDataSource);
                dialog.DataSources.Add(DataSource.SqlFileDataSource);
                dialog.DataSources.Add(DataSource.OracleDataSource);

                DialogResult userChoice = DataConnectionDialog.Show(dialog);
                if (userChoice == DialogResult.OK)
                {
                    connectionString = dialog.ConnectionString;
                }
            }
            return connectionString;
        }

        private async void _btnOpen_Click(object sender, EventArgs e)
        {
            await this.SwitchConnectState();
        }
        private void CloseConnection()
        {
            this.CurrentSchemaProvider.Close();
            this._toolTip.SetToolTip(this._btnOpen, "打开连接");
            this._btnOpen.Image = Resources.connnect_closed;

        }
        private void ClearSchemaInfo()
        {
            this._tvSchema.Nodes.Clear();
            this._dgvColumnSchema.DataSource = null;
            this._schemaInfoTable.Clear();
        }
        private async Task SwitchConnectState()
        {
            if (this.CurrentSchemaProvider != null)
            {
                if (_isConnectOperating) return;
                _isConnectOperating = true;
                try
                {
                    if (this.CurrentSchemaProvider.Opened)
                    {
                        this.CloseConnection();
                        this.ClearSchemaInfo();
                    }
                    else
                    {
                        if (this.GetConnectionStirng(out String connectionString))
                        {
                            await this.OpenConnection(connectionString);
                        }
                    }
                }
                finally
                {
                    _isConnectOperating = false;
                }
            }
        }


        private async Task LoadSchemaInfo(ISchemaProvider provider)
        {
            if (this._isLoadingSchemaInfo) return;

            _isLoadingSchemaInfo = true;
            try
            {
                List<SchemaInfoTuple> schemaInfos = new List<SchemaInfoTuple>();
                //加载表结构信息
                #region Load Table 
                this.ShowTipInformation("正在加载表信息...");
                var tableSchemaList = await TaskEx.Run(() => provider.LoadTableSchemaList());
                if (tableSchemaList.Count > 0)
                {
                    foreach (var tableSchema in tableSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            ObjectSchema = tableSchema,
                            SchemaType = SchemaType.Table
                        });
                    }
                }
                #endregion

                //加载视图信息
                #region Load View
                this.ShowTipInformation("正在加载视图信息...");
                var viewSchemaList = await TaskEx.Run(() => provider.LoadViewSchemaList());
                if (viewSchemaList.Count > 0)
                {
                    foreach (var viewSchema in viewSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            ObjectSchema = viewSchema,
                            SchemaType = SchemaType.View
                        });
                    }
                }
                #endregion

                //加载存储过程
                #region Load Procedure
                this.ShowTipInformation("正在加载视图信息...");
                var procedureSchemaList = await TaskEx.Run(() => provider.LoadProcedureSchemaList());
                if (procedureSchemaList.Count > 0)
                {
                    foreach (var procedureSchema in procedureSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            ObjectSchema = procedureSchema,
                            SchemaType = SchemaType.Procedure
                        });
                    }
                }
                #endregion

                //加载函数
                #region Load Function
                this.ShowTipInformation("正在加载视图信息...");
                var functionSchemaList = await TaskEx.Run(() => provider.LoadFunctionSchemaList());
                if (functionSchemaList.Count > 0)
                {
                    foreach (var functionSchema in functionSchemaList)
                    {
                        schemaInfos.Add(new SchemaInfoTuple
                        {
                            ObjectSchema = functionSchema,
                            SchemaType = SchemaType.Function

                        });
                    }
                }
                #endregion

                this.ShowSchemaInfoTuples(schemaInfos);
                this.ShowTipInformation("结构信息加载完毕！");
            }
            finally
            {
                _isLoadingSchemaInfo = false;
            }
        }
        public void ShowSchemaInfoTuples(List<SchemaInfoTuple> schemaInfos)
        {
            this.ClearSchemaInfo();

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
                            this._tvSchema.Nodes.Add(tableNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                tableNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.ObjectSchema, schemaInfo);
                            }
                        }
                        break;
                    case SchemaType.View:
                        {
                            TreeNode viewNodeHead = new TreeNode(Resources.SchemaExportForm_ViewNodeHead);
                            viewNodeHead.ImageIndex = imageIndex;
                            this._tvSchema.Nodes.Add(viewNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                viewNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.ObjectSchema, schemaInfo);
                            }
                        }
                        break;
                    case SchemaType.Procedure:
                        {
                            TreeNode procedureNodeHead = new TreeNode(Resources.SchemaExportForm_ProcedureNodeHead);
                            procedureNodeHead.ImageIndex = imageIndex;
                            this._tvSchema.Nodes.Add(procedureNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                procedureNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.ObjectSchema, schemaInfo);
                            }
                        }
                        break;
                    case SchemaType.Function:
                        {
                            TreeNode functionNodeHead = new TreeNode(Resources.SchemaExportForm_FunctionNodeHead);
                            functionNodeHead.ImageIndex = imageIndex;
                            this._tvSchema.Nodes.Add(functionNodeHead);
                            foreach (var schemaInfo in schemaInfoList)
                            {
                                var node = this.CreateTreeNode(schemaInfo.ObjectSchema);
                                node.ImageIndex = imageIndex;
                                functionNodeHead.Nodes.Add(node);
                                this._schemaInfoTable.Add(schemaInfo.ObjectSchema, schemaInfo);
                            }
                        }
                        break;
                }
            }
        }
        private TreeNode CreateTreeNode(IObjectSchema objectSchema)
        {
            TreeNode node = new TreeNode(objectSchema.Name);
            node.ToolTipText = objectSchema.Explain;
            node.Tag = objectSchema;
            return node;
        }

        private async Task OpenConnection(String connectionString)
        {
            try
            {
                this._waitConnect.Visible = true;
                this._waitConnect.IsRolled = true;
                this._toolTip.SetToolTip(this._btnOpen, "关闭连接");
                await TaskEx.Run(() => this.CurrentSchemaProvider.Open(connectionString));
                await this.LoadSchemaInfo(this.CurrentSchemaProvider);
                this._btnOpen.Image = Resources.connect_opened;
            }
            catch (ProviderConnectException exc)
            {
                MessageBox.Show(String.Format(Resources.SchemaExportForm_ConnectException, exc.Message), Resources.HintText, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this._waitConnect.Visible = false;
                this._waitConnect.IsRolled = false;
            }
        }

        private Boolean GetConnectionStirng(out String connectionString)
        {
            connectionString = this._tbConnectionString.Text.Trim();
            return !String.IsNullOrEmpty(connectionString);
        }

        private void ConnectionSchemaForm_Load(object sender, EventArgs e)
        {
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


            this._cbSchemaProvider.DisplayMember = nameof(ISchemaProvider.Name);

            //树状图的类型图像
            _iListSchemaTree.Images.Add("tree_selected", Resources.selected);
            _iListSchemaTree.Images.Add("tree_table", Resources.table);
            _iListSchemaTree.Images.Add("tree_view", Resources.view);
            _iListSchemaTree.Images.Add("tree_procedure", Resources.procedure);
            _iListSchemaTree.Images.Add("tree_function", Resources.function);
        }

        private async void ConnectionSchemaForm_Shown(object sender, EventArgs e)
        {
            await this.LoadSchemaProvider();
        }

        private async Task LoadSchemaProvider()
        {
            this._waitSchemProvider.Visible = true;


            this._waitSchemProvider.IsRolled = true;
            try
            {
                ProviderFactory factory = new ProviderFactory();
                var providers = await TaskEx.Run(() => factory.LoadSchemProviders());
                if (providers.Count > 0)
                {
                    this._cbSchemaProvider.DataSource = providers;
                }
            }
            finally
            {
                this._waitSchemProvider.IsRolled = false;
                this._waitSchemProvider.Visible = false;
            }
        }

        private Boolean _isLoadingColumnSchema = false;

        private async Task CompleteSchema(SchemaInfoTuple schemaInfo)
        {
            this.ShowTipInformation($"正在补全 [{schemaInfo.ObjectSchema.Name}] 的结构信息...");
            await TaskEx.Run(() =>
            {
                SchemaAssistor.CompleteSchema(this.CurrentSchemaProvider, schemaInfo);
            });
            this.ShowTipInformation();
        }

        private async void _tvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isLoadingColumnSchema) return;
            this._isLoadingColumnSchema = true;
            this._tvSchema.Enabled = false;
            try
            {
                var node = e.Node;
                if (node.Parent != null)
                {

                    var schemaData = e.Node.Tag as IObjectSchema;
                    var schemaInfo = this._schemaInfoTable[schemaData];
                    if (SchemaAssistor.IsRequiredCompleteSchema(schemaInfo))
                    {
                        _waitColumnSchemaLoad.IsRolled = true;
                        _waitColumnSchemaLoad.Visible = true;
                        try
                        {
                            await this.CompleteSchema(schemaInfo);

                        }
                        finally
                        {
                            _waitColumnSchemaLoad.IsRolled = false;
                            _waitColumnSchemaLoad.Visible = false;
                        }

                    }

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
            }
            finally
            {
                _isLoadingColumnSchema = false;
                this._tvSchema.Enabled = true;
            }

        }
        private void EnableContol(Boolean enabled)
        {
            this._btnCompare.Enabled = enabled;
            this._btnCannel.Enabled = enabled;
            this._btnOpen.Enabled = enabled;
            this._tvSchema.Enabled = enabled;
            this._dgvColumnSchema.Enabled = enabled;
            this._cbSchemaProvider.Enabled = enabled;
        }

        private async void _btnCompare_Click(object sender, EventArgs e)
        {
            if (this._schemaInfoTable.Count <= 0)
            {
                this.CanContinue = false;
                MessageBox.Show(this, "当前尚未加载结构信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.EnableContol(false);
            try
            {
                //补全所有尚未获取的元数据信息
                IList<SchemaInfoTuple> schemaInfos = this._schemaInfoTable.Values.ToList();
                foreach (var schemaInfo in schemaInfos)
                {
                    if (SchemaAssistor.IsRequiredCompleteSchema(schemaInfo))
                    {
                        this.ShowTipInformation(String.Format("正在补全 [{0}] 的结构信息...", schemaInfo.ObjectSchema.Name));
                        await this.CompleteSchema(schemaInfo);
                    }
                }
                var dialogResult = MessageBox.Show(this, "信息补全完成，是否开始比较？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
                this.CanContinue = true;
                this.Close();
            }
            catch (Exception exc)
            {
                this.CanContinue = false;
                MessageBox.Show(this, "补全目标结构信息时发生异常，操作已停止！" + exc.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.EnableContol(true);
            }
        }

        private void ConnectionSchemaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CurrentSchemaProvider?.Close();
        }

        private void _cbSchemaProvider_SelectedValueChanged(object sender, EventArgs e)
        {
            ISchemaProvider provider = this._cbSchemaProvider.SelectedValue as ISchemaProvider;
            if (provider != null)
            {
                if (this.CurrentSchemaProvider != null && this.CurrentSchemaProvider.Opened)
                {
                    this.CurrentSchemaProvider.Close();
                    this._btnOpen.Image = Resources.connnect_closed;
                    this.ClearSchemaInfo();
                }
                this._labelProviderExplain.Text = provider.Explain;
                this.CurrentSchemaProvider = provider;
            }
        }
    }
}
