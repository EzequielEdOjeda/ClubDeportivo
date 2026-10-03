using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Liquidación mensual del sueldo de los profesores (último día hábil del mes).</summary>
    public partial class frmSueldos : Form
    {
        private readonly ProfesorNegocio profesorNegocio = new ProfesorNegocio();
        private readonly SueldoNegocio sueldoNegocio = new SueldoNegocio();

        public frmSueldos()
        {
            InitializeComponent();

            for (int m = 1; m <= 12; m++) cmbMes.Items.Add(m);
            cmbMes.SelectedItem = DateTime.Today.Month;
            txtAnio.Text = DateTime.Today.Year.ToString();

            lblAviso.Text = sueldoNegocio.EsUltimoDiaHabilDelMes(DateTime.Today)
                ? "Hoy es el último día hábil del mes."
                : "Aviso: hoy NO es el último día hábil del mes (la liquidación se permite igual, para uso administrativo).";
        }

        private void FrmSueldos_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarHistorial();
            CargarPeriodo();
        }

        private void CargarProfesores()
        {
            cmbProfesor.DataSource = profesorNegocio.Listar();
            cmbProfesor.DisplayMember = "NombreCompleto";
            cmbProfesor.ValueMember = "IdProfesor";
        }

        private void CmbProfesor_SelectedIndexChanged(object sender, EventArgs e) => CargarHistorial();

        private void CargarHistorial()
        {
            if (cmbProfesor.SelectedItem is Profesor p)
                dgvHistorial.DataSource = sueldoNegocio.ListarPorProfesor(p.IdProfesor);
        }

        private void BtnVerPeriodo_Click(object sender, EventArgs e) => CargarPeriodo();

        private void CargarPeriodo()
        {
            if (int.TryParse(txtAnio.Text, out int anio) && cmbMes.SelectedItem is int mes)
                dgvPeriodo.DataSource = sueldoNegocio.ListarPorPeriodo(mes, anio);
        }

        private void BtnLiquidar_Click(object sender, EventArgs e)
        {
            if (!(cmbProfesor.SelectedItem is Profesor p)) { UIHelper.Error("Seleccione un profesor."); return; }
            if (!(cmbMes.SelectedItem is int mes)) { UIHelper.Error("Seleccione el mes."); return; }
            if (!int.TryParse(txtAnio.Text, out int anio)) { UIHelper.Error("Ingrese un año válido."); return; }
            if (!UIHelper.Decimal(txtMonto, "Monto", out decimal monto)) return;

            try
            {
                sueldoNegocio.LiquidarSueldo(p.IdProfesor, mes, anio, monto);
                UIHelper.Info("Sueldo liquidado correctamente.");
                CargarHistorial();
                CargarPeriodo();
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
