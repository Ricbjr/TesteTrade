using MeuCampeonato.Data.Map;
using MeuCampeonato.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    //DbSets de entidades
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Time> Times { get; set; }
    public DbSet<Campeonato> Campeonatos { get; set; }
    public DbSet<Jogo> Jogos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TimeMap());
        modelBuilder.ApplyConfiguration(new CampeonatoMap());
        modelBuilder.ApplyConfiguration(new JogoMap());
        base.OnModelCreating(modelBuilder);
    }
}