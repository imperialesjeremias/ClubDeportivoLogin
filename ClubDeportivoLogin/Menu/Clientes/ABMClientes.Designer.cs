namespace ClubDeportivoLogin
{
    partial class ABMClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMClientes));
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            btnSiguiente = new Button();
            btnSalir = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(14, 23);
            label1.Name = "label1";
            label1.Size = new Size(272, 38);
            label1.TabIndex = 1;
            label1.Text = "Maestro de clientes";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 11.25F);
            textBox1.Location = new Point(465, 29);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 30);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.GradientInactiveCaption;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(408, 20);
            label2.Name = "label2";
            label2.Size = new Size(245, 50);
            label2.TabIndex = 3;
            label2.Text = "DNI:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 9.75F);
            btnSiguiente.Location = new Point(325, 404);
            btnSiguiente.Margin = new Padding(3, 4, 3, 4);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(149, 38);
            btnSiguiente.TabIndex = 4;
            btnSiguiente.Text = "SIGUIENTE";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F);
            btnSalir.Location = new Point(505, 404);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(269, 85);
            label3.Name = "label3";
            label3.Size = new Size(205, 30);
            label3.TabIndex = 6;
            label3.Text = "Asistente de A.B.M.";
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(269, 130);
            label4.Name = "label4";
            label4.Size = new Size(377, 71);
            label4.TabIndex = 7;
            label4.Text = "Este asistente le ayudará a consultar, agregar, modificar\r\n o borrar un código de la tabla, y realizar cambios en el\r\n \"Maestro de clientes\".";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(283, 219);
            label5.Name = "label5";
            label5.Size = new Size(349, 60);
            label5.TabIndex = 8;
            label5.Text = "Ingrese el DNI (solo números) que desea consultar, \r\nagregar, modificar o borrar y presione \"Enter\" o \r\nbotón \"Siguiente\" para continuar.";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(14, 85);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // ABMClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSalir);
            Controls.Add(btnSiguiente);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ABMClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A.B.M. DE CLIENTES";
            Load += ABMClientes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button btnSiguiente;
        private Button btnSalir;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
    }
}