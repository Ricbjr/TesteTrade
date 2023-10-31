using MeuCampeonato.Models;

namespace MeuCampeonato.Repositories.Interfaces
{
    public interface ICampeonatoRepositorio
    {
        /// <summary>
        /// Busca todos os campeonatos do usu�rio
        /// </summary>
        /// <param name="IdUsuario"> Id do usu�rio logado</param>
        /// <returns>Lista de campeonatos passados</returns>
        Task<List<Campeonato>> BuscarCampeonatosPorUsuario(int IdUsuario);

        /// <summary>
        /// Buscar um �nico campeonato por Id
        /// </summary>
        /// <param name="IdCampeonato">Id do campeonato</param>
        /// <returns>O Campeonato</returns>
        Task<Campeonato> BuscarCampeonatoPorId(int IdCampeonato);

        /// <summary>
        /// Busca o time vencedor da final do campeonato
        /// </summary>
        /// <param name="IdCampeonato">Id do campeonato</param>
        /// <returns>Time vencedor do campeonato</returns>
        Task<Time> BuscarVencedorCampeonato(int IdCampeonato); 

        /// <summary>
        /// Adiciona novo campeonato
        /// </summary>
        /// <param name="Campeonato">Objeto do Campeonato</param>
        /// <returns>O Campeonato</returns>
        Task<Campeonato> AdicionarCampeonato(Campeonato Campeonato);

        /// <summary>
        /// Atualiza informa��es do campeonato
        /// </summary>
        /// <param name="Campeonato">Informa��es atualizadas do campeonato</param>
        /// <param name="idCampeonato">Id do campeonato que ser� atualizado</param>
        /// <returns>Campeonato atualizado</returns>
        Task<Campeonato> AtualizarCampeonato(Campeonato Campeonato, int idCampeonato);

        /// <summary>
        /// Apaga Campeonato
        /// </summary>
        /// <param name="IdCampeonato">Id do campeonato a ser apagado</param>
        /// <returns>True se apagou, ou uma exception se n�o achar o campeonato</returns>
        Task<bool> ApagarCampeonato(int IdCampeonato);
    }
}