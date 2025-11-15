namespace Painel.Investimento.Domain.Valueobjects
{

    public class UnidadeFederativa
    {
        public string Sigla { get; private set; } // Ex: "MG"
        public string Nome { get; private set; }  // Ex: "Minas Gerais"

        private UnidadeFederativa() { } // Necessário para EF Core

        public UnidadeFederativa(string sigla, string nome)
        {
            if (string.IsNullOrWhiteSpace(sigla) || sigla.Length != 2)
                throw new ArgumentException("Sigla inválida. Deve ter 2 caracteres.", nameof(sigla));

            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da UF não pode ser vazio.", nameof(nome));

            Sigla = sigla.ToUpper();
            Nome = nome;
        }

        public override string ToString() => $"{Nome} ({Sigla})";
    }
}
