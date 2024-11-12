using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class NoSocio : Clientes
    {

        public bool registrarActividad(int idActividad, int idCliente)
        {
            return Actividad.inscribirActividad(idActividad, idCliente);
        }

        private List<NoSocio> listarNoSocios()
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clientes WHERE esSocio = false", sqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<NoSocio> noSocios = new List<NoSocio>();
                while (reader.Read()) {
                    NoSocio noSocio = new NoSocio();
                    noSocio.idCliente = reader.GetInt32("idCliente");
                    noSocio.nombre = reader.GetString("nombre");
                    noSocio.apellido = reader.GetString("apellido");
                    noSocio.dni = reader.GetInt32("dni");
                    noSocio.aptoFisico = reader.GetBoolean("aptoFisico");
                    noSocio.esSocio = reader.GetBoolean("esSocio");
                    noSocios.Add(noSocio);
                }
                return noSocios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar listar los no socios: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }


        }
    }
}
