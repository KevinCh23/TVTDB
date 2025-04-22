using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KyA_DB
{
    class Conexion
    {
        SqlConnection cnx;

        public Conexion()
        {
            try
            {
                cnx = new SqlConnection("Data Source=DESKTOP-UFBV34N;Initial Catalog=TVTRACK;Integrated Security=True");
                cnx.Open();
                MessageBox.Show("Conexión exitosa", "Excelente", MessageBoxButtons.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de conexión: " + e.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
