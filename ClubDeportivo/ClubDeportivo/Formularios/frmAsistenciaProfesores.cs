using System;
using System.Linq;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Planilla de asistencia: el profesor firma al llegar al club (una firma por día).</summary>
    public partial class frmAsistenciaProfesores : Form
    {
        private readonly ProfesorNegocio negocio = new ProfesorNegocio();
        private readonly Datos.AsistenciaProfesorDAO asistenciaDao = new Datos.AsistenciaProfesorDAO();
        private readonly Usuario usuarioActual;

        public frmAsistenciaProfesores(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            dtpConsulta.Value = DateTime.Today;
        }

        private void FrmAsistenciaProfesores_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarHistorial();
            CargarDelDia();
        }

        private void CargarProfesores()
        {
            var profesores = negocio.Listar();
            cmbProfesor.DataSource = profesores;
            cmbProfesor.DisplayMember = "NombreCompleto";
            cmbProfesor.ValueMember = "IdProfesor";

            if (usuarioActual.Rol == "Profesor" && usuarioActual.IdPersona.HasValue)
            {
                var propio = profesores.FirstOrDefault(p => p.Id == usuarioActual.IdPersona.Value);
                if (propio != null) cmbProfesor.SelectedItem = propio;
                cmbProfesor.Enabled = false;
            }
        }

        private void CmbProfesor_SelectedIndexChanged(object sender, EventArgs e) => CargarHistorial();

        private void CargarHistorial()
        {
            if (cmbProfesor.SelectedItem is Profesor p)
            {
                var lista = asistenciaDao.ListarPorProfesor(p.IdProfesor);
                dgvHistorial.DataSource = lista;

                // Ocultar columnas innecesarias o renombrarlas
                if (dgvHistorial.Columns.Count > 0)
                {
                    if (dgvHistorial.Columns["IdAsistencia"] != null)
                        dgvHistorial.Columns["IdAsistencia"].Visible = false; // Ocultar ID

                    if (dgvHistorial.Columns["IdProfesor"] != null)
                        dgvHistorial.Columns["IdProfesor"].Visible = false;   // Ocultar ID Profesor

                    // Renombrar encabezados
                    if (dgvHistorial.Columns["Fecha"] != null)
                    {
                        dgvHistorial.Columns["Fecha"].HeaderText = "Fecha";
                        dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    }

                    if (dgvHistorial.Columns["HoraEntrada"] != null)
                    {
                        dgvHistorial.Columns["HoraEntrada"].HeaderText = "Hora de Entrada";
                        // NO aplicar formato de fecha aquí si es TimeSpan. 
                        // Si quieres mostrar solo HH:mm, puedes hacerlo así:
                        dgvHistorial.Columns["HoraEntrada"].DefaultCellStyle.Format = "hh\\:mm";
                    }
                }
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e) => CargarDelDia();

        private void CargarDelDia() => dgvDelDia.DataSource = asistenciaDao.ListarPorFecha(dtpConsulta.Value.Date);

        private void BtnFirmar_Click(object sender, EventArgs e)
        {
            if (!(cmbProfesor.SelectedItem is Profesor p)) { UIHelper.Error("Seleccione un profesor."); return; }
            try
            {
                negocio.RegistrarAsistencia(p.IdProfesor);
                UIHelper.Info("Asistencia registrada correctamente.");
                CargarHistorial();
                CargarDelDia();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();

        private void dgvHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
