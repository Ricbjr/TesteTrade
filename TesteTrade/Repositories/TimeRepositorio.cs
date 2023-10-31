using MeuCampeonato.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Repositories.Interfaces
{
    public class TimeRepositorio : ITimeRepositorio
    {
        private readonly ApplicationDbContext _dbContext;

        public TimeRepositorio(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        
        public async Task<Time> BuscarTimePorId(int IdTime)
        {
            return await _dbContext.Times
                                   .Include(x => x.Usuario)
                                   .FirstOrDefaultAsync(x => x.IdTime == IdTime);
        }

        public async Task<List<Time>> BuscarTimesPorUsuario(int IdUsuario)
        {
            return (List<Time>)_dbContext.Times
                                         .Include(x => x.Usuario)
                                         .Where(x => x.UsuarioId == IdUsuario);
        }

        public Task<List<Time>> BuscarTimesPorCampeonato(int IdCampeonato)
        {
            throw new NotImplementedException();
        }

        public async Task<Time> AdicionarTime(Time Time)
        {
            await _dbContext.Times.AddAsync(Time);
            await _dbContext.SaveChangesAsync();
            return Time;
        }

        public async Task<Time> AtualizarTime(Time Time, int IdTime)
        {
            Time timeQueSeraAlterado = await BuscarTimePorId(IdTime);
            if (timeQueSeraAlterado == null)
            {
                throw new Exception("Time não foi encontrado.");
            }
            else
            {
                timeQueSeraAlterado.UsuarioId = Time.UsuarioId;
                timeQueSeraAlterado.Nome = Time.Nome;
                timeQueSeraAlterado.Usuario = Time.Usuario;
                _dbContext.Times.Update(timeQueSeraAlterado);
                await _dbContext.SaveChangesAsync();
                return timeQueSeraAlterado;
            }
        }

        public async Task<bool> ApagarTime(int IdTime)
        {
            Time timeQueSeraExcluido = await BuscarTimePorId(IdTime);
            if (timeQueSeraExcluido == null)
            {
                throw new Exception("Time não foi encontrado.");
            }
            else
            {
                _dbContext.Times.Remove(timeQueSeraExcluido);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}