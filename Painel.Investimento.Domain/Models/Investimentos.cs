namespace Painel.Investimento.Domain.Models
{
    public class Investimentos
    {
        public int Id { get; private set; }

        public int? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }        
        public int ProdutoInvestimentoId { get; private set; }
        public ProdutoInvestimento? ProdutoInvestimento { get; private set; }
        public decimal? ValorInvestido { get; private set; }
        public DateTime? DataInvestimento { get; private set; }
        public int? PrazoMeses { get; private set; }       
        public int? Risco { get; private set; } // Pontuação para cálculo do perfil

        private Investimentos() { } 

        public Investimentos(int clienteId, int produtoInvestimentoId, decimal? valorInvestido, DateTime dataInvestimento,
                             int? prazoMeses, int? risco)
        {
            if (produtoInvestimentoId <= 0)
                throw new ArgumentException("Produto de investimento inválido.", nameof(produtoInvestimentoId));

            if (valorInvestido <= 0)
                throw new ArgumentException("Valor investido deve ser maior que zero.", nameof(valorInvestido));

            ClienteId = clienteId;
            ProdutoInvestimentoId = produtoInvestimentoId;
            ValorInvestido = valorInvestido;
            DataInvestimento = dataInvestimento;
            PrazoMeses = prazoMeses;
            Risco = risco;
        }

        public decimal CalcularValorFinal()
        {
            // ⚠️ Como RentabilidadeEsperada foi removida, 
            // esse cálculo deve ser ajustado futuramente para usar dados do ProdutoInvestimento.
            return ValorInvestido ?? 0;
        }
    }
}
