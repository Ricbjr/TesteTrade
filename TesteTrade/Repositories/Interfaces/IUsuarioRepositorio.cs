using MeuCampeonato.Models;

namespace MeuCampeonato.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Busca um usu�rio pelo Id
        /// </summary>
        /// <param name="IdUsuario">Id do usu�rio</param>
        /// <returns>Usu�rio encontrado</returns>
        Task<Usuario> BuscarUsuarioPorId(int IdUsuario);

        /// <summary>
        /// Busca um Usuario pelo seu Username
        /// </summary>
        /// <param name="Username">Username</param>
        /// <returns>Usuario encontrado</returns>
        Task<Usuario> BuscarUsuarioPorUsername(string Username);

        /// <summary>
        /// Adiciona novo usu�rio
        /// </summary>
        /// <param name="Usuario">Informa��es do usu�rio</param>
        /// <returns>Novo Usu�rio</returns>
        Task<Usuario> AdicionarUsuario(Usuario Usuario);

        /// <summary>
        /// Atualiza informa��es do usu�rio
        /// </summary>
        /// <param name="Usuario">Informa��es atualizadas do usu�rio</param>
        /// <param name="IdUsuario">Id do usu�rio</param>
        /// <returns>Usu�rio com as informa��es atualizadas</returns>
        Task<Usuario> AtualizarUsuario(Usuario Usuario, int IdUsuario);

        /// <summary>
        /// Apaga usu�rio
        /// </summary>
        /// <param name="IdUsuario">Id do usu�rio</param>
        /// <returns>True se apagar, Exception se n�o encontrar</returns>
        Task<bool> ApagarUsuario(int IdUsuario);

    }
}