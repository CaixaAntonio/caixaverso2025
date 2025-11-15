using Painel.Investimento.Aplication.Repository.Abstract;
using Painel.Investimento.Domain.Dtos;
using Painel.Investimento.Domain.Models;
using Painel.Investimento.Domain.Valueobjects;

namespace Painel.Investimento.Aplication.UserCases
{
    public class RegistrarClienteUseCase: IRegistrarClienteAplicationRepository
    {
        public async Task AddAsync(RegistrarClienteDto input)
        {
            var email = new Email(input.Email);
            var celular = new Celular(input.Celular);
            var cpf = new Cpf(input.Cpf);
            var dataNascimento = new DataDeNascimento(input.DataDeNascimento);
            var endereco = new Endereco(
                input.Logradouro,
                input.Numero,
                input.Complemento,
                input.Bairro,
                input.Cidade,
                new UnidadeFederativa(input.Estado.Sigla, input.Estado.Nome),
                new Cep(input.Cep.Valor)
            );
            var perfilDeRisco = new PerfilDeRisco(
                input.PerfilDeRiscoId,
                input.PerfilDeRiscoNome,
                input.PontuacaoMinima,
                input.PontuacaoMaxima,
                input.DescricaoPerfilDeRisco
               
            );

            var cliente = new Cliente(
                id: 0,
                nome: input.Nome,
                sobrenome: input.Sobrenome,
                email: email,
                celular: celular,
                cpf: cpf,
                dataDeNascimento: dataNascimento,
                perfilDeRisco: perfilDeRisco
            );

            cliente.AdicionarEndereco(endereco);
            
            // Persistir no banco
            //await _context.Clientes.AddAsync(cliente);
           // await _context.SaveChangesAsync();
        }
    }
}