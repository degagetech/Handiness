using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Handiness2.Schema.Exporter.Windows.Properties;
namespace Handiness2.Schema.Exporter.Windows
{
    public partial class AddGroupForm : Form
    {
        /// <summary>
        /// 表示添加的组名
        /// </summary>
        public String GroupName { get; private set; }
        public AddGroupForm()
        {
            InitializeComponent();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void _btnConfirm_Click(object sender, EventArgs e)
        {
            this.GroupName = this._tbGroupName.Text.Trim();
            if (String.IsNullOrEmpty(this.GroupName))
            {
                MessageBox.Show(Resources.AddGroupForm_GroupNameCannotNull, Resources.HintText, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
         
        }

        private void AddGroupForm_Activated(object sender, EventArgs e)
        {
            this._tbGroupName.Focus();
        }
    }
}
