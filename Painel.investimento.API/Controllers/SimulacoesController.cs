using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Painel.Investimento.Application.UseCaseInvestimentos;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Aplication.UseCaseInvestimentos;

namespace Painel.Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacoesController : ControllerBase
    {
        private readonly SimularInvestimentoUseCase _simularInvestimento;
        private readonly ConsultarHistoricoSimulacoesUseCase _consultarHistorico;
        private readonly IMapper _mapper;

        public SimulacoesController(SimularInvestimentoUseCase simularInvestimento,
                                    ConsultarHistoricoSimulacoesUseCase consultarHistorico,
                                    IMapper mapper)
        {
            _simularInvestimento = simularInvestimento;
            _consultarHistorico = consultarHistorico;
            _mapper = mapper;
        }

        [HttpPost("investimento")]
        public async Task<ActionResult<SimulacaoInvestimentoResponse>> Simular([FromBody] SimulacaoInvestimentoRequest request)
        {
            var useCaseRequest = _mapper.Map<SimulacaoInvestimentoRequest>(request);

            var useCaseResponse = await _simularInvestimento.ExecuteAsync(useCaseRequest);

            var response = _mapper.Map<SimulacaoInvestimentoResponse>(useCaseResponse);

            return Ok(response);
        }

        [HttpGet("{clienteId}")]
        public async Task<ActionResult<SimulacaoHistoricoResponse>> GetHistorico(int clienteId)
        {
            var useCaseResponse = await _consultarHistorico.ExecuteAsync(clienteId);

            if (useCaseResponse.Simulacoes == null || !useCaseResponse.Simulacoes.Any())
                return NotFound("Nenhuma simulação encontrada para este cliente.");

            var response = _mapper.Map<SimulacaoHistoricoResponse>(useCaseResponse);

            return Ok(response);
        }

        /// <summary>
        /// Endpoint que calcula a rentabilidade percentual e verifica se é rentável
        /// </summary>
        /// <param name="id">Id da simulação</param>
        /// <param name="minimoPercentual">Percentual mínimo esperado</param>
        /// <returns></returns>
        [HttpGet("{id}/rentabilidade")]
        public async Task<IActionResult> GetRentabilidade(int id, [FromQuery] decimal minimoPercentual)
        {
            try
            {
                var result = await _simularInvestimento.CalcularRentabilidadeAsync(id, minimoPercentual);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
