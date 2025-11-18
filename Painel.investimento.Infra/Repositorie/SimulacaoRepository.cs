using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Infra.Repositories
{
    public class SimulacaoRepository : ISimulacaoRepository
    {
        // Armazenamento em memória
        private static readonly Dictionary<int, List<SimulacaoInvestimentoResponse>> _simulacoes
            = new Dictionary<int, List<SimulacaoInvestimentoResponse>>();

        public Task AddAsync(SimulacaoInvestimentoResponse simulacao, int clienteId)
        {
            if (!_simulacoes.ContainsKey(clienteId))
                _simulacoes[clienteId] = new List<SimulacaoInvestimentoResponse>();

            _simulacoes[clienteId].Add(simulacao);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<SimulacaoInvestimentoResponse>> GetByClienteIdAsync(int clienteId)
        {
            if (_simulacoes.ContainsKey(clienteId))
                return Task.FromResult(_simulacoes[clienteId].AsEnumerable());

            return Task.FromResult(Enumerable.Empty<SimulacaoInvestimentoResponse>());
        }
    }
}
