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
        Task<ProdutoInvestimento?> ObterPorIdAsync(int id);
        Task<IEnumerable<ProdutoInvestimento>> GetAllAsync();
        Task<ProdutoInvestimento?> GetByTipoAsync(string tipoProduto);
        void Remove(ProdutoInvestimento produto);
    }

}
