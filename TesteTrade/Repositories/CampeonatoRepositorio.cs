using MeuCampeonato.Models;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Repositories
{
    public class CampeonatoRepositorio : ICampeonatoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        
        public CampeonatoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Campeonato> BuscarCampeonatoPorId(int IdCampeonato)
        {
            return await _dbContext.Campeonatos
                                   .Include(x => x.Usuario)
                                   .Include(x => x.Times)
                                   .Include(x => x.Jogos)
                                   .FirstOrDefaultAsync(x => x.IdCampeonato == IdCampeonato);
        }

        public async Task<List<Campeonato>> BuscarCampeonatosPorUsuario(int IdUsuario)
        {
            return (List<Campeonato>)_dbContext.Campeonatos
                                               .Include(x => x.Usuario)
                                               .Include(x => x.Times)
                                               .Include(x => x.Jogos)
                                               .Where(x => x.UsuarioId == IdUsuario);
        }

        public Task<Time> BuscarVencedorCampeonato(int IdCampeonato)
        {
            throw new NotImplementedException();
        }

        public async Task<Campeonato> AdicionarCampeonato(Campeonato Campeonato)
        {
            await _dbContext.Campeonatos.AddAsync(Campeonato);
            await _dbContext.SaveChangesAsync();
            return Campeonato;
        }

        public async Task<Campeonato> AtualizarCampeonato(Campeonato Campeonato, int idCampeonato)
        {
            Campeonato campeonatoQueSeraEditado = await BuscarCampeonatoPorId(idCampeonato);
            if (campeonatoQueSeraEditado == null)
            {
                throw new Exception("Campeonato não foi encontrado.");
            }
            else
            {
                campeonatoQueSeraEditado.Usuario = Campeonato.Usuario;
                campeonatoQueSeraEditado.Times = Campeonato.Times;
                campeonatoQueSeraEditado.Jogos = Campeonato.Jogos;

                _dbContext.Campeonatos.Update(campeonatoQueSeraEditado);
                await _dbContext.SaveChangesAsync();
                return campeonatoQueSeraEditado;
            }
        }

        public async Task<bool> ApagarCampeonato(int IdCampeonato)
        {
            Campeonato campeonatoQueSeraExcluido = await BuscarCampeonatoPorId(IdCampeonato);
            if (campeonatoQueSeraExcluido == null)
            {
                throw new Exception("Campeonato não foi encontrado.");
            }
            else
            {
                _dbContext.Campeonatos.Remove(campeonatoQueSeraExcluido);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        
    }
}