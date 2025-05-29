namespace ClubDeportivoLogin
{
    partial class FormRegistrarCliente
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
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDireccion = new TextBox();
            label5 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            chkAptoFisico = new CheckBox();
            dtpFechaNacimiento = new DateTimePicker();
            label7 = new Label();
            dtpInscripcion = new DateTimePicker();
            dtpVencimiento = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            chkCarnetEntregado = new CheckBox();
            chkAsociarse = new CheckBox();
            btnGuardar = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lblDni = new Label();
            tabPage2 = new TabPage();
            label11 = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblNumCarnet = new Label();
            btnSalir = new Button();
            lblEstado = new Label();
            lblTipoCliente = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 63);
            label1.Name = "label1";
            label1.Size = new Size(61, 17);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(158, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(188, 25);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(158, 84);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(188, 25);
            txtApellido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 92);
            label2.Name = "label2";
            label2.Size = new Size(60, 17);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 19);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 4;
            label3.Text = "DNI:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 119);
            label4.Name = "label4";
            label4.Size = new Size(138, 17);
            label4.TabIndex = 6;
            label4.Text = "Fecha de Nacimiento:";
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(158, 144);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(188, 25);
            txtDireccion.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 148);
            label5.Name = "label5";
            label5.Size = new Size(66, 17);
            label5.TabIndex = 8;
            label5.Text = "Dirección:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(158, 175);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(188, 25);
            txtTelefono.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 177);
            label6.Name = "label6";
            label6.Size = new Size(62, 17);
            label6.TabIndex = 10;
            label6.Text = "Teléfono:";
            // 
            // chkAptoFisico
            // 
            chkAptoFisico.AutoSize = true;
            chkAptoFisico.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAptoFisico.Location = new Point(382, 92);
            chkAptoFisico.Name = "chkAptoFisico";
            chkAptoFisico.Size = new Size(106, 24);
            chkAptoFisico.TabIndex = 12;
            chkAptoFisico.Text = "Apto Físico";
            chkAptoFisico.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "DD/MM/YYYY";
            dtpFechaNacimiento.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaNacimiento.Location = new Point(158, 113);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.ShowUpDown = true;
            dtpFechaNacimiento.Size = new Size(188, 25);
            dtpFechaNacimiento.TabIndex = 13;
            dtpFechaNacimiento.Value = new DateTime(2025, 5, 28, 13, 26, 37, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(31, 73);
            label7.Name = "label7";
            label7.Size = new Size(134, 17);
            label7.TabIndex = 14;
            label7.Text = "Fecha de Inscripción:";
            // 
            // dtpInscripcion
            // 
            dtpInscripcion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpInscripcion.Location = new Point(173, 67);
            dtpInscripcion.Name = "dtpInscripcion";
            dtpInscripcion.Size = new Size(139, 25);
            dtpInscripcion.TabIndex = 15;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVencimiento.Location = new Point(173, 106);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(139, 25);
            dtpVencimiento.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(40, 108);
            label8.Name = "label8";
            label8.Size = new Size(125, 17);
            label8.TabIndex = 16;
            label8.Text = "Vencimiento Cuota:";
            // 
            // label9
            // 
            label9.BackColor = Color.LightGray;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(34, 25);
            label9.Name = "label9";
            label9.Size = new Size(130, 25);
            label9.TabIndex = 18;
            label9.Text = "N° de Carnet:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkCarnetEntregado
            // 
            chkCarnetEntregado.AutoSize = true;
            chkCarnetEntregado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkCarnetEntregado.Location = new Point(352, 29);
            chkCarnetEntregado.Name = "chkCarnetEntregado";
            chkCarnetEntregado.Size = new Size(134, 21);
            chkCarnetEntregado.TabIndex = 20;
            chkCarnetEntregado.Text = "Carnet Entregado";
            chkCarnetEntregado.UseVisualStyleBackColor = true;
            // 
            // chkAsociarse
            // 
            chkAsociarse.BackColor = Color.Transparent;
            chkAsociarse.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAsociarse.ForeColor = Color.Black;
            chkAsociarse.Location = new Point(382, 148);
            chkAsociarse.Name = "chkAsociarse";
            chkAsociarse.Size = new Size(106, 30);
            chkAsociarse.TabIndex = 23;
            chkAsociarse.Text = "Asociar";
            chkAsociarse.UseVisualStyleBackColor = false;
            chkAsociarse.CheckedChanged += chkAsociarse_CheckedChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(294, 319);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(130, 30);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(36, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(517, 255);
            tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblDni);
            tabPage1.Controls.Add(txtDireccion);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(chkAsociarse);
            tabPage1.Controls.Add(txtNombre);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(txtApellido);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtTelefono);
            tabPage1.Controls.Add(chkAptoFisico);
            tabPage1.Controls.Add(dtpFechaNacimiento);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(509, 227);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Identificación";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDni
            // 
            lblDni.BackColor = Color.LightGray;
            lblDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDni.Location = new Point(75, 19);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(188, 25);
            lblDni.TabIndex = 24;
            lblDni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(dateTimePicker1);
            tabPage2.Controls.Add(lblNumCarnet);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(dtpInscripcion);
            tabPage2.Controls.Add(dtpVencimiento);
            tabPage2.Controls.Add(chkCarnetEntregado);
            tabPage2.Controls.Add(label9);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(509, 227);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Datos Socio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(55, 194);
            label11.Name = "label11";
            label11.Size = new Size(111, 17);
            label11.TabIndex = 23;
            label11.Text = "Fecha Baja Socio:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Checked = false;
            dateTimePicker1.CustomFormat = "\"dd/MM/yyyy\"";
            dateTimePicker1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(173, 192);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Size = new Size(139, 25);
            dateTimePicker1.TabIndex = 22;
            // 
            // lblNumCarnet
            // 
            lblNumCarnet.BackColor = Color.LightGray;
            lblNumCarnet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumCarnet.ForeColor = Color.Blue;
            lblNumCarnet.Location = new Point(163, 25);
            lblNumCarnet.Name = "lblNumCarnet";
            lblNumCarnet.Size = new Size(150, 25);
            lblNumCarnet.TabIndex = 21;
            lblNumCarnet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(442, 319);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 30);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.Blue;
            lblEstado.Location = new Point(220, 270);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(333, 36);
            lblEstado.TabIndex = 24;
            lblEstado.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTipoCliente
            // 
            lblTipoCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lblTipoCliente.Location = new Point(198, 5);
            lblTipoCliente.Name = "lblTipoCliente";
            lblTipoCliente.Size = new Size(355, 25);
            lblTipoCliente.TabIndex = 27;
            lblTipoCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(584, 361);
            Controls.Add(lblTipoCliente);
            Controls.Add(lblEstado);
            Controls.Add(btnSalir);
            Controls.Add(tabControl1);
            Controls.Add(btnGuardar);
            Name = "FormRegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A.B.M. de \"Maestro de Cliente\"";
            Load += FormRegistrarCliente_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtDireccion;
        private Label label5;
        private TextBox txtTelefono;
        private Label label6;
        private CheckBox chkAptoFisico;
        private DateTimePicker dtpFechaNacimiento;
        private Label label7;
        private DateTimePicker dtpInscripcion;
        private DateTimePicker dtpVencimiento;
        private Label label8;
        private Label label9;
        private CheckBox chkCarnetEntregado;
        private CheckBox chkAsociarse;
        private Button btnGuardar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnSalir;
        private Label lblNumCarnet;
        private Label lblEstado;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label lblDni;
        private Label lblTipoCliente;
    }
}