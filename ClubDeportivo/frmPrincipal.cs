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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        internal string? rol;
        internal string? usuario;
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                lblUser.Text = usuario;
            }
            btnRegistrarCliente.Focus();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            frmRegistroCliente frmRegistro = new frmRegistroCliente();
            frmRegistro.ShowDialog();

        }
    }
}
