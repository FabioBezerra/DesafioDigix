using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.PessoaDomain;
using Desafio.Domain.RendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.FamiliaDomain
{
    public class Familia
    {
        protected Familia()
        {
        }

        public Familia(List<Pessoa> pessoas, List<Renda> rendas, StatusDaFamiliaEnum status)
        {
            Pessoas = pessoas;
            Rendas = rendas;
            Status = status;
        }

        public string Id { get; private set; }
        public virtual List<Pessoa> Pessoas { get; private set; } = new List<Pessoa>();
        public virtual List<Renda> Rendas { get; private set; } = new List<Renda>();
        public StatusDaFamiliaEnum Status { get; private set; }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            if (pessoa == null || (pessoa != null && Pessoas.Any(p => p.Id == pessoa.Id)))
                return;

            Pessoas.Add(pessoa);
        }

        public void AdicionarRenda(Renda renda)
        {
            if (renda == null || (renda != null && Rendas.Any(p => p.Id == renda.Id)))
                return;

            Rendas.Add(renda);
        }
    }
}
