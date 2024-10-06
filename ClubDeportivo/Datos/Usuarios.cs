using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ClubDeportivo.Datos
{
    internal class Usuarios
    {
        public DataTable LoginUsuario(string usuario, string clave)
        {
            MySqlDataReader resultado;
            DataTable tabla = new DataTable();
            MySqlConnection sqlConexion = new MySqlConnection();
            try
            {
                sqlConexion = Conexion.getInstancia().getConexion();
                MySqlCommand comando = new MySqlCommand("IngresoLogin", sqlConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("Usu", usuario);
                comando.Parameters.AddWithValue("Pass", clave);
                sqlConexion.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConexion.State == ConnectionState.Open)
                {
                    sqlConexion.Close();
                }
            }
        }
    }
}
