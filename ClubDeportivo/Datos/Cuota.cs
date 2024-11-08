using ClubDeportivo.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Datos
{
    internal class Cuota
    {
        public int idCuota { get; set; }
        public DateTime fechaUltimoPago { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public int idSocio { get; set; }

        public bool actualizarFecha()
        {
            return true;
        }
        
        public List<E_Cuota_Cliente> listarVencimientos()
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon.Open();
                string query = "SELECT * FROM cuotas WHERE fechaVencimiento = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<E_Cuota_Cliente> cuotas = new List<E_Cuota_Cliente>();
                while (reader.Read()) {
                    E_Cuota_Cliente cuota = new E_Cuota_Cliente();
                    cuota.cuota = new E_Cuota();
                    cuota.cuota.idCuota = reader.GetInt32("idCuota");
                    cuota.cuota.fechaUltimoPago = reader.GetDateTime("fechaUltimoPago");
                    cuota.cuota.fechaVencimiento = reader.GetDateTime("fechaVencimiento");
                    cuota.cuota.valorCuota = reader.GetFloat("valorCuota");
                    cuota.cuota.formaPago = reader.GetString("formaPago");
                    cuota.cuota.idCliente = reader.GetInt32("idCliente");
                    cuotas.Add(cuota);
                }
                return cuotas;
                
            }catch (Exception ex) {
                throw new Exception("Error al intentar listar las cuotas vencidas: " + ex.Message);

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }

            }

        }
    }
}
