
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Data
{
    class Conexion
    {
        public string connStr = String.Empty;

        public SqlConnection conexion;

        public Conexion()
        {
          // connStr = "Server=DESKTOP-Q4CVHK7\\SQLEXPRESS;Database=bd_biblioteca;User ID=sa;password=admin1234;Integrated Security=true";
        }
 
        public void conectar() {
            connStr = "Server=DESKTOP-Q4CVHK7\\SQLEXPRESS;Database=bd_biblioteca;User ID=sa;password=admin1234;Integrated Security=true";
            conexion = new SqlConnection(connStr);
          
        }

        public SqlConnection getConexion() {
            return conexion;
        }

        public void desconectar() {
            
        }
    }
}
