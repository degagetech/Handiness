using Microsoft.Data.ConnectionUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Handiness2.Schema;
using System.Threading.Tasks;
using Handiness2.Schema.Exporter.Windows.Properties;
namespace Handiness2.Schema.Exporter.Windows
{
    public partial class SchemaExportForm : Form
    {
        public event Action<Object, IList<TableSchemaExtend>> CheckedTableSchemaChanged;

        public ISchemaProvider CurrentSchemaProvider { get; private set; }
        public TreeNode TableNodeHead { get; private set; }
        public TreeNode ViewNodeHead { get; private set; }

        public Dictionary<String, SchemaInfoTuple> _schemaInfoTable = new Dictionary<String, SchemaInfoTuple>();

        public IList<TableSchemaExtend> CheckedTableSchemas { get; private set; }


        // private Boolean _isExporting = false;

        public SchemaExportForm()
        {
            InitializeComponent();
        }

        private void _btnEditorConnectionString_Click(Object sender, EventArgs e)
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

        private void SchemaExportForm_HelpButtonClicked(Object sender, CancelEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WangLangJing/Handiness");
        }

        private void SchemaExportForm_Load(Object sender, EventArgs e)
        {
            this._dgvColumnSchema.AutoGenerateColumns = false;
            this._colName.DataPropertyName = nameof(ColumnSchemaExtend.Name);
            this._colPrimary.DataPropertyName = nameof(ColumnSchemaExtend.IsPrimaryKey);
            this._colType.DataPropertyName = nameof(ColumnSchemaExtend.DbTypeString);
            this._colLength.DataPropertyName = nameof(ColumnSchemaExtend.Length);
            this._colNullable.DataPropertyName = nameof(ColumnSchemaExtend.IsNullable);
            this._colExplain.DataPropertyName = nameof(ColumnSchemaExtend.Explain);

            this._cbSchemaProvider.DisplayMember = nameof(ISchemaProvider.Name);
            _iListSchemaTree.Images.Add("tree_table", Resources.table);
            _iListSchemaTree.Images.Add("tree_view", Resources.view);


        }

        private async void SchemaExportForm_Shown(Object sender, EventArgs e)
        {
            await this.LoadSchemaProvider();
            this._ctlExcelConfig.Initialize(this);
            this._ctlExcelConfig.SchemaExporter.ExportProgressChanged += SchemaExporter_ExportProgressChanged;
        }

