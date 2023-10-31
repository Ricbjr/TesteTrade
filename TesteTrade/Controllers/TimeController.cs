using MeuCampeonato.Models;
using MeuCampeonato.Repositories;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteTrade.Business.TimeBusiness;

namespace MeuCampeonato.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController :ControllerBase
    {
        private readonly ITimeRepositorio _timeRepositorio;
        private TimeB timeB { get; set; }
        public TimeController(ITimeRepositorio timeRepositorio)
        {
            this.timeB = new TimeB();
            _timeRepositorio = timeRepositorio;
        }

        /// <summary>
        /// Devolve uma lista com todos os times já cadastrados pelo usuário
        /// </summary>
        /// <param name="IdUsuario">Id do Usuário</param>
        /// <returns>Lista de times do usuario</returns>
        [HttpGet("buscarporusuario/{idUsuario}")]
        public async Task<ActionResult<List<Time>>> BuscarTimesDoUsuario(int IdUsuario)
        {
            List<Time> times = await _timeRepositorio.BuscarTimesPorUsuario(IdUsuario);
            return Ok(times);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTime"></param>
        /// <returns></returns>
        [HttpGet("{idTime}")]
        public async Task<ActionResult<Time>> BuscarTime(int idTime)
        {
            Time time = await _timeRepositorio.BuscarTimePorId(idTime);
            return Ok(time);
        }

        [HttpPost]
        public async Task<ActionResult<Time>> Cadastrar([FromBody] Time time)
        {
            Time timeCadastrado = await _timeRepositorio.AdicionarTime(time);

            return Ok(timeCadastrado);
        }

        [HttpPut("{idTime}")]
        public async Task<ActionResult<Time>> Atualizar([FromBody] Time time, int idTime)
        {
            Time timeAtualizado = await _timeRepositorio.AtualizarTime(time,idTime);

            return Ok(timeAtualizado);
        }

        [HttpDelete("{idTime}")]
        public async Task<ActionResult<bool>> Apagar( int idTime)
        {
            Time time = await _timeRepositorio.BuscarTimePorId(idTime);
            bool podeApagar = timeB.VerificarSePodeSerApagado(time);

            if( podeApagar )
            {
                bool apagado = await _timeRepositorio.ApagarTime(idTime);

                return Ok(apagado);
            }

            return Ok(false);
        }
    }
}