using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Valueobjects
{
    public class Cep
    {
        public string Valor { get; private set; }

        private Cep() { } 

        public Cep(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("CEP não pode ser vazio.", nameof(valor));

            // Remove caracteres não numéricos
            valor = new string(valor.Where(char.IsDigit).ToArray());

            if (valor.Length != 8)
                throw new ArgumentException("CEP inválido. Deve conter 8 dígitos.", nameof(valor));

            Valor = valor;
        }

        public override string ToString()
        {           
            return $"{Valor.Substring(0, 5)}-{Valor.Substring(5, 3)}";
        }
    }
}
