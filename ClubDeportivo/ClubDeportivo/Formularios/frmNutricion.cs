using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>
    /// Turnos de nutrición: el servicio atiende una vez por semana (miércoles), con turno asignado
    /// con anticipación. Se lleva ficha médica y carga de actividad física permitida por socio.
    /// </summary>
    public partial class frmNutricion : Form
    {
        private readonly NutricionNegocio negocio = new NutricionNegocio();
        private readonly SocioNegocio socioNegocio = new SocioNegocio();
        private int idConsultaSeleccionada = 0;
        private bool modoAlta = true;

        public frmNutricion()
        {
            InitializeComponent();
        }

        private void FrmNutricion_Load(object sender, EventArgs e)
        {
            CargarSocios();
            PonerModoAlta();
        }

        private void CargarSocios()
        {
            cmbSocio.DataSource = socioNegocio.Listar();
            cmbSocio.DisplayMember = "NombreCompleto";
            cmbSocio.ValueMember = "IdSocio";
        }

        private void CmbSocio_SelectedIndexChanged(object sender, EventArgs e) => CargarGrilla();

        private void CargarGrilla()
        {
            if (cmbSocio.SelectedItem is Socio s)
                dgv.DataSource = negocio.ListarPorSocio(s.IdSocio);
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is ConsultaNutricion c)
            {
                idConsultaSeleccionada = c.IdConsulta;
                dtpFecha.Value = c.Fecha;
                dtpHora.Value = DateTime.Today.Add(c.Hora);
                txtTurno.Text = c.Turno.ToString();
                txtObservaciones.Text = c.Observaciones;
                txtCarga.Text = c.CargaActividadPermitida;
            }
        }

        private void PonerModoAlta()
        {
            modoAlta = true;
            idConsultaSeleccionada = 0;
            dtpFecha.Value = NutricionNegocio.ProximoDiaDeAtencion(DateTime.Today);
            dtpHora.Value = DateTime.Today.AddHours(10);
            txtTurno.Clear(); txtObservaciones.Clear(); txtCarga.Clear();
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => PonerModoAlta();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!(cmbSocio.SelectedItem is Socio s)) { UIHelper.Error("Seleccione un socio."); return; }
            if (!UIHelper.Entero(txtTurno, "N° de turno", out int turno)) return;

            var consulta = new ConsultaNutricion
            {
                IdConsulta = idConsultaSeleccionada,
                IdSocio = s.IdSocio,
                Fecha = dtpFecha.Value.Date,
                Hora = dtpHora.Value.TimeOfDay,
                Turno = turno,
                Observaciones = txtObservaciones.Text.Trim(),
                CargaActividadPermitida = txtCarga.Text.Trim()
            };

            try
            {
                if (modoAlta) { negocio.AsignarTurno(consulta); UIHelper.Info("Turno asignado correctamente."); }
                else { negocio.ModificarTurno(consulta); UIHelper.Info("Turno modificado correctamente."); }
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
            if (idConsultaSeleccionada == 0) { UIHelper.Error("Seleccione un turno de la grilla."); return; }
            modoAlta = false;
            UIHelper.Info("Modifique los datos y presione Guardar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idConsultaSeleccionada == 0) { UIHelper.Error("Seleccione un turno de la grilla."); return; }
            if (!UIHelper.Confirmar("¿Confirma cancelar el turno seleccionado?")) return;
            try
            {
                negocio.CancelarTurno(idConsultaSeleccionada);
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
