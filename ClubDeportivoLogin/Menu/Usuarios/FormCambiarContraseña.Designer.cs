namespace ClubDeportivoLogin.Menu.Usuarios
{
    partial class FormCambiarContraseña
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
            txtPassActual = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPassNueva = new TextBox();
            txtRepetirNueva = new TextBox();
            btnGuardar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 43);
            label1.Name = "label1";
            label1.Size = new Size(169, 20);
            label1.TabIndex = 0;
            label1.Text = "CONTRASEÑA ACTUAL:";
            // 
            // txtPassActual
            // 
            txtPassActual.Location = new Point(192, 40);
            txtPassActual.Name = "txtPassActual";
            txtPassActual.Size = new Size(157, 26);
            txtPassActual.TabIndex = 1;
            txtPassActual.TextAlign = HorizontalAlignment.Center;
            txtPassActual.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 87);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 6;
            label2.Text = "CONTRASEÑA NUEVA:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(63, 129);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 7;
            label3.Text = "REPETIR NUEVA:";
            // 
            // txtPassNueva
            // 
            txtPassNueva.Location = new Point(191, 85);
            txtPassNueva.Name = "txtPassNueva";
            txtPassNueva.Size = new Size(157, 26);
            txtPassNueva.TabIndex = 8;
            txtPassNueva.TextAlign = HorizontalAlignment.Center;
            txtPassNueva.UseSystemPasswordChar = true;
            // 
            // txtRepetirNueva
            // 
            txtRepetirNueva.Location = new Point(191, 127);
            txtRepetirNueva.Name = "txtRepetirNueva";
            txtRepetirNueva.Size = new Size(157, 26);
            txtRepetirNueva.TabIndex = 9;
            txtRepetirNueva.TextAlign = HorizontalAlignment.Center;
            txtRepetirNueva.UseSystemPasswordChar = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(21, 200);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(224, 200);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FormCambiarContraseña
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(396, 250);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(txtRepetirNueva);
            Controls.Add(txtPassNueva);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassActual);
            Controls.Add(label1);
            Name = "FormCambiarContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MODIFICAR CONTRASEÑA";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPassActual;
        private Label label2;
        private Label label3;
        private TextBox txtPassNueva;
        private TextBox txtRepetirNueva;
        private Button btnGuardar;
        private Button btnSalir;
    }
}