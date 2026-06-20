using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fortune_telling.Utilities;

namespace Fortune_telling
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 應用啟動時初始化數據庫和相關資源
            ApplicationInitializer.Initialize();

            Application.Run(new frmStart());
        }
    }
}
