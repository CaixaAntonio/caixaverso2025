using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Application.UserCases
{
    public class InvestimentosUseCase
    {
        private readonly IInvestimentosRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoInvestimentoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvestimentosUseCase(
            IInvestimentosRepository repository,
            IClienteRepository clienteRepository,
            IProdutoInvestimentoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        // ✅ Registrar novo investimento
        public async Task<Investimentos?> RegistrarAsync(
            int clienteId,
            int produtoInvestimentoId,
            decimal valorInvestido,
            DateTime dataInvestimento,
            int? prazoMeses,
            int? risco)
        {
            // Valida cliente
            var cliente = await _clienteRepository.ObterPorIdAsync(clienteId);
            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado.", nameof(clienteId));

            // Valida produto
            var produto = await _produtoRepository.ObterPorIdAsync(produtoInvestimentoId);
            if (produto == null)
                throw new ArgumentException("Produto de investimento não encontrado.", nameof(produtoInvestimentoId));

            // Cria entidade
            var investimento = new Investimentos(clienteId, produtoInvestimentoId, valorInvestido, dataInvestimento, prazoMeses, risco);

            await _repository.AdicionarAsync(investimento);
            await _unitOfWork.CommitAsync();

            return investimento;
        }

        // ✅ Obter investimento por Id
        public async Task<Investimentos?> ObterPorIdAsync(int id) => await _repository.ObterPorIdAsync(id);

        // ✅ Listar todos os investimentos de um cliente
        public async Task<IEnumerable<Investimentos>> ListarPorClienteAsync(int clienteId) =>
            await _repository.ObterPorClienteAsync(clienteId);

        // ✅ Atualizar investimento (exemplo: valor ou prazo)
        public async Task<Investimentos?> AtualizarAsync(int id, decimal? novoValor, int? novoPrazoMeses, int? novoRisco)
        {
            var investimento = await _repository.ObterPorIdAsync(id);
            if (investimento == null) return null;

            if (novoValor.HasValue && novoValor.Value > 0)
                investimento.GetType().GetProperty("ValorInvestido")?.SetValue(investimento, novoValor);

            if (novoPrazoMeses.HasValue)
                investimento.GetType().GetProperty("PrazoMeses")?.SetValue(investimento, novoPrazoMeses);

            if (novoRisco.HasValue)
                investimento.GetType().GetProperty("Risco")?.SetValue(investimento, novoRisco);

            await _unitOfWork.CommitAsync();
            return investimento;
        }

        // ✅ Remover investimento
        public async Task<bool> RemoverAsync(int id)
        {
            var investimento = await _repository.ObterPorIdAsync(id);
            if (investimento == null) return false;

            _repository.RemoverAsync(id);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
