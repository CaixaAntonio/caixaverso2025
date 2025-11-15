using Painel.Investimento.Domain.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Models
{
    public class ProdutoInvestimento : IAggregateRoot
    {
        public int? Id { get; private set; }
        public string? Nome { get; private set; } // Ex: "CDB", "LCI", "Tesouro Direto"
        public string? Tipo { get; private set; } // Categoria ou sub-tipo
        public decimal? RentabilidadeAnual { get; private set; } // Ex: 0.12 para 12% ao ano
        public int? Risco { get; private set; } // Pontuação para perfil (ex: Conservador = 10, Arrojado = 90)
        public string? Descricao { get; private set; }

        private ProdutoInvestimento() { } // Necessário para EF Core

        public ProdutoInvestimento(string? nome, string? tipo, decimal? rentabilidadeAnual, int? risco, string? descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(nome));

            if (rentabilidadeAnual <= 0)
                throw new ArgumentException("Rentabilidade deve ser maior que zero.", nameof(rentabilidadeAnual));

            Nome = nome;
            Tipo = tipo;
            RentabilidadeAnual = rentabilidadeAnual;
            Risco = risco;
            Descricao = descricao;
        }
    }
}
