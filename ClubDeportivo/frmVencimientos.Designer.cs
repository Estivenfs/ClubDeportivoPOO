namespace ClubDeportivo
{
    partial class frmVencimientos
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
            dgvVencimientos = new DataGridView();
            lblTitulo = new Label();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).BeginInit();
            SuspendLayout();
            // 
            // dgvVencimientos
            // 
            dgvVencimientos.AllowUserToAddRows = false;
            dgvVencimientos.AllowUserToDeleteRows = false;
            dgvVencimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVencimientos.Location = new Point(12, 72);
            dgvVencimientos.Name = "dgvVencimientos";
            dgvVencimientos.ReadOnly = true;
            dgvVencimientos.RowHeadersWidth = 51;
            dgvVencimientos.Size = new Size(433, 308);
            dgvVencimientos.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(12, 32);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(171, 37);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Vencen HOY";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(351, 409);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmVencimientos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 450);
            Controls.Add(btnVolver);
            Controls.Add(lblTitulo);
            Controls.Add(dgvVencimientos);
            Name = "frmVencimientos";
            Text = "frmVencimientos";
            Load += frmVencimientos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVencimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvVencimientos;
        private Label lblTitulo;
        private Button btnVolver;
    }
}