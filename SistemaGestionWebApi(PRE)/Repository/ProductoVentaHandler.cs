using SistemaGestionWebApi.Models;
using System.Data.SqlClient;

namespace SistemaGestionWebApi.Repository
{
    public class ProductoVentaHandler
    {
        public static string connectionString = "Data Source=DESKTOP-RURP1C2;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Producto> ObtenerProductoVendido(long IdUsuario)
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto inner join ProductoVendido ON ProductoVendido.IdProducto = Producto.Id where IdUsuario = @IdUsuario", connection);
                command.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();

                        producto.Id = reader.GetInt64(0);
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);

                        productos.Add(producto);
                    }
                }
            }
            return productos;
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
