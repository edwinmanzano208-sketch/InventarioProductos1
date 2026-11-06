using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class CategoriaDatos
    {
        public DataTable Listar()
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdCategoria, Nombre FROM Categoria", con);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
    }
}