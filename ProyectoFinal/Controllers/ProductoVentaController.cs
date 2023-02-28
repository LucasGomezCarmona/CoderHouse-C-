using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVentaController : ControllerBase
    {
        [HttpGet("ObtenerProductosVendidos/{idUsuario}")]
        public List<ProductoVenta> TraerProductosVendidos(long idUsuario)
        {
            List<ProductoVenta> ProductosVendidos = ProductoVentaHandler.ObtenerProductoVendido(idUsuario);
            return ProductosVendidos;
        }
    }
}
