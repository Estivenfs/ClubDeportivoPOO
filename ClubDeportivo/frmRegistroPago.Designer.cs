namespace ClubDeportivo
{
    partial class frmRegistroPago
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
            txtBusqueda = new TextBox();
            label1 = new Label();
            btnBuscar = new Button();
            lblActividades = new Label();
            cmbActividades = new ComboBox();
            rdbDebito = new RadioButton();
            rdbCredito = new RadioButton();
            cmbCuotas = new ComboBox();
            btnRegistrarPago = new Button();
            lblNombreCliente = new Label();
            lblMonto = new Label();
            txtMonto = new TextBox();
            SuspendLayout();
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(154, 26);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(288, 27);
            txtBusqueda.TabIndex = 0;
            txtBusqueda.Text = "DNI, Nombre o Apellido";
            txtBusqueda.Enter += txtBusqueda_Enter;
            txtBusqueda.Leave += txtBusqueda_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 29);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 1;
            label1.Text = "Buscar Usuario";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(477, 26);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblActividades
            // 
            lblActividades.AutoSize = true;
            lblActividades.Location = new Point(28, 82);
            lblActividades.Name = "lblActividades";
            lblActividades.Size = new Size(86, 20);
            lblActividades.TabIndex = 3;
            lblActividades.Text = "Actividades";
            // 
            // cmbActividades
            // 
            cmbActividades.FormattingEnabled = true;
            cmbActividades.Location = new Point(154, 79);
            cmbActividades.Name = "cmbActividades";
            cmbActividades.Size = new Size(288, 28);
            cmbActividades.TabIndex = 4;
            cmbActividades.Text = "Seleccione";
            // 
            // rdbDebito
            // 
            rdbDebito.AutoSize = true;
            rdbDebito.Checked = true;
            rdbDebito.Location = new Point(32, 183);
            rdbDebito.Name = "rdbDebito";
            rdbDebito.Size = new Size(76, 24);
            rdbDebito.TabIndex = 5;
            rdbDebito.TabStop = true;
            rdbDebito.Text = "Debito";
            rdbDebito.UseVisualStyleBackColor = true;
            rdbDebito.CheckedChanged += rdbDebito_CheckedChanged;
            // 
            // rdbCredito
            // 
            rdbCredito.AutoSize = true;
            rdbCredito.Location = new Point(158, 183);
            rdbCredito.Name = "rdbCredito";
            rdbCredito.Size = new Size(79, 24);
            rdbCredito.TabIndex = 6;
            rdbCredito.TabStop = true;
            rdbCredito.Text = "Credito";
            rdbCredito.UseVisualStyleBackColor = true;
            rdbCredito.CheckedChanged += rdbCredito_CheckedChanged;
            // 
            // cmbCuotas
            // 
            cmbCuotas.FormattingEnabled = true;
            cmbCuotas.Items.AddRange(new object[] { "1 Cuota", "3 Cuotas", "6 Cuotas" });
            cmbCuotas.Location = new Point(328, 183);
            cmbCuotas.Name = "cmbCuotas";
            cmbCuotas.Size = new Size(151, 28);
            cmbCuotas.TabIndex = 7;
            cmbCuotas.Text = "Seleccione";
            cmbCuotas.Visible = false;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(527, 228);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(139, 29);
            btnRegistrarPago.TabIndex = 8;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(45, 231);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(86, 20);
            lblNombreCliente.TabIndex = 9;
            lblNombreCliente.Text = "Pedro Perez";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(28, 129);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(53, 20);
            lblMonto.TabIndex = 10;
            lblMonto.Text = "Monto";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(154, 126);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(288, 27);
            txtMonto.TabIndex = 11;
            // 
            // frmRegistroPago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 280);
            Controls.Add(txtMonto);
            Controls.Add(lblMonto);
            Controls.Add(lblNombreCliente);
            Controls.Add(btnRegistrarPago);
            Controls.Add(cmbCuotas);
            Controls.Add(rdbCredito);
            Controls.Add(rdbDebito);
            Controls.Add(cmbActividades);
            Controls.Add(lblActividades);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Name = "frmRegistroPago";
            Text = "Pago";
            Load += frmRegistroPago_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBusqueda;
        private Label label1;
        private Button btnBuscar;
        private Label lblActividades;
        private ComboBox cmbActividades;
        private RadioButton rdbDebito;
        private RadioButton rdbCredito;
        private ComboBox cmbCuotas;
        private Button btnRegistrarPago;
        private Label lblNombreCliente;
        private Label lblMonto;
        private TextBox txtMonto;
    }
}