using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    /// <summary>Acceso a datos de las liquidaciones de sueldo de los profesores.</summary>
    public class SueldoDAO
    {
        /// <summary>Liquida (o actualiza) el sueldo del período mediante sp_LiquidarSueldo.</summary>
        public void Liquidar(int idProfesor, int mes, int anio, decimal monto)
        {
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand("sp_LiquidarSueldo", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("p_idprofesor", idProfesor);
                cmd.Parameters.AddWithValue("p_mes", mes);
                cmd.Parameters.AddWithValue("p_anio", anio);
                cmd.Parameters.AddWithValue("p_monto", monto);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al liquidar el sueldo: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }

        public List<Sueldo> ListarPorProfesor(int idProfesor)
        {
            var lista = new List<Sueldo>();
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand(
                    "SELECT id_sueldo, id_profesor, mes, anio, monto, fecha_pago FROM sueldo " +
                    "WHERE id_profesor=@id ORDER BY anio DESC, mes DESC", con);
                cmd.Parameters.AddWithValue("@id", idProfesor);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        lista.Add(new Sueldo
                        {
                            IdSueldo = DbHelper.Int(r, "id_sueldo"),
                            IdProfesor = DbHelper.Int(r, "id_profesor"),
                            Mes = DbHelper.Int(r, "mes"),
                            Anio = DbHelper.Int(r, "anio"),
                            Monto = DbHelper.Decimal(r, "monto"),
                            FechaPago = DbHelper.FechaNull(r, "fecha_pago")
                        });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los sueldos del profesor: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }

        public DataTable ListarPorPeriodo(int mes, int anio)
        {
            var cn = new Conexion();
            try
            {
                var con = cn.Abrir();
                var cmd = new MySqlCommand(
                    "SELECT CONCAT(p.apellido, ', ', p.nombre) AS Profesor, pr.legajo AS Legajo, " +
                    "       s.monto AS Monto, s.fecha_pago AS FechaDePago FROM sueldo s " +
                    "JOIN profesor pr ON pr.id_profesor = s.id_profesor " +
                    "JOIN persona p ON p.id_persona = pr.id_persona " +
                    "WHERE s.mes=@mes AND s.anio=@anio ORDER BY p.apellido", con);
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@anio", anio);
                var dt = new DataTable();
                using (var adapter = new MySqlDataAdapter(cmd))
                    adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los sueldos del período: " + ex.Message, ex);
            }
            finally
            {
                cn.Cerrar();
            }
        }
    }
}
