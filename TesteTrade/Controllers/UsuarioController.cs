using MeuCampeonato.Models;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController :ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        [HttpGet("{username}")]
        public async Task<ActionResult<Usuario>> BuscarUsuario(string Username)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarUsuarioPorUsername(Username);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] Usuario usuario)
        {
            Usuario usuarioCadastrado = await _usuarioRepositorio.AdicionarUsuario(usuario);

            return Ok(usuarioCadastrado);
        }
    }
}