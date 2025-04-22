using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KyA_DB
{
    public partial class FormUsuario : Form
    {
        private string connectionString = "Data Source=DESKTOP-UFBV34N;Initial Catalog=TVTRACK;Integrated Security=True;TrustServerCertificate=True";
        private string usuarioActual;

        public FormUsuario(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarPeliculas(); // Por defecto, cargamos las películas
        }

        private void CargarPeliculas()
        {
            CargarDatos("peliculas", dgvPeliculas);
        }

        private void CargarSeries()
        {
            CargarDatos("series", dgvSeries);
        }

        private void CargarDatos(string tabla, DataGridView dgv)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = $"SELECT Título, Valoración, Vista FROM {tabla} WHERE Usuario = @Usuario";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    adapter.SelectCommand.Parameters.AddWithValue("@Usuario", usuarioActual);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;

                    // Configurar columnas editables
                    dgv.Columns["Valoración"].ReadOnly = false;
                    dgv.Columns["Vista"].ReadOnly = false;
                }

                // Cargar comentarios
                CargarComentarios(tabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComentarios(string tabla)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = $"SELECT Usuario, Comentarios FROM {tabla} WHERE Comentarios IS NOT NULL";
                    SqlCommand cmd = new SqlCommand(query, cnx);
                    SqlDataReader reader = cmd.ExecuteReader();

                    lstComentarios.Items.Clear();
                    while (reader.Read())
                    {
                        string usuario = reader["Usuario"].ToString();
                        string comentario = reader["Comentarios"].ToString();
                        lstComentarios.Items.Add($"{usuario}: {comentario}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los comentarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    DataGridView dgv = tabControl.SelectedTab == tabPeliculas ? dgvPeliculas : dgvSeries;
                    string tabla = tabControl.SelectedTab == tabPeliculas ? "peliculas" : "series";

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string titulo = row.Cells["Título"].Value.ToString();
                        int valoracion = Convert.ToInt32(row.Cells["Valoración"].Value);
                        bool vista = Convert.ToBoolean(row.Cells["Vista"].Value);

                        string query = $"UPDATE {tabla} SET Valoración = @Valoración, Vista = @Vista WHERE Título = @Título AND Usuario = @Usuario";
                        using (SqlCommand cmd = new SqlCommand(query, cnx))
                        {
                            cmd.Parameters.AddWithValue("@Título", titulo);
                            cmd.Parameters.AddWithValue("@Valoración", valoracion);
                            cmd.Parameters.AddWithValue("@Vista", vista);
                            cmd.Parameters.AddWithValue("@Usuario", usuarioActual);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 loginForm = new Form2();
            loginForm.Show();
        }
    }
}

