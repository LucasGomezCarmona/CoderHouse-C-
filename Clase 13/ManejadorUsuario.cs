using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    internal class ManejadorUsuario
    {
        public static string connectionString = "Data Source=DESKTOP-RURP1C2;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Usuario ObtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Usuario WHERE Id = {id}", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }
            }
            return usuario;
        }

        public static Usuario IniciarSesion(string nombreUsuario, string contraseña)
        {

            Usuario usuario = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario AND Contraseña = @Contraseña", connection);
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);
                }
                else
                {
                    usuario.Id = 0;
                    usuario.Nombre = string.Empty;
                    usuario.Apellido = string.Empty;
                    usuario.NombreUsuario = string.Empty;
                    usuario.Contraseña = string.Empty;
                    usuario.Mail = string.Empty;
                }
            }
            return usuario;
        }
    }
}
