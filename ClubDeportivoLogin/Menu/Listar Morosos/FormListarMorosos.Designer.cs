namespace ClubDeportivoLogin
{
    partial class FormListarMorosos
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
            dgvMorosos = new DataGridView();
            btnSalir = new Button();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMorosos).BeginInit();
            SuspendLayout();
            // 
            // dgvMorosos
            // 
            dgvMorosos.BackgroundColor = SystemColors.Control;
            dgvMorosos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMorosos.Location = new Point(36, 31);
            dgvMorosos.Margin = new Padding(3, 4, 3, 4);
            dgvMorosos.Name = "dgvMorosos";
            dgvMorosos.RowHeadersWidth = 47;
            dgvMorosos.Size = new Size(596, 365);
            dgvMorosos.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(483, 407);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(315, 407);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(149, 38);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // frmSociosMorosos
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(btnImprimir);
            Controls.Add(btnSalir);
            Controls.Add(dgvMorosos);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSociosMorosos";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Morosos";
            Load += frmSociosMorosos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMorosos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMorosos;
        private Button btnSalir;
        private Button btnImprimir;
    }
}