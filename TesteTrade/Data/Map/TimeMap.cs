using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MeuCampeonato.Models;

namespace MeuCampeonato.Data.Map
{
    public class TimeMap : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(x => x.IdTime);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Cor).IsRequired().HasMaxLength(7);

            builder.HasOne(x => x.Usuario);
        }
    }
}