using System;
using System.Windows.Forms;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Emisión de carnet al socio (requiere apto físico presentado y cuota al día).</summary>
    public partial class frmCarnet : Form
    {
        private readonly SocioNegocio socioNegocio = new SocioNegocio();
        private readonly CarnetNegocio carnetNegocio = new CarnetNegocio();
        private Entidades.Socio socioActual;

        public frmCarnet()
        {
            InitializeComponent();
        }

        private void FrmCarnet_Load(object sender, EventArgs e) => CargarGrilla();

        private void CargarGrilla() => dgv.DataSource = carnetNegocio.Listar();

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtBuscar, "N° de socio o DNI")) return;
            socioActual = socioNegocio.Buscar(txtBuscar.Text.Trim());
            if (socioActual == null)
            {
                UIHelper.Info("No se encontró ningún socio con ese criterio.");
                lblDatos.Text = ""; lblCondiciones.Text = ""; btnEmitir.Enabled = false;
                return;
            }

            lblDatos.Text = $"{socioActual.NombreCompleto}   |   N° Socio: {socioActual.NroSocio}";
            string aptoTxt = socioActual.AptoFisico ? "Apto físico: SI" : "Apto físico: NO PRESENTADO";
            string cuotaTxt = socioActual.CuotaAlDia ? "Cuota: AL DÍA" : "Cuota: VENCIDA";
            string carnetTxt = socioActual.CarnetEntregado ? " | Ya tiene carnet entregado (se renovará)." : "";
            lblCondiciones.Text = $"{aptoTxt}   |   {cuotaTxt}{carnetTxt}";
            btnEmitir.Enabled = socioActual.AptoFisico && socioActual.CuotaAlDia;
        }

        private void BtnEmitir_Click(object sender, EventArgs e)
        {
            if (socioActual == null) return;
            try
            {
                carnetNegocio.EmitirCarnet(socioActual.IdSocio);
                UIHelper.Info("Carnet emitido y entregado correctamente.");
                CargarGrilla();
                BtnBuscar_Click(sender, e);
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
