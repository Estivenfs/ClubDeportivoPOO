namespace ClubDeportivo
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalir = new Button();
            lblUser = new Label();
            btnRegistrarCliente = new Button();
            btnRegistrarPago = new Button();
            btnVencimientos = new Button();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(694, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Stencil", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(12, 16);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(70, 27);
            lblUser.TabIndex = 1;
            lblUser.Text = "User";
            // 
            // btnRegistrarCliente
            // 
            btnRegistrarCliente.Location = new Point(53, 143);
            btnRegistrarCliente.Name = "btnRegistrarCliente";
            btnRegistrarCliente.Size = new Size(280, 74);
            btnRegistrarCliente.TabIndex = 1;
            btnRegistrarCliente.Text = "REGISTRAR CLIENTE";
            btnRegistrarCliente.UseVisualStyleBackColor = true;
            btnRegistrarCliente.Click += btnRegistrarCliente_Click;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(355, 143);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(280, 74);
            btnRegistrarPago.TabIndex = 6;
            btnRegistrarPago.Text = "REGISTRAR PAGO";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnVencimientos
            // 
            btnVencimientos.Location = new Point(53, 247);
            btnVencimientos.Name = "btnVencimientos";
            btnVencimientos.Size = new Size(280, 74);
            btnVencimientos.TabIndex = 7;
            btnVencimientos.Text = "VER VENCIMIENTOS";
            btnVencimientos.UseVisualStyleBackColor = true;
            btnVencimientos.Click += btnVencimientos_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVencimientos);
            Controls.Add(btnRegistrarPago);
            Controls.Add(btnRegistrarCliente);
            Controls.Add(lblUser);
            Controls.Add(btnSalir);
            Name = "frmPrincipal";
            Text = "Administracion";
            Load += frmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Label lblUser;
        private Button btnRegistrarCliente;
        private Button btnRegistrarPago;
        private Button btnVencimientos;
    }
}