using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    public class ProductoDatos
    {
        // Consulta base que se reutiliza en varios métodos
        private string consulta =
            "SELECT p.IdProducto, p.Codigo, p.Nombre, p.Precio, p.Stock, p.IdCategoria, c.Nombre AS Categoria " +
            "FROM Producto p INNER JOIN Categoria c ON p.IdCategoria = c.IdCategoria ";

        private DataTable Llenar(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable Listar()
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand(consulta, con);
                return Llenar(cmd);
            }
        }

        public DataTable Buscar(string texto)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand(consulta + "WHERE p.Codigo LIKE @Texto OR p.Nombre LIKE @Texto", con);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");
                return Llenar(cmd);
            }
        }

        public DataTable ListarStockBajo()
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand(consulta + "WHERE p.Stock < 5", con);
                return Llenar(cmd);
            }
        }

        public decimal ValorTotalInventario()
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Precio * Stock), 0) FROM Producto", con);
                con.Open();
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        public bool ExisteCodigo(string codigo, int idProducto)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "SELECT COUNT(*) FROM Producto WHERE Codigo = @Codigo AND IdProducto <> @IdProducto";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                con.Open();
                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad > 0;
            }
        }

        public void Insertar(string codigo, string nombre, decimal precio, int stock, int idCategoria)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "INSERT INTO Producto (Codigo, Nombre, Precio, Stock, IdCategoria) " +
                             "VALUES (@Codigo, @Nombre, @Precio, @Stock, @IdCategoria)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(int idProducto, string codigo, string nombre, decimal precio, int stock, int idCategoria)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                string sql = "UPDATE Producto SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, " +
                             "Stock = @Stock, IdCategoria = @IdCategoria WHERE IdProducto = @IdProducto";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idProducto)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Producto WHERE IdProducto = @IdProducto", con);
                cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
} 