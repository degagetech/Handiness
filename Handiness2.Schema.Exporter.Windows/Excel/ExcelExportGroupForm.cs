using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    public partial class ExcelExportGroupForm : Form
    {
        public ExcelExportGroupForm()
        {
            InitializeComponent();
            this._checkItemContainer.Items.Add("测试");
        }

        public void SetGroupInfo(GroupInfoCollection collection)
        {

        }
        private void _btnAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm form = new AddGroupForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this._cbGroup.Items.Add(form.GroupName);
                this._cbGroup.SelectedItem = form.GroupName;
            }
        }

        private void _btnDeleteGroup_Click(object sender, EventArgs e)
        {
            var current = this._cbGroup.SelectedItem;
            if (current != null)
            {
                this._cbGroup.Items.Remove(current);
                if (this._cbGroup.Items.Count > 0)
                {
                    this._cbGroup.SelectedIndex = 0;
                }
            }
        }
    }
}
