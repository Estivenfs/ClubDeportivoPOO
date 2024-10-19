using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Clientes
    {
        
        public string completarInscripcion(Entidades.E_Cliente cliente)
        {
            string? salida;
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().getConexion();
                MySqlCommand comando = new MySqlCommand("NuevoCliente",sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nom", cliente.nombre);
                comando.Parameters.AddWithValue("@ape", cliente.apellido);
                comando.Parameters.AddWithValue("@clientDni", cliente.dni);
                comando.Parameters.AddWithValue("@aptoFisico", cliente.aptoFisico);
                comando.Parameters.AddWithValue("@esSocio", cliente.esSocio);

                MySqlParameter parametroSalida = new MySqlParameter();
                parametroSalida.ParameterName = "@rta";
                parametroSalida.MySqlDbType = MySqlDbType.Int32;
                parametroSalida.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametroSalida);

                sqlCon.Open();
                comando.ExecuteNonQuery();
                salida = comando.Parameters["@rta"].Value.ToString();
            }
            catch (Exception ex)
            {
                salida = "Error al intentar registrar el cliente: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            return salida;
        }
    }
}
