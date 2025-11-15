using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Repository
{
    public interface IProdutoInvestimentoRepository
    {
        Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produto);
    }
}
