using Painel.Investimento.Domain.Dtos;

namespace Painel.investimento.Infra.Repository.Abstract
{
    public interface IRegistrarClienteAplicationRepository
    {
        Task AddAsync(RegistrarClienteDto input);

    }
}
