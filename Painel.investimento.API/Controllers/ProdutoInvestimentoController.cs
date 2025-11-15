using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Painel.Investimento.Aplication.UserCases;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;

namespace Painel.investimento.API.Controllers
{
    [Route("api/produtoinvestimento")]
    [ApiController]
    public class ProdutoInvestimentoController : ControllerBase
    {
        private readonly CadastrarProdutoInvestimentoUseCase _cadastrarProduto;
        private readonly IMapper _mapper;

        public ProdutoInvestimentoController(CadastrarProdutoInvestimentoUseCase cadastrarProduto, IMapper mapper)
        {
            _cadastrarProduto = cadastrarProduto;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProdutoInvestimentoRequestDto dto)
        {
            // Mapeia DTO → Entidade
            var produto = _mapper.Map<ProdutoInvestimento>(dto);

            var result = await _cadastrarProduto.ExecuteAsync(produto.Nome,produto.Tipo, produto.RentabilidadeAnual, produto.Risco, produto.Descricao);

            // Mapeia Entidade → Response DTO
            var response = _mapper.Map<ProdutoInvestimentoResponseDto>(result);

            return Ok(response);
        }
    }
}
