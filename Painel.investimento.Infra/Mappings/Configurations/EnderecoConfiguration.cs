using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.investimento.Infra.Mappings.Configurations
{

    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro).HasMaxLength(150).IsRequired();
            builder.Property(e => e.Numero).HasMaxLength(10);
            builder.Property(e => e.Complemento).HasMaxLength(50);
            builder.Property(e => e.Bairro).HasMaxLength(100);
            builder.Property(e => e.Cidade).HasMaxLength(100);           
           
            builder.OwnsOne(e => e.Estado, uf =>
            {
                uf.Property(u => u.Sigla).HasColumnName("EstadoSigla").HasMaxLength(2).IsRequired();
                uf.Property(u => u.Nome).HasColumnName("EstadoNome").HasMaxLength(50).IsRequired();
            });
            
            builder.OwnsOne(e => e.Cep, cep =>
            {
                cep.Property(c => c.Valor).HasColumnName("Cep").HasMaxLength(8).IsRequired();
            });
        }

    }

}


    


