using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace KyA_DB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de inicio de sesión.
        /// Valida las credenciales del usuario y redirige al formulario correspondiente según el rol.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Por favor, ingrese usuario y contraseña.";
                return;
            }

            try
            {
                using (SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-UFBV34N;Initial Catalog=TVTRACK;Integrated Security=True;TrustServerCertificate=True"))
                {
                    cnx.Open();

                    // Consulta para obtener el rol del usuario
                    string query = "SELECT Rol FROM dbo.usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", username);
                        cmd.Parameters.AddWithValue("@Contraseña", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            // Redirigir según el rol del usuario
                            if (role == "Admin")
                            {
                                FormAdmin adminForm = new FormAdmin();
                                adminForm.Show();
                            }
                            else if (role == "Usuario")
                            {
                                FormUsuario userForm = new FormUsuario(username);
                                userForm.Show();
                            }
                            else
                            {
                                lblError.Text = "Rol desconocido.";
                            }

                            // Registrar la sesión en la base de datos
                            string insertSessionQuery = "INSERT INTO HistorialSesiones (Usuario, FechaInicioSesion) VALUES (@Usuario, GETDATE())";
                            using (SqlCommand insertCmd = new SqlCommand(insertSessionQuery, cnx))
                            {
                                insertCmd.Parameters.AddWithValue("@Usuario", username);
                                insertCmd.ExecuteNonQuery();
                            }

                            // Ocultar el formulario de inicio de sesión
                            this.Hide();
                        }
                        else
                        {
                            lblError.Text = "Usuario o contraseña incorrectos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre un problema con la conexión
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

