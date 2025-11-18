using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Repository.Abstract
{
    public interface ISimulacaoRepository
    {
        Task AddAsync(Simulacao simulacao);
        Task<IEnumerable<SimulacaoInvestimentoResponse>> GetByClienteIdAsync(int clienteId);
        Task<Simulacao?> GetByIdAsync(int id);
    }

}
