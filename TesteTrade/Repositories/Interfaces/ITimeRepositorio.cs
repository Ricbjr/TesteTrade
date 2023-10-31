using MeuCampeonato.Models;

namespace MeuCampeonato.Repositories.Interfaces
{
    public interface ITimeRepositorio
    {
        /// <summary>
        /// Busca informa��es de um time
        /// </summary>
        /// <param name="IdTime">Id do time</param>
        /// <returns>Informa��es do Time</returns>
        Task<Time> BuscarTimePorId(int IdTime);

        /// <summary>
        /// Buscar todos os times cadastrados por um usu�rio
        /// </summary>
        /// <param name="IdUsuario">Id do Usu�rio</param>
        /// <returns>Lista contendo os times cadastrados pelo usu�rio logado</returns>
        Task<List<Time>> BuscarTimesPorUsuario(int IdUsuario);

        /// <summary>
        /// Busca todos os times cadastrados em um campeonato
        /// </summary>
        /// <param name="IdCampeonato">Id do Campeonato</param>
        /// <returns>Lista contendo os times cadastrados em um campeonato</returns>
        Task<List<Time>> BuscarTimesPorCampeonato(int IdCampeonato);

        /// <summary>
        /// Adicionar novo time
        /// </summary>
        /// <param name="Time">Informa��es do novo time</param>
        /// <returns>Time adicionado</returns>
        Task<Time> AdicionarTime(Time Time);

        /// <summary>
        /// Atualiza informa��es do time
        /// </summary>
        /// <param name="Time">Informa��es atualizadas do time</param>
        /// <param name="IdTime">Id do Time</param>
        /// <returns>Time com as informa��es atualizadas</returns>
        Task<Time> AtualizarTime(Time Time, int IdTime);

        /// <summary>
        /// Apaga um time
        /// </summary>
        /// <param name="IdTime">Id do time</param>
        /// <returns>True se apagar, Exception se n�o encontrar</returns>
        Task<bool> ApagarTime(int IdTime);
    }
}