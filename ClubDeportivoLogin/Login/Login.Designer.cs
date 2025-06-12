namespace ClubDeportivoLogin
{
    partial class Login
    {

        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            camposObligatorios = new Label();
            lblUsuarioCerroSesion = new Label();
            btnConfigConexion = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(282, 138);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "USUARIO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(246, 212);
            label2.Name = "label2";
            label2.Size = new Size(143, 25);
            label2.TabIndex = 1;
            label2.Text = "CONTRASEÑA:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(386, 134);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(217, 32);
            txtUsuario.TabIndex = 2;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(386, 208);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(217, 32);
            txtPassword.TabIndex = 3;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(224, 224, 224);
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(121, 343);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(457, 61);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "INGRESAR";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(31, 27);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(209, 234);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(294, 53);
            label3.Name = "label3";
            label3.Size = new Size(339, 42);
            label3.TabIndex = 6;
            label3.Text = "INGRESO AL SISTEMA";
            // 
            // camposObligatorios
            // 
            camposObligatorios.AutoSize = true;
            camposObligatorios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            camposObligatorios.ForeColor = Color.Red;
            camposObligatorios.Location = new Point(600, 138);
            camposObligatorios.Name = "camposObligatorios";
            camposObligatorios.Size = new Size(21, 100);
            camposObligatorios.TabIndex = 7;
            camposObligatorios.Text = "*\r\n\r\n\r\n*";
            camposObligatorios.Visible = false;
            // 
            // lblUsuarioCerroSesion
            // 
            lblUsuarioCerroSesion.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsuarioCerroSesion.ForeColor = Color.Blue;
            lblUsuarioCerroSesion.Location = new Point(14, 408);
            lblUsuarioCerroSesion.Name = "lblUsuarioCerroSesion";
            lblUsuarioCerroSesion.Size = new Size(640, 38);
            lblUsuarioCerroSesion.TabIndex = 8;
            lblUsuarioCerroSesion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnConfigConexion
            // 
            btnConfigConexion.BackColor = Color.White;
            btnConfigConexion.FlatStyle = FlatStyle.Popup;
            btnConfigConexion.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfigConexion.ForeColor = Color.Blue;
            btnConfigConexion.Location = new Point(31, 268);
            btnConfigConexion.Name = "btnConfigConexion";
            btnConfigConexion.Size = new Size(209, 53);
            btnConfigConexion.TabIndex = 9;
            btnConfigConexion.Text = "Configurar Conexión con la BASE DE DATOS";
            btnConfigConexion.UseVisualStyleBackColor = false;
            btnConfigConexion.Click += btnConfigurar_Click;
            // 
            // Login
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(btnConfigConexion);
            Controls.Add(pictureBox1);
            Controls.Add(lblUsuarioCerroSesion);
            Controls.Add(camposObligatorios);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CLUB DEPORTIVO";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pictureBox1;
        private Label label3;
        private Label camposObligatorios;
        private Label lblUsuarioCerroSesion;
        private Button btnConfigConexion;
    }
}
