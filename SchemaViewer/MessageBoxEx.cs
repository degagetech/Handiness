using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SchemaViewer
{
    public static class MessageBoxEx
    {
        public static DialogResult Show(String text, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text,caption,buttons,icon);
        }
        public static DialogResult Show(String text)
        {
            return MessageBox.Show(text);
        }
        public static DialogResult DialogShow(this String str)
        {
            return MessageBox.Show(str);
        }
        public static DialogResult DialogShow(this String str, String caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(str, caption, buttons, icon);
        }
        
    }
}
