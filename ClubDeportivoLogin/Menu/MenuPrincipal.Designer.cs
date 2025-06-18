namespace ClubDeportivoLogin
{
    partial class MenuPrincipal
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
            btnABMCliente = new Button();
            btnFacturar = new Button();
            btnLisMorosos = new Button();
            usuarioActivo = new Label();
            btnABMActividades = new Button();
            btnLisPagos = new Button();
            btnLisClientes = new Button();
            cerrarSesion = new Button();
            btnSalir = new Button();
            btnModPass = new Button();
            btnUsers = new Button();
            SuspendLayout();
            // 
            // btnABMCliente
            // 
            btnABMCliente.BackColor = Color.FromArgb(255, 255, 192);
            btnABMCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnABMCliente.Location = new Point(64, 86);
            btnABMCliente.Margin = new Padding(3, 4, 3, 4);
            btnABMCliente.Name = "btnABMCliente";
            btnABMCliente.Size = new Size(146, 106);
            btnABMCliente.TabIndex = 0;
            btnABMCliente.Text = "A.B.M. CLIENTES";
            btnABMCliente.UseVisualStyleBackColor = false;
            btnABMCliente.Click += btnABMClientes_Click;
            // 
            // btnFacturar
            // 
            btnFacturar.BackColor = Color.FromArgb(255, 255, 192);
            btnFacturar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFacturar.Location = new Point(246, 86);
            btnFacturar.Margin = new Padding(3, 4, 3, 4);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(146, 106);
            btnFacturar.TabIndex = 1;
            btnFacturar.Text = " A.B.M. \r\nPAGOS";
            btnFacturar.UseVisualStyleBackColor = false;
            btnFacturar.Click += btnPago_Click;
            // 
            // btnLisMorosos
            // 
            btnLisMorosos.BackColor = Color.FromArgb(255, 255, 192);
            btnLisMorosos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLisMorosos.Location = new Point(428, 234);
            btnLisMorosos.Margin = new Padding(3, 4, 3, 4);
            btnLisMorosos.Name = "btnLisMorosos";
            btnLisMorosos.Size = new Size(146, 106);
            btnLisMorosos.TabIndex = 2;
            btnLisMorosos.Text = "LISTAR MOROSOS";
            btnLisMorosos.UseVisualStyleBackColor = false;
            btnLisMorosos.Click += btnLisMorosos_Click;
            // 
            // usuarioActivo
            // 
            usuarioActivo.BackColor = SystemColors.InactiveCaption;
            usuarioActivo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuarioActivo.ForeColor = Color.Blue;
            usuarioActivo.Location = new Point(14, 23);
            usuarioActivo.Name = "usuarioActivo";
            usuarioActivo.Size = new Size(640, 38);
            usuarioActivo.TabIndex = 3;
            usuarioActivo.TextAlign = ContentAlignment.MiddleLeft;
            usuarioActivo.Click += label1_Click;
            // 
            // btnABMActividades
            // 
            btnABMActividades.BackColor = Color.FromArgb(255, 255, 192);
            btnABMActividades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnABMActividades.Location = new Point(428, 86);
            btnABMActividades.Margin = new Padding(3, 4, 3, 4);
            btnABMActividades.Name = "btnABMActividades";
            btnABMActividades.Size = new Size(146, 106);
            btnABMActividades.TabIndex = 4;
            btnABMActividades.Text = "A.B.M. ACTIVIDADES";
            btnABMActividades.UseVisualStyleBackColor = false;
            btnABMActividades.Click += btnABMActividad_Click;
            // 
            // btnLisPagos
            // 
            btnLisPagos.BackColor = Color.FromArgb(255, 255, 192);
            btnLisPagos.Font = new Font("Segoe UI", 11.1272726F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLisPagos.Location = new Point(246, 234);
            btnLisPagos.Margin = new Padding(3, 4, 3, 4);
            btnLisPagos.Name = "btnLisPagos";
            btnLisPagos.Size = new Size(146, 106);
            btnLisPagos.TabIndex = 5;
            btnLisPagos.Text = "LISTAR PAGOS HISTORICO";
            btnLisPagos.UseVisualStyleBackColor = false;
            btnLisPagos.Click += btnLisPagos_Click;
            // 
            // btnLisClientes
            // 
            btnLisClientes.BackColor = Color.FromArgb(255, 255, 192);
            btnLisClientes.Font = new Font("Segoe UI", 11.1272726F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLisClientes.Location = new Point(64, 234);
            btnLisClientes.Margin = new Padding(3, 4, 3, 4);
            btnLisClientes.Name = "btnLisClientes";
            btnLisClientes.Size = new Size(146, 106);
            btnLisClientes.TabIndex = 6;
            btnLisClientes.Text = "LISTAR CLIENTES HISTORICO";
            btnLisClientes.UseVisualStyleBackColor = false;
            btnLisClientes.Click += btnLisClientes_Click;
            // 
            // cerrarSesion
            // 
            cerrarSesion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarSesion.Location = new Point(338, 404);
            cerrarSesion.Margin = new Padding(3, 4, 3, 4);
            cerrarSesion.Name = "cerrarSesion";
            cerrarSesion.Size = new Size(149, 38);
            cerrarSesion.TabIndex = 7;
            cerrarSesion.Text = "CERRAR SESION";
            cerrarSesion.UseVisualStyleBackColor = true;
            cerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(505, 404);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnModPass
            // 
            btnModPass.BackColor = Color.White;
            btnModPass.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModPass.ForeColor = Color.Blue;
            btnModPass.Location = new Point(446, 25);
            btnModPass.Name = "btnModPass";
            btnModPass.Size = new Size(199, 32);
            btnModPass.TabIndex = 9;
            btnModPass.Text = "CAMBIAR CONTRASEÑA";
            btnModPass.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.FromArgb(255, 255, 192);
            btnUsers.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsers.ForeColor = Color.FromArgb(192, 0, 0);
            btnUsers.Location = new Point(64, 404);
            btnUsers.Margin = new Padding(3, 4, 3, 4);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(268, 38);
            btnUsers.TabIndex = 10;
            btnUsers.Text = "ADMINISTRAR USUARIOS";
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Visible = false;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = cerrarSesion;
            ClientSize = new Size(667, 457);
            Controls.Add(btnUsers);
            Controls.Add(btnModPass);
            Controls.Add(btnSalir);
            Controls.Add(cerrarSesion);
            Controls.Add(btnLisClientes);
            Controls.Add(btnLisPagos);
            Controls.Add(btnABMActividades);
            Controls.Add(usuarioActivo);
            Controls.Add(btnLisMorosos);
            Controls.Add(btnFacturar);
            Controls.Add(btnABMCliente);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MENU PRINCIPAL";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnABMCliente;
        private Button btnFacturar;
        private Button btnLisMorosos;
        private Label usuarioActivo;
        private Button btnABMActividades;
        private Button btnLisPagos;
        private Button btnLisClientes;
        private Button cerrarSesion;
        private Button btnSalir;
        private Button btnModPass;
        private Button btnUsers;
    }
}