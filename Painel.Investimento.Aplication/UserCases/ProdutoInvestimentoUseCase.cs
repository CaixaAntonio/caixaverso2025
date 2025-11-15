using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Aplication.UserCases
{
    public class ProdutoInvestimentoUseCase
    {
        private readonly IProdutoInvestimentoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoInvestimentoUseCase(IProdutoInvestimentoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProdutoInvestimento> ExecuteAsync(string nome, string tipo, decimal rentabilidadeAnual, int risco, string descricao)
        {
            var produto = new ProdutoInvestimento(nome, tipo, rentabilidadeAnual, risco, descricao);

            await _repository.AddAsync(produto);
            await _unitOfWork.CommitAsync();

            return produto;
        }

        public async Task<ProdutoInvestimento?> ObterPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProdutoInvestimento>> ListarTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ProdutoInvestimento?> AtualizarAsync(int id, string nome, string tipo, decimal? rentabilidadeAnual, int? risco, string descricao)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return null;

            produto.AtualizarProdutoInvestimento(nome, tipo, rentabilidadeAnual ?? produto.RentabilidadeAnual, risco ?? produto.Risco, descricao);
            // aqui você pode criar outros métodos na entidade para atualizar nome, tipo, risco etc.

            await _unitOfWork.CommitAsync();
            return produto;
        }

       

        public async Task<bool> RemoverAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null) return false;

            _repository.Remove(produto);
            await _unitOfWork.CommitAsync();
            return true;
        }




    }
}
