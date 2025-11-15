using Painel.Investimento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimentos.Testes
{
    public class ProdutoInvestimentoTests
    {
        [Fact]
        public void Deve_Criar_ProdutoInvestimento_Valido()
        {
            // Arrange & Act
            var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Certificado de Depósito Bancário");

            // Assert
            Assert.Equal("CDB", produto.Nome);
            Assert.Equal("Renda Fixa", produto.Tipo);
            Assert.Equal(0.12m, produto.RentabilidadeAnual);
            Assert.Equal(10, produto.Risco);
            Assert.Equal("Certificado de Depósito Bancário", produto.Descricao);
        }

        [Theory]
        [InlineData("", "Renda Fixa", 0.12, 10, "Descrição válida", "Nome não pode ser vazio.")]
        [InlineData("CDB", "", 0.12, 10, "Descrição válida", "Tipo não pode ser vazio.")]
        [InlineData("CDB", "Renda Fixa", 0, 10, "Descrição válida", "Rentabilidade deve ser maior que zero.")]
        [InlineData("CDB", "Renda Fixa", 0.12, 0, "Descrição válida", "Risco deve estar entre 1 e 100.")]
        [InlineData("CDB", "Renda Fixa", 0.12, 10, "", "Descrição não pode ser vazia.")]
        public void Deve_Lancar_Excecao_Quando_Dados_Invalidos(
            string nome, string tipo, decimal rentabilidade, int risco, string descricao, string mensagemEsperada)
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                new ProdutoInvestimento(nome, tipo, rentabilidade, risco, descricao));

            Assert.Contains(mensagemEsperada, ex.Message);
        }

        [Fact]
        public void Deve_Atualizar_ProdutoInvestimento_Com_Dados_Validos()
        {
            // Arrange
            var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Descrição inicial");

            // Act
            produto.AtualizarProdutoInvestimento("LCI", "Renda Fixa", 0.15m, 20, "Nova descrição");

            // Assert
            Assert.Equal("LCI", produto.Nome);
            Assert.Equal("Renda Fixa", produto.Tipo);
            Assert.Equal(0.15m, produto.RentabilidadeAnual);
            Assert.Equal(20, produto.Risco);
            Assert.Equal("Nova descrição", produto.Descricao);
        }

        [Fact]
        public void Deve_Lancar_Excecao_Ao_Atualizar_Com_Dados_Invalidos()
        {
            // Arrange
            var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Descrição inicial");

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                produto.AtualizarProdutoInvestimento("", "Renda Fixa", 0.12m, 10, "Descrição válida"));
        }

        [Fact]
        public void Deve_Validar_Produto_Correto()
        {
            // Arrange
            var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Descrição válida");

            // Act & Assert
            produto.Validar(); // não deve lançar exceção
        }

        [Fact]
        public void Deve_Lancar_Excecao_Ao_Atualizar_Com_Rentabilidade_Invalida()
        {
            var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Descrição válida");

            Assert.Throws<ArgumentException>(() =>
                produto.AtualizarProdutoInvestimento("CDB", "Renda Fixa", -1m, 10, "Descrição válida"));
        }

    }
}
