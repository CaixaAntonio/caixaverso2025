using Painel.Investimento.Domain.Models;
using Painel.investimento.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Painel.investimento.Infra.Repository.Concrete
{
    public class ProdutoInvestimentoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoInvestimentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoInvestimento> AddAsync(ProdutoInvestimento produto)
        {
            _context.ProdutosInvestimento.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoInvestimento?> GetByIdAsync(int id)
        {
            return await _context.ProdutosInvestimento
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(ProdutoInvestimento produto)
        {
            _context.ProdutosInvestimento.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
