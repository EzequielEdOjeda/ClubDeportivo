using System;
using System.Windows.Forms;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>Requerimiento 3 del enunciado: listado diario de socios a los que vence la cuota.</summary>
    public partial class frmVencimientos : Form
    {
        private readonly SocioNegocio negocio = new SocioNegocio();

        public frmVencimientos()
        {
            InitializeComponent();
            dtpFecha.Value = DateTime.Today;
        }

        private void FrmVencimientos_Load(object sender, EventArgs e) => BtnListar_Click(sender, e);

        private void BtnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var tabla = negocio.ListarVencimientosDelDia(dtpFecha.Value.Date);
                if (tabla.Columns.Contains("IdSocio")) tabla.Columns["IdSocio"].SetOrdinal(tabla.Columns.Count - 1);
                dgv.DataSource = tabla;
                if (dgv.Columns.Contains("IdSocio")) dgv.Columns["IdSocio"].Visible = false;
                lblTotal.Text = $"Socios con vencimiento el {dtpFecha.Value:dd/MM/yyyy}: {tabla.Rows.Count}";
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e) => Close();
    }
}
