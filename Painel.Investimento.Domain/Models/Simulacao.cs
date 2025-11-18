using System;

namespace Painel.Investimento.Domain.Models
{
    public class Simulacao
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public string NomeProduto { get; private set; }
        public decimal ValorInicial { get; private set; }
        public decimal ValorFinal { get; private set; }
        public decimal RentabilidadeEfetiva { get; private set; }
        public int PrazoMeses { get; private set; }
        public DateTime DataSimulacao { get; private set; }

        // 🔹 Construtor rico: força consistência ao criar
        public Simulacao(int clienteId, string nomeProduto, decimal valorInicial, int prazoMeses, decimal valorFinal)
        {
            if (clienteId <= 0)
                throw new ArgumentException("ClienteId deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(nomeProduto))
                throw new ArgumentException("Nome do produto é obrigatório.");

            if (valorInicial <= 0)
                throw new ArgumentException("Valor inicial deve ser maior que zero.");

            if (prazoMeses <= 0)
                throw new ArgumentException("Prazo deve ser maior que zero.");

            ClienteId = clienteId;
            NomeProduto = nomeProduto;
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
            ValorFinal = valorFinal;
            RentabilidadeEfetiva = valorFinal - valorInicial;
            DataSimulacao = DateTime.UtcNow;
        }

        // 🔹 Método de negócio: calcula rentabilidade percentual
        public decimal CalcularRentabilidadePercentual()
        {
            if (ValorInicial <= 0) return 0;
            return (RentabilidadeEfetiva / ValorInicial) * 100;
        }

        // 🔹 Método de negócio: verifica se a simulação atingiu um mínimo esperado
        public bool EhRentavel(decimal minimoPercentual)
        {
            return CalcularRentabilidadePercentual() >= minimoPercentual;
        }

        // 🔹 Validação adicional
        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(NomeProduto))
                throw new InvalidOperationException("Nome do produto é obrigatório.");

            if (ValorInicial <= 0)
                throw new InvalidOperationException("Valor inicial deve ser maior que zero.");

            if (PrazoMeses <= 0)
                throw new InvalidOperationException("Prazo deve ser maior que zero.");
        }
    }
}
