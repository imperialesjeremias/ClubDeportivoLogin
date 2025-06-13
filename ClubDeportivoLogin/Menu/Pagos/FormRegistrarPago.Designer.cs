namespace ClubDeportivoLogin
{
    partial class FormRegistrarPago
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnImprimirS = new Button();
            panel1 = new Panel();
            lblTotalDescuentoS = new Label();
            label13 = new Label();
            txtCuotasS = new TextBox();
            txtDescuentoS = new TextBox();
            lblDescuentoS = new Label();
            lblCuotasS = new Label();
            lblMontoS = new Label();
            lblMedPagoS = new Label();
            txtMontoS = new TextBox();
            comboMedPagoS = new ComboBox();
            lblEstadoS = new Label();
            label11 = new Label();
            dateFePagoS = new DateTimePicker();
            label5 = new Label();
            lblClienteS = new Label();
            label2 = new Label();
            lblDniS = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            btnAgregarActividad = new Button();
            btnImprimirNS = new Button();
            comboBox1 = new ComboBox();
            label7 = new Label();
            dateFePagoNS = new DateTimePicker();
            label8 = new Label();
            lblClienteNS = new Label();
            label10 = new Label();
            panel2 = new Panel();
            lblTotalDescuentoNS = new Label();
            label6 = new Label();
            txtCuotasNS = new TextBox();
            txtDescuentoNS = new TextBox();
            lblDescuentoNS = new Label();
            lblCuotasNS = new Label();
            lblMontoNS = new Label();
            lblMedPagoNS = new Label();
            txtMontoNS = new TextBox();
            comboMedPagoNS = new ComboBox();
            lblDniNS = new Label();
            label3 = new Label();
            btnSalir = new Button();
            btnGuardar = new Button();
            btnBorrar = new Button();
            lblTipoRegistro = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(39, 35);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(591, 335);
            tabControl1.TabIndex = 0;
            tabControl1.Click += btnImprimirNS_Click;
            tabControl1.Leave += txtMontoNS_Leave;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnImprimirS);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(lblEstadoS);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(dateFePagoS);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(lblClienteS);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(lblDniS);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(583, 303);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Pago Socio";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImprimirS
            // 
            btnImprimirS.BackColor = Color.FromArgb(192, 255, 192);
            btnImprimirS.Location = new Point(438, 113);
            btnImprimirS.Name = "btnImprimirS";
            btnImprimirS.Size = new Size(136, 47);
            btnImprimirS.TabIndex = 40;
            btnImprimirS.Text = "Reimprimir Comprobante";
            btnImprimirS.UseVisualStyleBackColor = false;
            btnImprimirS.Click += btnImprimirS_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalDescuentoS);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(txtCuotasS);
            panel1.Controls.Add(txtDescuentoS);
            panel1.Controls.Add(lblDescuentoS);
            panel1.Controls.Add(lblCuotasS);
            panel1.Controls.Add(lblMontoS);
            panel1.Controls.Add(lblMedPagoS);
            panel1.Controls.Add(txtMontoS);
            panel1.Controls.Add(comboMedPagoS);
            panel1.Location = new Point(6, 167);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 132);
            panel1.TabIndex = 34;
            // 
            // lblTotalDescuentoS
            // 
            lblTotalDescuentoS.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDescuentoS.ForeColor = Color.DarkGreen;
            lblTotalDescuentoS.Location = new Point(223, 11);
            lblTotalDescuentoS.Name = "lblTotalDescuentoS";
            lblTotalDescuentoS.Size = new Size(339, 29);
            lblTotalDescuentoS.TabIndex = 33;
            lblTotalDescuentoS.TextAlign = ContentAlignment.MiddleRight;
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
            // txtCuotasS
            // 
            txtCuotasS.Location = new Point(453, 95);
            txtCuotasS.Margin = new Padding(3, 4, 3, 4);
            txtCuotasS.Name = "txtCuotasS";
            txtCuotasS.Size = new Size(76, 26);
            txtCuotasS.TabIndex = 31;
            txtCuotasS.TextAlign = HorizontalAlignment.Center;
            txtCuotasS.Visible = false;
            // 
            // txtDescuentoS
            // 
            txtDescuentoS.Location = new Point(453, 53);
            txtDescuentoS.Margin = new Padding(3, 4, 3, 4);
            txtDescuentoS.Name = "txtDescuentoS";
            txtDescuentoS.Size = new Size(76, 26);
            txtDescuentoS.TabIndex = 30;
            txtDescuentoS.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDescuentoS
            // 
            lblDescuentoS.AutoSize = true;
            lblDescuentoS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescuentoS.Location = new Point(353, 57);
            lblDescuentoS.Name = "lblDescuentoS";
            lblDescuentoS.Size = new Size(85, 20);
            lblDescuentoS.TabIndex = 29;
            lblDescuentoS.Text = "Descuento:";
            // 
            // lblCuotasS
            // 
            lblCuotasS.AutoSize = true;
            lblCuotasS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCuotasS.Location = new Point(345, 99);
            lblCuotasS.Name = "lblCuotasS";
            lblCuotasS.Size = new Size(98, 20);
            lblCuotasS.TabIndex = 28;
            lblCuotasS.Text = "Cant. Cuotas:";
            lblCuotasS.Visible = false;
            // 
            // lblMontoS
            // 
            lblMontoS.AutoSize = true;
            lblMontoS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMontoS.Location = new Point(74, 54);
            lblMontoS.Name = "lblMontoS";
            lblMontoS.Size = new Size(59, 20);
            lblMontoS.TabIndex = 24;
            lblMontoS.Text = "Monto:";
            // 
            // lblMedPagoS
            // 
            lblMedPagoS.AutoSize = true;
            lblMedPagoS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMedPagoS.Location = new Point(18, 99);
            lblMedPagoS.Name = "lblMedPagoS";
            lblMedPagoS.Size = new Size(117, 20);
            lblMedPagoS.TabIndex = 26;
            lblMedPagoS.Text = "Medio de Pago:";
            // 
            // txtMontoS
            // 
            txtMontoS.Location = new Point(141, 52);
            txtMontoS.Margin = new Padding(3, 4, 3, 4);
            txtMontoS.Name = "txtMontoS";
            txtMontoS.Size = new Size(138, 26);
            txtMontoS.TabIndex = 25;
            // 
            // comboMedPagoS
            // 
            comboMedPagoS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            comboMedPagoS.FormattingEnabled = true;
            comboMedPagoS.Location = new Point(141, 95);
            comboMedPagoS.Margin = new Padding(3, 4, 3, 4);
            comboMedPagoS.Name = "comboMedPagoS";
            comboMedPagoS.Size = new Size(138, 27);
            comboMedPagoS.TabIndex = 27;
            // 
            // lblEstadoS
            // 
            lblEstadoS.BorderStyle = BorderStyle.FixedSingle;
            lblEstadoS.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstadoS.Location = new Point(184, 114);
            lblEstadoS.Name = "lblEstadoS";
            lblEstadoS.Size = new Size(214, 27);
            lblEstadoS.TabIndex = 33;
            lblEstadoS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(25, 117);
            label11.Name = "label11";
            label11.Size = new Size(142, 20);
            label11.TabIndex = 32;
            label11.Text = "Vencimiento Cuota:";
            // 
            // dateFePagoS
            // 
            dateFePagoS.Checked = false;
            dateFePagoS.Format = DateTimePickerFormat.Short;
            dateFePagoS.Location = new Point(445, 23);
            dateFePagoS.Name = "dateFePagoS";
            dateFePagoS.Size = new Size(121, 26);
            dateFePagoS.TabIndex = 31;
            dateFePagoS.Value = new DateTime(2025, 6, 9, 14, 55, 0, 0);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(322, 27);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 30;
            label5.Text = "Fecha de Pago:";
            // 
            // lblClienteS
            // 
            lblClienteS.BorderStyle = BorderStyle.FixedSingle;
            lblClienteS.Font = new Font("Segoe UI Semibold", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClienteS.Location = new Point(184, 73);
            lblClienteS.Name = "lblClienteS";
            lblClienteS.Size = new Size(214, 27);
            lblClienteS.TabIndex = 29;
            lblClienteS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 78);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 27;
            label2.Text = "Cliente:";
            // 
            // lblDniS
            // 
            lblDniS.BackColor = Color.LightGray;
            lblDniS.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDniS.Location = new Point(90, 21);
            lblDniS.Name = "lblDniS";
            lblDniS.Size = new Size(215, 32);
            lblDniS.TabIndex = 26;
            lblDniS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.LightGray;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 21);
            label1.Name = "label1";
            label1.Size = new Size(67, 32);
            label1.TabIndex = 25;
            label1.Text = "DNI:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnAgregarActividad);
            tabPage2.Controls.Add(btnImprimirNS);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(dateFePagoNS);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(lblClienteNS);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(lblDniNS);
            tabPage2.Controls.Add(label3);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(583, 303);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Pago No Socio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAgregarActividad
            // 
            btnAgregarActividad.BackColor = Color.DarkGray;
            btnAgregarActividad.Font = new Font("Segoe UI", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarActividad.Location = new Point(380, 117);
            btnAgregarActividad.Name = "btnAgregarActividad";
            btnAgregarActividad.Size = new Size(29, 27);
            btnAgregarActividad.TabIndex = 40;
            btnAgregarActividad.Text = "+";
            btnAgregarActividad.TextAlign = ContentAlignment.TopCenter;
            btnAgregarActividad.UseVisualStyleBackColor = false;
            btnAgregarActividad.Click += btnAgregarActividad_Click;
            // 
            // btnImprimirNS
            // 
            btnImprimirNS.BackColor = Color.FromArgb(192, 255, 192);
            btnImprimirNS.Location = new Point(438, 106);
            btnImprimirNS.Name = "btnImprimirNS";
            btnImprimirNS.Size = new Size(136, 47);
            btnImprimirNS.TabIndex = 39;
            btnImprimirNS.Text = "Reimprimir Comprobante";
            btnImprimirNS.UseVisualStyleBackColor = false;
            btnImprimirNS.Click += btnImprimirNS_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(189, 117);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(185, 27);
            comboBox1.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(30, 117);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 37;
            label7.Text = "Actividad:";
            // 
            // dateFePagoNS
            // 
            dateFePagoNS.Checked = false;
            dateFePagoNS.Format = DateTimePickerFormat.Short;
            dateFePagoNS.Location = new Point(450, 23);
            dateFePagoNS.Name = "dateFePagoNS";
            dateFePagoNS.Size = new Size(121, 26);
            dateFePagoNS.TabIndex = 36;
            dateFePagoNS.Value = new DateTime(2025, 6, 9, 14, 55, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(327, 27);
            label8.Name = "label8";
            label8.Size = new Size(113, 20);
            label8.TabIndex = 35;
            label8.Text = "Fecha de Pago:";
            // 
            // lblClienteNS
            // 
            lblClienteNS.BorderStyle = BorderStyle.FixedSingle;
            lblClienteNS.Font = new Font("Segoe UI Semibold", 11.7818184F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClienteNS.Location = new Point(189, 71);
            lblClienteNS.Name = "lblClienteNS";
            lblClienteNS.Size = new Size(214, 27);
            lblClienteNS.TabIndex = 34;
            lblClienteNS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(30, 78);
            label10.Name = "label10";
            label10.Size = new Size(60, 20);
            label10.TabIndex = 33;
            label10.Text = "Cliente:";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblTotalDescuentoNS);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtCuotasNS);
            panel2.Controls.Add(txtDescuentoNS);
            panel2.Controls.Add(lblDescuentoNS);
            panel2.Controls.Add(lblCuotasNS);
            panel2.Controls.Add(lblMontoNS);
            panel2.Controls.Add(lblMedPagoNS);
            panel2.Controls.Add(txtMontoNS);
            panel2.Controls.Add(comboMedPagoNS);
            panel2.Location = new Point(6, 167);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(571, 132);
            panel2.TabIndex = 30;
            // 
            // lblTotalDescuentoNS
            // 
            lblTotalDescuentoNS.Font = new Font("Segoe UI Semibold", 11.1272726F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalDescuentoNS.ForeColor = Color.DarkGreen;
            lblTotalDescuentoNS.Location = new Point(223, 11);
            lblTotalDescuentoNS.Name = "lblTotalDescuentoNS";
            lblTotalDescuentoNS.Size = new Size(339, 29);
            lblTotalDescuentoNS.TabIndex = 33;
            lblTotalDescuentoNS.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label6.Location = new Point(13, 11);
            label6.Name = "label6";
            label6.Size = new Size(144, 20);
            label6.TabIndex = 32;
            label6.Text = "DETALLE DEL PAGO:";
            // 
            // txtCuotasNS
            // 
            txtCuotasNS.Location = new Point(453, 95);
            txtCuotasNS.Margin = new Padding(3, 4, 3, 4);
            txtCuotasNS.Name = "txtCuotasNS";
            txtCuotasNS.Size = new Size(76, 26);
            txtCuotasNS.TabIndex = 31;
            txtCuotasNS.TextAlign = HorizontalAlignment.Center;
            txtCuotasNS.Visible = false;
            // 
            // txtDescuentoNS
            // 
            txtDescuentoNS.Location = new Point(453, 53);
            txtDescuentoNS.Margin = new Padding(3, 4, 3, 4);
            txtDescuentoNS.Name = "txtDescuentoNS";
            txtDescuentoNS.Size = new Size(76, 26);
            txtDescuentoNS.TabIndex = 30;
            txtDescuentoNS.TextAlign = HorizontalAlignment.Center;
            // 
            // lblDescuentoNS
            // 
            lblDescuentoNS.AutoSize = true;
            lblDescuentoNS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescuentoNS.Location = new Point(353, 57);
            lblDescuentoNS.Name = "lblDescuentoNS";
            lblDescuentoNS.Size = new Size(85, 20);
            lblDescuentoNS.TabIndex = 29;
            lblDescuentoNS.Text = "Descuento:";
            // 
            // lblCuotasNS
            // 
            lblCuotasNS.AutoSize = true;
            lblCuotasNS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCuotasNS.Location = new Point(345, 99);
            lblCuotasNS.Name = "lblCuotasNS";
            lblCuotasNS.Size = new Size(98, 20);
            lblCuotasNS.TabIndex = 28;
            lblCuotasNS.Text = "Cant. Cuotas:";
            lblCuotasNS.Visible = false;
            // 
            // lblMontoNS
            // 
            lblMontoNS.AutoSize = true;
            lblMontoNS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMontoNS.Location = new Point(74, 54);
            lblMontoNS.Name = "lblMontoNS";
            lblMontoNS.Size = new Size(59, 20);
            lblMontoNS.TabIndex = 24;
            lblMontoNS.Text = "Monto:";
            // 
            // lblMedPagoNS
            // 
            lblMedPagoNS.AutoSize = true;
            lblMedPagoNS.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMedPagoNS.Location = new Point(18, 99);
            lblMedPagoNS.Name = "lblMedPagoNS";
            lblMedPagoNS.Size = new Size(117, 20);
            lblMedPagoNS.TabIndex = 26;
            lblMedPagoNS.Text = "Medio de Pago:";
            // 
            // txtMontoNS
            // 
            txtMontoNS.Location = new Point(141, 52);
            txtMontoNS.Margin = new Padding(3, 4, 3, 4);
            txtMontoNS.Name = "txtMontoNS";
            txtMontoNS.Size = new Size(138, 26);
            txtMontoNS.TabIndex = 25;
            // 
            // comboMedPagoNS
            // 
            comboMedPagoNS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            comboMedPagoNS.FormattingEnabled = true;
            comboMedPagoNS.Location = new Point(141, 97);
            comboMedPagoNS.Margin = new Padding(3, 4, 3, 4);
            comboMedPagoNS.Name = "comboMedPagoNS";
            comboMedPagoNS.Size = new Size(138, 27);
            comboMedPagoNS.TabIndex = 27;
            // 
            // lblDniNS
            // 
            lblDniNS.BackColor = Color.LightGray;
            lblDniNS.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDniNS.Location = new Point(93, 22);
            lblDniNS.Name = "lblDniNS";
            lblDniNS.Size = new Size(215, 32);
            lblDniNS.TabIndex = 26;
            lblDniNS.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.LightGray;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 22);
            label3.Name = "label3";
            label3.Size = new Size(67, 32);
            label3.TabIndex = 25;
            label3.Text = "DNI:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(481, 407);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(314, 407);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(149, 38);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(39, 407);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(149, 38);
            btnBorrar.TabIndex = 3;
            btnBorrar.Text = "BORRAR";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Visible = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // lblTipoRegistro
            // 
            lblTipoRegistro.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipoRegistro.ForeColor = Color.FromArgb(192, 0, 0);
            lblTipoRegistro.Location = new Point(226, 23);
            lblTipoRegistro.Name = "lblTipoRegistro";
            lblTipoRegistro.Size = new Size(404, 32);
            lblTipoRegistro.TabIndex = 28;
            lblTipoRegistro.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormRegistrarPago
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(667, 457);
            Controls.Add(lblTipoRegistro);
            Controls.Add(btnBorrar);
            Controls.Add(btnGuardar);
            Controls.Add(btnSalir);
            Controls.Add(tabControl1);
            Name = "FormRegistrarPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "A.B.M. de \"Maestro de Pagos\"";
            Load += FormRegistrarPago_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnSalir;
        private Button btnGuardar;
        private Button btnBorrar;
        private Label lblDniNS;
        private Label label3;
        private Label lblDniS;
        private Label label1;
        private Label label2;
        private Label lblClienteS;
        private DateTimePicker dateFePagoS;
        private Label label5;
        private Label label11;
        private Label lblEstadoS;
        private Panel panel1;
        private Label lblTotalDescuentoS;
        private Label label13;
        private TextBox txtCuotasS;
        private TextBox txtDescuentoS;
        private Label lblDescuentoS;
        private Label lblCuotasS;
        private Label lblMontoS;
        private Label lblMedPagoS;
        private TextBox txtMontoS;
        private ComboBox comboMedPagoS;
        private Panel panel2;
        private Label lblTotalDescuentoNS;
        private Label label6;
        private TextBox txtCuotasNS;
        private TextBox txtDescuentoNS;
        private Label lblDescuentoNS;
        private Label lblCuotasNS;
        private Label lblMontoNS;
        private Label lblMedPagoNS;
        private TextBox txtMontoNS;
        private ComboBox comboMedPagoNS;
        private Label label7;
        private DateTimePicker dateFePagoNS;
        private Label label8;
        private Label lblClienteNS;
        private Label label10;
        private ComboBox comboBox1;
        private Button btnImprimirNS;
        private Label lblTipoRegistro;
        private Button btnImprimirS;
        private Button btnAgregarActividad;
    }
}