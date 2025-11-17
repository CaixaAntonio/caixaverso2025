using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Repositories;
using Painel.Investimento.Domain.Repository.Abstract;
using Painel.Investimento.Domain.Services;

namespace Painel.Investimento.Aplication.UseCaseInvestimentos
{
    public class CalcularPerfilDeRiscoUseCase
    {
        private readonly IInvestimentosRepository _investimentoRepo;
        private readonly IPerfilDeRiscoRepository _perfilRepo;
        private readonly IRiskProfileService _riskService;
        public CalcularPerfilDeRiscoUseCase(
            IInvestimentosRepository investimentoRepo,
            IPerfilDeRiscoRepository perfilRepo,
            IRiskProfileService riskService)
        {
            _investimentoRepo = investimentoRepo;
            _perfilRepo = perfilRepo;
            _riskService = riskService;
        }

        public async Task<PerfilDeRisco> ExecuteAsync(int clienteId)
        {
            // 1. Buscar os investimentos do cliente
            var investimentos = await _investimentoRepo.ObterPorClienteAsync(clienteId);

            // 2. Calcular pontuação com base nos investimentos
            int pontuacao = CalcularPontuacao(investimentos);

            // 3. Buscar perfis disponíveis
            var perfis = await _perfilRepo.GetAllAsync();

            // 4. Determinar perfil correspondente
            var perfil = _riskService.DeterminarPerfil(pontuacao, perfis);

            return perfil;
        }

        private int CalcularPontuacao(IEnumerable<Investimentos> investimentos)
        {
            int score = 0;

            foreach (var inv in investimentos)
            {
                // Peso pelo valor investido
                if (inv.ValorInvestido.HasValue)
                {
                    if (inv.ValorInvestido.Value >= 1000) score += 20;
                    else if (inv.ValorInvestido.Value >= 500) score += 10;
                }

                // Peso pelo prazo
                if (inv.PrazoMeses.HasValue)
                {
                    if (inv.PrazoMeses.Value >= 24) score += 15;
                    else if (inv.PrazoMeses.Value >= 12) score += 10;
                }

                // Peso pelo risco do produto
               
            }

            return score;
        }



    }
}
