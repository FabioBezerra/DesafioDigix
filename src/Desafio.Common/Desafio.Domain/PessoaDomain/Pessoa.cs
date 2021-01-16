using Desafio.Domain.FamiliaDomain;
using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.RendaDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.PessoaDomain
{
    public class Pessoa
    {
        protected Pessoa()
        {
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public TipoDePessoaEnum Tipo { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string FamiliaId { get; private set; }
        public virtual Familia Familia { get; private set; }
        public virtual Renda Renda { get; private set; }
    }
}
