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
namespace Handiness.CodeBuild
{
    public partial class EditForm : LightForm
    {
        /// <summary>
        /// 获取编辑窗体编辑的内容
        /// </summary>
        public String EditContent
        {
            get
            {
                return this._tbContent.Text.Trim();
            }
        }

        public EditForm()
        {
            InitializeComponent();
        }
        public EditForm(String editContent) : this()
        {
            this.ShowEditContent(editContent);
        }

        public T GetEditContentObject<T>() where T : class
        {
            String str = this.EditContent;
            T obj = null;
            try
            {
                obj = XmlSerializer.DeSerializeFromString<T>(str);
            }
            catch { }
            return obj;
        }
        /// <summary>
        /// 显示并设计编辑的内容
        /// </summary>
        /// <param name="content"></param>
        public void ShowEditContent<T>(T content) where T : class
        {
            this._tbContent.Text = XmlSerializer.SerializeToString<T>(content);
        }
        /// <summary>
        /// 显示并设置编辑的内容
        /// </summary>
        /// <param name="content"></param>
        public void ShowEditContent(String content)
        {
            this._tbContent.Text = content;
        }
        private void _btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = this._btnOk.DialogResult;
            this.Close();
        }

        private void _btnCannel_Click(object sender, EventArgs e)
        {
            this.DialogResult = this._btnCannel.DialogResult;
            this.Close();
        }
    }
}
