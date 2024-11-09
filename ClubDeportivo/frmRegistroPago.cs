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
            Clientes clientes = cliente.BuscarCliente(busqueda);
            if (clientes != null)
            {
                this.clientes = clientes;
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
            string tipoPago = rdbDebito.Checked ? "Debito" : "Credito";
            float monto = float.Parse(txtMonto.Text);
            DateOnly fechaPago = DateOnly.FromDateTime(DateTime.Now);
            DateTime? fechaVencimiento;
            if (clientes.esSocio)
            {
                fechaVencimiento = fechaPago.AddMonths(1).ToDateTime(TimeOnly.MinValue);
            }
            else
            {
                fechaVencimiento = null;
            }

            E_Cuota cuota = new E_Cuota()
            {
                fechaUltimoPago = fechaPago.ToDateTime(TimeOnly.MinValue),
                fechaVencimiento = (DateTime)fechaVencimiento,              
                valorCuota = monto,
                idCliente = idCliente
            };

            Cuota cuotas = new Cuota();
            bool resultado = cuotas.insertarCuota(cuota);
            if (resultado) {
                MessageBox.Show("El pago se registró correctamente.", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar registrar el pago.", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
