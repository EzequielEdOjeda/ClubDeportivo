using System;
using System.Windows.Forms;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Listados e informes de gestión.</summary>
    public partial class frmReportes : Form
    {
        private readonly ReporteNegocio negocio = new ReporteNegocio();

        public frmReportes()
        {
            InitializeComponent();
            for (int m = 1; m <= 12; m++) cmbMes.Items.Add(m);
            cmbMes.SelectedItem = DateTime.Today.Month;
            txtAnio.Text = DateTime.Today.Year.ToString();
        }

        private void FrmReportes_Load(object sender, EventArgs e) => cmbReporte.SelectedIndex = 0;

        private void CmbReporte_SelectedIndexChanged(object sender, EventArgs e) => ActualizarVisibilidadPeriodo();

        private void ActualizarVisibilidadPeriodo()
        {
            bool esRecaudacion = cmbReporte.SelectedItem?.ToString() == "Recaudación del mes";
            cmbMes.Visible = esRecaudacion;
            txtAnio.Visible = esRecaudacion;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable tabla;
                switch (cmbReporte.SelectedItem?.ToString())
                {
                    case "Socios activos":
                        tabla = negocio.SociosActivos();
                        break;
                    case "Socios inactivos":
                        tabla = negocio.SociosInactivos();
                        break;
                    case "Recaudación del mes":
                        if (!int.TryParse(txtAnio.Text, out int anio)) { UIHelper.Error("Ingrese un año válido."); return; }
                        int mes = cmbMes.SelectedItem is int m ? m : DateTime.Today.Month;
                        tabla = negocio.RecaudacionDelMes(mes, anio);
                        break;
                    case "Carnets emitidos":
                        tabla = negocio.CarnetsEmitidos();
                        break;
                    case "Ocupación de actividades":
                        tabla = negocio.ActividadesConCupo();
                        break;
                    default:
                        UIHelper.Error("Seleccione un reporte.");
                        return;
                }
                dgv.DataSource = tabla;
                lblCantidad.Text = $"Registros encontrados: {tabla.Rows.Count}";
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
