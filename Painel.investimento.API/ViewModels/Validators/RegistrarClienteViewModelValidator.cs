using FluentValidation;
using Painel.Investimento.Domain.Dtos;


namespace Painel.Investimento.Application.Validators
{
    public class RegistrarClienteViewModelValidator : AbstractValidator<RegistrarClienteDto>
    {
        public RegistrarClienteViewModelValidator()
        {
            // Nome e Sobrenome obrigatórios
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome não pode ter mais que 100 caracteres.");

            RuleFor(x => x.Sobrenome)
                .NotEmpty().WithMessage("Sobrenome é obrigatório.")
                .MaximumLength(100).WithMessage("Sobrenome não pode ter mais que 100 caracteres.");

            // Email válido
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            // Celular com 11 dígitos
            RuleFor(x => x.Celular)
                .NotEmpty().WithMessage("Celular é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("Celular deve ter 11 dígitos.");

            // CPF com 11 dígitos
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("CPF deve ter 11 dígitos.");

            // Data de nascimento não pode ser no futuro
            RuleFor(x => x.DataDeNascimento)
                .LessThan(DateTime.Today).WithMessage("Data de nascimento não pode ser no futuro.");

            // Endereço obrigatório
            RuleFor(x => x.Logradouro).NotEmpty().WithMessage("Logradouro é obrigatório.");
            RuleFor(x => x.Numero).NotEmpty().WithMessage("Número é obrigatório.");
            RuleFor(x => x.Bairro).NotEmpty().WithMessage("Bairro é obrigatório.");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("Cidade é obrigatória.");
            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("Estado é obrigatório.");

            RuleFor(x => x.Cep)
                .NotEmpty().WithMessage("CEP é obrigatório.");               

            // Perfil de risco obrigatório
            RuleFor(x => x.PerfilDeRiscoNome)
                .NotEmpty().WithMessage("Perfil de risco é obrigatório.");
        }
    }
}