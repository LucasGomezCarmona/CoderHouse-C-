using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionWebApi.Models;
using SistemaGestionWebApi.Repository;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace SistemaGestionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("{nombreUsuario}/{password}")]
        public Usuario LogIn(string nombreUsuario, string password)
        {
            return UsuarioHandler.IniciarSesion(nombreUsuario,password);
        }

        [HttpPut("modificarUsuario/{id}")]
        public void ModifyUsuario([FromBody] Usuario usuario)
        {
            UsuarioHandler.ModificarUsuario(usuario);
        }
    }
}
