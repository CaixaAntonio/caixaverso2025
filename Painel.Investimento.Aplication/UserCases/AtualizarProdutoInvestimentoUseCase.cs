using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Aplication.UserCases
{
    public class AtualizarProdutoInvestimentoUseCase
    {
        private readonly IProdutoInvestimentoRepository _repository;

        public AtualizarProdutoInvestimentoUseCase(IProdutoInvestimentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoInvestimento?> ExecuteAsync(int id, string nome, string tipo, decimal rentabilidadeAnual, int risco, string descricao)
        {
            var produtoExistente = await _repository.GetByIdAsync(id);

            if (produtoExistente == null)
                throw new ArgumentException("Produto não encontrado.");

            // Atualiza os campos via reflexão ou métodos internos
            var produtoAtualizado = new ProdutoInvestimento(nome, tipo, rentabilidadeAnual, risco, descricao);

            // Hack simples: recriar objeto e manter o mesmo Id
            typeof(ProdutoInvestimento)
                .GetProperty(nameof(ProdutoInvestimento.Id))?
                .SetValue(produtoAtualizado, id);

            await _repository.UpdateAsync(produtoAtualizado);

            return produtoAtualizado;
        }
    }
}
