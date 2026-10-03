using System;
using System.Windows.Forms;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Formularios
{
    /// <summary>
    /// Formulario principal (contenedor MDI). Arma el menú según el rol del usuario que inició sesión
    /// (Administrador, Recepcionista, Profesor o Nutricionista) y abre cada módulo como ventana hija.
    /// El MenuStrip y el StatusStrip se crean vacíos en el Diseñador; sus ítems se agregan aquí en
    /// tiempo de ejecución porque dependen del rol del usuario.
    /// </summary>
    public partial class frmMenuPrincipal : Form
    {
        private readonly Usuario usuarioActual;

        public frmMenuPrincipal(Usuario usuario)
        {
            usuarioActual = usuario;
            InitializeComponent();
            ArmarMenuSegunRol();

            statusStrip1.Items.Add(new ToolStripStatusLabel(
                $"Usuario: {usuarioActual.NombreUsuario}   |   Rol: {usuarioActual.Rol}   |   Fecha: {DateTime.Today:dd/MM/yyyy}"));
        }

        private void ArmarMenuSegunRol()
        {
            bool esAdmin = usuarioActual.Rol == "Administrador";
            bool esRecepcion = esAdmin || usuarioActual.Rol == "Recepcionista";
            bool esProfesor = esAdmin || usuarioActual.Rol == "Profesor";
            bool esNutricionista = esAdmin || usuarioActual.Rol == "Nutricionista";

            if (esRecepcion)
            {
                var mSocios = new ToolStripMenuItem("Socios");
                mSocios.DropDownItems.Add("Gestión de socios", null, (s, e) => AbrirHija(new frmSocios()));
                mSocios.DropDownItems.Add("Gestión de no socios", null, (s, e) => AbrirHija(new frmNoSocios()));
                mSocios.DropDownItems.Add("Emisión de carnet", null, (s, e) => AbrirHija(new frmCarnet()));
                menuStrip1.Items.Add(mSocios);

                var mCuotas = new ToolStripMenuItem("Cuotas");
                mCuotas.DropDownItems.Add("Cobro de cuota", null, (s, e) => AbrirHija(new frmCuotas()));
                mCuotas.DropDownItems.Add("Listado diario de vencimientos", null, (s, e) => AbrirHija(new frmVencimientos()));
                menuStrip1.Items.Add(mCuotas);
            }

            if (esAdmin)
            {
                var mPlantel = new ToolStripMenuItem("Plantel");
                mPlantel.DropDownItems.Add("Profesores", null, (s, e) => AbrirHija(new frmProfesores()));
                mPlantel.DropDownItems.Add("Actividades", null, (s, e) => AbrirHija(new frmActividades()));
                mPlantel.DropDownItems.Add("Liquidación de sueldos", null, (s, e) => AbrirHija(new frmSueldos()));
                menuStrip1.Items.Add(mPlantel);
            }

            if (esProfesor)
            {
                var mProfesor = new ToolStripMenuItem("Mi actividad");
                mProfesor.DropDownItems.Add("Firmar asistencia", null, (s, e) => AbrirHija(new frmAsistenciaProfesores(usuarioActual)));
                mProfesor.DropDownItems.Add("Rutinas de alumnos", null, (s, e) => AbrirHija(new frmRutinas(usuarioActual)));
                menuStrip1.Items.Add(mProfesor);
            }

            if (esNutricionista)
            {
                var mNutricion = new ToolStripMenuItem("Nutrición");
                mNutricion.DropDownItems.Add("Turnos y ficha médica", null, (s, e) => AbrirHija(new frmNutricion()));
                menuStrip1.Items.Add(mNutricion);
            }

            if (esAdmin || esRecepcion)
            {
                var mReportes = new ToolStripMenuItem("Reportes");
                mReportes.DropDownItems.Add("Listados e informes", null, (s, e) => AbrirHija(new frmReportes()));
                menuStrip1.Items.Add(mReportes);
            }

            var mSalir = new ToolStripMenuItem("Salir");
            mSalir.Click += (s, e) => Close();
            menuStrip1.Items.Add(mSalir);
        }

        private void AbrirHija(Form hija)
        {
            hija.MdiParent = this;
            hija.WindowState = FormWindowState.Maximized;
            hija.Show();
        }
    }
}
