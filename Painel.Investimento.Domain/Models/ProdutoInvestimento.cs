using Painel.Investimento.Domain.Repository.Abstract;
using System;

namespace Painel.Investimento.Domain.Models
{
    public class ProdutoInvestimento : IAggregateRoot
    {
        public int? Id { get; private set; }
        public string Nome { get; private set; }
        public string Tipo { get; private set; }
        public decimal RentabilidadeAnual { get; private set; }
        public int Risco { get; private set; }
        public string Descricao { get; private set; }

        private ProdutoInvestimento() { } // EF Core

        public ProdutoInvestimento(string nome, string tipo, decimal rentabilidadeAnual, int risco, string descricao)
        {
            AtualizarProdutoInvestimento(nome, tipo, rentabilidadeAnual, risco, descricao);
           
        }

        public void AtualizarProdutoInvestimento(string nome, string tipo, decimal rentabilidadeAnual, int risco, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio.");
            Nome = nome;
            if (string.IsNullOrWhiteSpace(tipo))
                throw new ArgumentException("Tipo não pode ser vazio.");
            Tipo = tipo;
            if (rentabilidadeAnual <= 0)
                throw new ArgumentException("Rentabilidade deve ser maior que zero.");
            RentabilidadeAnual = rentabilidadeAnual;
            if (risco < 1 || risco > 100)
                throw new ArgumentException("Risco deve estar entre 1 e 100.");
            Risco = risco;
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição não pode ser vazia.");
            Descricao = descricao;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new InvalidOperationException("Produto inválido: Nome obrigatório.");
            if (RentabilidadeAnual <= 0)
                throw new InvalidOperationException("Produto inválido: Rentabilidade deve ser maior que zero.");
            if (Risco < 1 || Risco > 100)
                throw new InvalidOperationException("Produto inválido: Risco deve estar entre 1 e 100.");
        }
    }
}
