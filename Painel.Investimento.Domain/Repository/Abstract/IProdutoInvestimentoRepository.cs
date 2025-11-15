using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Repository.Abstract
{
    public interface IProdutoInvestimentoRepository
    {
        Task AddAsync(ProdutoInvestimento produto);
        Task<ProdutoInvestimento?> GetByIdAsync(int id);
        Task<IEnumerable<ProdutoInvestimento>> GetAllAsync();
        void Remove(ProdutoInvestimento produto);
    }

}
