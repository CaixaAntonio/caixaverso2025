using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.investimento.Infra.Mappings.Configurations
{
    public class ProdutoInvestimentoConfiguration : IEntityTypeConfiguration<ProdutoInvestimento>
    {
        public void Configure(EntityTypeBuilder<ProdutoInvestimento> builder)
        {
            builder.ToTable("ProdutoInvestimento");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Tipo).HasMaxLength(50).IsRequired();
            builder.Property(p => p.RentabilidadeAnual).HasColumnType("decimal(18,4)").IsRequired();
            builder.Property(p => p.Risco).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(250);
        }
    }
}
