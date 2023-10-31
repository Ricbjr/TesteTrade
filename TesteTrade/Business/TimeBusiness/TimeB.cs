using MeuCampeonato.Models;
using MeuCampeonato.Repositories.Interfaces;

namespace TesteTrade.Business.TimeBusiness
{
    public class TimeB
    {
        private readonly ITimeRepositorio _timeRepositorio;

        public TimeB()
        {

        }
        /// <summary>
        /// Verifica a pontuação acumulada do time até esse jogo dentro do campeonato do jogo
        /// </summary>
        /// <param jogo="jogo">Jogo atual</param>
        /// <param name="time">Time</param>
        /// <returns>Retorna a pontuação acumulada do time</returns>
        public int VerificarPontuacaoAcumuladaTime(Jogo jogo, Time time)
        {
            int pontuacaoTime = 0;
            int chaveCampeonato = jogo.ChaveDoCampeonato;

            foreach (Jogo j in jogo.Campeonato.Jogos.Where(x => x.ChaveDoCampeonato < chaveCampeonato
                                                          && x.Times.Any(y => y.IdTime == time.IdTime)).ToList())
            {
                int posTime = j.Times.FindIndex(x => x.IdTime == time.IdTime);
                if (posTime == 0)
                {
                    pontuacaoTime = pontuacaoTime + j.Gols[0] - j.Gols[1];
                }
                else
                {
                    pontuacaoTime = pontuacaoTime + j.Gols[1] - j.Gols[0];
                }
            }

            return pontuacaoTime;
        }

        /// <summary>
        /// Verifica se time não está participando de nenhum campeonato
        /// </summary>
        /// <param name="time">Time</param>
        /// <returns>True se não está participando</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool VerificarSePodeSerApagado(Time time)
        {
            throw new NotImplementedException();
        }
    }
}
