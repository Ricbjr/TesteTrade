using MeuCampeonato.Models;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioRepositorio(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Usuario> BuscarUsuarioPorId(int IdUsuario)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
        }

        public async Task<Usuario> BuscarUsuarioPorUsername(string Username)
        {
            if(Username == "") 
                throw new ArgumentNullException(nameof(Username));
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Username == Username);
        }

        public async Task<Usuario> AdicionarUsuario(Usuario Usuario)
        {
            await _dbContext.Usuarios.AddAsync(Usuario);
            await _dbContext.SaveChangesAsync();
            return Usuario;
        }
        public async Task<Usuario> AtualizarUsuario(Usuario Usuario, int IdUsuario)
        {
            Usuario usuarioQueSeraEditado = await BuscarUsuarioPorId(IdUsuario);
            if(usuarioQueSeraEditado == null)
            {
                throw new Exception($"Usuário não foi encontrado.");
            }
            else
            {
                usuarioQueSeraEditado.Username = Usuario.Username;
                usuarioQueSeraEditado.Senha = Usuario.Senha;

                _dbContext.Usuarios.Update(usuarioQueSeraEditado);
                await _dbContext.SaveChangesAsync();
                return usuarioQueSeraEditado;
            }
        }

        public async Task<bool> ApagarUsuario(int IdUsuario)
        {
            Usuario usuarioQueSeraExcluido = await BuscarUsuarioPorId(IdUsuario);
            if (usuarioQueSeraExcluido == null)
            {
                throw new Exception("Usuário não foi encontrado.");
            }
            else
            {
                _dbContext.Usuarios.Remove(usuarioQueSeraExcluido);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        
    }
}