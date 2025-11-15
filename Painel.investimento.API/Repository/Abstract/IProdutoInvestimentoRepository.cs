using Painel.Investimento.Domain.Models;

namespace Painel.investimento.API.Repository.Abstract
{
    public interface IProdutoInvestimentoRepository
    {
        Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produto);
        Task<ProdutoInvestimento?> GetByIdAsync(int id);
        Task UpdateAsync(ProdutoInvestimento produto);
    }
}
