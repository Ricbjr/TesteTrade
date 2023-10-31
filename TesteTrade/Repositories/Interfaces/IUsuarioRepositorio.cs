using MeuCampeonato.Models;

namespace MeuCampeonato.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Busca um usuário pelo Id
        /// </summary>
        /// <param name="IdUsuario">Id do usuário</param>
        /// <returns>Usuário encontrado</returns>
        Task<Usuario> BuscarUsuarioPorId(int IdUsuario);

        /// <summary>
        /// Busca um Usuario pelo seu Username
        /// </summary>
        /// <param name="Username">Username</param>
        /// <returns>Usuario encontrado</returns>
        Task<Usuario> BuscarUsuarioPorUsername(string Username);

        /// <summary>
        /// Adiciona novo usuário
        /// </summary>
        /// <param name="Usuario">Informações do usuário</param>
        /// <returns>Novo Usuário</returns>
        Task<Usuario> AdicionarUsuario(Usuario Usuario);

        /// <summary>
        /// Atualiza informações do usuário
        /// </summary>
        /// <param name="Usuario">Informações atualizadas do usuário</param>
        /// <param name="IdUsuario">Id do usuário</param>
        /// <returns>Usuário com as informações atualizadas</returns>
        Task<Usuario> AtualizarUsuario(Usuario Usuario, int IdUsuario);

        /// <summary>
        /// Apaga usuário
        /// </summary>
        /// <param name="IdUsuario">Id do usuário</param>
        /// <returns>True se apagar, Exception se não encontrar</returns>
        Task<bool> ApagarUsuario(int IdUsuario);

    }
}