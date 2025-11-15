using FluentValidation;
using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Domain.Dtos;

namespace Painel.investimento.API.Services
{
    public class ClienteService
    {

        private readonly IValidator<RegistrarClienteDto> _validator;
        private readonly IRegistrarClienteAplicationRepository _registrarCliente;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IValidator<RegistrarClienteDto> validator, IRegistrarClienteAplicationRepository registrarCliente,
            ILogger<ClienteService> logger)
        {
            _validator = validator;
            _registrarCliente = registrarCliente;
            _logger = logger;
        }

        public async Task AddAsync(RegistrarClienteDto request)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException($"Erro de validação: {errors}");
            }

            await _registrarCliente.AddAsync(request);

            _logger.LogInformation("Enviado para Aplication com Sucesso.");

        }



    }
}
