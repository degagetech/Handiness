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
using System.Reflection;
using System.Collections;
namespace Handiness.VSIX
{
    public partial class MainForm : BaseForm
    {
        public enum BuildStateType
        {
            StepUnfinished = 0,
            StepFinished,
            Building,
            BuildCompleted
        }
        public event Action<BuildStateType, BuildStateType> BuildStateChanged;
        /// <summary>
        /// 代码组建的结果
        /// </summary>
        public IEnumerable<(String Name, String Code)> BuildResult { get; private set; }
        /// <summary>
        /// 当前代码组建的状态 0步骤未完成  1步骤完成  2组建中  3组建完成
        /// </summary>
        public BuildStateType CurrentBuildState
        {
            get => this._currentBuildState;
            private set
            {
                BuildStateType oldState = this._currentBuildState;
                this._currentBuildState = value;
                this.BuildStateChanged?.Invoke(oldState, this._currentBuildState);
            }
        }
        public BuildAssistPacket BuildAssistPacket { get; set; } = new BuildAssistPacket();

        private BuildStateType _currentBuildState = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


        }


        private void MainForm_BuildStateChanged(BuildStateType oldState, BuildStateType newState)
        {
            this.DrawButtonStyleByBuildState(newState);
        }
        /// <summary>
        /// 通过组建状态绘制按钮样式
        /// </summary>
        /// <param name="state"></param>
        private void DrawButtonStyleByBuildState(BuildStateType state)
        {
            switch (state)
            {
                case BuildStateType.StepUnfinished:
                    {
                        this._btnBuild.Text = "下一步";
                    }
                    break;
                case BuildStateType.StepFinished:
                    {
                        this._btnBuild.Text = "组建";
                    }
                    break;
                case BuildStateType.BuildCompleted:
                    {
                        this._btnBuild.Text = "完成";
                    }
                    break;
                default: break;
            }
        }
        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);
        }

        private void StepControl_StepBuildCompleted(BuildAssistPacket obj)
        {
            //TODO:当步骤控件完成时
        }



        private void _btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnBuildControl_Click(object sender, EventArgs e)
        {

        }

        private void _sylSetting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.ShowDialog();
        }

    }
}
