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
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(237, 32);
            label1.TabIndex = 1;
            label1.Text = "Maestro de clientes";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 11.25F);
            textBox1.Location = new Point(407, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(153, 27);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.GradientInactiveCaption;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(357, 16);
            label2.Name = "label2";
            label2.Size = new Size(215, 40);
            label2.TabIndex = 3;
            label2.Text = "DNI:                                 ";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 9.75F);
            btnSiguiente.Location = new Point(284, 319);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(130, 30);
            btnSiguiente.TabIndex = 4;
            btnSiguiente.Text = "SIGUIENTE";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F);
            btnSalir.Location = new Point(442, 319);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 30);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(235, 67);
            label3.Name = "label3";
            label3.Size = new Size(179, 25);
            label3.TabIndex = 6;
            label3.Text = "Asistente de A.B.M.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F);
            label4.Location = new Point(235, 103);
            label4.Name = "label4";
            label4.Size = new Size(336, 51);
            label4.TabIndex = 7;
            label4.Text = "Este asistente le ayudará a consultar, agregar, modificar\r\n o borrar un código de la tabla, y realizar cambios en el\r\n \"Maestro de clientes\".";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(248, 173);
            label5.Name = "label5";
            label5.Size = new Size(312, 51);
            label5.TabIndex = 8;
            label5.Text = "Ingrese el DNI (solo números) que desea consultar, \r\nagregar, modificar o borrar y presione \"Enter\" o \r\nbotón \"Siguiente\" para continuar.";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // ABMClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSalir);
            Controls.Add(btnSiguiente);
            Controls.Add(label2);
            Controls.Add(label1);
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