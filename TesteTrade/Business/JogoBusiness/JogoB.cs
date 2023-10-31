using MeuCampeonato.Models;
using MeuCampeonato.Repositories;
using MeuCampeonato.Repositories.Interfaces;
using Python.Runtime;
using TesteTrade.Business.CampeonatoBusiness;
using TesteTrade.Business.TimeBusiness;

namespace TesteTrade.Business.JogoBusiness
{
    public class JogoB
    {
        private readonly IJogoRepositorio _jogoRepositorio;
        private CampeonatoB campeonatoB { get; set; }
        private TimeB timeB { get; set; }

        public JogoB() {
            this.campeonatoB = new CampeonatoB();
            this.timeB = new TimeB();
        }

        public void RealizarJogo(Jogo jogo)
        {
            jogo.Gols = ExecutarScriptPython();
            jogo.Vencedor = VencedorJogo(jogo);
            _jogoRepositorio.AtualizarJogo(jogo, jogo.IdJogo);
        }

        /// <summary>
        /// Executa o script Python e retorna a quantidade de gols dos 2 times
        /// </summary>
        /// <returns>Lista contendo os gols dos 2 times</returns>
        public List<int> ExecutarScriptPython()
        {
            List<int> gols = new List<int>();

            using (Py.GIL())
            {
                PythonEngine.Initialize();
                var standardOutput = new StringWriter();

                dynamic sys = Py.Import("sys");
                dynamic script = Py.Import("__main__");

                string pythonPath = "../../teste.py";
                dynamic result = script.ExecuteFile(pythonPath);

                string resultado = result.standardOutput.ToString();

                
                string[] linhasDoResultado = resultado.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                foreach (string gol in linhasDoResultado)
                {
                    if (int.TryParse(gol, out int valor))
                    {
                        gols.Add(valor);
                    }
                }

                PythonEngine.Shutdown();
            }

            return gols;
        }

        /// <summary>
        /// Verificar qual time ganhou o jogo
        /// Condição 1: Quantidade de gols
        /// Condição 2: Desempate
        /// </summary>
        /// <param name="jogo">Jogo a ser verificado</param>
        /// <returns>Time vencedor</returns>
        public Time? VencedorJogo(Jogo jogo)
        {
            if (jogo == null)
                return null;

            Time vencedor;

            if (jogo.Gols[0] == jogo.Gols[1])
            {
                vencedor = Desempate(jogo);
            }
            else
            {
                int maiorQuantidadeGols = jogo.Gols.Max();
                vencedor = jogo.Times[jogo.Gols.IndexOf(maiorQuantidadeGols)];
                jogo.Vencedor = vencedor;
            }

            return vencedor;
        }

        /// <summary>
        /// Desempata o jogo, tendo um vencedor
        /// Condição 1: Pontuação dentro do campeonato
        /// Condição 2: Primeiro time a ser incluido no campeonato
        /// </summary>
        /// <param name="jogo"></param>
        /// <returns>Vencedor do jogo</returns>
        private Time Desempate(Jogo jogo)
        {
            List<int> pontuacaoTimes = new List<int> {0,0};

            for (int p = 0; p < pontuacaoTimes.Count; p++)
            {
                pontuacaoTimes[p] = timeB.VerificarPontuacaoAcumuladaTime(jogo, jogo.Times[p]);
            }

            if(pontuacaoTimes[0] == pontuacaoTimes[1])
            {
                jogo.Vencedor = campeonatoB.VerificarTimeQueSeCadastrouPrimeiro(jogo.Campeonato,jogo.Times[0], jogo.Times[1]);
            }
            else
            {
                int maiorPontuacao = pontuacaoTimes.Max();
                jogo.Vencedor = jogo.Times[pontuacaoTimes.IndexOf(maiorPontuacao)];
            }
            return jogo.Vencedor;
        }
    }
}
