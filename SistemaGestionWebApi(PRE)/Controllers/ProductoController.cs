using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionWebApi.Models;
using SistemaGestionWebApi.Repository;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost("AgregarProducto")]
        public void AgregarProducto([FromBody] Producto producto)
        {
            ProductoHandler.AgregarProducto(producto);
        }

        [HttpPut("ModificarProducto")]
        public void ModificarProducto([FromBody] Producto producto)
        {
            ProductoHandler.ModificarProducto(producto);
        }
    }
}
