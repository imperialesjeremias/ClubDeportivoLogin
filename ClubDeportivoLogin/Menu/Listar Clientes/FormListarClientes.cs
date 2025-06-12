using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing.Printing;

namespace ClubDeportivoLogin.clientes
{
    public partial class FormListarClientes : Form
    {
        public FormListarClientes()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FormListarClientes_KeyDown;
        }

        private void FormListarClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void FormListarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintListadoClientes;
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 900,
                Height = 700
            };
            preview.ShowDialog();
        }

        private void CargarClientes()
        {
            try
            {
                Conexion conn = new Conexion();
                using MySqlConnection conexion = conn.Conectar();
                string query = @"
                    SELECT 
                        c.nombre AS Nombre,
                        c.apellido AS Apellido,
                        TIMESTAMPDIFF(YEAR, c.fechaNacimiento, CURDATE()) AS Edad,
                        c.telefono AS Teléfono,
                        CASE 
                            WHEN EXISTS (SELECT 1 FROM Socio s WHERE s.id = c.id) THEN 'SOCIO'
                            ELSE 'NO SOCIO'
                        END AS 'Tipo Cliente'
                    FROM Cliente c
                    ORDER BY c.apellido, c.nombre";

                using MySqlCommand cmd = new MySqlCommand(query, conexion);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                dgvClientes.DataSource = tabla;
                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void PrintListadoClientes(object sender, PrintPageEventArgs e)
        {
            int left = 40;
            int top = 40;
            int y = top;
            int colSpacing = 20;
            int pageWidth = e.MarginBounds.Width;
            int pageLeft = e.MarginBounds.Left;

            // Fuentes
            Font fontTitle = new Font("Segoe UI", 20, FontStyle.Bold);
            Font fontHeader = new Font("Segoe UI", 11, FontStyle.Bold);
            Font fontBody = new Font("Segoe UI", 10);

            // Título centrado
            string titulo = "Listado de Clientes";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fontTitle);
            float tituloX = pageLeft + (pageWidth - sizeTitulo.Width) / 2;
            e.Graphics.DrawString(titulo, fontTitle, Brushes.Black, tituloX, y);
            y += (int)sizeTitulo.Height + 20;

            // Calcular anchos de columnas
            int[] colWidths = new int[dgvClientes.Columns.Count];
            int totalWidth = 0;
            for (int i = 0; i < dgvClientes.Columns.Count; i++)
            {
                int ancho = Math.Max(100, dgvClientes.Columns[i].Width);
                colWidths[i] = ancho;
                totalWidth += ancho + colSpacing;
            }
            totalWidth -= colSpacing;

            // Encabezados con fondo sombreado y recuadro
            int x = pageLeft + (pageWidth - totalWidth) / 2;
            int headerHeight = (int)e.Graphics.MeasureString("Ay", fontHeader).Height + 10;
            Rectangle headerRect = new Rectangle(x - 4, y - 2, totalWidth + 8, headerHeight + 4);
            using (SolidBrush brush = new SolidBrush(Color.LightSteelBlue))
            {
                e.Graphics.FillRectangle(brush, headerRect);
            }
            using (Pen pen = new Pen(Color.SteelBlue, 2))
            {
                e.Graphics.DrawRectangle(pen, headerRect);
            }

            // Dibujar los textos de los encabezados
            int colX = x;
            for (int i = 0; i < dgvClientes.Columns.Count; i++)
            {
                string header = dgvClientes.Columns[i].HeaderText;
                e.Graphics.DrawString(header, fontHeader, Brushes.Black, colX + 4, y);
                colX += colWidths[i] + colSpacing;
            }
            y += headerHeight + 2;

            // Filas
            foreach (DataGridViewRow row in dgvClientes.Rows)
            {
                if (row.IsNewRow) continue;
                colX = x;
                for (int i = 0; i < dgvClientes.Columns.Count; i++)
                {
                    string text = row.Cells[i].Value?.ToString() ?? "";
                    e.Graphics.DrawString(text, fontBody, Brushes.Black, colX + 4, y);
                    colX += colWidths[i] + colSpacing;
                }
                y += 25;
                if (y > e.MarginBounds.Bottom - 40)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
        }
    }
}