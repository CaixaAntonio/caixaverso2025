using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Repository.Abstract;

namespace Painel.Investimento.Application.UseCaseInvestimentos
{
    public class SimularInvestimentoUseCase
    {
        private readonly IProdutoInvestimentoRepository _produtoRepo;

        public SimularInvestimentoUseCase(IProdutoInvestimentoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }

        public async Task<SimulacaoInvestimentoResponse> ExecuteAsync(SimulacaoInvestimentoRequest request)
        {
            // 1. Buscar produto pelo tipo
            var produto = await _produtoRepo.GetByTipoAsync(request.NomeDoProduto);
            if (produto == null)
                throw new InvalidOperationException("Produto de investimento não encontrado.");

            produto.Validar();

            decimal valorFinal = 0;
            decimal rentabilidadeEfetiva = 0;

            // 2. Calcular valor final conforme tipo de produto
            switch (produto.Tipo.ToLower())
            {
                case "poupança":
                    // regra simplificada: ~0,5% ao mês
                    decimal taxaPoupanca = 0.005m;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaPoupanca), request.PrazoMeses);
                    break;

                case "cdb":
                case "lci":
                case "lca":
                    // juros compostos com base na rentabilidade anual
                    decimal taxaMensalCdb = produto.RentabilidadeAnual / 12 / 100;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaMensalCdb), request.PrazoMeses);

                    // tributação regressiva (simplificada: 15% sobre ganho)
                    decimal ganhoCdb = valorFinal - request.Valor;
                    valorFinal -= ganhoCdb * 0.15m;
                    break;

                case "fundos renda fixa":
                    decimal taxaMensalRF = produto.RentabilidadeAnual / 12 / 100;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaMensalRF), request.PrazoMeses);
                    // tributação simplificada: 20% sobre ganho
                    decimal ganhoRF = valorFinal - request.Valor;
                    valorFinal -= ganhoRF * 0.20m;
                    break;

                case "fundos multimercado":
                    decimal taxaMensalMM = produto.RentabilidadeAnual / 12 / 100;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaMensalMM), request.PrazoMeses);
                    // tributação simplificada: 20% sobre ganho
                    decimal ganhoMM = valorFinal - request.Valor;
                    valorFinal -= ganhoMM * 0.20m;
                    break;

                case "fundos de ações":
                case "ações":
                case "home broker caixa":
                    decimal taxaMensalAcoes = produto.RentabilidadeAnual / 12 / 100;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaMensalAcoes), request.PrazoMeses);
                    // tributação simplificada: 15% sobre ganho
                    decimal ganhoAcoes = valorFinal - request.Valor;
                    valorFinal -= ganhoAcoes * 0.15m;
                    break;

                default:
                    // fallback: juros compostos padrão
                    decimal taxaMensal = produto.RentabilidadeAnual / 12 / 100;
                    valorFinal = request.Valor * (decimal)Math.Pow((double)(1 + taxaMensal), request.PrazoMeses);
                    break;
            }

            // 3. Rentabilidade efetiva
            rentabilidadeEfetiva = valorFinal - request.Valor;

            // 4. Montar response
            return new SimulacaoInvestimentoResponse
            {
                ProdutoValidado = new ProdutoValidadoDto
                {
                    Id = produto.Id ?? 0,
                    Nome = produto.Nome,
                    Tipo = produto.Tipo,
                    Rentabilidade = produto.RentabilidadeAnual,
                    Risco = produto.Risco
                },
                ResultadoSimulacao = new ResultadoSimulacaoDto
                {
                    ValorFinal = valorFinal,
                    RentabilidadeEfetiva = rentabilidadeEfetiva,
                    PrazoMeses = request.PrazoMeses
                },
                DataSimulacao = DateTime.UtcNow
            };
        }

    }
}