        private void SchemaExporter_ExportProgressChanged(Object sender, SchemaExportEventArgs e)
        {

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
        private void ClearSchemaInfo()
        {
            this._tvSchema.Nodes.Clear();
            this.TableNodeHead = null;
            this.ViewNodeHead = null;
            this._dgvColumnSchema.DataSource = null;
            this._schemaInfoTable.Clear();
        }

        private Boolean GetConnectionStirng(out String connectionString)
        {
            connectionString = this._tbConnectionString.Text.Trim();
            return !String.IsNullOrEmpty(connectionString);
        }

        private Boolean _isLoadingSchemaInfo = false;
        private async Task LoadSchemaInfo(ISchemaProvider provider)
        {
            if (this._isLoadingSchemaInfo) return;

            _isLoadingSchemaInfo = true;
            try
            {
                this.ClearSchemaInfo();

                var tableSchemaList = await TaskEx.Run(() => provider.LoadTableSchemaList());
                if (tableSchemaList.Count > 0)
                {

                    TreeNode tableNodeHead = new TreeNode(Resources.SchemaExportForm_TableNodeHead);
                    tableNodeHead.ImageIndex = 0;
                    this._tvSchema.Nodes.Add(tableNodeHead);
                    this.TableNodeHead = tableNodeHead;
                    foreach (var tableSchema in tableSchemaList)
                    {
                        var node = this.CreateTreeNode(tableSchema);
                        node.ImageIndex = 0;
                        tableNodeHead.Nodes.Add(node);
                        this._schemaInfoTable.Add(tableSchema.Name, new SchemaInfoTupleEx
                        {
                            TableSchema = tableSchema
                        });
                    }
                }


                var viewSchemaList = await TaskEx.Run(() => provider.LoadViewSchemaList());
                if (viewSchemaList.Count > 0)
                {
                    TreeNode viewNodeHead = new TreeNode(Resources.SchemaExportForm_ViewNodeHead);
                    viewNodeHead.ImageIndex = 1;
                    this._tvSchema.Nodes.Add(viewNodeHead);
                    this.ViewNodeHead = viewNodeHead;
                    foreach (var viewSchema in viewSchemaList)
                    {
                        var node = this.CreateTreeNode(viewSchema);
                        node.ImageIndex = 1;
                        viewNodeHead.Nodes.Add(node);
                        this._schemaInfoTable.Add(viewSchema.Name, new SchemaInfoTupleEx
                        {
                            TableSchema = viewSchema
                        });
                    }
                }
            }
            finally
            {
                _isLoadingSchemaInfo = false;
            }
        }
        private Boolean _isConnectOperating = false;

        private TreeNode CreateTreeNode(TableSchemaExtend tableSchema)
        {
            TreeNode node = new TreeNode(tableSchema.Name);
            node.ToolTipText = tableSchema.Explain;
            node.Tag = tableSchema;
            return node;
        }
        private async void _btnOpen_Click(object sender, EventArgs e)
        {
            if (this.CurrentSchemaProvider != null)
            {
                if (_isConnectOperating) return;
                _isConnectOperating = true;
                try
                {
                    if (this.CurrentSchemaProvider.Opened)
                    {
                        this.CurrentSchemaProvider.Close();
                        this._btnOpen.Image = Resources.connnect_closed;
                        this.ClearSchemaInfo();
                    }
                    else
                    {
                        if (this.GetConnectionStirng(out String connectionString))
                        {
                            try
                            {
                                this._waitConnect.Visible = true;
                                this._waitConnect.IsRolled = true;
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
                    }
                }
                finally
                {
                    _isConnectOperating = false;
                }
            }
        }

        private void _tvSchema_AfterCheck(object sender, TreeViewEventArgs e)
        {

            this._tvSchema.AfterCheck -= _tvSchema_AfterCheck;
            var node = e.Node;
            if (node.Parent != null)
            {
                if (node.Checked)
                {
                    node.Parent.Checked = true;
                }
            }
            else
            {
                if (node.Nodes != null)
                {
                    foreach (TreeNode cn in node.Nodes)
                    {
                        if (cn.Checked != node.Checked)
                        {
                            cn.Checked = node.Checked;
                        }

                    }
                }
            }
            this.RaiseCheckedTableSchemaChanged();
            this._tvSchema.AfterCheck += _tvSchema_AfterCheck;
        }
        public IList<TableSchemaExtend> GetCheckedNodesData()
        {
            IList<TableSchemaExtend> schemas = new List<TableSchemaExtend>();
            if (this.TableNodeHead != null)
            {
                foreach (TreeNode node in this.TableNodeHead.Nodes)
                {
                    if (node.Checked)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        schemas.Add(schema);
                    }

                }
            }
            if (this.ViewNodeHead != null)
            {
                foreach (TreeNode node in this.ViewNodeHead.Nodes)
                {
                    if (node.Checked)
                    {
                        var schema = node.Tag as TableSchemaExtend;
                        schemas.Add(schema);
                    }
                }
            }

            return schemas;
        }
        private void RaiseCheckedTableSchemaChanged()
        {
            var schemas = this.GetCheckedNodesData();
            this.CheckedTableSchemaChanged?.Invoke(this, schemas);
        }
        private Boolean _isLoadColumnSchema = false;
        private async void _tvSchema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (_isLoadColumnSchema) return;
            _isLoadColumnSchema = true;
            try
            {
                var node = e.Node;
                if (node.Parent != null)
                {
                    var schema = e.Node.Tag as TableSchemaExtend;
                    var schemaInfo = this._schemaInfoTable[schema.Name];
                    Boolean needLoad = schemaInfo.ColumnSchems == null;

                    //加载表结构信息
                    if (needLoad)
                    {
                        _waitColumnSchemaLoad.IsRolled = true;
                        _waitColumnSchemaLoad.Visible = true;

                        try
                        {
                            if (node.Parent == this.TableNodeHead)
                            {
                                schemaInfo.ColumnSchems = await TaskEx.Run(() => this.CurrentSchemaProvider.LoadColumnSchemaList(schema.Name));
                            }
                            else
                            {
                                schemaInfo.ColumnSchems = await TaskEx.Run(() => this.CurrentSchemaProvider.LoadViewColumnSchemaList(schema.Name));
                            }
                        }
                        finally
                        {
                            _waitColumnSchemaLoad.IsRolled = false;
                            _waitColumnSchemaLoad.Visible = false;
                        }


                    }
                    this._dgvColumnSchema.DataSource = schemaInfo.ColumnSchems;
                }
            }
            finally
            {
                _isLoadColumnSchema = false;
            }

        }
    }
    public class SchemaInfoTupleEx : SchemaInfoTuple
    {
        public Boolean Selected { get; set; }
    }
}

