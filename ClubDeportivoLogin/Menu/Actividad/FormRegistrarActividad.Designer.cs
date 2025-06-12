namespace ClubDeportivoLogin
{
    partial class FormRegistrarActividad
    {
        
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnGuardar = new Button();
            btnSalir = new Button();
            tabPage1 = new TabPage();
            txtCosto = new TextBox();
            txtActividad = new TextBox();
            lblCosto = new Label();
            lblActividad = new Label();
            tabControl1 = new TabControl();
            lblEstado = new Label();
            btnBorrar = new Button();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(333, 405);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 38);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(506, 405);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.GradientActiveCaption;
            tabPage1.Controls.Add(txtCosto);
            tabPage1.Controls.Add(txtActividad);
            tabPage1.Controls.Add(lblCosto);
            tabPage1.Controls.Add(lblActividad);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(575, 281);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            // 
            // txtCosto
            // 
            txtCosto.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCosto.ForeColor = Color.SeaGreen;
            txtCosto.Location = new Point(369, 159);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(152, 30);
            txtCosto.TabIndex = 3;
            txtCosto.TextAlign = HorizontalAlignment.Center;
            // 
            // txtActividad
            // 
            txtActividad.Font = new Font("Segoe UI", 11.1272726F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtActividad.Location = new Point(141, 79);
            txtActividad.Name = "txtActividad";
            txtActividad.Size = new Size(380, 30);
            txtActividad.TabIndex = 2;
            txtActividad.TextAlign = HorizontalAlignment.Center;
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCosto.Location = new Point(281, 161);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(82, 23);
            lblCosto.TabIndex = 1;
            lblCosto.Text = "COSTO: $";
            // 
            // lblActividad
            // 
            lblActividad.AutoSize = true;
            lblActividad.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActividad.Location = new Point(34, 82);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(101, 23);
            lblActividad.TabIndex = 0;
            lblActividad.Text = "ACTIVIDAD:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(43, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(583, 313);
            tabControl1.TabIndex = 0;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI Semibold", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.Blue;
            lblEstado.Location = new Point(214, 31);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(408, 32);
            lblEstado.TabIndex = 3;
            lblEstado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(43, 405);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(149, 38);
            btnBorrar.TabIndex = 4;
            btnBorrar.Text = "BORRAR";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // FormRegistrarActividad
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(btnBorrar);
            Controls.Add(lblEstado);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(tabControl1);
            Name = "FormRegistrarActividad";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A.B.M. de \"Maestro de Actividades\"";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnGuardar;
        private Button btnSalir;
        private TabPage tabPage1;
        private TabControl tabControl1;
        private Label lblActividad;
        private TextBox txtCosto;
        private TextBox txtActividad;
        private Label lblCosto;
        private Label lblEstado;
        private Button btnBorrar;
    }
}