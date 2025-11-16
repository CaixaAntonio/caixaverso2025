using Microsoft.EntityFrameworkCore;
using Painel.investimento.Infra.Mappings.Configurations;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Infra.Configurations;

namespace Painel.investimento.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<PerfilDeRisco> PerfisDeRisco { get; set; }
        public DbSet<Investimentos> Investimentos { get; set; }
        public DbSet<ProdutoInvestimento> ProdutosInvestimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilDeRiscoConfiguration());
            modelBuilder.ApplyConfiguration(new InvestimentosConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoInvestimentoConfiguration());
        }

    }
}
