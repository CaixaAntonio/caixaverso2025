using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Valueobjects;

public sealed class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Sobrenome { get; private set; }
    public Email Email { get; private set; }
    public Celular Celular { get; private set; }
    public Cpf Cpf { get; private set; }
    public Idade Idade { get; private set; }
    public DataDeNascimento DataDeNascimento { get; private set; }
    public int PerfilDeRiscoId { get; private set; } // FK
    public PerfilDeRisco PerfilDeRisco { get; private set; } // Navegação

    public ICollection<Endereco> Enderecos { get; private set; } = new List<Endereco>();

    public ICollection<Investimentos> Investimentos { get; private set; } = new List<Investimentos>();



    private Cliente() { }

    public Cliente(int id, string nome, string sobrenome, Email email, Celular celular, Cpf cpf,
                   DataDeNascimento dataDeNascimento, PerfilDeRisco perfilDeRisco)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.", nameof(nome));

        if (string.IsNullOrWhiteSpace(sobrenome))
            throw new ArgumentException("Sobrenome não pode ser vazio.", nameof(sobrenome));

        Id = id;
        Nome = nome;
        Sobrenome = sobrenome;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Celular = celular ?? throw new ArgumentNullException(nameof(celular));
        Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
        DataDeNascimento = dataDeNascimento ?? throw new ArgumentNullException(nameof(dataDeNascimento));
        Idade = new Idade(dataDeNascimento.CalcularIdade());
        PerfilDeRiscoId = (int)perfilDeRisco.Id;
        
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        if (endereco == null) throw new ArgumentNullException(nameof(endereco));
        Enderecos.Add(endereco);
    }

    public void AjustarPerfil(PerfilDeRisco novoPerfil)
    {
        PerfilDeRisco = novoPerfil;
        PerfilDeRiscoId = (int)novoPerfil.Id;
    }



}