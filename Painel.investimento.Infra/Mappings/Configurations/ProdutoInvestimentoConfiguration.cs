using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Painel.Investimento.Domain.Models;

namespace Painel.Investimento.Infra.Configurations
{
    public class ProdutoInvestimentoConfiguration : IEntityTypeConfiguration<ProdutoInvestimento>
    {
        public void Configure(EntityTypeBuilder<ProdutoInvestimento> builder)
        {
            builder.ToTable("ProdutoInvestimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(p => p.TipoPerfil)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.RentabilidadeAnual)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.Risco)
                   .IsRequired(); // int, escala 1–100

            builder.Property(p => p.Liquidez)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(p => p.Tributacao)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Garantia)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.Descricao)
                   .HasMaxLength(500)
                   .IsRequired();
        }
    }
}
