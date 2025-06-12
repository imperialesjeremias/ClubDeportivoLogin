namespace ClubDeportivoLogin.Menu.Usuarios
{
    partial class FormUsuarios
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
            label1 = new Label();
            lblContraseña = new Label();
            lblRol = new Label();
            txtUsuario = new TextBox();
            comboRol = new ComboBox();
            txtContraseña = new TextBox();
            btnGuardar = new Button();
            btnSalir = new Button();
            lblTipoRegistro = new Label();
            btnBorrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 52);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "USUARIO:";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(24, 136);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(110, 20);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "CONTRASEÑA:";
            lblContraseña.Visible = false;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(94, 95);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(40, 20);
            lblRol.TabIndex = 2;
            lblRol.Text = "ROL:";
            lblRol.Visible = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(143, 53);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(191, 26);
            txtUsuario.TabIndex = 3;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // comboRol
            // 
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(140, 93);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(194, 27);
            comboRol.TabIndex = 4;
            comboRol.Visible = false;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(141, 137);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(193, 26);
            txtContraseña.TabIndex = 5;
            txtContraseña.Visible = false;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(161, 214);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 38);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Visible = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(272, 214);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(105, 38);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTipoRegistro
            // 
            lblTipoRegistro.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoRegistro.ForeColor = Color.Blue;
            lblTipoRegistro.Location = new Point(143, 1);
            lblTipoRegistro.Name = "lblTipoRegistro";
            lblTipoRegistro.Size = new Size(235, 30);
            lblTipoRegistro.TabIndex = 8;
            lblTipoRegistro.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(12, 214);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(105, 38);
            btnBorrar.TabIndex = 9;
            btnBorrar.Text = "BORRAR";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Visible = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(390, 264);
            Controls.Add(btnBorrar);
            Controls.Add(lblTipoRegistro);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(txtContraseña);
            Controls.Add(comboRol);
            Controls.Add(txtUsuario);
            Controls.Add(lblRol);
            Controls.Add(lblContraseña);
            Controls.Add(label1);
            Name = "FormUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ADMINISTRAR USUARIOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblContraseña;
        private Label lblRol;
        private TextBox txtUsuario;
        private ComboBox comboRol;
        private TextBox txtContraseña;
        private Button btnGuardar;
        private Button btnSalir;
        private Label lblTipoRegistro;
        private Button btnBorrar;
    }
}