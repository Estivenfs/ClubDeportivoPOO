namespace ClubDeportivo
{
    partial class frmCredencial
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
            pictureBox1 = new PictureBox();
            lblCredencial = new Label();
            lblTextNombre = new Label();
            lblTextApellido = new Label();
            lblTextDni = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            LblDni = new Label();
            pictureBox2 = new PictureBox();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.clubDeportivo;
            pictureBox1.Location = new Point(26, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(271, 364);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblCredencial
            // 
            lblCredencial.AutoSize = true;
            lblCredencial.BackColor = Color.White;
            lblCredencial.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCredencial.Location = new Point(326, 34);
            lblCredencial.Name = "lblCredencial";
            lblCredencial.Size = new Size(224, 46);
            lblCredencial.TabIndex = 1;
            lblCredencial.Text = "CREDENCIAL";
            // 
            // lblTextNombre
            // 
            lblTextNombre.AutoSize = true;
            lblTextNombre.BackColor = Color.White;
            lblTextNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTextNombre.Location = new Point(326, 107);
            lblTextNombre.Name = "lblTextNombre";
            lblTextNombre.Size = new Size(94, 28);
            lblTextNombre.TabIndex = 2;
            lblTextNombre.Text = "Nombre:";
            // 
            // lblTextApellido
            // 
            lblTextApellido.AutoSize = true;
            lblTextApellido.BackColor = Color.White;
            lblTextApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTextApellido.Location = new Point(326, 161);
            lblTextApellido.Name = "lblTextApellido";
            lblTextApellido.Size = new Size(96, 28);
            lblTextApellido.TabIndex = 3;
            lblTextApellido.Text = "Apellido:";
            // 
            // lblTextDni
            // 
            lblTextDni.AutoSize = true;
            lblTextDni.BackColor = Color.White;
            lblTextDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTextDni.Location = new Point(326, 240);
            lblTextDni.Name = "lblTextDni";
            lblTextDni.Size = new Size(54, 28);
            lblTextDni.TabIndex = 4;
            lblTextDni.Text = "DNI:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.White;
            lblNombre.Font = new Font("Perpetua Titling MT", 12F, FontStyle.Bold);
            lblNombre.Location = new Point(439, 107);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(84, 24);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "pedro";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.BackColor = Color.White;
            lblApellido.Font = new Font("Perpetua Titling MT", 12F, FontStyle.Bold);
            lblApellido.Location = new Point(439, 165);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(78, 24);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "PEREZ";
            // 
            // LblDni
            // 
            LblDni.AutoSize = true;
            LblDni.BackColor = Color.White;
            LblDni.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            LblDni.Location = new Point(439, 240);
            LblDni.Name = "LblDni";
            LblDni.Size = new Size(92, 27);
            LblDni.TabIndex = 7;
            LblDni.Text = "95852748";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Diseño_sin_título;
            pictureBox2.Location = new Point(-1, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(800, 450);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(663, 387);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(94, 29);
            btnImprimir.TabIndex = 9;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            // 
            // frmCredencial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnImprimir);
            Controls.Add(LblDni);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(lblTextDni);
            Controls.Add(lblTextApellido);
            Controls.Add(lblTextNombre);
            Controls.Add(lblCredencial);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Name = "frmCredencial";
            Text = "frmCredencial";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblCredencial;
        private Label lblTextNombre;
        private Label lblTextApellido;
        private Label lblTextDni;
        private Label lblNombre;
        private Label lblApellido;
        private Label LblDni;
        private PictureBox pictureBox2;
        private Button btnImprimir;
    }
}