using Painel.Investimento.Domain.Valueobjects;
using System.Runtime.ConstrainedExecution;

public class Endereco
{
    public int Id { get; private set; } 
    public string? Logradouro { get; private set; }
    public string? Numero { get; private set; }
    public string? Complemento { get; private set; }
    public string? Bairro { get; private set; }
    public string? Cidade { get; private set; }
    public UnidadeFederativa? Estado { get; private set; }
    public Cep? Cep { get; private set; }
    public int? ClienteId { get; private set; } 
    public Cliente? Cliente { get; private set; }

    private Endereco() { }

    public Endereco(string? logradouro, string? numero, string? complemento, string? bairro,
                    string? cidade, UnidadeFederativa? estado, Cep? cep)
    {
        Logradouro = logradouro;
        Numero = numero;
        Complemento = complemento;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado ?? throw new ArgumentNullException(nameof(estado));
        Cep = cep ?? throw new ArgumentNullException(nameof(cep));
    }
}