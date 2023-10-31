using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MeuCampeonato.Models;

namespace MeuCampeonato.Data.Map
{
    public class CampeonatoMap : IEntityTypeConfiguration<Campeonato>
    {
        public void Configure(EntityTypeBuilder<Campeonato> builder)
        {
            builder.HasKey(x => x.IdCampeonato);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.Jogos).IsRequired();
            builder.Property(x => x.Times).IsRequired();

            builder.HasOne(x => x.Usuario);
            
            builder.HasMany(x => x.Jogos)
                   .WithOne(jogo => jogo.Campeonato)
                   .HasForeignKey(jogo => jogo.CampeonatoId);

            builder.HasMany(x => x.Times);
        }
    }
}