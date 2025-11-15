using AutoMapper;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;

namespace Painel.investimento.API.Mapper
{
    public class ProdutoInvestimentoProfile : Profile
    {
        public ProdutoInvestimentoProfile()
        {
            // Request → Domain
            CreateMap<ProdutoInvestimentoRequestDto, ProdutoInvestimento>()
                .ConstructUsing(dto => new ProdutoInvestimento(
                    dto.Nome,
                    dto.Tipo,
                    dto.RentabilidadeAnual,
                    dto.Risco,
                    dto.Descricao
                ));

            // Domain → Response
            CreateMap<ProdutoInvestimento, ProdutoInvestimentoResponseDto>();
        }
    }
}
