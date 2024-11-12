using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Actividad
    {
        public string nombre { get; set; }
        public int codActividad { get; set; }
        public float precio { get; set; }
        public DateTime horario { get; set; }
        public int cupo { get; set; }
        public int cupoDisponible { get; set; }

        public static List<E_Actividad> listarActividades()
        {
            List<E_Actividad> actividades = new List<E_Actividad>();
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon = Conexion.getInstancia().getConexion();
            try
            {
                sqlCon.Open();
                string query = "SELECT * FROM actividades";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    E_Actividad actividad = new E_Actividad();
                    actividad.codActividad = reader.GetInt32("codActividad");
                    actividad.nombre = reader.GetString("nombre");
                    actividad.precio = reader.GetFloat("precio");
                    actividad.horario = reader.GetDateTime("horario");
                    actividad.cupo = reader.GetInt32("cupo");
                    actividad.cupoDisponible = reader.GetInt32("cupoDisponible");
                    actividades.Add(actividad);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar listar las actividades: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (sqlCon.State == System.Data.ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }


            return actividades;
        }

        public static bool inscribirActividad(int idActividad, int idCliente)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            sqlCon = Conexion.getInstancia().getConexion();
            try
            {
                sqlCon.Open();
                //Valido si la actividad tiene cupo disponible
                MySqlCommand cmdCupo = new MySqlCommand("SELECT cupoDisponible FROM actividades WHERE codActividad = @idActividad", sqlCon);
                cmdCupo.Parameters.AddWithValue("@idActividad", idActividad);
                int cupoDisponible = Convert.ToInt32(cmdCupo.ExecuteScalar());
                if (cupoDisponible == 0)
                {
                    MessageBox.Show("La actividad seleccionada no tiene cupo disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //Inscribo al cliente en la actividad usando un query
                MySqlCommand cmdInscribir = new MySqlCommand("INSERT INTO cliente_actividad (idCliente, codActividad) VALUES (@idCliente, @idActividad)", sqlCon);
                cmdInscribir.Parameters.AddWithValue("@idCliente", idCliente);
                cmdInscribir.Parameters.AddWithValue("@idActividad", idActividad);
                cmdInscribir.ExecuteNonQuery();

                //Actualizo el cupo disponible de la actividad
                MySqlCommand cmdActualizarCupo = new MySqlCommand("UPDATE actividades SET cupoDisponible = cupoDisponible - 1 WHERE codActividad = @idActividad", sqlCon);
                cmdActualizarCupo.Parameters.AddWithValue("@idActividad", idActividad);
                cmdActualizarCupo.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar inscribir al cliente en la actividad: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
