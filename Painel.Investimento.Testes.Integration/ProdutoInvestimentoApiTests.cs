using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Painel.Investimento.Domain.Dtos;
using System.Net.Http.Json;

namespace Painel.Investimento.Testes.Integration
{
    public class ProdutoInvestimentoApiTests
        : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ProdutoInvestimentoApiTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_Cadastrar_ProdutoInvestimento_Com_Sucesso()
        {
            // Arrange
            var dto = new ProdutoInvestimentoRequestDto
            {
                Nome = "CDB",
                Tipo = "Renda Fixa",
                RentabilidadeAnual = 0.12m,
                Risco = 10,
                Descricao = "Certificado de Depósito Bancário"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/ProdutoInvestimento", dto);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var result = await response.Content.ReadFromJsonAsync<ProdutoInvestimentoResponseDto>();
            result.Should().NotBeNull();
            result!.Nome.Should().Be("CDB");
            result.Tipo.Should().Be("Renda Fixa");
            result.RentabilidadeAnual.Should().Be(0.12m);
            result.Risco.Should().Be(10);
        }
    }
}
