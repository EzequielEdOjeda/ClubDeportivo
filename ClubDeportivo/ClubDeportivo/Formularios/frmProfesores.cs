using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>ABM de Profesores (titulares y suplentes).</summary>
    public partial class frmProfesores : Form
    {
        private readonly ProfesorNegocio negocio = new ProfesorNegocio();

        private int idProfesorSeleccionado = 0;
        private int idPersonaSeleccionada = 0;
        private bool modoAlta = true;

        public frmProfesores()
        {
            InitializeComponent();
        }

        private void FrmProfesores_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            PonerModoAlta();
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e) => CargarGrilla();

        private void CargarGrilla()
        {
            dgv.DataSource = cmbFiltro.SelectedItem?.ToString() == "Solo suplentes"
                ? negocio.ListarSuplentes()
                : negocio.Listar();
            if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].Visible = false;
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Profesor p)
            {
                idProfesorSeleccionado = p.IdProfesor;
                idPersonaSeleccionada = p.Id;
                txtNombre.Text = p.Nombre;
                txtApellido.Text = p.Apellido;
                txtDni.Text = p.Dni;
                dtpFechaNacimiento.Value = p.FechaNacimiento;
                txtTelefono.Text = p.Telefono;
                txtDireccion.Text = p.Direccion;
                txtEmail.Text = p.Email;
                txtLegajo.Text = p.Legajo;
                txtEspecialidad.Text = p.Especialidad;
                cmbTipo.SelectedItem = p.Tipo;
                txtHorarios.Text = p.HorariosAsignados;
            }
        }

        private void PonerModoAlta()
        {
            modoAlta = true;
            idProfesorSeleccionado = 0;
            idPersonaSeleccionada = 0;
            txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear(); txtTelefono.Clear();
            txtDireccion.Clear(); txtEmail.Clear(); txtLegajo.Clear(); txtEspecialidad.Clear(); txtHorarios.Clear();
            dtpFechaNacimiento.Value = DateTime.Today.AddYears(-25);
            cmbTipo.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => PonerModoAlta();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtNombre, "Nombre")) return;
            if (!UIHelper.Requerido(txtApellido, "Apellido")) return;
            if (!UIHelper.Requerido(txtDni, "DNI")) return;
            if (!UIHelper.Requerido(txtLegajo, "Legajo")) return;

            var prof = new Profesor
            {
                Id = idPersonaSeleccionada,
                IdProfesor = idProfesorSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date,
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Legajo = txtLegajo.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                Tipo = cmbTipo.SelectedItem?.ToString() ?? "Titular",
                HorariosAsignados = txtHorarios.Text.Trim()
            };

            try
            {
                if (modoAlta)
                {
                    negocio.AltaProfesor(prof);
                    UIHelper.Info("Profesor registrado correctamente.");
                }
                else
                {
                    negocio.ModificarProfesor(prof);
                    UIHelper.Info("Profesor modificado correctamente.");
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
            if (idProfesorSeleccionado == 0) { UIHelper.Error("Seleccione un profesor de la grilla."); return; }
            modoAlta = false;
            UIHelper.Info("Modifique los datos y presione Guardar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idProfesorSeleccionado == 0) { UIHelper.Error("Seleccione un profesor de la grilla."); return; }
            if (!UIHelper.Confirmar("¿Confirma eliminar al profesor seleccionado?")) return;
            try
            {
                negocio.BajaProfesor(idProfesorSeleccionado);
                UIHelper.Info("Profesor eliminado.");
                CargarGrilla();
                PonerModoAlta();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
