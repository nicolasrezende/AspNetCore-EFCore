using AspNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.PrecoUnitario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
