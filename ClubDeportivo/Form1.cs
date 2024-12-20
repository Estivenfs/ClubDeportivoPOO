using System.Data;

namespace ClubDeportivo
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            txtUsuario.ForeColor = Color.Silver;
            txtClave.ForeColor = Color.Silver;
            txtUsuario.Focus();

        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "CONTRASEŅA")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.Black;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "CONTRASEŅA";
                txtClave.ForeColor = Color.Silver;
                txtClave.UseSystemPasswordChar = false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO" || txtClave.Text == "CONTRASEŅA")
            {
                MessageBox.Show("Ingrese usuario y contraseņa", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable tablaLogin = new DataTable();
            Datos.Usuarios usuarios = new Datos.Usuarios();
            try
            {

                tablaLogin = usuarios.LoginUsuario(txtUsuario.Text, txtClave.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar ingresar al sistema: " + ex.Message, "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (tablaLogin.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido al sistema", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPrincipal principal = new frmPrincipal();
                principal.rol= Convert.ToString(tablaLogin.Rows[0][0]);
                principal.usuario = Convert.ToString(txtUsuario.Text);
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseņa incorrecta", "Club Deportivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
