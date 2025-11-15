using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Aplication.UserCases
{
    public class CadastrarProdutoInvestimentoUseCase
    {
        private readonly IProdutoInvestimentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarProdutoInvestimentoUseCase(IProdutoInvestimentoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoInvestimento> ExecuteAsync(string nome, string tipo, decimal? rentabilidadeAnual, int? risco, string descricao)
        {
            var produto = new ProdutoInvestimento(nome, tipo, rentabilidadeAnual, risco, descricao);

            await _repository.AddAsync(produto);
            await _unitOfWork.CommitAsync();

            return produto;
        }
    }
}
