using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.Winform.AppAirBnB.Layers.UI;

namespace AppAirBnB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin ofrmLogin = new frmLogin();

            ofrmLogin.ShowDialog();

            if (ofrmLogin.DialogResult == DialogResult.OK)
                
                Application.Run(new frmPrincipal());
        }
    }
}
