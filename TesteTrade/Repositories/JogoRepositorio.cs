using MeuCampeonato.Models;
using MeuCampeonato.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeuCampeonato.Repositories
{
    public class JogoRepositorio : IJogoRepositorio
    {
        private readonly ApplicationDbContext _dbContext;
        
        public JogoRepositorio(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Jogo> BuscarJogoPorId(int IdJogo)
        {
            return await _dbContext.Jogos
                                   .Include(x => x.Campeonato)
                                   .FirstOrDefaultAsync(x => x.IdJogo == IdJogo);
        }

        public async Task<List<Jogo>> BuscarJogosPorCampeonato(int IdCampeonato)
        {
            return (List<Jogo>)_dbContext.Jogos
                                         .Include(x => x.Campeonato)
                                         .Where(x => x.CampeonatoId == IdCampeonato);
        }

        public Task<Time> BuscarVencedorJogo(int IdJogo)
        {
            throw new NotImplementedException();
        }

        public async Task<Jogo> AdicionarJogo(Jogo Jogo)
        {
            await _dbContext.Jogos.AddAsync(Jogo);
            await _dbContext.SaveChangesAsync();
            return Jogo;
        }

        public async Task<Jogo> AtualizarJogo(Jogo Jogo, int IdJogo)
        {
            Jogo jogoQueSeraEditado = await BuscarJogoPorId(IdJogo);
            if (jogoQueSeraEditado == null)
            {
                throw new Exception("Jogo não foi encontrado.");
            }
            else
            {
                jogoQueSeraEditado.Campeonato = Jogo.Campeonato;
                jogoQueSeraEditado.ChaveDoCampeonato = Jogo.ChaveDoCampeonato;
                jogoQueSeraEditado.Gols = Jogo.Gols;
                jogoQueSeraEditado.Times = Jogo.Times;
                jogoQueSeraEditado.Vencedor = Jogo.Vencedor;

                _dbContext.Jogos.Update(jogoQueSeraEditado);
                await _dbContext.SaveChangesAsync();
                return jogoQueSeraEditado;
            }
        }

        public async Task<bool> ApagarJogo(int IdJogo)
        {
            Jogo jogoQueSeraExcluido = await BuscarJogoPorId(IdJogo);
            if (jogoQueSeraExcluido == null)
            {
                throw new Exception("Jogo não foi encontrado.");
            }
            else
            {
                _dbContext.Jogos.Remove(jogoQueSeraExcluido);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}