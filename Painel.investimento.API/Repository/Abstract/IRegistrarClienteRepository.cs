using Painel.Investimento.Domain.Dtos;


namespace Painel.investimento.API.Repository.Abstract
{
    public interface IRegistrarClienteRepository
    {
        Task AddAsync(RegistrarClienteDto input);
    }
}
