using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Painel.Investimento.Aplication.UseCaseInvestimentos;
using Painel.Investimento.Application.DTOs;
using Painel.Investimento.Domain.Models;

namespace Painel.Investimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentosController : ControllerBase
    {
        private readonly InvestimentosUseCase _useCase;
        private readonly IMapper _mapper;

        public InvestimentosController(InvestimentosUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        // ✅ Registrar novo investimento
        [HttpPost]
        public async Task<ActionResult<InvestimentoDto>> Post([FromBody] CreateInvestimentoDto dto)
        {
            var investimento = await _useCase.RegistrarAsync(
                dto.ClienteId,
                dto.ProdutoInvestimentoId,
                dto.ValorInvestido,
                dto.DataInvestimento,
                dto.PrazoMeses
            );

            if (investimento == null)
                return BadRequest("Não foi possível registrar o investimento.");

            var investimentoDto = _mapper.Map<InvestimentoDto>(investimento);
            return CreatedAtAction(nameof(GetById), new { id = investimentoDto.Id }, investimentoDto);
        }

        // ✅ Registrar retirada
        [HttpPost("retir-investimento")]
        public async Task<ActionResult<InvestimentoDto>> RetiraInvestimento([FromBody] RetiradaInvestimentoDto dto)
        {
            var investimento = await _useCase.RetirarInvestimentoAsync(
                dto.ClienteId,
                dto.ProdutoInvestimentoId,
                dto.ValorInvestido,
                 dto.DataInvestimento,
                 dto.PrazoMeses,
                dto.ValorRetirado ?? 0,                             
                dto.Crise                
            );
            
            if (investimento == null)
                return BadRequest("Não há investimentos para retirada.");

            var investimentoDto = _mapper.Map<RetiradaInvestimentoDto>(investimento);
            return CreatedAtAction(nameof(GetById), new { id = investimentoDto.ClienteId }, investimentoDto);
        }

        // ✅ Obter investimento por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<InvestimentoDto>> GetById(int id)
        {
            var investimento = await _useCase.ObterPorIdAsync(id);
            if (investimento == null)
                return NotFound();

            return Ok(_mapper.Map<InvestimentoDto>(investimento));
        }

        // ✅ Listar investimentos de um cliente
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<InvestimentoDto>>> GetByCliente(int clienteId)
        {
            var investimentos = await _useCase.ListarPorClienteAsync(clienteId);
            return Ok(_mapper.Map<IEnumerable<InvestimentoDto>>(investimentos));
        }

        // ✅ Atualizar investimento
        [HttpPut("{id}")]
        public async Task<ActionResult<InvestimentoDto>> Put(int id, [FromBody] InvestimentoDto dto)
        {
            var investimento = await _useCase.AtualizarAsync(id, dto.ValorInvestido, dto.PrazoMeses);
            if (investimento == null)
                return NotFound();

            return Ok(_mapper.Map<InvestimentoDto>(investimento));
        }

        // ✅ Remover investimento
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removido = await _useCase.RemoverAsync(id);
            if (!removido)
                return NotFound();

            return NoContent();
        }
    }
}
