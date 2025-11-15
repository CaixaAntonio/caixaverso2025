using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository;

namespace Painel.Investimento.Aplication.UserCases
{
    public class CadastrarProdutoInvestimentoUseCase
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public CadastrarProdutoInvestimentoUseCase(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoInvestimento> ExecuteAsync(string nome, string tipo, decimal? rentabilidadeAnual, int? risco, string descricao)
        {
            var produto = new ProdutoInvestimento(nome, tipo, rentabilidadeAnual, risco, descricao);
            return await _repository.AddAsync(produto);
        }
    }
}
