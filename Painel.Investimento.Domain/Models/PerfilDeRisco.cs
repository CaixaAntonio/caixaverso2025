using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Models
{
    public class PerfilDeRisco
    {
        public int? Id { get; private set; }
        public string? Nome { get; private set; }
        public int? PontuacaoMinima { get; private set; }
        public int? PontuacaoMaxima { get; private set; }
        public string? Descricao { get; private set; }
        
        public PerfilDeRisco(int? id, string? nome, int? pontuacaoMinima, int? pontuacaoMaxima, string? descricao)
        {
            Id = id;
            Nome = nome;
            PontuacaoMinima = pontuacaoMinima;
            PontuacaoMaxima = pontuacaoMaxima;
            Descricao = descricao;
            
        }

        public bool PertenceAoIntervalo(int pontuacao) => pontuacao >= PontuacaoMinima && pontuacao <= PontuacaoMaxima;

    }
}


