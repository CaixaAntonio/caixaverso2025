using Painel.investimento.Infra.Data;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.investimento.Infra.Repositorie
{
    public class ProdutoInvestimentoRepository : IProdutoInvestimentoRepository
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
    }
}
