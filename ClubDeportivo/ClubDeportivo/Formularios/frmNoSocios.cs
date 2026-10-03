using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Registro de no socios: abonan solo el costo de la actividad que realizan, según cartilla.</summary>
    public partial class frmNoSocios : Form
    {
        private readonly NoSocioNegocio negocio = new NoSocioNegocio();
        private readonly ActividadNegocio actividadNegocio = new ActividadNegocio();

        public frmNoSocios()
        {
            InitializeComponent();
        }

        private void FrmNoSocios_Load(object sender, EventArgs e)
        {
            CargarActividades();
            CargarGrilla();
        }

        private void CargarActividades()
        {
            cmbActividad.DataSource = actividadNegocio.Listar();
            cmbActividad.DisplayMember = "Nombre";
            cmbActividad.ValueMember = "IdActividad";
        }

        private void CargarGrilla()
        {
            dgv.DataSource = negocio.Listar();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void CmbActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActividad.SelectedItem is Actividad a)
                lblCosto.Text = $"Costo (no socio): $ {a.CostoNoSocio:N2}";
        }

        private void BtnActualizarListado_Click(object sender, EventArgs e) => CargarGrilla();

        private void BtnSalir_Click(object sender, EventArgs e) => Close();

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtNombre, "Nombre")) return;
            if (!UIHelper.Requerido(txtApellido, "Apellido")) return;
            if (!UIHelper.Requerido(txtDni, "DNI")) return;
            if (!UIHelper.ComboRequerido(cmbActividad, "Actividad")) return;

            var noSocio = new NoSocio
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            try
            {
                int idActividad = ((Actividad)cmbActividad.SelectedItem).IdActividad;
                negocio.RegistrarVisita(noSocio, idActividad);
                UIHelper.Info("Visita registrada y cobro realizado correctamente.");
                txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear(); txtTelefono.Clear(); txtEmail.Clear();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }
    }
}
