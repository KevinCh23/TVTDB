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
            CargarPeliculas();
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
                    string query = tabla == "peliculas"
                        ? @"SELECT p.Título, up.Valoracion, up.Vista
                             FROM peliculas p
                             LEFT JOIN UsuarioPeliculas up ON p.Id = up.PeliculaId AND up.Usuario = @Usuario"
                        : @"SELECT s.Título, us.Valoracion, us.Vista
                             FROM series s
                             LEFT JOIN UsuarioSeries us ON s.Id = us.SerieId AND us.Usuario = @Usuario";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    adapter.SelectCommand.Parameters.AddWithValue("@Usuario", usuarioActual);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;

                    dgv.Columns["Valoracion"].ReadOnly = false;
                    dgv.Columns["Vista"].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();

                    // Guardar cambios en Películas
                    foreach (DataGridViewRow row in dgvPeliculas.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string titulo = row.Cells["Título"].Value?.ToString();
                        string valoracion = row.Cells["Valoracion"].Value?.ToString();
                        string vista = row.Cells["Vista"].Value?.ToString();

                        string query = @"UPDATE UsuarioPeliculas
                                         SET Valoracion = @Valoracion, Vista = @Vista
                                         WHERE Usuario = @Usuario AND PeliculaId = (SELECT Id FROM peliculas WHERE Título = @Título)";

                        using (SqlCommand cmd = new SqlCommand(query, cnx))
                        {
                            cmd.Parameters.AddWithValue("@Usuario", usuarioActual);
                            cmd.Parameters.AddWithValue("@Título", titulo);
                            cmd.Parameters.AddWithValue("@Valoracion", string.IsNullOrEmpty(valoracion) ? DBNull.Value : valoracion);
                            cmd.Parameters.AddWithValue("@Vista", string.IsNullOrEmpty(vista) ? DBNull.Value : vista);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Guardar cambios en Series
                    foreach (DataGridViewRow row in dgvSeries.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string titulo = row.Cells["Título"].Value?.ToString();
                        string valoracion = row.Cells["Valoracion"].Value?.ToString();
                        string vista = row.Cells["Vista"].Value?.ToString();

                        string query = @"UPDATE UsuarioSeries
                                         SET Valoracion = @Valoracion, Vista = @Vista
                                         WHERE Usuario = @Usuario AND SerieId = (SELECT Id FROM series WHERE Título = @Título)";

                        using (SqlCommand cmd = new SqlCommand(query, cnx))
                        {
                            cmd.Parameters.AddWithValue("@Usuario", usuarioActual);
                            cmd.Parameters.AddWithValue("@Título", titulo);
                            cmd.Parameters.AddWithValue("@Valoracion", string.IsNullOrEmpty(valoracion) ? DBNull.Value : valoracion);
                            cmd.Parameters.AddWithValue("@Vista", string.IsNullOrEmpty(vista) ? DBNull.Value : vista);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sesión cerrada correctamente.", "Cerrar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnComentar_Click(object sender, EventArgs e)
        {
            string comentario = txtComentario.Text.Trim();
            if (string.IsNullOrEmpty(comentario))
            {
                MessageBox.Show("El comentario no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = tabControl.SelectedTab == tabPeliculas
                        ? @"INSERT INTO Comentarios (Usuario, PeliculaId, Comentario, Fecha)
                             SELECT @Usuario, p.Id, @Comentario, GETDATE()
                             FROM peliculas p
                             WHERE p.Título = @Título"
                        : @"INSERT INTO Comentarios (Usuario, SerieId, Comentario, Fecha)
                             SELECT @Usuario, s.Id, @Comentario, GETDATE()
                             FROM series s
                             WHERE s.Título = @Título";

                    string titulo = tabControl.SelectedTab == tabPeliculas
                        ? dgvPeliculas.CurrentRow?.Cells["Título"].Value?.ToString()
                        : dgvSeries.CurrentRow?.Cells["Título"].Value?.ToString();

                    if (string.IsNullOrEmpty(titulo))
                    {
                        MessageBox.Show("Debe seleccionar una película o serie para comentar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuarioActual);
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.Parameters.AddWithValue("@Comentario", comentario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Comentario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComentario.Clear();
                    CargarComentarios(tabControl.SelectedTab == tabPeliculas ? "peliculas" : "series");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el comentario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComentarios(string tabla)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = tabla == "peliculas"
                        ? @"SELECT Usuario, Comentario, Fecha
                             FROM Comentarios
                             WHERE PeliculaId = (SELECT Id FROM peliculas WHERE Título = @Título)"
                        : @"SELECT Usuario, Comentario, Fecha
                             FROM Comentarios
                             WHERE SerieId = (SELECT Id FROM series WHERE Título = @Título)";

                    string titulo = tabla == "peliculas"
                        ? dgvPeliculas.CurrentRow?.Cells["Título"].Value?.ToString()
                        : dgvSeries.CurrentRow?.Cells["Título"].Value?.ToString();

                    if (string.IsNullOrEmpty(titulo))
                    {
                        lstComentarios.Items.Clear();
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@Título", titulo);
                    SqlDataReader reader = cmd.ExecuteReader();

                    lstComentarios.Items.Clear();
                    while (reader.Read())
                    {
                        string usuario = reader["Usuario"].ToString();
                        string comentario = reader["Comentario"].ToString();
                        DateTime fecha = Convert.ToDateTime(reader["Fecha"]);
                        lstComentarios.Items.Add($"{fecha}: {usuario} - {comentario}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los comentarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            CargarComentarios("peliculas");
        }

        private void dgvSeries_SelectionChanged(object sender, EventArgs e)
        {
            CargarComentarios("series");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabSeries)
            {
                CargarSeries();
                CargarComentarios("series");
            }
            else if (tabControl.SelectedTab == tabPeliculas)
            {
                CargarPeliculas();
                CargarComentarios("peliculas");
            }
        }
    }
}


