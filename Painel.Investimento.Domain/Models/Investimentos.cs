namespace Painel.Investimento.Domain.Models
{
    public class Investimentos
    {
        public int Id { get; private set; }
        public int? ClienteId { get; private set; }
        public Cliente? Cliente { get; private set; }
        public string? Produto { get; private set; } // Ex: CDB, LCI, Tesouro Direto
        public decimal? ValorInvestido { get; private set; }
        public DateTime? DataInvestimento { get; private set; }
        public int? PrazoMeses { get; private set; }
        public decimal? RentabilidadeEsperada { get; private set; } // Ex: 0.12 para 12% ao ano
        public int? Risco { get; private set; } // Pontuação para cálculo do perfil

        private Investimentos() { } // Necessário para EF Core

        public Investimentos(int clienteId, string? produto, decimal? valorInvestido, DateTime dataInvestimento,
                                      int? prazoMeses, decimal? rentabilidadeEsperada, int? risco)
        {
            if (string.IsNullOrWhiteSpace(produto))
                throw new ArgumentException("Produto não pode ser vazio.", nameof(produto));

            if (valorInvestido <= 0)
                throw new ArgumentException("Valor investido deve ser maior que zero.", nameof(valorInvestido));

            ClienteId = clienteId;
            Produto = produto;
            ValorInvestido = valorInvestido;
            DataInvestimento = dataInvestimento;
            PrazoMeses = prazoMeses;
            RentabilidadeEsperada = rentabilidadeEsperada;
            Risco = risco;
        }

        public decimal CalcularValorFinal()
        {
            // Exemplo simples: juros compostos
            //double taxaMensal = (double)RentabilidadeEsperada / 12;
            //return ValorInvestido * (decimal)Math.Pow(1 + taxaMensal, (double)PrazoMeses);

            return 10;
        }
    }
}
