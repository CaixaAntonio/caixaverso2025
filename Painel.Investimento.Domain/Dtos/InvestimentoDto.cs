namespace Painel.Investimento.Application.DTOs
{
    public class InvestimentoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string? NomeCliente { get; set; }
        public int ProdutoInvestimentoId { get; set; }
        public string? NomeProduto { get; set; }
        public decimal? ValorInvestido { get; set; }
        public DateTime? DataInvestimento { get; set; }
        public int? PrazoMeses { get; set; }
        public int? Risco { get; set; }
    }

    public class CreateInvestimentoDto
    {
        public int ClienteId { get; set; }
        public int ProdutoInvestimentoId { get; set; }
        public decimal ValorInvestido { get; set; }
        public DateTime DataInvestimento { get; set; }
        public int? PrazoMeses { get; set; }
        public int? Risco { get; set; }
    }
}
