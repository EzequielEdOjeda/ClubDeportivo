using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    /// <summary>
    /// Clase responsable exclusivamente de abrir y cerrar la conexión a la base de datos MySQL.
    /// Toda clase DAO de la carpeta "Datos" instancia esta clase para dialogar con "Proyecto".
    /// </summary>
    public class Conexion
    {
        // Datos de conexión (servidor, puerto, base, usuario, clave).
        // Se intenta leer primero desde App.config (clave "ClubDeportivoDB"); si no existe,
        // se usa esta cadena por defecto, pensada para un entorno local con XAMPP / MySQL Workbench.
        private const string CADENA_POR_DEFECTO =
            "Server=localhost;Port=3306;Database=Proyecto;Uid=root;Pwd=;SslMode=none;";

        private MySqlConnection conexion;

        private string ObtenerCadenaConexion()
        {
            try
            {
                var config = ConfigurationManager.ConnectionStrings["ClubDeportivoDB"];
                if (config != null && !string.IsNullOrWhiteSpace(config.ConnectionString))
                    return config.ConnectionString;
            }
            catch
            {
                // Si App.config no está disponible o no tiene la clave, se usa el valor por defecto.
            }
            return CADENA_POR_DEFECTO;
        }

        /// <summary>Abre la conexión a MySQL y la devuelve lista para usar.</summary>
        public MySqlConnection Abrir()
        {
            try
            {
                conexion = new MySqlConnection(ObtenerCadenaConexion());
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al conectar a la base de datos MySQL: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al abrir la conexión: " + ex.Message, ex);
            }
        }

        /// <summary>Cierra y libera la conexión si estuviera abierta.</summary>
        public void Cerrar()
        {
            try
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message, ex);
            }
            finally
            {
                conexion?.Dispose();
            }
        }
    }
}
