using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>
    /// Cobro de cuota mensual. La cuota se abona por adelantado, en efectivo o tarjeta de crédito
    /// (con promociones de 3 y 6 cuotas). Muestra el historial de cuotas del socio seleccionado.
    /// </summary>
    public partial class frmCuotas : Form
    {
        private const decimal MONTO_CUOTA_BASE = 15000.00m;

        private readonly SocioNegocio socioNegocio = new SocioNegocio();
        private readonly CuotaNegocio cuotaNegocio = new CuotaNegocio();
        private Socio socioActual;

        public frmCuotas()
        {
            InitializeComponent();
            txtMonto.Text = MONTO_CUOTA_BASE.ToString("0.00");
            HabilitarPanelCobro(false);
        }

        private void CmbFormaPago_SelectedIndexChanged(object sender, EventArgs e) =>
            cmbCuotasTarjeta.Enabled = cmbFormaPago.SelectedItem?.ToString() == "Tarjeta";

        private void HabilitarPanelCobro(bool habilitar)
        {
            txtMonto.Enabled = habilitar;
            cmbFormaPago.Enabled = habilitar;
            cmbCuotasTarjeta.Enabled = habilitar && cmbFormaPago.SelectedItem?.ToString() == "Tarjeta";
        }

        private void BtnBuscarSocio_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtBuscar, "N° de socio o DNI")) return;
            socioActual = socioNegocio.Buscar(txtBuscar.Text.Trim());
            if (socioActual == null)
            {
                UIHelper.Info("No se encontró ningún socio con ese criterio.");
                lblDatosSocio.Text = "";
                lblEstadoActual.Text = "";
                HabilitarPanelCobro(false);
                dgv.DataSource = null;
                return;
            }

            lblDatosSocio.Text = $"{socioActual.NombreCompleto}   |   N° Socio: {socioActual.NroSocio}   |   Estado: {socioActual.Estado}";
            lblEstadoActual.Text = socioActual.UltimoVencimiento.HasValue
                ? $"Último vencimiento pagado: {socioActual.UltimoVencimiento:dd/MM/yyyy}" +
                  (socioActual.CuotaAlDia ? "  (cuota al día)" : "  (cuota VENCIDA - no puede realizar actividades)")
                : "Sin cuotas abonadas todavía.";

            HabilitarPanelCobro(true);
            dgv.DataSource = cuotaNegocio.HistorialPorSocio(socioActual.IdSocio);
        }

        private void BtnCobrar_Click(object sender, EventArgs e)
        {
            if (socioActual == null) { UIHelper.Error("Primero busque un socio."); return; }
            if (!UIHelper.Decimal(txtMonto, "Monto", out decimal monto)) return;

            string formaPago = cmbFormaPago.SelectedItem?.ToString() ?? "Efectivo";
            int? cuotasTarjeta = null;
            if (formaPago == "Tarjeta")
            {
                switch (cmbCuotasTarjeta.SelectedItem?.ToString())
                {
                    case "3 cuotas": cuotasTarjeta = 3; break;
                    case "6 cuotas": cuotasTarjeta = 6; break;
                    default: cuotasTarjeta = null; break;
                }
            }

            try
            {
                DateTime nuevoVenc = cuotaNegocio.CobrarCuota(socioActual.IdSocio, monto, formaPago, cuotasTarjeta);
                string aviso = nuevoVenc.Date < DateTime.Today
                    ? "\n\nATENCIÓN: el socio continúa con la cuota vencida. Debe abonar las cuotas adeudadas para retomar las actividades."
                    : "";
                UIHelper.Info($"Cuota cobrada correctamente.\nNueva fecha de vencimiento: {nuevoVenc:dd/MM/yyyy}{aviso}");
                BtnBuscarSocio_Click(sender, e); // refresca datos y grilla
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
