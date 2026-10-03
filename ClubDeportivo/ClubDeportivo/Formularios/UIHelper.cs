using System.Windows.Forms;

namespace ClubDeportivo.Formularios
{
    /// <summary>
    /// Validaciones y mensajes comunes a todos los formularios ABM. La creación de controles
    /// ahora la genera el Diseñador de Windows Forms en cada FormName.Designer.cs.
    /// </summary>
    internal static class UIHelper
    {
        public static void Error(string mensaje) =>
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void Info(string mensaje) =>
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static bool Confirmar(string mensaje) =>
            MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static bool Requerido(TextBox txt, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                Error($"El campo '{nombreCampo}' es obligatorio.");
                txt.Focus();
                return false;
            }
            return true;
        }

        public static bool ComboRequerido(ComboBox cmb, string nombreCampo)
        {
            if (cmb.SelectedItem == null)
            {
                Error($"Debe seleccionar '{nombreCampo}'.");
                cmb.Focus();
                return false;
            }
            return true;
        }

        public static bool Decimal(TextBox txt, string nombreCampo, out decimal valor)
        {
            if (!System.Decimal.TryParse(txt.Text, out valor) || valor < 0)
            {
                Error($"El campo '{nombreCampo}' debe ser un número válido.");
                txt.Focus();
                return false;
            }
            return true;
        }

        public static bool Entero(TextBox txt, string nombreCampo, out int valor)
        {
            if (!int.TryParse(txt.Text, out valor) || valor < 0)
            {
                Error($"El campo '{nombreCampo}' debe ser un número entero válido.");
                txt.Focus();
                return false;
            }
            return true;
        }
    }
}
