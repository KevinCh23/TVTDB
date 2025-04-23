using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KyA_DB
{
    public partial class FormAdmin : Form
    {
        private string connectionString = "Data Source=DESKTOP-UFBV34N;Initial Catalog=TVTRACK;Integrated Security=True;TrustServerCertificate=True";

        public FormAdmin()
        {
            InitializeComponent();
            CargarReportes();
        }

        /// <summary>
        /// Maneja el evento de clic para añadir un nuevo usuario.
        /// Solicita el nombre y la contraseña del usuario y lo registra en la base de datos.
        /// </summary>
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string usuario = Prompt("Ingrese el nombre del usuario:");
            string contraseña = Prompt("Ingrese la contraseña del usuario:");
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = "INSERT INTO usuarios (Usuario, Contraseña, Rol) VALUES (@Usuario, @Contraseña, 'Usuario')";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para borrar un usuario.
        /// Solicita el nombre del usuario y lo elimina de la base de datos.
        /// </summary>
        private void btnBorrarUsuario_Click(object sender, EventArgs e)
        {
            string usuario = Prompt("Ingrese el nombre del usuario a borrar:");
            if (string.IsNullOrEmpty(usuario)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = "DELETE FROM usuarios WHERE Usuario = @Usuario";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Usuario borrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para añadir una película.
        /// Solicita el título de la película y la registra en la base de datos.
        /// </summary>
        private void btnAgregarPelicula_Click(object sender, EventArgs e)
        {
            string titulo = Prompt("Ingrese el título de la película:");
            if (string.IsNullOrEmpty(titulo)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = "INSERT INTO peliculas (Título) VALUES (@Título)";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Película agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la película: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para añadir una serie.
        /// Solicita el título de la serie y la registra en la base de datos.
        /// </summary>
        private void btnAgregarSerie_Click(object sender, EventArgs e)
        {
            string titulo = Prompt("Ingrese el título de la serie:");
            if (string.IsNullOrEmpty(titulo)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = "INSERT INTO series (Título) VALUES (@Título)";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Serie agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la serie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para borrar una película.
        /// Solicita el título de la película y la elimina de la base de datos.
        /// </summary>
        private void btnBorrarPelicula_Click(object sender, EventArgs e)
        {
            string titulo = Prompt("Ingrese el título de la película a borrar:");
            if (string.IsNullOrEmpty(titulo)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = "DELETE FROM peliculas WHERE Título = @Título";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Película borrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar la película: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para borrar una serie.
        /// Solicita el título de la serie y la elimina de la base de datos.
        /// </summary>
        private void btnBorrarSerie_Click(object sender, EventArgs e)
        {
            string titulo = Prompt("Ingrese el título de la serie a borrar:");
            if (string.IsNullOrEmpty(titulo)) return;

            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string deleteReferencesQuery = "DELETE FROM UsuarioSeries WHERE SerieId IN (SELECT Id FROM series WHERE Título = @Título)";
                    using (SqlCommand cmd = new SqlCommand(deleteReferencesQuery, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.ExecuteNonQuery();
                    }

                    string query = "DELETE FROM series WHERE Título = @Título";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Título", titulo);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Serie borrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al borrar la serie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic para cerrar sesión.
        /// Cierra el formulario actual y regresa al formulario de inicio de sesión.
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 loginForm = new Form2();
            loginForm.Show();
        }

        /// <summary>
        /// Carga los reportes de los últimos usuarios que iniciaron sesión.
        /// </summary>
        private void CargarReportes()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();
                    string query = @"SELECT TOP 10 Usuario, FechaInicioSesion
                                     FROM HistorialSesiones
                                     ORDER BY FechaInicioSesion DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay usuarios en el historial de sesiones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvReportes.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los reportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra un cuadro de entrada para solicitar información al usuario.
        /// </summary>
        private string Prompt(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Entrada", "");
        }
    }
}


