using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Datos
{
    public static class AdmAuto
    {
        public static List<Auto> Listar()
        {
            //consulta de SQL
            string consultaSQL = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto";

            SqlCommand comando = new SqlCommand(consultaSQL, AdminDB.ConetarDB());

            SqlDataReader reader;

            reader = comando.ExecuteReader();

            //Recorrer leer los datos hacia adelante
            List<Auto> lista = new List<Auto>();

            while (reader.Read())
            {
                lista.Add(
                    new Auto()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        Matricula = reader["Matricula"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"])
                    }
                    );
            }
            AdminDB.ConetarDB().Close();//cierre de la conexión
            reader.Close();
            return lista;

        }

        public static DataTable Listar(string marca)
        {
            //query
            string consultaSLQ = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto WHERE Marca=@Marca";
         
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSLQ, AdminDB.ConetarDB());
            // declaracion de parametros
            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar,50).Value = marca;
           
            DataSet ds = new DataSet();
          
            adapter.Fill(ds, "AutoXMarca"); 

            return ds.Tables["AutoXMarca"];
        }

        public static DataTable ListarMarcas()
        {
            //query
            string consultaSLQ = "SELECT Marca FROM dbo.Marca";

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSLQ, AdminDB.ConetarDB());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Marca");

            return ds.Tables["Marca"];
        }

        public static int Insertar(Auto auto)
        {
            string insertSQL = "INSERT dbo.Auto(Marca,Modelo,Matricula,Precio) VALUES(@Marca, @Modelo, @Matricula, @Precio)";
            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConetarDB());
            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char,6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;

            int filasAfectadas = command.ExecuteNonQuery();
            AdminDB.ConetarDB().Close();

            return filasAfectadas;
        }
        public static int Modificar(Auto auto)
        {
            string insertSQL = "UPDATE dbo.Auto SET Marca = @Marca, Modelo = @Modelo, Matricula = @Matricula, Precio=@Precio WHERE Id = @Id ";

            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConetarDB());

            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConetarDB().Close();

            return filasAfectadas;
        }
        public static int Eliminar(int id)
        {
            string insertSQL = "DELETE FROM dbo.Auto WHERE Id = @Id";

            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConetarDB());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            int filasAfectadas = command.ExecuteNonQuery();

            AdminDB.ConetarDB().Close();

            return filasAfectadas;

        }
    }
}
