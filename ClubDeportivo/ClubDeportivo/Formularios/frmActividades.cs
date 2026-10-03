using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClubDeportivo.Entidades;
using ClubDeportivo.Negocio;

namespace ClubDeportivo.Formularios
{
    /// <summary>ABM de Actividades que ofrece el club.</summary>
    public partial class frmActividades : Form
    {
        private readonly ActividadNegocio negocio = new ActividadNegocio();
        private readonly ProfesorNegocio profesorNegocio = new ProfesorNegocio();
        private int idActividadSeleccionada = 0;
        private bool modoAlta = true;

        private class ProfesorItem
        {
            public int? Id { get; set; }
            public string Texto { get; set; }
            public override string ToString() => Texto;
        }

        public frmActividades()
        {
            InitializeComponent();
        }

        private void FrmActividades_Load(object sender, EventArgs e)
        {
            CargarProfesores();
            CargarGrilla();
            PonerModoAlta();
        }

        private void CargarProfesores()
        {
            var items = new List<ProfesorItem> { new ProfesorItem { Id = null, Texto = "(Sin asignar)" } };
            foreach (var p in profesorNegocio.Listar())
                items.Add(new ProfesorItem { Id = p.IdProfesor, Texto = p.NombreCompleto + " - " + p.Legajo });
            cmbProfesor.DataSource = items;
        }

        private void CargarGrilla()
        {
            dgv.DataSource = negocio.Listar();
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow?.DataBoundItem is Actividad a)
            {
                idActividadSeleccionada = a.IdActividad;
                txtNombre.Text = a.Nombre;
                txtTipo.Text = a.Tipo;
                txtCosto.Text = a.CostoNoSocio.ToString("0.00");
                txtHorario.Text = a.Horario;
                txtCupo.Text = a.CupoMaximo.ToString();
                foreach (ProfesorItem it in cmbProfesor.Items)
                    if (it.Id == a.IdProfesor) { cmbProfesor.SelectedItem = it; break; }
            }
        }

        private void PonerModoAlta()
        {
            modoAlta = true;
            idActividadSeleccionada = 0;
            txtNombre.Clear(); txtTipo.Clear(); txtCosto.Clear(); txtHorario.Clear(); txtCupo.Clear();
            if (cmbProfesor.Items.Count > 0) cmbProfesor.SelectedIndex = 0;
            txtNombre.Focus();
        }

        private void BtnNuevo_Click(object sender, EventArgs e) => PonerModoAlta();

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!UIHelper.Requerido(txtNombre, "Nombre")) return;
            if (!UIHelper.Decimal(txtCosto, "Costo no socio", out decimal costo)) return;
            if (!UIHelper.Entero(txtCupo, "Cupo máximo", out int cupo)) return;

            var act = new Actividad
            {
                IdActividad = idActividadSeleccionada,
                Nombre = txtNombre.Text.Trim(),
                Tipo = txtTipo.Text.Trim(),
                CostoNoSocio = costo,
                Horario = txtHorario.Text.Trim(),
                CupoMaximo = cupo,
                IdProfesor = (cmbProfesor.SelectedItem as ProfesorItem)?.Id
            };

            try
            {
                if (modoAlta) { negocio.AltaActividad(act); UIHelper.Info("Actividad registrada correctamente."); }
                else { negocio.ModificarActividad(act); UIHelper.Info("Actividad modificada correctamente."); }
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
            if (idActividadSeleccionada == 0) { UIHelper.Error("Seleccione una actividad de la grilla."); return; }
            modoAlta = false;
            UIHelper.Info("Modifique los datos y presione Guardar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idActividadSeleccionada == 0) { UIHelper.Error("Seleccione una actividad de la grilla."); return; }
            if (!UIHelper.Confirmar("¿Confirma eliminar la actividad seleccionada?")) return;
            try
            {
                negocio.BajaActividad(idActividadSeleccionada);
                UIHelper.Info("Actividad eliminada.");
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
