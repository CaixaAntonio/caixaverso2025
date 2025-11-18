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

}
