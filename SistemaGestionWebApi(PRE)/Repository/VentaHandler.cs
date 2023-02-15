using SistemaGestionWebApi.Models;
using System.Data.SqlClient;

namespace SistemaGestionWebApi.Repository
{
    public class VentaHandler
    {
        public static string connectionString = "Data Source=DESKTOP-RURP1C2;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @IdUsuario", connection);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();

                        venta.Id = reader.GetInt64(0);
                        venta.Comentarios = reader.GetString(1);
                        venta.IdUsuario = reader.GetInt64(2);
                    }
                }
            }
            return ventas;
        }

        public static long InsertarVenta(Venta venta)
        {
            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Venta(Comentarios,IdUsuario) VALUES (@comentarios, @idUsuario)", connection);
                command.Parameters.AddWithValue("@comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
                connection.Open();
                
                return Convert.ToInt64(command.ExecuteScalar());
            }
        }

        public static void CargarVenta(long idUsuario, List<Producto> productosVendidos)
        {
            Venta venta = new Venta();
            venta.IdUsuario = idUsuario;
            venta.Comentarios = "Venta";
            long idVenta = InsertarVenta(venta);

            foreach(Producto producto in productosVendidos)
            {
                ProductoVenta newVenta = new ProductoVenta();

                newVenta.Stock = producto.Stock;
                newVenta.IdProducto = producto.Id;
                newVenta.IdVenta = idVenta;
                ProductoVentaHandler.AgregarProductoVendido(newVenta);
                ProductoHandler.ModificarStock(producto.Id, 1);
            }
        }
    }
}
