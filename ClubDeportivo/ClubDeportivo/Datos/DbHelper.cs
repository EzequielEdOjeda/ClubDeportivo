using System;
using System.Data;

namespace ClubDeportivo.Datos
{
    /// <summary>
    /// Utilidades comunes para leer valores de un IDataReader de forma segura frente a NULLs.
    /// Evita repetir la verificación DBNull en cada DAO.
    /// </summary>
    internal static class DbHelper
    {
        public static string Str(IDataRecord r, string col)
            => r[col] == DBNull.Value ? null : r[col].ToString();

        public static int Int(IDataRecord r, string col)
            => Convert.ToInt32(r[col]);

        public static int? IntNull(IDataRecord r, string col)
            => r[col] == DBNull.Value ? (int?)null : Convert.ToInt32(r[col]);

        public static decimal Decimal(IDataRecord r, string col)
            => r[col] == DBNull.Value ? 0m : Convert.ToDecimal(r[col]);

        public static bool Bool(IDataRecord r, string col)
            => r[col] != DBNull.Value && Convert.ToBoolean(r[col]);

        public static DateTime Fecha(IDataRecord r, string col)
            => Convert.ToDateTime(r[col]);

        public static DateTime? FechaNull(IDataRecord r, string col)
            => r[col] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(r[col]);

        public static TimeSpan Hora(IDataRecord r, string col)
            => (TimeSpan)r[col];
    }
}
