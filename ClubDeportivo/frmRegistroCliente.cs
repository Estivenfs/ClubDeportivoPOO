using ClubDeportivo.Datos;
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
    public partial class frmRegistroCliente : Form
    {
        public frmRegistroCliente()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblRegistroCliente = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDni = new Label();
            lblAptoFisico = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            chckAptoFisico = new CheckBox();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            toolTipLimpiarDatos = new ToolTip(components);
            btnVolverRegistro = new Button();
            chckEsSocio = new CheckBox();
            lblEsSocio = new Label();
            btnVerCredencial = new Button();
            SuspendLayout();
            // 
            // lblRegistroCliente
            // 
            lblRegistroCliente.AutoSize = true;
            lblRegistroCliente.Location = new Point(377, 39);
            lblRegistroCliente.Name = "lblRegistroCliente";
            lblRegistroCliente.Size = new Size(158, 20);
            lblRegistroCliente.TabIndex = 0;
            lblRegistroCliente.Text = "REGISTRO DE CLIENTE";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(285, 100);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(285, 148);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(66, 20);
            lblApellido.TabIndex = 2;
            lblApellido.Text = "Apellido";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(285, 194);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(35, 20);
            lblDni.TabIndex = 3;
            lblDni.Text = "DNI";
            // 
            // lblAptoFisico
            // 
            lblAptoFisico.AutoSize = true;
            lblAptoFisico.Location = new Point(285, 243);
            lblAptoFisico.Name = "lblAptoFisico";
            lblAptoFisico.Size = new Size(83, 20);
            lblAptoFisico.TabIndex = 4;
            lblAptoFisico.Text = "Apto Fìsico";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(377, 97);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(261, 27);
            txtNombre.TabIndex = 5;
            txtNombre.KeyDown += txtNombre_KeyDown;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(377, 145);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(261, 27);
            txtApellido.TabIndex = 6;
            txtApellido.KeyDown += txtNombre_KeyDown;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(377, 191);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(261, 27);
            txtDni.TabIndex = 7;
            txtDni.KeyDown += txtNombre_KeyDown;
            txtDni.KeyPress += txtDni_KeyPress;
            // 
            // chckAptoFisico
            // 
            chckAptoFisico.AutoSize = true;
            chckAptoFisico.Location = new Point(377, 246);
            chckAptoFisico.Name = "chckAptoFisico";
            chckAptoFisico.Size = new Size(18, 17);
            chckAptoFisico.TabIndex = 8;
            chckAptoFisico.UseVisualStyleBackColor = true;
            chckAptoFisico.CheckedChanged += chckAptoFisico_CheckedChanged;
            chckAptoFisico.KeyDown += txtNombre_KeyDown;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(285, 282);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(221, 67);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackgroundImage = Properties.Resources.cleanIcon;
            btnLimpiar.BackgroundImageLayout = ImageLayout.Stretch;
            btnLimpiar.Location = new Point(705, 349);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(56, 53);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVolverRegistro
            // 
            btnVolverRegistro.Location = new Point(667, 12);
            btnVolverRegistro.Name = "btnVolverRegistro";
            btnVolverRegistro.Size = new Size(94, 29);
            btnVolverRegistro.TabIndex = 11;
            btnVolverRegistro.Text = "VOLVER";
            btnVolverRegistro.UseVisualStyleBackColor = true;
            btnVolverRegistro.Click += btnVolverRegistro_Click;
            // 
            // chckEsSocio
            // 
            chckEsSocio.AutoSize = true;
            chckEsSocio.Location = new Point(544, 246);
            chckEsSocio.Name = "chckEsSocio";
            chckEsSocio.Size = new Size(18, 17);
            chckEsSocio.TabIndex = 9;
            chckEsSocio.UseVisualStyleBackColor = true;
            chckEsSocio.CheckedChanged += chckEsSocio_CheckedChanged;
            chckEsSocio.KeyDown += txtNombre_KeyDown;
            // 
            // lblEsSocio
            // 
            lblEsSocio.AutoSize = true;
            lblEsSocio.Location = new Point(452, 243);
            lblEsSocio.Name = "lblEsSocio";
            lblEsSocio.Size = new Size(64, 20);
            lblEsSocio.TabIndex = 12;
            lblEsSocio.Text = "Es Socio";
            // 
            // btnVerCredencial
            // 
            btnVerCredencial.Location = new Point(524, 284);
            btnVerCredencial.Name = "btnVerCredencial";
            btnVerCredencial.Size = new Size(146, 62);
            btnVerCredencial.TabIndex = 13;
            btnVerCredencial.Text = "VER CREDENCIAL";
            btnVerCredencial.UseVisualStyleBackColor = true;
            btnVerCredencial.Visible = false;
            btnVerCredencial.Click += btnVerCredencial_Click;
            // 
            // frmRegistroCliente
            // 
            ClientSize = new Size(773, 414);
            Controls.Add(btnVerCredencial);
            Controls.Add(chckEsSocio);
            Controls.Add(lblEsSocio);
            Controls.Add(btnVolverRegistro);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrar);
            Controls.Add(chckAptoFisico);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(lblAptoFisico);
            Controls.Add(lblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblRegistroCliente);
            Name = "frmRegistroCliente";
            Load += frmRegistroCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblRegistroCliente;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private CheckBox chckAptoFisico;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private ToolTip toolTipLimpiarDatos;
        private IContainer components;
        private Button btnVolverRegistro;
        private CheckBox chckEsSocio;
        private Label lblEsSocio;
        private Button btnVerCredencial;
        private Label lblAptoFisico;

        private void frmRegistroCliente_Load(object sender, EventArgs e)
        {
            toolTipLimpiarDatos.SetToolTip(btnLimpiar, "Limpiar Datos");
            txtNombre.Focus();
            btnVerCredencial.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtNombre.Clear();
            txtDni.Clear();
            chckAptoFisico.Checked = false;
            chckEsSocio.Checked = false;
            txtNombre.Focus();
            btnVerCredencial.Visible = false;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número, cancelar el evento para que el carácter no se muestre
                e.Handled = true;
            }
        }

        private void btnVolverRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                this.SelectNextControl((Control)sender, true, true, true, true);
                e.SuppressKeyPress = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Entidades.E_Cliente cliente = new Entidades.E_Cliente();
                cliente.nombre = txtNombre.Text;
                cliente.apellido = txtApellido.Text;
                cliente.dni = Convert.ToInt32(txtDni.Text);
                cliente.aptoFisico = chckAptoFisico.Checked;
                cliente.esSocio = chckEsSocio.Checked;

                Datos.Clientes datos;
                if (cliente.esSocio)
                {
                    datos = new Datos.Socio();
                }
                else
                {
                    datos = new Datos.NoSocio();
                }
                string? respuesta = datos.completarInscripcion(cliente);
                if (respuesta == "-1")
                {
                    MessageBox.Show("Error, el cliente ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Cliente registrado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cliente.idCliente = Convert.ToInt32(respuesta);
                    Clientes pagoCliente = new Clientes() { 
                        idCliente = cliente.idCliente,
                        nombre = cliente.nombre,
                        apellido = cliente.apellido,
                        dni = cliente.dni,
                        aptoFisico = cliente.aptoFisico,
                        esSocio = cliente.esSocio
                    };
                    frmRegistroPago frmRegistroPago = new frmRegistroPago();
                    frmRegistroPago.clientes = pagoCliente;
                    frmRegistroPago.ShowDialog();

                    if (cliente.esSocio)
                    {
                        //btnVerCredencial_Click(null, e);
                        btnVerCredencial.Visible = true;
                    }
                    
                }

            }
        }

        private void chckEsSocio_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEsSocio.Checked && !chckAptoFisico.Checked)
            {
                MessageBox.Show("El apto físico es requerido para ser socio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Desmarcar el CheckBox de "Socio"
                chckEsSocio.Checked = false;
            }
        }

        private void chckAptoFisico_CheckedChanged(object sender, EventArgs e)
        {
            if (!chckAptoFisico.Checked)
            {
                chckEsSocio.Checked = false;
            }
        }

        private void btnVerCredencial_Click(object sender, EventArgs e)
        {
            frmCredencial frmCredencial = new frmCredencial();
            frmCredencial.nombre = txtNombre.Text;
            frmCredencial.apellido = txtApellido.Text;
            frmCredencial.dni = txtDni.Text;
            frmCredencial.ShowDialog();
        }
    }
}
