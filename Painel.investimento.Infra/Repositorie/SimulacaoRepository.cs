using Microsoft.EntityFrameworkCore;
using Painel.investimento.Infra.Data;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Infra.Repositories
{
    public class SimulacaoRepository : ISimulacaoRepository
    {
        private readonly AppDbContext _context;

        public SimulacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Simulacao simulacao)
        {
            await _context.Simulacoes.AddAsync(simulacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SimulacaoInvestimentoResponse>> GetByClienteIdAsync(int clienteId)
        {
            var simulacoes = await _context.Simulacoes
                                           .Where(s => s.ClienteId == clienteId)
                                           .ToListAsync();

            // Mapeia de entidade para DTO
            return simulacoes.Select(s => new SimulacaoInvestimentoResponse
            {
                ProdutoValidado = new ProdutoValidadoDto
                {
                    Id = 0, // se não tiver FK para ProdutoInvestimento
                    Nome = s.NomeProduto,
                    Tipo = "", // pode ser preenchido se houver relacionamento
                    Rentabilidade = 0,
                    Risco = 0
                },
                ResultadoSimulacao = new ResultadoSimulacaoDto
                {
                    ValorFinal = s.ValorFinal,
                    RentabilidadeEfetiva = s.RentabilidadeEfetiva,
                    PrazoMeses = s.PrazoMeses
                },
                DataSimulacao = s.DataSimulacao
            });
        }
    }
}
