using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost("agregarProducto")]
        public void AgregarProducto([FromBody] Producto producto)
        {
            ProductoHandler.AgregarProducto(producto);
        }

        [HttpPut("modificarProducto/{id}")]
        public void ModificarProducto([FromBody] Producto producto)
        {
            ProductoHandler.ModificarProducto(producto);
        }

        [HttpDelete("eliminarProducto/{id}")]
        public void EliminarProducto(long id)
        {
            ProductoHandler.EliminarProducto(id);
        }

        [HttpGet("obtenerProductos")]
        public List<Producto> ObtenerProductos()
        {
            List<Producto> productos = ProductoHandler.ObtenerProductos();
            return productos;
        }
    }
}
