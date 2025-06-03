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
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            cerrarSesion = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnABMCliente
            // 
            btnABMCliente.BackColor = Color.FromArgb(255, 255, 192);
            btnABMCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnABMCliente.Location = new Point(56, 68);
            btnABMCliente.Name = "btnABMCliente";
            btnABMCliente.Size = new Size(128, 84);
            btnABMCliente.TabIndex = 0;
            btnABMCliente.Text = "A.B.M. CLIENTES";
            btnABMCliente.UseVisualStyleBackColor = false;
            btnABMCliente.Click += btnABMCliente_Click;
            // 
            // btnFacturar
            // 
            btnFacturar.BackColor = Color.FromArgb(255, 255, 192);
            btnFacturar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFacturar.Location = new Point(215, 68);
            btnFacturar.Name = "btnFacturar";
            btnFacturar.Size = new Size(128, 84);
            btnFacturar.TabIndex = 1;
            btnFacturar.Text = "FACTURAR";
            btnFacturar.UseVisualStyleBackColor = false;
            btnFacturar.Click += btnFacturar_Click;
            // 
            // btnLisMorosos
            // 
            btnLisMorosos.BackColor = Color.FromArgb(255, 255, 192);
            btnLisMorosos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLisMorosos.Location = new Point(379, 68);
            btnLisMorosos.Name = "btnLisMorosos";
            btnLisMorosos.Size = new Size(128, 84);
            btnLisMorosos.TabIndex = 2;
            btnLisMorosos.Text = "LISTAR MOROSOS";
            btnLisMorosos.UseVisualStyleBackColor = false;
            // 
            // usuarioActivo
            // 
            usuarioActivo.BackColor = SystemColors.InactiveCaption;
            usuarioActivo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usuarioActivo.ForeColor = Color.Blue;
            usuarioActivo.Location = new Point(12, 19);
            usuarioActivo.Name = "usuarioActivo";
            usuarioActivo.Size = new Size(560, 30);
            usuarioActivo.TabIndex = 3;
            usuarioActivo.TextAlign = ContentAlignment.MiddleLeft;
            usuarioActivo.Click += label1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(56, 185);
            button3.Name = "button3";
            button3.Size = new Size(128, 84);
            button3.TabIndex = 4;
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(215, 185);
            button1.Name = "button1";
            button1.Size = new Size(128, 84);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(379, 185);
            button2.Name = "button2";
            button2.Size = new Size(128, 84);
            button2.TabIndex = 6;
            button2.UseVisualStyleBackColor = false;
            // 
            // cerrarSesion
            // 
            cerrarSesion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cerrarSesion.Location = new Point(296, 319);
            cerrarSesion.Name = "cerrarSesion";
            cerrarSesion.Size = new Size(130, 30);
            cerrarSesion.TabIndex = 7;
            cerrarSesion.Text = "CERRAR SESION";
            cerrarSesion.UseVisualStyleBackColor = true;
            cerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(442, 319);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 30);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(btnSalir);
            Controls.Add(cerrarSesion);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(usuarioActivo);
            Controls.Add(btnLisMorosos);
            Controls.Add(btnFacturar);
            Controls.Add(btnABMCliente);
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
        private Button button3;
        private Button button1;
        private Button button2;
        private Button cerrarSesion;
        private Button btnSalir;
    }
}