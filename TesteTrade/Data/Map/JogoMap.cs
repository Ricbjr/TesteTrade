using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MeuCampeonato.Models;
using System.Diagnostics.Eventing.Reader;

namespace MeuCampeonato.Data.Map
{
    public class JogoMap : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(x => x.IdJogo);
            builder.Property(x => x.CampeonatoId).IsRequired();
            builder.Property(x => x.ChaveDoCampeonato).IsRequired();
            builder.Property(x => x.Times).IsRequired();
            builder.Property(x => x.Vencedor);

            builder.HasOne(x => x.Campeonato);
            builder.HasMany(x => x.Times);
        }
    }
}