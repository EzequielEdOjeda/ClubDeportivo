using System;
using System.Linq;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>ABM de rutinas que el profesor confecciona para sus alumnos.</summary>
    public partial class frmRutinas : Form
    {
        private readonly RutinaNegocio negocio = new RutinaNegocio();
        private readonly ProfesorNegocio profesorNegocio = new ProfesorNegocio();
        private readonly SocioNegocio socioNegocio = new SocioNegocio();
        private readonly Usuario usuarioActual;
        private int idRutinaSeleccionada = 0;
        private bool modoAlta = true;

        public frmRutinas(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
        }

        private void FrmRutinas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla();
            PonerModoAlta();
        }

        private void CargarCombos()
        {
            var profesores = profesorNegocio.Listar();
            cmbProfesor.DataSource = profesores;
            cmbProfesor.DisplayMember = "NombreCompleto";
            cmbProfesor.ValueMember = "IdProfesor";

            if (usuarioActual.Rol == "Profesor" && usuarioActual.IdPersona.HasValue)
            {
                var propio = profesores.FirstOrDefault(p => p.Id == usuarioActual.IdPersona.Value);
                if (propio != null) cmbProfesor.SelectedItem = propio;
                cmbProfesor.Enabled = false; // un profesor solo gestiona sus propias rutinas
            }

            cmbSocio.DataSource = socioNegocio.Listar();
            cmbSocio.DisplayMember = "NombreCompleto";
            cmbSocio.ValueMember = "IdSocio";
        }

        private void CmbProfesor_SelectedIndexChanged(object sender, EventArgs e) => CargarGrilla();

        private void CargarGrilla()
        {
            if (cmbProfesor.SelectedItem is Profesor p)
                dgv.DataSource = negocio.ListarPorProfesor(p.IdProfesor);
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Rutina r)
            {
                idRutinaSeleccionada = r.IdRutina;
                dtpFecha.Value = r.Fecha;
                txtDescripcion.Text = r.Descripcion;
                foreach (Socio s in cmbSocio.Items)
                    if (s.IdSocio == r.IdSocio) { cmbSocio.SelectedItem = s; break; }
            }
        }

        private void PonerModoAlta()
        {
            modoAlta = true;
            idRutinaSeleccionada = 0;
            txtDescripcion.Clear();
            dtpFecha.Value = DateTime.Today;
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => PonerModoAlta();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(cmbProfesor.SelectedItem is Profesor prof)) { UIHelper.Error("Seleccione un profesor."); return; }
            if (!(cmbSocio.SelectedItem is Socio soc)) { UIHelper.Error("Seleccione un socio."); return; }
            if (!UIHelper.Requerido(txtDescripcion, "Descripción")) return;

            var rutina = new Rutina
            {
                IdRutina = idRutinaSeleccionada,
                IdProfesor = prof.IdProfesor,
                IdSocio = soc.IdSocio,
                Descripcion = txtDescripcion.Text.Trim(),
                Fecha = dtpFecha.Value.Date
            };

            try
            {
                if (modoAlta) { negocio.AltaRutina(rutina); UIHelper.Info("Rutina registrada."); }
                else { negocio.ModificarRutina(rutina); UIHelper.Info("Rutina modificada."); }
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
            if (idRutinaSeleccionada == 0) { UIHelper.Error("Seleccione una rutina de la grilla."); return; }
            modoAlta = false;
            UIHelper.Info("Modifique los datos y presione Guardar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idRutinaSeleccionada == 0) { UIHelper.Error("Seleccione una rutina de la grilla."); return; }
            if (!UIHelper.Confirmar("¿Confirma eliminar la rutina seleccionada?")) return;
            try
            {
                negocio.BajaRutina(idRutinaSeleccionada);
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
