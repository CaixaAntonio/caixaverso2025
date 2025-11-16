using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository.Abstract;
using Painel.Investimento.Domain.Valueobjects;

namespace Painel.Investimento.Aplication.UserCases
{
    public class ClienteUseCase
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteUseCase(IClienteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> ExecuteAsync(
            int id,
            string nome,
            string sobrenome,
            Email email,
            Celular celular,
            Cpf cpf,
            DataDeNascimento dataDeNascimento,
            int perfilDeRiscoId)
        {
            var cliente = new Cliente(id, nome, sobrenome, email, celular, cpf, dataDeNascimento, perfilDeRiscoId);

            await _repository.AddAsync(cliente);
            await _unitOfWork.CommitAsync();

            return cliente;
        }

        public async Task<Cliente?> ObterPorIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Cliente>> ListarTodosAsync() => await _repository.GetAllAsync();

        public async Task<Cliente?> AtualizarPerfilAsync(int id, int novoPerfilDeRiscoId)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return null;

            cliente.AjustarPerfil(novoPerfilDeRiscoId);
            await _unitOfWork.CommitAsync();
            return cliente;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return false;

            _repository.Remove(cliente);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
