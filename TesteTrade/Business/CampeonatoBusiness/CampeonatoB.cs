using MeuCampeonato.Models;

namespace TesteTrade.Business.CampeonatoBusiness
{
    public class CampeonatoB
    {
        const int primeiraChave = 0;
        const int segundaChave = 1;
        const int terceiraChave = 2;
        const int quartaChave = 3;
        public CampeonatoB()
        {

        }
        /// <summary>
        /// Verifica qual time se cadastrou primeiro em um campeonato
        /// </summary>
        /// <param name="campeonato">Campeonato</param>
        /// <param name="primeiroTime">Primeiro time</param>
        /// <param name="segundoTime">Segundo time</param>
        /// <returns>Time que foi cadastrado antes no campeonato</returns>
        public Time? VerificarTimeQueSeCadastrouPrimeiro(Campeonato campeonato, Time primeiroTime, Time segundoTime)
        {
            Time time = primeiroTime;

            if (campeonato.Times.FindIndex(x => x.IdTime == primeiroTime.IdTime) < campeonato.Times.FindIndex(x => x.IdTime == segundoTime.IdTime))
                time = segundoTime;

            return time;
        }

        /// <summary>
        /// Realizar jogos do campeonato
        /// </summary>
        /// <param name="campeonato"></param>
        public void RealizaCampeonato(Campeonato campeonato)
        {

        }

        /// <summary>
        /// Cria a chave atual do campeonato
        /// Primeira chave: 4 jogos com os 8 times
        /// Segunda chave: 2 jogos com 4 times restantes
        /// Terceira chave: 1 jogo com times perdedores da segunda chave
        /// Quarta chave: final
        /// </summary>
        /// <param name="campeonato"></param>
        /// <param name="chaveCampeonato"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Campeonato CriarChaveDoCampeonato(Campeonato campeonato, int chaveCampeonato)
        {
            int quantidadeJogos = 0;
            List<Time> timesDisponiveis = new List<Time>();
            int aleatorio = 0;
            Time primeiroTime;
            Time segundoTime;
            Random random = new Random();

            if (chaveCampeonato == primeiraChave)
            {
                quantidadeJogos = 4;

                foreach (Time time in campeonato.Times)
                {
                    timesDisponiveis.Add(time);
                }

                for(int i = 0; i< quantidadeJogos; i++)
                { 
                    aleatorio = random.Next(0, timesDisponiveis.Count);
                    primeiroTime = timesDisponiveis[aleatorio];
                    timesDisponiveis.RemoveAt(aleatorio);

                    aleatorio = random.Next(0, timesDisponiveis.Count);
                    segundoTime = timesDisponiveis[aleatorio];
                    timesDisponiveis.RemoveAt(aleatorio);

                    Jogo jogo = new Jogo
                    {
                        Campeonato = campeonato,
                        CampeonatoId = campeonato.IdCampeonato,
                        Times = new List<Time> { primeiroTime, segundoTime},
                        Gols = new List<int> { 0,0 },
                        ChaveDoCampeonato = chaveCampeonato

                    };
                    campeonato.Jogos.Add(jogo);
                }
                
            }
            if(chaveCampeonato == segundaChave)
            {

            }

            return campeonato;
        }
    }
}
