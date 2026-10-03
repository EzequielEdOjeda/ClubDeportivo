using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    /// <summary>Acceso a datos de las cuotas mensuales. El cobro y el listado de vencimientos usan stored procedures.</summary>
    public class CuotaDAO
    {
        /// <summary>
        /// Registra el cobro de la cuota mediante sp_CobrarCuota y devuelve la nueva fecha de vencimiento.
        /// El nuevo plazo comienza a correr desde el día siguiente al vencimiento anterior (o desde hoy si es el primer pago).
        /// </summary>
        public DateTime CobrarCuota(int idSocio, decimal monto, string formaPago, int? cuotasTarjeta)
        {
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand("sp_CobrarCuota", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("p_idsocio", idSocio);
                cmd.Parameters.AddWithValue("p_monto", monto);
                cmd.Parameters.AddWithValue("p_formapago", formaPago);
                cmd.Parameters.AddWithValue("p_cuotastarjeta", (object)cuotasTarjeta ?? DBNull.Value);
                return Convert.ToDateTime(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cobrar la cuota: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }

        public List<Cuota> ListarPorSocio(int idSocio)
        {
            var lista = new List<Cuota>();
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand(
                    "SELECT id_cuota, id_socio, mes, anio, monto, fecha_vencimiento, fecha_pago, forma_pago, cuotas_tarjeta " +
                    "FROM cuota WHERE id_socio=@id ORDER BY fecha_vencimiento DESC", con);
                cmd.Parameters.AddWithValue("@id", idSocio);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Cuota
                        {
                            IdCuota = DbHelper.Int(r, "id_cuota"),
                            IdSocio = DbHelper.Int(r, "id_socio"),
                            Mes = DbHelper.Int(r, "mes"),
                            Anio = DbHelper.Int(r, "anio"),
                            Monto = DbHelper.Decimal(r, "monto"),
                            FechaVencimiento = DbHelper.Fecha(r, "fecha_vencimiento"),
                            FechaPago = DbHelper.FechaNull(r, "fecha_pago"),
                            FormaPago = DbHelper.Str(r, "forma_pago"),
                            CuotasTarjeta = DbHelper.IntNull(r, "cuotas_tarjeta")
                        });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el historial de cuotas: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }

        /// <summary>Listado diario de vencimientos (requerimiento 3 del enunciado), vía sp_ListarVencimientosDia.</summary>
        public DataTable ListarVencimientosDia(DateTime fecha)
        {
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand("sp_ListarVencimientosDia", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("p_fecha", fecha.Date);
                var dt = new DataTable();
                using (var adapter = new MySqlDataAdapter(cmd))
                    adapter.Fill(dt);
                dt.Columns["apellido"].ColumnName = "Apellido";
                dt.Columns["nombre"].ColumnName = "Nombre";
                dt.Columns["nro_socio"].ColumnName = "N° Socio";
                dt.Columns["fecha_vencimiento"].ColumnName = "Vencimiento";
                dt.Columns["mes"].ColumnName = "Mes";
                dt.Columns["anio"].ColumnName = "Año";
                dt.Columns["id_socio"].ColumnName = "IdSocio";
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los vencimientos del día: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }
    }
}
