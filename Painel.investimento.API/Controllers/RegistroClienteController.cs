using Microsoft.AspNetCore.Mvc;
using Painel.investimento.API.Repository.Abstract;
using Painel.investimento.API.Services;
using Painel.Investimento.Domain.Dtos;


namespace Painel.investimento.API.Controllers
{
    [Route("api/registros")]
    [ApiController]
    public class RegistroClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public RegistroClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RegistrarClienteDto request)
        {
            await _clienteService.AddAsync(request);
            
            return Ok("Sucesso ao criar Cliente."); 
        }

    }
}
