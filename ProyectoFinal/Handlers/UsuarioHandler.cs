using ProyectoFinal.ADO.NET;
using ProyectoFinal.Models;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoFinal.Repository
{
    public class UsuarioHandler : SqlHandler
    {
            public static Usuario ObtenerUsuario(string nombre)
            {
                Usuario usuario = new Usuario();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * From Usuario WHERE Nombre = @nombre", connection);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
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

                    if (reader.HasRows)
                    {
                        reader.Read();
                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);
                    }
                }
                return usuario;
            }

            public static void ModificarUsuario(Usuario usuario)
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("UPDATE Usuario SET Nombre = @nombre,Apellido = @apellido,NombreUsuario = @nombreUsuario,Contraseña = @clave,Mail = @mail WHERE Id = @id",connection);
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@clave", usuario.Contraseña);
                    command.Parameters.AddWithValue("@mail", usuario.Mail );
                    command.Parameters.AddWithValue("@id", usuario.Id);
                    connection.Open();
                    
                    command.ExecuteNonQuery();
                }
            }

            
            public static void AgregarUsuario(Usuario usuario)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES (@nombre, @apellido, @nombreUsuario, @clave, @mail)", connection);
                    command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                    command.Parameters.AddWithValue("@clave", usuario.Contraseña);
                    command.Parameters.AddWithValue("@mail", usuario.Mail);

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }

        public static void EliminarUsuario(long id)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                List<Producto> productos = new List<Producto>();
                foreach(Producto producto in productos)
                {
                    ProductoHandler.EliminarProducto(producto.Id);
                }
                VentaHandler.EliminarVenta(id);

                SqlCommand command = new SqlCommand("DELETE FROM Usuario WHERE Id = @id",connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
