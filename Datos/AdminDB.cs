using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal static class AdminDB
    {
        internal static SqlConnection ConetarDB()
        {
            string cadena = Datos.Properties.Settings.Default.KeyDBTransporte;
            SqlConnection connection = new SqlConnection(cadena);
            connection.Open();

            return connection;

        }
    }
}
