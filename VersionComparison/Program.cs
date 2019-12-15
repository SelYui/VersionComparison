using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VersionComparison
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBox.Show(
                "Перед началом работы с программой убедитесь,\nчто на вашем ПК установлена программа WinMerge\n с размещением C:\\Program Files\\WinMerge\\WinMergeU.exe",
                "Добро пожаловать", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.Run(new MainForm());
        }
    }
}
