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
        public ISchemaProvider CurrentSchemaProvider { get; private set; }


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

        }

        private void SchemaExportForm_Load(Object sender, EventArgs e)
        {
            this._colName.DataPropertyName = nameof(ColumnSchemaExtend.SourceName);
            this._colPrimary.DataPropertyName = nameof(ColumnSchemaExtend.IsPrimaryKey);
            this._cbSchemaProvider.DisplayMember = nameof(ISchemaProvider.Name);
        }

        private async void SchemaExportForm_Shown(Object sender, EventArgs e)
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
            this._dgvColumnSchema.Rows.Clear();
        }

        private Boolean GetConnectionStirng(out String connectionString)
        {
            connectionString = this._tbConnectionString.Text.Trim();
            return !String.IsNullOrEmpty(connectionString);
        }

        private Boolean _isLoadingSchemaInfo = false;
        private void LoadSchemaInfo(ISchemaProvider provider)
        {
            //加载表
            var tableList = provider.LoadTableSchemaList();
            //生成表头节点
            TreeNode node = new TreeNode();
            //加载视图
        }
        private Boolean _isConnectOperating = false;

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
                    }
                    else
                    {
                        if (this.GetConnectionStirng(out String connectionString))
                        {
                            try
                            {
                                await TaskEx.Run(() => this.CurrentSchemaProvider.Open(connectionString));
                                this.ClearSchemaInfo();
                                this._btnOpen.Image = Resources.connect_opened;
                            }
                            catch (ProviderConnectException exc)
                            {
                                MessageBox.Show($"连接打开失败！{exc.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}




