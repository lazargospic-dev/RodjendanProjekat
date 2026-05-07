using System;
using System.Windows.Forms;

namespace RodjendanProjekat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var login = new Forms.LoginForm())
            {
                var res = login.ShowDialog();
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    Application.Run(new Forms.MainForm());
                }
            }
        }
    }
}