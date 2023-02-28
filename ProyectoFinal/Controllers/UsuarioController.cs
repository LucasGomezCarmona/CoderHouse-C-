using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("IniciarSesion/{nombreUsuario}/{password}")]
        public Usuario LogIn(string nombreUsuario, string password)
        {
            return UsuarioHandler.IniciarSesion(nombreUsuario,password);
        }

        [HttpPut("ModificarUsuario/{id}")]
        public void ModifyUsuario([FromBody] Usuario usuario)
        {
            UsuarioHandler.ModificarUsuario(usuario);
        }

        [HttpPost("AgregarUsuario/")]
        public void AddUsuario([FromBody] Usuario usuario)
        {
            UsuarioHandler.AgregarUsuario(usuario);
        }

        [HttpGet("ObtenerNombre/{nombre}")]
        public Usuario GetUsuario(string nombre)
        {
            return UsuarioHandler.ObtenerUsuario(nombre);
        }

        [HttpDelete("EliminarUsuario/{id}")]
        public void DeleteUsuario(long id)
        {
            UsuarioHandler.EliminarUsuario(id);
        }
    }
}
