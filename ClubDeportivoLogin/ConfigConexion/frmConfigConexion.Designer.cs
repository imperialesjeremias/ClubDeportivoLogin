namespace ClubDeportivoApp
{
    partial class frmConfigConexion
    {
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtServidor;
        private TextBox txtBaseDatos;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnGuardar;
        private Button btnProbar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtServidor = new TextBox();
            txtBaseDatos = new TextBox();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnGuardar = new Button();
            btnProbar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Servidor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 82);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 1;
            label2.Text = "Base de datos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(31, 126);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 2;
            label3.Text = "Usuario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 170);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 3;
            label4.Text = "Contraseña:";
            // 
            // txtServidor
            // 
            txtServidor.Font = new Font("Segoe UI", 9.818182F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtServidor.Location = new Point(144, 34);
            txtServidor.Margin = new Padding(4);
            txtServidor.Name = "txtServidor";
            txtServidor.Size = new Size(169, 27);
            txtServidor.TabIndex = 4;
            txtServidor.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Font = new Font("Segoe UI", 9.818182F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBaseDatos.Location = new Point(144, 77);
            txtBaseDatos.Margin = new Padding(4);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(169, 27);
            txtBaseDatos.TabIndex = 5;
            txtBaseDatos.TextAlign = HorizontalAlignment.Center;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 9.818182F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(144, 121);
            txtUsuario.Margin = new Padding(4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(169, 27);
            txtUsuario.TabIndex = 6;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 9.818182F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContrasena.Location = new Point(144, 165);
            txtContrasena.Margin = new Padding(4);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(169, 27);
            txtContrasena.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(13, 212);
            btnGuardar.Margin = new Padding(4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(244, 44);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnProbar
            // 
            btnProbar.Font = new Font("Segoe UI Semibold", 7.85454559F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProbar.Location = new Point(265, 212);
            btnProbar.Margin = new Padding(4);
            btnProbar.Name = "btnProbar";
            btnProbar.Size = new Size(48, 44);
            btnProbar.TabIndex = 9;
            btnProbar.Text = "TEST";
            btnProbar.UseVisualStyleBackColor = true;
            btnProbar.Click += btnProbar_Click;
            // 
            // frmConfigConexion
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(330, 275);
            Controls.Add(btnProbar);
            Controls.Add(btnGuardar);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(txtBaseDatos);
            Controls.Add(txtServidor);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmConfigConexion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CONFIGURAR CONEXIÓN";
            Load += frmConfigConexion_Load;
            ResumeLayout(false);
            PerformLayout();

        }
    }
}