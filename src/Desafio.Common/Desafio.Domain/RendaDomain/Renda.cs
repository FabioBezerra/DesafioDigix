using Desafio.Domain.FamiliaDomain;
using Desafio.Domain.PessoaDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.RendaDomain
{
    public class Renda
    {
        protected Renda()
        {
        }

        public string Id { get; private set; }
        public decimal Valor { get; private set; }
        public string PessoaId { get; private set; }
        public virtual Pessoa Pessoa { get; private set; }
        public string FamiliaId { get; private set; }
        public virtual Familia Familia { get; private set; }
    }
}
