using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
