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
    public partial class frmVencimientos : Form
    {
        public frmVencimientos()
        {
            InitializeComponent();
        }

        private void frmVencimientos_Load(object sender, EventArgs e)
        {
            Cuota cuota = new Cuota();
            List<E_Cuota_Cliente> vencimientos = cuota.listarVencimientos();

            // Llenar el DataGridView con solo las columnas requeridas
            if( vencimientos == null)
            {
                MessageBox.Show("No hay vencimientos pendientes");
                return;
            }
            dgvVencimientos.DataSource = vencimientos.Select(vc => new
            {
                Nombre = vc.cliente.nombre,
                Apellido = vc.cliente.apellido,
                DNI = vc.cliente.dni
            }).ToList();

            // Opcional: Ajustar el ancho de las columnas
            dgvVencimientos.Columns["Nombre"].Width = 100;
            dgvVencimientos.Columns["Apellido"].Width = 100;
            dgvVencimientos.Columns["DNI"].Width = 80;




        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
