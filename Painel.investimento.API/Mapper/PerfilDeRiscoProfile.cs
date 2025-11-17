using AutoMapper;
using Painel.Investimento.Domain.Models;

namespace Painel.Investimento.API.Mappings
{
    public class PerfilDeRiscoProfile : Profile
    {
        public PerfilDeRiscoProfile()
        {
            // PerfilDeRisco → PerfilDeRiscoDto
            CreateMap<PerfilDeRisco, PerfilDeRiscoDto>();
           
        }
    }
}
