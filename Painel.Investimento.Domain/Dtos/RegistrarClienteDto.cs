using Painel.Investimento.Domain.Valueobjects;

namespace Painel.Investimento.Domain.Dtos
{
    public class RegistrarClienteDto
    {
        // Dados pessoais
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }

        // Endereço
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public UnidadeFederativa? Estado { get; set; } // UF
        public Cep? Cep { get; set; }

        // Perfil de risco (baseado na classe PerfilDeRisco)
        public int PerfilDeRiscoId { get; set; }
        public string? PerfilDeRiscoNome { get; set; } // Conservador, Moderado, Agressivo
        public int PontuacaoMinima { get; set; }
        public int PontuacaoMaxima { get; set; }
        public string? DescricaoPerfilDeRisco { get; set; }
        public bool? status {  get; set; }
    }
}