using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Dtos
{
    // DTO para entrada de dados (Request)
    public class ProdutoInvestimentoRequestDto
    {
        public string? Nome { get; set; }          // Ex: "CDB", "LCI", "Tesouro Direto"
        public string? Tipo { get; set; }          // Categoria ou sub-tipo
        public decimal? RentabilidadeAnual { get; set; } // Ex: 0.12 para 12% ao ano
        public int? Risco { get; set; }            // Pontuação para perfil (ex: Conservador = 10, Arrojado = 90)
        public string? Descricao { get; set; }
    }

    // DTO para saída de dados (Response)
    public class ProdutoInvestimentoResponseDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public decimal? RentabilidadeAnual { get; set; }
        public int? Risco { get; set; }
        public string? Descricao { get; set; }
    }
}
