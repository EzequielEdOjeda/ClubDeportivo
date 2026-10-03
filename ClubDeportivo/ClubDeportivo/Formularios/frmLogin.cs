using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Pantalla de inicio de sesión. Valida usuario y contraseña contra la tabla "usuario".</summary>
    public partial class frmLogin : Form
    {
        private readonly UsuarioNegocio negocio = new UsuarioNegocio();

        public Usuario UsuarioAutenticado { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnIngresar_Click(sender, e);
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtUsuario, "Usuario")) return;
            if (!UIHelper.Requerido(txtPassword, "Contraseña")) return;

            try
            {
                var usuario = negocio.Login(txtUsuario.Text.Trim(), txtPassword.Text);
                if (usuario == null)
                {
                    UIHelper.Error("Usuario o contraseña incorrectos.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }
                UsuarioAutenticado = usuario;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                UIHelper.Error("No se pudo validar el usuario.\n" + ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
