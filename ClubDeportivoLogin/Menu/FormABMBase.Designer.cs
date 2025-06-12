namespace ClubDeportivoLogin
{
    partial class FormABMBase
    {
      
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pictureIcono = new PictureBox();
            lblAyuda2 = new Label();
            txtCampoID = new TextBox();
            lblAyuda1 = new Label();
            lblSubtitulo = new Label();
            btnSalir = new Button();
            btnSiguiente = new Button();
            lblFondo = new Label();
            lblTitulo = new Label();
            lblCampoID = new Label();
            cmbModo = new ComboBox();
            txtCentroID = new TextBox();
            txtComprobanteID = new TextBox();
            lblmodo = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureIcono).BeginInit();
            SuspendLayout();
            // 
            // pictureIcono
            // 
            pictureIcono.BorderStyle = BorderStyle.FixedSingle;
            pictureIcono.Location = new Point(12, 125);
            pictureIcono.Margin = new Padding(3, 4, 3, 4);
            pictureIcono.Name = "pictureIcono";
            pictureIcono.Size = new Size(221, 225);
            pictureIcono.SizeMode = PictureBoxSizeMode.Zoom;
            pictureIcono.TabIndex = 18;
            pictureIcono.TabStop = false;
            // 
            // lblAyuda2
            // 
            lblAyuda2.AutoEllipsis = true;
            lblAyuda2.Font = new Font("Segoe UI", 9.75F);
            lblAyuda2.ForeColor = Color.Blue;
            lblAyuda2.Location = new Point(281, 214);
            lblAyuda2.Name = "lblAyuda2";
            lblAyuda2.Size = new Size(357, 91);
            lblAyuda2.TabIndex = 17;
            lblAyuda2.Text = "lblAyuda2";
            // 
            // txtCampoID
            // 
            txtCampoID.BorderStyle = BorderStyle.FixedSingle;
            txtCampoID.Font = new Font("Segoe UI", 11.25F);
            txtCampoID.Location = new Point(463, 24);
            txtCampoID.Margin = new Padding(3, 4, 3, 4);
            txtCampoID.Name = "txtCampoID";
            txtCampoID.Size = new Size(175, 30);
            txtCampoID.TabIndex = 11;
            txtCampoID.TextAlign = HorizontalAlignment.Center;
            // 
            // lblAyuda1
            // 
            lblAyuda1.AutoEllipsis = true;
            lblAyuda1.Font = new Font("Segoe UI", 9.75F);
            lblAyuda1.Location = new Point(267, 125);
            lblAyuda1.Name = "lblAyuda1";
            lblAyuda1.Size = new Size(385, 73);
            lblAyuda1.TabIndex = 16;
            lblAyuda1.Text = "lblAyuda1";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            lblSubtitulo.Location = new Point(15, 67);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(130, 30);
            lblSubtitulo.TabIndex = 15;
            lblSubtitulo.Text = "lblSubtitulo";
            // 
            // btnSalir
            // 
            btnSalir.Font = new Font("Segoe UI", 9.75F);
            btnSalir.Location = new Point(503, 399);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(149, 38);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Font = new Font("Segoe UI", 9.75F);
            btnSiguiente.Location = new Point(323, 399);
            btnSiguiente.Margin = new Padding(3, 4, 3, 4);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(149, 38);
            btnSiguiente.TabIndex = 13;
            btnSiguiente.Text = "SIGUIENTE";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // lblFondo
            // 
            lblFondo.BackColor = SystemColors.GradientInactiveCaption;
            lblFondo.BorderStyle = BorderStyle.FixedSingle;
            lblFondo.Font = new Font("Segoe UI", 14.25F);
            lblFondo.Location = new Point(339, 14);
            lblFondo.Name = "lblFondo";
            lblFondo.Size = new Size(313, 50);
            lblFondo.TabIndex = 12;
            lblFondo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 15.7090912F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(15, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(317, 38);
            lblTitulo.TabIndex = 10;
            lblTitulo.Text = "lblTitulo";
            // 
            // lblCampoID
            // 
            lblCampoID.BackColor = SystemColors.GradientInactiveCaption;
            lblCampoID.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCampoID.Location = new Point(343, 24);
            lblCampoID.Name = "lblCampoID";
            lblCampoID.Size = new Size(120, 30);
            lblCampoID.TabIndex = 19;
            lblCampoID.Text = "CENTRO Y N°: ";
            lblCampoID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbModo
            // 
            cmbModo.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbModo.FormattingEnabled = true;
            cmbModo.Location = new Point(463, 67);
            cmbModo.Name = "cmbModo";
            cmbModo.Size = new Size(175, 27);
            cmbModo.TabIndex = 20;
            cmbModo.Visible = false;
            cmbModo.SelectedIndexChanged += cmbModo_SelectedIndexChanged;
            // 
            // txtCentroID
            // 
            txtCentroID.BorderStyle = BorderStyle.FixedSingle;
            txtCentroID.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCentroID.Location = new Point(465, 26);
            txtCentroID.Name = "txtCentroID";
            txtCentroID.Size = new Size(70, 26);
            txtCentroID.TabIndex = 21;
            txtCentroID.TextAlign = HorizontalAlignment.Center;
            txtCentroID.Visible = false;
            // 
            // txtComprobanteID
            // 
            txtComprobanteID.BorderStyle = BorderStyle.FixedSingle;
            txtComprobanteID.Font = new Font("Segoe UI Semibold", 9.163636F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtComprobanteID.Location = new Point(541, 26);
            txtComprobanteID.Name = "txtComprobanteID";
            txtComprobanteID.Size = new Size(97, 26);
            txtComprobanteID.TabIndex = 22;
            txtComprobanteID.TextAlign = HorizontalAlignment.Center;
            txtComprobanteID.Visible = false;
            // 
            // lblmodo
            // 
            lblmodo.BackColor = SystemColors.GradientInactiveCaption;
            lblmodo.Font = new Font("Segoe UI Semibold", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblmodo.Location = new Point(391, 64);
            lblmodo.Name = "lblmodo";
            lblmodo.Size = new Size(66, 30);
            lblmodo.TabIndex = 23;
            lblmodo.Text = "MODO:";
            lblmodo.TextAlign = ContentAlignment.MiddleRight;
            lblmodo.Visible = false;
            // 
            // FormABMBase
            // 
            AcceptButton = btnSiguiente;
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnSalir;
            ClientSize = new Size(667, 457);
            Controls.Add(lblmodo);
            Controls.Add(txtComprobanteID);
            Controls.Add(txtCentroID);
            Controls.Add(cmbModo);
            Controls.Add(lblCampoID);
            Controls.Add(pictureIcono);
            Controls.Add(lblAyuda2);
            Controls.Add(txtCampoID);
            Controls.Add(lblAyuda1);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnSalir);
            Controls.Add(btnSiguiente);
            Controls.Add(lblFondo);
            Controls.Add(lblTitulo);
            Name = "FormABMBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormABMBase";
            ((System.ComponentModel.ISupportInitialize)pictureIcono).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureIcono;
        private Label lblAyuda2;
        private TextBox txtCampoID;
        private Label lblAyuda1;
        private Label lblSubtitulo;
        private Button btnSalir;
        private Button btnSiguiente;
        private Label lblFondo;
        private Label lblTitulo;
        private Label lblCampoID;
        private ComboBox cmbModo;
        private TextBox txtCentroID;
        private TextBox txtComprobanteID;
        private Label lblmodo;
    }
}