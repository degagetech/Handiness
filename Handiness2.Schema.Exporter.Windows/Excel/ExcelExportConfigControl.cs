using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class ExcelExportConfigControl : BaseExportConfigControl
    {
        public override ExportConfig ExportConfig { get => this._exportConfig; }
        public override ISchemaExporter SchemaExporter { get => this._schemaExporter; }

        private ExcelExportConfig _exportConfig;
        private ExcelSchemaExporter _schemaExporter;
        private IList<TableSchemaExtend> _checkedTableSchemas;
        public ExcelExportConfigControl()
        {
            InitializeComponent();

            _exportConfig = new ExcelExportConfig();
            _exportConfig.GroupInfo = new GroupInfoCollection();
            _schemaExporter = new ExcelSchemaExporter();
        }

        private void _checkCustomGroup_CheckedChanged(Object sender, EventArgs e)
        {
            this._pannelGroup.Enabled = this._checkCustomGroup.Checked;
            if (!this._checkCustomGroup.Checked)
            {
                this._lvGroup.Items.Clear();
                _exportConfig.GroupInfo.Clear();
            }
            else
            {
                this._checkedTableSchemas = this.SchemaExportForm.CheckedTableSchemas;
            }

        }

        private void _btnEditGroup_Click(Object sender, EventArgs e)
        {
            ExcelExportGroupForm form = new ExcelExportGroupForm();
            form.ShowDialog(this);
        }
        public override void Initialize(SchemaExportForm form)
        {
            base.Initialize(form);
            form.CheckedTableSchemaChanged += Form_CheckedTableSchemaChanged;
        }
        private void Reanalyse(IList<TableSchemaExtend> schemas)
        {
            if (this._checkedTableSchemas != null && this._lvGroup.Items.Count > 0)
            {
                HashSet<String> newItem = new HashSet<String>(schemas.Select(t => t.Name));
                foreach (var schema in this._checkedTableSchemas)
                {
                    if (!newItem.Contains(schema.Name))
                    {
                        this._lvGroup.Items.RemoveByKey(schema.Name);
                    }
                }
            }
            this._checkedTableSchemas = schemas;
        }
        private void Form_CheckedTableSchemaChanged(Object sender, IList<TableSchemaExtend> schemas)
        {
            this.Reanalyse(schemas);
        }
        private void RenderingGroupInfo()
        {
            this._lvGroup.Items.Clear();
            this._lvGroup.Groups.Clear();
            if (this._exportConfig.GroupInfo.Count > 0)
            {
                this._lvGroup.BeginUpdate();
                this._lvGroup.SuspendLayout();
                foreach (var pair in this._exportConfig.GroupInfo)
                {
                    ListViewGroup group = new ListViewGroup(pair.Key);
                    this._lvGroup.Groups.Add(group);
                    IList<String> schemaNames = pair.Value;
                    if (schemaNames != null && schemaNames.Count > 0)
                    {
                        foreach (String name in schemaNames)
                        {
                            ListViewItem item = new ListViewItem(name);
                            item.Name = name;
                            item.Group = group;
                            item.ImageIndex = 0;
                            this._lvGroup.Items.Add(item);
                        }
                    }

                }
                this._lvGroup.EndUpdate();
                this._lvGroup.ResumeLayout();
            }

        }
    }

}
