using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Aplication.Repository.Abstract
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente?> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        void Remove(Cliente cliente);
    }
}
