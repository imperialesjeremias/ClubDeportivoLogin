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
            btnImprimirCarnet = new Button();
            panel1 = new Panel();
            lblTotalDescuento = new Label();
            label13 = new Label();
            txtCuotas = new TextBox();
            txtDescuento = new TextBox();
            lblDescuento = new Label();
            lblCuotas = new Label();
            lblMonto = new Label();
            lblMedPago = new Label();
            txtMonto = new TextBox();
            comboMedPago = new ComboBox();
            lblFeBaja = new Label();
            dateBaja = new DateTimePicker();
            lblNumCarnet = new Label();
            btnSalir = new Button();
            lblEstado = new Label();
            lblTipoCliente = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 75);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(181, 70);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(214, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(181, 106);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(214, 27);
            txtApellido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 110);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // label3
            // 
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 24);
            label3.Name = "label3";
            label3.Size = new Size(67, 32);
            label3.TabIndex = 4;
            label3.Text = "DNI:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 146);
            label4.Name = "label4";
            label4.Size = new Size(157, 20);
            label4.TabIndex = 6;
            label4.Text = "Fecha de Nacimiento:";
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(181, 182);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(214, 27);
            txtDireccion.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 182);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "Dirección:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(181, 222);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(214, 27);
            txtTelefono.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(16, 219);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 10;
            label6.Text = "Teléfono:";
            // 
            // chkAptoFisico
            // 
            chkAptoFisico.AutoSize = true;
            chkAptoFisico.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAptoFisico.Location = new Point(437, 117);
            chkAptoFisico.Margin = new Padding(3, 4, 3, 4);
            chkAptoFisico.Name = "chkAptoFisico";
            chkAptoFisico.Size = new Size(125, 29);
            chkAptoFisico.TabIndex = 12;
            chkAptoFisico.Text = "Apto Físico";
            chkAptoFisico.UseVisualStyleBackColor = true;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.CustomFormat = "DD/MM/YYYY";
            dtpFechaNacimiento.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFechaNacimiento.Location = new Point(181, 143);
            dtpFechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(214, 27);
            dtpFechaNacimiento.TabIndex = 13;
            dtpFechaNacimiento.Value = new DateTime(2025, 6, 7, 1, 54, 11, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(35, 92);
            label7.Name = "label7";
            label7.Size = new Size(152, 20);
            label7.TabIndex = 14;
            label7.Text = "Fecha de Inscripción:";
            // 
            // dtpInscripcion
            // 
            dtpInscripcion.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpInscripcion.Location = new Point(198, 85);
            dtpInscripcion.Margin = new Padding(3, 4, 3, 4);
            dtpInscripcion.Name = "dtpInscripcion";
            dtpInscripcion.Size = new Size(158, 27);
            dtpInscripcion.TabIndex = 15;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpVencimiento.Location = new Point(198, 134);
            dtpVencimiento.Margin = new Padding(3, 4, 3, 4);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(158, 27);
            dtpVencimiento.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(46, 137);
            label8.Name = "label8";
            label8.Size = new Size(142, 20);
            label8.TabIndex = 16;
            label8.Text = "Vencimiento Cuota:";
            // 
            // label9
            // 
            label9.BackColor = Color.LightGray;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(39, 32);
            label9.Name = "label9";
            label9.Size = new Size(149, 32);
            label9.TabIndex = 18;
            label9.Text = "N° de Carnet:";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkCarnetEntregado
            // 
            chkCarnetEntregado.AutoSize = true;
            chkCarnetEntregado.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkCarnetEntregado.Location = new Point(430, 8);
            chkCarnetEntregado.Margin = new Padding(3, 4, 3, 4);
            chkCarnetEntregado.Name = "chkCarnetEntregado";
            chkCarnetEntregado.Size = new Size(148, 24);
            chkCarnetEntregado.TabIndex = 20;
            chkCarnetEntregado.Text = "Carnet Entregado";
            chkCarnetEntregado.UseVisualStyleBackColor = true;
            // 
            // chkAsociarse
            // 
            chkAsociarse.BackColor = Color.Transparent;
            chkAsociarse.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAsociarse.ForeColor = Color.Black;
            chkAsociarse.Location = new Point(437, 187);
            chkAsociarse.Margin = new Padding(3, 4, 3, 4);
            chkAsociarse.Name = "chkAsociarse";
            chkAsociarse.Size = new Size(121, 38);
            chkAsociarse.TabIndex = 23;
            chkAsociarse.Text = "Asociar";
            chkAsociarse.UseVisualStyleBackColor = false;
            chkAsociarse.CheckedChanged += chkAsociarse_CheckedChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(318, 404);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 38);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(41, 15);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(591, 345);
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
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(583, 313);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Identificación";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDni
            // 
            lblDni.BackColor = Color.LightGray;
            lblDni.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDni.Location = new Point(86, 24);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(215, 32);
            lblDni.TabIndex = 24;
            lblDni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnImprimirCarnet);
            tabPage2.Controls.Add(panel1);
            tabPage2.Controls.Add(lblFeBaja);
            tabPage2.Controls.Add(dateBaja);
            tabPage2.Controls.Add(lblNumCarnet);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(dtpInscripcion);
            tabPage2.Controls.Add(dtpVencimiento);
            tabPage2.Controls.Add(chkCarnetEntregado);
            tabPage2.Controls.Add(label9);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(583, 313);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Datos Socio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnImprimirCarnet
            // 
            btnImprimirCarnet.BackColor = Color.FromArgb(255, 255, 192);
            btnImprimirCarnet.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimirCarnet.Location = new Point(442, 39);
            btnImprimirCarnet.Name = "btnImprimirCarnet";
            btnImprimirCarnet.Size = new Size(127, 29);
            btnImprimirCarnet.TabIndex = 30;
            btnImprimirCarnet.Text = "Imprimir Carnet";
            btnImprimirCarnet.UseVisualStyleBackColor = false;
            btnImprimirCarnet.Click += btnImprimirCarnet_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalDescuento);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtCuotas);
            panel1.Controls.Add(txtDescuento);
            panel1.Controls.Add(lblDescuento);
            panel1.Controls.Add(lblCuotas);
            panel1.Controls.Add(lblMonto);
            panel1.Controls.Add(lblMedPago);
            panel1.Controls.Add(txtMonto);
            panel1.Controls.Add(comboMedPago);
            panel1.Location = new Point(7, 174);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 132);
            panel1.TabIndex = 29;
            // 
            // lblTotalDescuento
            // 
            lblTotalDescuento.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDescuento.ForeColor = Color.DarkGreen;
            lblTotalDescuento.Location = new Point(223, 11);
            lblTotalDescuento.Name = "lblTotalDescuento";
            lblTotalDescuento.Size = new Size(339, 29);
            lblTotalDescuento.TabIndex = 33;
            lblTotalDescuento.TextAlign = ContentAlignment.MiddleRight;
            lblTotalDescuento.TextChanged += txtDescuento_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label13.Location = new Point(13, 11);
            label13.Name = "label13";
            label13.Size = new Size(201, 20);
            label13.TabIndex = 32;
            label13.Text = "DETALLE DEL PRIMER PAGO:";
            // 
            // txtCuotas
            // 
            txtCuotas.Location = new Point(453, 95);
            txtCuotas.Margin = new Padding(3, 4, 3, 4);
            txtCuotas.Name = "txtCuotas";
            txtCuotas.Size = new Size(76, 26);
            txtCuotas.TabIndex = 31;
            txtCuotas.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDescuento
            // 
            txtDescuento.Location = new Point(453, 53);
            txtDescuento.Margin = new Padding(3, 4, 3, 4);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(76, 26);
            txtDescuento.TabIndex = 30;
            txtDescuento.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDescuento
            // 
            lblDescuento.AutoSize = true;
            lblDescuento.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescuento.Location = new Point(353, 57);
            lblDescuento.Name = "lblDescuento";
            lblDescuento.Size = new Size(85, 20);
            lblDescuento.TabIndex = 29;
            lblDescuento.Text = "Descuento:";
            // 
            // lblCuotas
            // 
            lblCuotas.AutoSize = true;
            lblCuotas.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCuotas.Location = new Point(345, 99);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(98, 20);
            lblCuotas.TabIndex = 28;
            lblCuotas.Text = "Cant. Cuotas:";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonto.Location = new Point(74, 54);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(59, 20);
            lblMonto.TabIndex = 24;
            lblMonto.Text = "Monto:";
            // 
            // lblMedPago
            // 
            lblMedPago.AutoSize = true;
            lblMedPago.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMedPago.Location = new Point(18, 99);
            lblMedPago.Name = "lblMedPago";
            lblMedPago.Size = new Size(117, 20);
            lblMedPago.TabIndex = 26;
            lblMedPago.Text = "Medio de Pago:";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(141, 52);
            txtMonto.Margin = new Padding(3, 4, 3, 4);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(138, 26);
            txtMonto.TabIndex = 25;
            // 
            // comboMedPago
            // 
            comboMedPago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            comboMedPago.FormattingEnabled = true;
            comboMedPago.Location = new Point(141, 95);
            comboMedPago.Margin = new Padding(3, 4, 3, 4);
            comboMedPago.Name = "comboMedPago";
            comboMedPago.Size = new Size(138, 27);
            comboMedPago.TabIndex = 27;
            // 
            // lblFeBaja
            // 
            lblFeBaja.AutoSize = true;
            lblFeBaja.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFeBaja.ForeColor = Color.FromArgb(192, 0, 0);
            lblFeBaja.Location = new Point(409, 110);
            lblFeBaja.Name = "lblFeBaja";
            lblFeBaja.Size = new Size(127, 20);
            lblFeBaja.TabIndex = 23;
            lblFeBaja.Text = "Fecha Baja Socio:";
            lblFeBaja.Visible = false;
            // 
            // dateBaja
            // 
            dateBaja.Checked = false;
            dateBaja.CustomFormat = "\"dd/MM/yyyy\"";
            dateBaja.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateBaja.Format = DateTimePickerFormat.Custom;
            dateBaja.Location = new Point(396, 134);
            dateBaja.Margin = new Padding(3, 4, 3, 4);
            dateBaja.Name = "dateBaja";
            dateBaja.ShowCheckBox = true;
            dateBaja.Size = new Size(158, 27);
            dateBaja.TabIndex = 22;
            dateBaja.Visible = false;
            // 
            // lblNumCarnet
            // 
            lblNumCarnet.BackColor = Color.LightGray;
            lblNumCarnet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumCarnet.ForeColor = Color.Blue;
            lblNumCarnet.Location = new Point(186, 32);
            lblNumCarnet.Name = "lblNumCarnet";
            lblNumCarnet.Size = new Size(171, 32);
            lblNumCarnet.TabIndex = 21;
            lblNumCarnet.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(483, 404);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.ForeColor = Color.Blue;
            lblEstado.Location = new Point(251, 364);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(381, 37);
            lblEstado.TabIndex = 24;
            lblEstado.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTipoCliente
            // 
            lblTipoCliente.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoCliente.ForeColor = Color.FromArgb(192, 0, 0);
            lblTipoCliente.Location = new Point(226, 6);
            lblTipoCliente.Name = "lblTipoCliente";
            lblTipoCliente.Size = new Size(406, 32);
            lblTipoCliente.TabIndex = 27;
            lblTipoCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(lblTipoCliente);
            Controls.Add(lblEstado);
            Controls.Add(btnSalir);
            Controls.Add(tabControl1);
            Controls.Add(btnGuardar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A.B.M. de \"Maestro de Cliente\"";
            Load += FormRegistrarCliente_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Label lblFeBaja;
        private DateTimePicker dateBaja;
        private Label lblDni;
        private Label lblTipoCliente;
        private TextBox txtMonto;
        private Label lblMonto;
        private Label lblMedPago;
        private ComboBox comboMedPago;
        private Label lblCuotas;
        private Panel panel1;
        private Label label13;
        private TextBox txtCuotas;
        private TextBox txtDescuento;
        private Label lblDescuento;
        private Label lblTotalDescuento;
        private Button btnImprimirCarnet;
    }
}