namespace Proyecto_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PUNTO 1
            Usuario usuario = ManejadorUsuario.ObtenerUsuario(1);
            
            Console.WriteLine("\nNOMBRE DE USUARIO POR ID (1)\n");
            Console.WriteLine(usuario.Nombre);

            // PUNTO 2
            List<Producto> productos = ManejadorProducto.ObtenerProductos(1);
            Console.WriteLine("\nDESCRIPCIONES DE PRODUCTOS POR ID(1)\n");
            foreach (Producto producto1 in productos)
            {
                Console.WriteLine(producto1.Descripciones);
            }

            // PUNTO 3
            Console.WriteLine("\nPRODUCTOS VENDIDOS POR ID(1)\n");
            List<Producto> productosVendidos = ProductoVentaHandler.ObtenerProductoVendido(1);
            foreach(Producto producto2 in productos)
            {
                Console.WriteLine(producto2.Descripciones);
                Console.WriteLine(producto2.PrecioVenta);
                Console.WriteLine(producto2.Stock);
                Console.WriteLine("\n");
            }

            // PUNTO 4
            Console.WriteLine("\nVENTAS POR ID DE USUARIO(1)\n");
            List<Venta> ventas = VentaHandler.ObtenerVentas(1);
            foreach(Venta venta in ventas)
            {
                Console.WriteLine(venta.Id);
                Console.WriteLine(venta.Comentarios);
                Console.WriteLine("\n");
            }

            // PUNTO 5
            Console.WriteLine("\nINICIO DE SESION(1)\n");
            Usuario usuarioLogIn = ManejadorUsuario.IniciarSesion("tcasazza","SoyTobiasCasazza");
            if(usuarioLogIn.NombreUsuario != string.Empty)
            {
                Console.WriteLine($"Has iniciado sesion como {usuarioLogIn.NombreUsuario}.");
            }
            else
            {
                Console.WriteLine("Error al iniciar sesion.");
            }

        }
    }
}