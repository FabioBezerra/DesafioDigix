using Desafio.Domain.FamiliaDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.FamiliaDomain
{
    public class Familia
    {
        public string Id { get; private set; }
        public List<Pessoa> Pessoas { get; private set; } = new List<Pessoa>();
        public List<Renda> Rendas { get; private set; } = new List<Renda>();
        public StatusDaFamiliaEnum Status { get; private set; }

        protected Familia()
        {
        }

        public Familia(List<Pessoa> pessoas, List<Renda> rendas, StatusDaFamiliaEnum status)
        {
            Pessoas = pessoas;
            Rendas = rendas;
            Status = status;
        }

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

    public class Renda
    {
        public string Id { get; private set; }
        public decimal Valor { get; set; }
    }

    public class Pessoa
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public TipoDePessoaEnum Tipo { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
