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
        public DateTime? fechaVencimiento { get; set; }
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
                sqlCon = Conexion.getInstancia().getConexion();
                sqlCon.Open();
                string query = "SELECT cu.idCuota, cu.fechaUltimoPago, cu.valorCuota, cu.formaPago, cu.fechaVencimiento," +
                    "cl.idCliente, cl.nombre, cl.apellido, cl.dni, cl.aptoFisico, cl.esSocio " +
                    "FROM cuotas cu JOIN clientes cl ON cu.idCliente = cl.idCliente WHERE cu.fechaVencimiento = CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<E_Cuota_Cliente> cuotas = new List<E_Cuota_Cliente>();
                while (reader.Read()) {
                    E_Cuota_Cliente cuota_cliente = new E_Cuota_Cliente();
                    cuota_cliente.cuota = new E_Cuota();
                    cuota_cliente.cuota.idCuota = reader.GetInt32("idCuota");
                    cuota_cliente.cuota.fechaUltimoPago = reader.GetDateTime("fechaUltimoPago");
                    cuota_cliente.cuota.fechaVencimiento = reader.GetDateTime("fechaVencimiento");
                    cuota_cliente.cuota.valorCuota = reader.GetFloat("valorCuota");
                    cuota_cliente.cuota.formaPago = reader.GetString("formaPago");
                    cuota_cliente.cuota.idCliente = reader.GetInt32("idCliente");
                    cuota_cliente.cliente = new E_Cliente();
                    cuota_cliente.cliente.idCliente = reader.GetInt32("idCliente");
                    cuota_cliente.cliente.nombre = reader.GetString("nombre");
                    cuota_cliente.cliente.apellido = reader.GetString("apellido");
                    cuota_cliente.cliente.dni = reader.GetInt32("dni");
                    cuota_cliente.cliente.aptoFisico = reader.GetBoolean("aptoFisico");
                    cuota_cliente.cliente.esSocio = reader.GetBoolean("esSocio");
                    cuotas.Add(cuota_cliente);
                }
                return cuotas;
                
            }catch (Exception ex) {
                MessageBox.Show("Error al intentar listar las cuotas: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }

            }

        }

        public bool insertarCuota(E_Cuota cuota)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().getConexion();

                // Construir la consulta SQL con parámetros
                string query = "INSERT INTO cuotas (fechaUltimoPago, fechaVencimiento, valorCuota, idCliente, formaPago) " +
                               "VALUES (@fechaUltimoPago, @fechaVencimiento, @valorCuota, @idCliente, @formaPago)";

                MySqlCommand comando = new MySqlCommand(query, sqlCon);

                // Agregar los parámetros con los valores de la cuota
                comando.Parameters.AddWithValue("@fechaUltimoPago", cuota.fechaUltimoPago);
                comando.Parameters.AddWithValue("@fechaVencimiento", cuota.fechaVencimiento);
                comando.Parameters.AddWithValue("@valorCuota", cuota.valorCuota);
                comando.Parameters.AddWithValue("@idCliente", cuota.idCliente);
                comando.Parameters.AddWithValue("@formaPago", cuota.formaPago);

                // Abrir la conexión y ejecutar la consulta
                sqlCon.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                // Verificar si se insertó correctamente
                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                return false;
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
