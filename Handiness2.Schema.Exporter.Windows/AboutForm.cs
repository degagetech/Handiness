using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace Handiness2.Schema.Exporter.Windows
{
    public partial class AboutForm : BaseForm
    {
        [DllImport("shell32.dll", EntryPoint = "ShellExecuteA")]
        public static extern int ShellExecute(
            int hwnd,
            String lpOperation,
            String lpFile,
            String lpParameters,
            String lpDirectory,
            int nShowCmd
    );
        public AboutForm()
        {
            InitializeComponent();
        }

        private void _lblGitHub_Click(object sender, EventArgs e)
        {
            Process.Start(this._lblGitHub.Text);
        }

        private void _lblEmail_Click(object sender, EventArgs e)
        {
            ShellExecute(0, String.Empty, $"mailto:{this._lblEmail.Text}", String.Empty, String.Empty, 1);
        }
    }
}
