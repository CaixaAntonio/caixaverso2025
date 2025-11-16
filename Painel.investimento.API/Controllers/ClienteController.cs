using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Painel.Investimento.Aplication.UserCases;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Valueobjects;

namespace Painel.Investimento.API.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteUseCase _useCase;
        private readonly IMapper _mapper;

        public ClienteController(ClienteUseCase useCase, IMapper mapper)
        {
            _useCase = useCase;
            _mapper = mapper;
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteRequestDto dto)
        {
            var email = new Email(dto.Email);
            var celular = new Celular(dto.Celular);
            var cpf = new Cpf(dto.Cpf);
            var dataNascimento = new DataDeNascimento(dto.DataDeNascimento);

            var cliente = await _useCase.ExecuteAsync(
                dto.Id,
                dto.Nome,
                dto.Sobrenome,
                email,
                celular,
                cpf,
                dataNascimento,
                dto.PerfilDeRiscoId
            );

            var response = _mapper.Map<ClienteResponseDto>(cliente);
            return Ok(response);
        }

        // GET: api/cliente/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _useCase.ObterPorIdAsync(id);
            if (cliente == null) return NotFound();

            var response = _mapper.Map<ClienteResponseDto>(cliente);
            return Ok(response);
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _useCase.ListarTodosAsync();
            var response = _mapper.Map<IEnumerable<ClienteResponseDto>>(clientes);
            return Ok(response);
        }

        // PUT: api/cliente/{id}/perfil
        [HttpPut("{id:int}/perfil")]
        public async Task<IActionResult> AtualizarPerfil(int id, [FromBody] PerfilDeRiscoRequestDto dto)
        {
            var clienteAtualizado = await _useCase.AtualizarPerfilAsync(id, dto.Id);
            if (clienteAtualizado == null) return NotFound();

            var response = _mapper.Map<ClienteResponseDto>(clienteAtualizado);
            return Ok(response);
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removido = await _useCase.RemoverAsync(id);
            if (!removido) return NotFound();

            return NoContent();
        }
    }
}
