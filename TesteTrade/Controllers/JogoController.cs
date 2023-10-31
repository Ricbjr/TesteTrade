using MeuCampeonato.Models;
using MeuCampeonato.Repositories;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeuCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoController(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }

        [HttpGet("{idCampeonato}")]
        public async Task<ActionResult<List<Jogo>>> BuscarJogosDoCampeonato(int IdCampeonato)
        {
            List<Jogo> jogos = await _jogoRepositorio.BuscarJogosPorCampeonato(IdCampeonato);
            return Ok(jogos);
        }

        [HttpGet("{idJogo}")]
        public async Task<ActionResult<Jogo>> BuscarJogo(int idJogo)
        {
            Jogo jogo = await _jogoRepositorio.BuscarJogoPorId(idJogo);
            return Ok(jogo);
        }

        [HttpPut("{idJogo}")]
        public async Task<ActionResult<Jogo>> Atualizar([FromBody] Jogo jogo, int idJogo)
        {
            Jogo jogoAtualizado = await _jogoRepositorio.AtualizarJogo(jogo, idJogo);

            return Ok(jogoAtualizado);
        }


        [HttpPost]
        public async Task<ActionResult<Jogo>> CadastrarJogo([FromBody] Jogo jogo)
        {
            Jogo jogoCadastrado = await _jogoRepositorio.AdicionarJogo(jogo);

            return Ok(jogoCadastrado);
        }
    }
}