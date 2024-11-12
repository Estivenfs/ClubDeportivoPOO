using ClubDeportivo.Datos;
using ClubDeportivo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmRegistroPago : Form
    {
        internal Clientes? clientes;
        public frmRegistroPago()
        {
            InitializeComponent();
        }

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "DNI, Nombre o Apellido")
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = Color.Black;
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "")
            {
                txtBusqueda.Text = "DNI, Nombre o Apellido";
                txtBusqueda.ForeColor = Color.Silver;
            }
        }

        private void frmRegistroPago_Load(object sender, EventArgs e)
        {
            txtBusqueda.Text = "DNI, Nombre o Apellido";
            txtBusqueda.ForeColor = Color.Silver;

            if (clientes != null)
            {
                txtBusqueda.Enabled = false;
                btnBuscar.Enabled = false;
                lblNombreCliente.Text = clientes.nombre + " " + clientes.apellido;
                if (clientes.esSocio)
                {
                    cmbActividades.Visible = false;
                    lblActividades.Visible = false;
                }
                else
                {
                    cmbActividades.Visible = true;
                    lblActividades.Visible = true;
                    List<E_Actividad> actividades = Actividad.listarActividades();
                    cmbActividades.DataSource = actividades;
                    cmbActividades.DisplayMember = "nombre";
                    cmbActividades.ValueMember = "codActividad";
                    cmbActividades.SelectedIndex = 0;

                    txtMonto.Text = actividades[0].precio.ToString();


                }

            }
        }

        private void rdbDebito_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDebito.Checked)
            {
                cmbCuotas.Visible = false;
            }
        }

        private void rdbCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCredito.Checked)
            {
                cmbCuotas.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Text;
            Clientes cliente = new Clientes();
            try
            {
                cliente = cliente.BuscarCliente(busqueda);
                if (cliente == null)
                {
                    MessageBox.Show("No se encontró ningún cliente con los datos ingresados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cliente.idCliente > 0)
            {
                this.clientes = cliente;
                lblNombreCliente.Text = clientes.nombre + " " + clientes.apellido;
                if (clientes.esSocio)
                {
                    cmbActividades.Visible = false;
                    lblActividades.Visible = false;
                }
                else
                {
                    cmbActividades.Visible = true;
                    lblActividades.Visible = true;
                    List<E_Actividad> actividades = Actividad.listarActividades();
                    cmbActividades.DataSource = actividades;
                    cmbActividades.DisplayMember = "nombre";
                    cmbActividades.ValueMember = "codActividad";
                    cmbActividades.SelectedIndex = 0;

                    txtMonto.Text = actividades[0].precio.ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontró ningún cliente con los datos ingresados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (clientes == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para registrar el pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbCredito.Checked && cmbCuotas.Text == "Seleccione")
            {
                MessageBox.Show("Debe seleccionar la cantidad de cuotas para registrar el pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = clientes.idCliente;
            string tipoPago = rdbDebito.Checked ? "TARJETA_DEBITO" : "TARJETA_CREDITO";

            if (txtMonto.Text == "")
            {
                MessageBox.Show("Debe ingresar el monto a pagar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            float monto = float.Parse(txtMonto.Text);

            if (monto <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateOnly fechaPago = DateOnly.FromDateTime(DateTime.Now);
            DateTime? fechaVencimiento;
            if (clientes.esSocio)
            {
                fechaVencimiento = fechaPago.AddMonths(1).ToDateTime(TimeOnly.MinValue);
            }
            else
            {
                fechaVencimiento = null;
                NoSocio noSocio = new NoSocio();
                int codActividad = ((E_Actividad)cmbActividades.SelectedItem).codActividad;
                bool result = noSocio.registrarActividad(codActividad, idCliente);
                if(!result) {
                  
                    return;
                }
            }

            E_Cuota cuota = new E_Cuota()
            {
                fechaUltimoPago = fechaPago.ToDateTime(TimeOnly.MinValue),
                fechaVencimiento = fechaVencimiento,
                valorCuota = monto,
                idCliente = idCliente,
                formaPago = tipoPago
            };

            Cuota cuotas = new Cuota();
            bool resultado = cuotas.insertarCuota(cuota);
            if (resultado)
            {
                if (!clientes.esSocio)
                {
                   
                }
                MessageBox.Show("El pago se registró correctamente.", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar registrar el pago.", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Obtiene el carácter decimal de la cultura actual
            char decimalSeparator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true; // Cancela el evento si no cumple las condiciones
            }

            // Evita más de un separador decimal
            if (e.KeyChar == decimalSeparator && txtMonto.Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void cmbActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMonto.Text = ((E_Actividad)cmbActividades.SelectedItem).precio.ToString();
        }
    }
}
