using MagGestion.Forms;
using System;
using System.Windows.Forms;

namespace MagGestion
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login = new LoginForm();
            login.Show();
            Application.Run();
        }
    }
}
