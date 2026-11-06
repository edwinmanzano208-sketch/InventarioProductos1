using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        private ProductoDatos datos = new ProductoDatos();

        // Consultas
        public DataTable Listar()
        {
            return datos.Listar();
        }

        public DataTable Buscar(string texto)
        {
            if (texto.Trim() == "")
            {
                return datos.Listar();
            }
            return datos.Buscar(texto.Trim());
        }

        public DataTable ListarStockBajo()
        {
            return datos.ListarStockBajo();
        }

        public decimal ValorTotalInventario()
        {
            return datos.ValorTotalInventario();
        }

        // Validaciones: devuelve "" si todo está bien, o el mensaje de error
        private string Validar(int idProducto, string codigo, string nombre, string precio, string stock, int idCategoria)
        {
            if (codigo.Trim() == "")
            {
                return "El código es obligatorio.";
            }
            if (nombre.Trim() == "")
            {
                return "El nombre es obligatorio.";
            }

            decimal precioNumero;
            if (!decimal.TryParse(precio, out precioNumero))
            {
                return "El precio debe ser un número.";
            }
            if (precioNumero <= 0)
            {
                return "El precio debe ser mayor que 0.";
            }

            int stockNumero;
            if (!int.TryParse(stock, out stockNumero))
            {
                return "El stock debe ser un número entero.";
            }
            if (stockNumero < 0)
            {
                return "El stock no puede ser negativo.";
            }

            if (idCategoria <= 0)
            {
                return "Debe seleccionar una categoría.";
            }

            if (datos.ExisteCodigo(codigo.Trim(), idProducto))
            {
                return "Ya existe un producto con ese código.";
            }

            return "";
        }

        // Operaciones: devuelven "" si se hizo, o el mensaje de error
        public string Insertar(string codigo, string nombre, string precio, string stock, int idCategoria)
        {
            string error = Validar(0, codigo, nombre, precio, stock, idCategoria);
            if (error != "")
            {
                return error;
            }

            Producto p = new Producto();
            p.Codigo = codigo.Trim();
            p.Nombre = nombre.Trim();
            p.Precio = decimal.Parse(precio);
            p.Stock = int.Parse(stock);
            p.IdCategoria = idCategoria;

            datos.Insertar(p.Codigo, p.Nombre, p.Precio, p.Stock, p.IdCategoria);
            return "";
        }

        public string Modificar(int idProducto, string codigo, string nombre, string precio, string stock, int idCategoria)
        {
            if (idProducto <= 0)
            {
                return "Seleccione un producto de la lista.";
            }

            string error = Validar(idProducto, codigo, nombre, precio, stock, idCategoria);
            if (error != "")
            {
                return error;
            }

            Producto p = new Producto();
            p.IdProducto = idProducto;
            p.Codigo = codigo.Trim();
            p.Nombre = nombre.Trim();
            p.Precio = decimal.Parse(precio);
            p.Stock = int.Parse(stock);
            p.IdCategoria = idCategoria;

            datos.Modificar(p.IdProducto, p.Codigo, p.Nombre, p.Precio, p.Stock, p.IdCategoria);
            return "";
        }

        public string Eliminar(int idProducto)
        {
            if (idProducto <= 0)
            {
                return "Seleccione un producto de la lista.";
            }

            datos.Eliminar(idProducto);
            return "";
        }
    }
}