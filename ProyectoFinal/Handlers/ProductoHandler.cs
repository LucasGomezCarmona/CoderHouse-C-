using ProyectoFinal.ADO.NET;
using ProyectoFinal.Models;
using System.Data.SqlClient;

namespace ProyectoFinal.Repository
{
    public class ProductoHandler : SqlHandler
    {
        public static List<Producto> ObtenerProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto", connection);
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

        public static void AgregarProducto(Producto producto)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@descripcion, @costo, @precioVenta, @stock, @idUsuario)", connection);

                command.Parameters.AddWithValue("@descripcion", producto.Descripciones);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@id", producto.Id);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public static int ModificarProducto(Producto producto)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Producto SET Descripciones = @descripcion, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@descripcion", producto.Descripciones);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("@id", producto.Id);
                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

        public static int ModificarStock(long id, int cantidad)
        {
            Producto producto = ObtenerProducto(id);
            producto.Stock = cantidad;
            return ModificarProducto(producto);
        }

        public static void EliminarProducto(long id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                ProductoVentaHandler.EliminarProductoVendido(id);
                SqlCommand command = new SqlCommand("DELETE FROM Producto WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE Id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        producto.Id = reader.GetInt64(0);
                        producto.Descripciones = reader.GetString(1);
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario= reader.GetInt64(5);
                    }
                }
                return producto;
            }
        }

        public static List<Producto> ObtenerProductosUsuario(long idUsuario) 
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
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
                return productos;
            }
        }
    }
}
