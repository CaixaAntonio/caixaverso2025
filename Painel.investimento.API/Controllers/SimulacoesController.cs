using Microsoft.AspNetCore.Mvc;
using Painel.Investimento.Aplication.UseCaseInvestimentos;
using Painel.Investimento.Application.UseCaseInvestimentos;
using Painel.Investimento.Domain.Dtos;

namespace Painel.Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacoesController : ControllerBase
    {
        private readonly SimularInvestimentoUseCase _simularInvestimento;
        private readonly ConsultarHistoricoSimulacoesUseCase _consultarHistorico;

        public SimulacoesController(SimularInvestimentoUseCase simularInvestimento,
                                    ConsultarHistoricoSimulacoesUseCase consultarHistorico)
        {
            _simularInvestimento = simularInvestimento;
            _consultarHistorico = consultarHistorico;
        }

        [HttpPost("investimento")]
        public async Task<ActionResult<SimulacaoInvestimentoResponse>> Simular([FromBody] SimulacaoInvestimentoRequest request)
        {
            var response = await _simularInvestimento.ExecuteAsync(request);
            // salvar no repositório de histórico
            // await _simulacaoRepo.AddAsync(response, request.ClienteId);
            return Ok(response);
        }

        [HttpGet("{clienteId}")]
        public async Task<ActionResult<SimulacaoHistoricoResponse>> GetHistorico(int clienteId)
        {
            var response = await _consultarHistorico.ExecuteAsync(clienteId);
            if (response.Simulacoes == null || !response.Simulacoes.Any())
                return NotFound("Nenhuma simulação encontrada para este cliente.");

            return Ok(response);
        }
    }

}
