using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Dtos
{
    public class SimulacaoInvestimentoRequest
    {
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public int PrazoMeses { get; set; }
        public string NomeDoProduto { get; set; }
    }

    public class ProdutoValidadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Rentabilidade { get; set; }
        public int Risco { get; set; }
    }

    public class ResultadoSimulacaoDto
    {
        public decimal ValorFinal { get; set; }
        public decimal RentabilidadeEfetiva { get; set; }
        public int PrazoMeses { get; set; }
    }

    public class SimulacaoInvestimentoResponse
    {
        public ProdutoValidadoDto ProdutoValidado { get; set; }
        public ResultadoSimulacaoDto ResultadoSimulacao { get; set; }
        public DateTime DataSimulacao { get; set; }
    }

    public class SimulacaoHistoricoResponse
    {
        public int ClienteId { get; set; }
        public IEnumerable<SimulacaoInvestimentoResponse> Simulacoes { get; set; }
    }

    // DTO de resposta para o endpoint
    public class RentabilidadeResponse
    {
        public int SimulacaoId { get; set; }
        public decimal PercentualRentabilidade { get; set; }
        public bool EhRentavel { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal RentabilidadeEfetiva { get; set; }
        public int PrazoMeses { get; set; }
        public DateTime DataSimulacao { get; set; }
    }

    public class SimulacaoPorDiaProdutoResponse
    {
        public string Produto { get; set; }
        public DateTime Data { get; set; }
        public int QuantidadeSimulacoes { get; set; }
        public decimal MediaValorFinal { get; set; }
    }
    public class SimulacaoResumoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Produto { get; set; } = string.Empty;
        public decimal ValorInvestido { get; set; }
        public decimal ValorFinal { get; set; }
        public int PrazoMeses { get; set; }
        public DateTime DataSimulacao { get; set; }
    }

}
