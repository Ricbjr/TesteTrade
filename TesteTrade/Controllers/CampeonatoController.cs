using MeuCampeonato.Models;
using MeuCampeonato.Repositories;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTrade.Business.CampeonatoBusiness;

namespace MeuCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController :ControllerBase
    {
        private readonly ICampeonatoRepositorio _campeonatoRepositorio;
        private CampeonatoB camp;
        const int primeiraChave = 0;
        public CampeonatoController(ICampeonatoRepositorio campeonatoRepositorio)
        {
            this.camp = new CampeonatoB();
            _campeonatoRepositorio = campeonatoRepositorio;
        }

        [HttpGet("campeonatosdousuario/{IdUsuario}")]
        public async Task<ActionResult<List<Campeonato>>> BuscarCampeonatosDoUsuario(int IdUsuario)
        {
            List<Campeonato> campeonatos = await _campeonatoRepositorio.BuscarCampeonatosPorUsuario(IdUsuario);
            return Ok(campeonatos);
        }

        [HttpGet]
        public async Task<ActionResult<Campeonato>> BuscarCampeonato(int IdCampeonato)
        {
            Campeonato campeonato = await _campeonatoRepositorio.BuscarCampeonatoPorId(IdCampeonato);
            return Ok(campeonato);
        }

        [HttpPost]
        public async Task<ActionResult<Campeonato>> Cadastrar([FromBody] Campeonato campeonato)
        {
            
            campeonato = camp.CriarChaveDoCampeonato(campeonato, primeiraChave);
            Campeonato campeonatoCadastrado = await _campeonatoRepositorio.AdicionarCampeonato(campeonato);
            
            return Ok(campeonatoCadastrado);
        }

        [HttpPost("realizarcampeonato/{IdCampeonato}")]
        public async Task<ActionResult<Campeonato>> RealizarCampeonato(int idCampenato)
        {
            return Ok();
        }
    }
}