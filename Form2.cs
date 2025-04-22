using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace KyA_DB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Por favor, ingrese usuario y contraseña.";
                return;
            }

            try
            {
                // Conexión a la base de datos
                using (SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-UFBV34N;Initial Catalog=TVTRACK;Integrated Security=True;TrustServerCertificate=True"))
                {
                    cnx.Open();

                    // Consulta para validar el usuario
                    string query = "SELECT Rol FROM dbo.usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                    using (SqlCommand cmd = new SqlCommand(query, cnx))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.NVarChar) { Value = username });
                        cmd.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = password });


                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            // Redirigir según el rol
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

                            this.Hide(); // Ocultar el formulario de login
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
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

