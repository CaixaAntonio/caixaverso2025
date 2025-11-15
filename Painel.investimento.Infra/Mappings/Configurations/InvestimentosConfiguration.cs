using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painel.Investimento.Domain.Models;

namespace Painel.investimento.Infra.Mappings.Configurations
{
    public class InvestimentosConfiguration : IEntityTypeConfiguration<Investimentos>
    {
        public void Configure(EntityTypeBuilder<Investimentos> builder)
        {
            builder.ToTable("Investimentos");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Produto).HasMaxLength(100).IsRequired();
            builder.Property(h => h.ValorInvestido).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(h => h.RentabilidadeEsperada).HasColumnType("decimal(5,4)").IsRequired();

            builder.HasOne(h => h.Cliente)
                   .WithMany(c => c.Investimentos)
                   .HasForeignKey(h => h.ClienteId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
