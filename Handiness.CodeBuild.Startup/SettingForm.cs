using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Concision;
using Handiness.CodeBuild;
namespace Handiness.CodeBuild
{
    public partial class SettingForm : BaseForm
    {
        public BuildAssistPacket BuildAssistPacket { get; set; } = new BuildAssistPacket();

        public SettingForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this._txtNameSpace.Text = "Handiness";
            Win32Utility.SetCueText(this._txtConnectionString,"请输入数据库连接字符串");
            this._txtConnectionString.Focus();
            
        }
        public SettingForm(BuildAssistPacket assistPacket) : this()
        {
            this.BuildAssistPacket = assistPacket;
            if (!String.IsNullOrEmpty(assistPacket.NameSpace))
            {
                this._txtNameSpace.Text = assistPacket.NameSpace;
            }
            if (!String.IsNullOrEmpty(assistPacket.ConnectionString))
            {
                this._txtConnectionString.Text = assistPacket.ConnectionString;
            }
        }

        private void _btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Boolean ValidatingData(String data)
        {
            return !String.IsNullOrWhiteSpace(data);
        }
        private void _txtNameSpace_Validating(object sender, CancelEventArgs e)
        {
            if (!this.ValidatingData(this._txtNameSpace.Text))
            {
                this._eprNamesapce.SetError(this._txtNameSpace, "命名空间不能为空！");
                e.Cancel = true;
            }
            else
            {
                this._eprNamesapce.SetError(this._txtNameSpace,String.Empty);
            }
        }
        private void _txtConnectionString_Validating(object sender, CancelEventArgs e)
        {
            if (!this.ValidatingData(this._txtConnectionString.Text))
            {
                this._eprConnectionString.SetError(this._txtConnectionString, "连接字符串不能为空！");
                e.Cancel = true;
            }
            else
            {
                this._eprConnectionString.SetError(this._txtConnectionString, String.Empty);
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            this._btnOk.Focus();
            this.Setting();
        }
        private void Setting()
        {
            Boolean isPassed = this.ValidateChildren();
            if (isPassed)
            {
                this.DialogResult = DialogResult.OK;
                this.BuildAssistPacket.ConnectionString = this._txtConnectionString.Text.Trim();
                this.BuildAssistPacket.NameSpace = this._txtNameSpace.Text.Trim();
                this.Close();
            }
        }
    }
}
