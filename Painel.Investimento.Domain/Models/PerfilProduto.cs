using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painel.Investimento.Domain.Models
{
    public class PerfilProduto
    {
        public int? PerfilDeRiscoId { get; set; }
        public PerfilDeRisco? PerfilDeRisco { get; set; }

        public int? ProdutoInvestimentoId { get; set; }
        public ProdutoInvestimento? ProdutoInvestimento { get; set; }
    }
}
