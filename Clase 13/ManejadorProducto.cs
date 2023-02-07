using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal static class ManejadorProducto
    {
        public static string connectionString = "Data Source=DESKTOP-RURP1C2;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> ObtenerProductos(long id)
        {
            List<Producto> productos = new List<Producto>();

            using(SqlConnection connection= new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
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
            }
            return productos;
        }
    }
}
