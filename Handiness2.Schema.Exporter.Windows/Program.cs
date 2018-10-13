using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Handiness2.Schema.Exporter.Windows
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;

            Application.Run(new SchemaExportForm());


        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "系统发生异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
