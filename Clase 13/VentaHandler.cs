using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class VentaHandler
    {
        public static string connectionString = "Data Source=DESKTOP-RURP1C2;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @IdUsuario", connection);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
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
    }
}
