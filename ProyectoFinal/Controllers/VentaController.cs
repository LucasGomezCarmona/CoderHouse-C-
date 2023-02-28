using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("CargarVenta/{idUsuario}")]
        public void CargarVenta(long idUsuario, [FromBody] List<Producto> productos)
        {
            VentaHandler.CargarVenta(idUsuario, productos);
        }

        [HttpGet("ObtenerVentas/")]
        public List<Venta> TraerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            return ventas;
        }

        [HttpDelete("EliminarVenta/{id}")]
        public void EliminarVenta(long id) 
        {
            VentaHandler.EliminarVenta(id);
        }
    }
}
