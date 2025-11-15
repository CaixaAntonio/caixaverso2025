using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Painel.investimento.Infra.Data;


namespace Painel.Investimento.Testes.Integration
{
    public class CustomWebApplicationFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
          
            builder.UseContentRoot("..\\Painel.Investimento.API"); // caminho do projeto da API
        }
    }
    
}
