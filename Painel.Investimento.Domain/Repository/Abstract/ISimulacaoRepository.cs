using Painel.Investimento.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Repository.Abstract
{
    public interface ISimulacaoRepository
    {
        Task AddAsync(SimulacaoInvestimentoResponse simulacao, int clienteId);
        Task<IEnumerable<SimulacaoInvestimentoResponse>> GetByClienteIdAsync(int clienteId);
    }

}
