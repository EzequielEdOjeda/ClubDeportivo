using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>ABM de Socios: alta, baja (lógica), modificación y listado.</summary>
    public partial class frmSocios : Form
    {
        private readonly SocioNegocio negocio = new SocioNegocio();

        private int idSocioSeleccionado = 0;
        private int idPersonaSeleccionada = 0;
        private bool modoAlta = true;

        public frmSocios()
        {
            InitializeComponent();
        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            PonerModoAlta();
        }

        private void CargarGrilla()
        {
            dgv.DataSource = negocio.Listar();
            OcultarColumnasInternas();
        }

        private void OcultarColumnasInternas()
        {
            foreach (var nombre in new[] { "Id" })
                if (dgv.Columns.Contains(nombre)) dgv.Columns[nombre].Visible = false;
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Socio s)
            {
                idSocioSeleccionado = s.IdSocio;
                idPersonaSeleccionada = s.Id;
                txtNombre.Text = s.Nombre;
                txtApellido.Text = s.Apellido;
                txtDni.Text = s.Dni;
                dtpFechaNacimiento.Value = s.FechaNacimiento;
                txtTelefono.Text = s.Telefono;
                txtDireccion.Text = s.Direccion;
                txtEmail.Text = s.Email;
                txtNroSocio.Text = s.NroSocio;
                chkAptoFisico.Checked = s.AptoFisico;
                chkCarnetEntregado.Checked = s.CarnetEntregado;
                cmbEstado.SelectedItem = s.Estado;
            }
        }

        private void PonerModoAlta()
        {
            modoAlta = true;
            idSocioSeleccionado = 0;
            idPersonaSeleccionada = 0;
            txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear();
            txtTelefono.Clear(); txtDireccion.Clear(); txtEmail.Clear(); txtNroSocio.Clear();
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-20);
            chkAptoFisico.Checked = false;
            chkCarnetEntregado.Checked = false;
            cmbEstado.SelectedItem = "Activo";
            txtNombre.Focus();
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => PonerModoAlta();

        private bool ValidarCampos()
        {
            return UIHelper.Requerido(txtNombre, "Nombre")
                && UIHelper.Requerido(txtApellido, "Apellido")
                && UIHelper.Requerido(txtDni, "DNI")
                && UIHelper.Requerido(txtNroSocio, "N° de Socio");
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var socio = new Socio
            {
                Id = idPersonaSeleccionada,
                IdSocio = idSocioSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NroSocio = txtNroSocio.Text.Trim(),
                AptoFisico = chkAptoFisico.Checked,
                CarnetEntregado = chkCarnetEntregado.Checked,
                Estado = cmbEstado.SelectedItem?.ToString() ?? "Activo"
            };

            try
            {
                if (modoAlta)
                {
                    negocio.AltaSocio(socio);
                    UIHelper.Info("Socio registrado correctamente. Se entregará el carnet desde el módulo de Carnet una vez validada la cuota.");
                }
                else
                {
                    negocio.ModificarSocio(socio);
                    UIHelper.Info("Socio modificado correctamente.");
                }
                CargarGrilla();
                PonerModoAlta();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                UIHelper.Error("Seleccione un socio de la grilla para modificar.");
                return;
            }
            modoAlta = false;
            UIHelper.Info("Modifique los datos y presione Guardar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                UIHelper.Error("Seleccione un socio de la grilla para dar de baja.");
                return;
            }
            if (!UIHelper.Confirmar("¿Confirma la baja del socio seleccionado? (baja lógica, no se pierde el historial)")) return;

            try
            {
                negocio.BajaSocio(idSocioSeleccionado);
                UIHelper.Info("Socio dado de baja.");
                CargarGrilla();
                PonerModoAlta();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarGrilla();
                return;
            }
            var s = negocio.Buscar(txtBuscar.Text.Trim());
            if (s == null)
            {
                UIHelper.Info("No se encontró ningún socio con ese criterio.");
                return;
            }
            dgv.DataSource = new System.Collections.Generic.List<Socio> { s };
            OcultarColumnasInternas();
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
