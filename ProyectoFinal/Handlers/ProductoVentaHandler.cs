using ProyectoFinal.ADO.NET;
using ProyectoFinal.Models;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ProductoVentaHandler : SqlHandler
    {
        public static List<ProductoVenta> ObtenerProductoVendido(long IdUsuario)
        {
            List<ProductoVenta> productosVendidos = new List<ProductoVenta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto INNER JOIN ProductoVendido ON ProductoVendido.IdProducto = Producto.Id WHERE IdUsuario = @IdUsuario", connection);
                command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVenta productoVendido = new ProductoVenta();

                        productoVendido.Id = reader.GetInt64(0);
                        productoVendido.Stock = reader.GetInt32(1);
                        productoVendido.IdProducto = reader.GetInt64(2);
                        productoVendido.IdVenta = reader.GetInt64(3);

                        productosVendidos.Add(productoVendido);
                    }
                }
            }
            return productosVendidos;
        }

        public static void AgregarProductoVendido(ProductoVenta productoVendido)
        {
            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta) VALUES (@stock, @idProducto, @idVenta", connection);
                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void EliminarProductoVendido(long idProducto)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM ProductoVendido WHERE IdProducto = @idProducto", connection);
                command.Parameters.AddWithValue("@idProducto", idProducto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
