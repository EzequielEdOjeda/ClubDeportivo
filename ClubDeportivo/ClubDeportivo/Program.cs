using System;
using System.Windows.Forms;
using ClubDeportivo.Formularios;

namespace ClubDeportivo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var login = new frmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK && login.UsuarioAutenticado != null)
                {
                    Application.Run(new frmMenuPrincipal(login.UsuarioAutenticado));
                }
            }
        }
    }
}
