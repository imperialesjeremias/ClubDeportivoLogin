using ClubDeportivoApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoLogin.Menu.ListadoMorosos
{
    public partial class frmSociosMorosos : Form
    {
        public frmSociosMorosos()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conn = new Conexion();

                using (MySqlConnection conexion = conn.Conectar())
                {
                    string query = @"
                SELECT c.nombre, c.apellido, c.dni, s.numeroCarnet, s.fechaVencimientoCuota
                FROM Cliente c
                INNER JOIN Socio s ON c.id = s.id
                WHERE s.fechaVencimientoCuota < CURDATE()
                  AND s.estado = 'Activo'";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    dgvMorosos.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar socios morosos: " + ex.Message);
            }
        }
    }
    }

