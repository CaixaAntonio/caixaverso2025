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
            // Arrange
            var nome = "CDB";
            var tipo = "Renda Fixa";
            var rentabilidade = 0.12m;
            var risco = 10;
            var descricao = "Certificado de Depósito Bancário";

            // Act
            var produto = new ProdutoInvestimento(nome, tipo, rentabilidade, risco, descricao);

            // Assert
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(tipo, produto.Tipo);
            Assert.Equal(rentabilidade, produto.RentabilidadeAnual);
            Assert.Equal(risco, produto.Risco);
            Assert.Equal(descricao, produto.Descricao);
        }

        [Fact]
        public void Deve_Lancar_Excecao_Quando_Nome_Vazio()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ProdutoInvestimento("", "Renda Fixa", 0.12m, 10, "Teste"));
        }

        [Fact]
        public void Deve_Lancar_Excecao_Quando_Rentabilidade_Menor_Ou_Igual_A_Zero()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                new ProdutoInvestimento("CDB", "Renda Fixa", 0m, 10, "Teste"));
        }

        //[Fact]
        //public void Deve_Atualizar_Rentabilidade_Valida()
        //{
        //    // Arrange
        //    var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Teste");

        //    // Act
        //    produto.AtualizarRentabilidade(0.15m);

        //    // Assert
        //    Assert.Equal(0.15m, produto.RentabilidadeAnual);
        //}

        //[Fact]
        //public void Deve_Lancar_Excecao_Ao_Atualizar_Rentabilidade_Invalida()
        //{
        //    // Arrange
        //    var produto = new ProdutoInvestimento("CDB", "Renda Fixa", 0.12m, 10, "Teste");

        //    // Act & Assert
        //    Assert.Throws<ArgumentException>(() => produto.AtualizarRentabilidade(0m));
        //}
    }
}
