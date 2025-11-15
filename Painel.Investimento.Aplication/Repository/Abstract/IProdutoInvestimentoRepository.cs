using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Aplication.Repository.Abstract
{
    public interface IProdutoInvestimentoRepository
    {
        Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produto);
        Task<ProdutoInvestimento?> GetByIdAsync(int id);
        Task UpdateAsync(ProdutoInvestimento produto);
    }
}
