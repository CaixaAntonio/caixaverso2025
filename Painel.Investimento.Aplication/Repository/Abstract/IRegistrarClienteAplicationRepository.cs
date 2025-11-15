using Painel.Investimento.Domain.Dtos;

namespace Painel.Investimento.Aplication.Repository.Abstract
{
    public interface IRegistrarClienteAplicationRepository
    {
        Task AddAsync(RegistrarClienteDto input);
       
    }
}
