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
    internal class Clientes
    {
        public int idCliente;
        public string nombre;
        public string apellido;
        public int dni;
        public bool aptoFisico;
        public bool esSocio;

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

        public bool actualizarCliente(Entidades.E_Cliente cliente)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().getConexion();
                string query = $"UPDATE cliente SET nombre = {cliente.nombre}, apellido = {cliente.apellido}" +
                    $", dni = {cliente.dni}, aptoFisico = {cliente.aptoFisico}, esSocio = {cliente.esSocio}"+
                    $" WHERE idCliente = {cliente.idCliente}";
                MySqlCommand comando = new MySqlCommand(query, sqlCon);
                sqlCon.Open();
                comando.ExecuteNonQuery();

                if (comando.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
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

        public Clientes ObtenerClientePorId(int id) {
            try {
                MySqlConnection sqlCon = Conexion.getInstancia().getConexion();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM clientes WHERE idCliente = @id", sqlCon);
                cmd.Parameters.AddWithValue("@id", id);
                sqlCon.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Clientes cliente = new Clientes
                    {
                        idCliente = reader.GetInt32("idCliente"),
                        nombre = reader.GetString("nombre"),
                        apellido = reader.GetString("apellido"),
                        dni = reader.GetInt32("dni"),
                        aptoFisico = reader.GetBoolean("aptoFisico"),
                        esSocio = reader.GetBoolean("esSocio")
                    };
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener cliente por ID: " + ex.Message);
            }
        }

        public Clientes BuscarCliente(string criterio)
        {
            MySqlConnection sqlCon = new MySqlConnection();
            List<Clientes> clientes = new List<Clientes>();

            // Determinar si el criterio es numérico (DNI) o texto (nombre/apellido)
            string consultaSQL;
            MySqlCommand cmd;

            if (int.TryParse(criterio, out int dni))
            {
                // Búsqueda por DNI
                consultaSQL = "SELECT * FROM clientes WHERE dni = @criterio";
                cmd = new MySqlCommand(consultaSQL, sqlCon);
                cmd.Parameters.AddWithValue("@criterio", dni);
            }
            else
            {
                // Búsqueda por nombre y/o apellido usando LIKE (case-insensitive)
                consultaSQL = "SELECT * FROM clientes WHERE  " +
                              "(LOWER(nombre) LIKE @criterio OR LOWER(apellido) LIKE @criterio)";
                cmd = new MySqlCommand(consultaSQL, sqlCon);
                cmd.Parameters.AddWithValue("@criterio", "%" + criterio.ToLower() + "%");
            }

            try
            {
                sqlCon.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Clientes cliente = new Clientes
                    {
                        idCliente = reader.GetInt32("idCliente"),
                        nombre = reader.GetString("nombre"),
                        apellido = reader.GetString("apellido"),
                        dni = reader.GetInt32("dni"),
                        aptoFisico = reader.GetBoolean("aptoFisico"),
                        esSocio = reader.GetBoolean("esSocio")
                    };
                    clientes.Add(cliente);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar cliente: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            // Si se encontraron múltiples clientes, mostrar un cuadro de selección
            if (clientes.Count > 1)
            {
                return MostrarSeleccionDialogo(clientes);
            }
            else if (clientes.Count == 1)
            {
                // Solo un cliente encontrado, retornarlo
                return clientes[0];
            }
            else
            {
                // No se encontraron clientes
                MessageBox.Show("No se encontraron clientes con el criterio especificado.", "Búsqueda de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        private Clientes MostrarSeleccionDialogo(List<Clientes> clientes)
        {
            // Crear un formulario de selección para mostrar los clientes
            using (Form seleccionForm = new Form())
            {
                seleccionForm.Text = "Seleccione el Cliente";
                seleccionForm.Width = 400;
                seleccionForm.Height = 300;

                ListBox listBox = new ListBox
                {
                    Dock = DockStyle.Fill
                };
                foreach (var cliente in clientes)
                {
                    listBox.Items.Add($"{cliente.nombre} {cliente.apellido} - DNI: {cliente.dni} - Socio: {cliente.esSocio}");
                }

                Button selectButton = new Button
                {
                    Text = "Seleccionar",
                    Dock = DockStyle.Bottom
                };

                seleccionForm.Controls.Add(listBox);
                seleccionForm.Controls.Add(selectButton);

                Clientes clienteSeleccionado = null;

                selectButton.Click += (sender, e) =>
                {
                    if (listBox.SelectedIndex != -1)
                    {
                        clienteSeleccionado = clientes[listBox.SelectedIndex];
                        seleccionForm.DialogResult = DialogResult.OK;
                        seleccionForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un cliente de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                if (seleccionForm.ShowDialog() == DialogResult.OK)
                {
                    return clienteSeleccionado;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
