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
    public partial class BaseForm : Form
    {
        public Boolean BusyingFlag { get; private set; }

        public void EnterBusyingState()
        {
            this.BusyingFlag = true;
            this.Cursor = Cursors.WaitCursor;
        }
        public void LeaveBusyingState()
        {
            this.BusyingFlag = false;
            this.Cursor = Cursors.Default;
        }
        public Boolean IsBusyingState(Boolean isTip = false)
        {
            if (this.BusyingFlag && isTip)
            {
                MessageBox.Show(this, "系统当前正忙...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return BusyingFlag;
        }
        public BaseForm()
        {
            InitializeComponent();
        }
    }
}
