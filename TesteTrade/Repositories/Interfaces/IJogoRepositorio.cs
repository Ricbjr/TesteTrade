using MeuCampeonato.Models;

namespace MeuCampeonato.Repositories.Interfaces
{
    public interface IJogoRepositorio
    {
        /// <summary>
        /// Busca todos os jogos de um campeonato
        /// </summary>
        /// <param name="IdCampeonato">Id do Campeonato</param>
        /// <returns>Lista de jogos do campeonato</returns>
        Task<List<Jogo>> BuscarJogosPorCampeonato(int IdCampeonato);

        /// <summary>
        /// Busca as informações de um jogo
        /// </summary>
        /// <param name="IdJogo">Id do jogo</param>
        /// <returns>Informações do jogo</returns>
        Task<Jogo> BuscarJogoPorId(int IdJogo);

        /// <summary>
        /// Busca vencedor de um jogo
        /// </summary>
        /// <param name="IdJogo">Id do Jogo</param>
        /// <returns>Time vencedor do jogo</returns>
        Task<Time> BuscarVencedorJogo(int IdJogo);

        /// <summary>
        /// Adiciona um novo jogo com as informações
        /// </summary>
        /// <param name="Jogo">Jogo</param>
        /// <returns>Jogo</returns>
        Task<Jogo> AdicionarJogo(Jogo Jogo);

        /// <summary>
        /// Atualiza informações do jogo
        /// </summary>
        /// <param name="Jogo">Informações novas do jogo</param>
        /// <param name="IdJogo">Id do jogo</param>
        /// <returns>Jogo com as informações atualizadas</returns>
        Task<Jogo> AtualizarJogo(Jogo Jogo, int IdJogo);

        /// <summary>
        /// Apaga um jogo
        /// </summary>
        /// <param name="IdJogo">Id do Jogo</param>
        /// <returns>True se apagar, Exception se não encontrar</returns>
        Task<bool> ApagarJogo(int IdJogo);
    }
}