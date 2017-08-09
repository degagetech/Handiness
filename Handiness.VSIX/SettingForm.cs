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

namespace Handiness.VSIX
{
    public partial class SettingForm : BaseForm
    {
        protected BuildAssistPacket BuildAssistPacket { get; set; }

        public SettingForm()
        {
            InitializeComponent();
        }
        public SettingForm(BuildAssistPacket assistPacket) : base()
        {
            this.BuildAssistPacket = assistPacket;
        }
    }
}
