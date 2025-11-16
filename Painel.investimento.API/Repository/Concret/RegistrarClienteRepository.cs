using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Painel.investimento.API.Repository.Abstract;
using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Domain.Dtos;

namespace Painel.investimento.API.Repository.Concret
{
    public class RegistrarClienteRepository 
    {
        private readonly IValidator<ClienteRequestDto> _validator;

        public RegistrarClienteRepository(IValidator<ClienteRequestDto> validator)
        {
            _validator = validator;
        }


    }

       
}
