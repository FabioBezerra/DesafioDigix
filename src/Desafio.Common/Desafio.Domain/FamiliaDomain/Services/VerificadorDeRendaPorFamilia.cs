using Desafio.Domain.FamiliaDomain.Dtos;
using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using Desafio.Domain.PessoaDomain;
using System;
using System.Linq;

namespace Desafio.Domain.FamiliaDomain.Services
{
    public class VerificadorDeRendaPorFamilia : IVerificadorDeRendaPorFamilia
    {
        private readonly int _idadeMaximaParaDependenteValido = 8;
        private readonly int _tres = 3;
        private readonly int _um = 1;

        public void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto)
        {
            var quantidadeDeDependentes = CalcularQuantidadeDeDependentes(familia);

            if (quantidadeDeDependentes >= _tres)
                familiaComBeneficioVerificadoDto.PontosPorDependentes = PontosPorDependentesEnum.IgualOuAcimaDeTres;
            else if (quantidadeDeDependentes < _tres && quantidadeDeDependentes >= _um)
                familiaComBeneficioVerificadoDto.PontosPorDependentes = PontosPorDependentesEnum.DeUmAteDois;
            else
                familiaComBeneficioVerificadoDto.PontosPorDependentes = PontosPorDependentesEnum.Nenhum;
        }

        private int CalcularQuantidadeDeDependentes(Familia familia)
        {
            var quantidadeDeDependentesValidos = 0;
            var dependentes = familia.Pessoas
                .Where(p => p.Tipo == TipoDePessoaEnum.Dependente);

            foreach (var dependente in dependentes)
            {
                var idadeDoDependente = CalcularIdadeDoDependente(dependente);

                if (idadeDoDependente <= _idadeMaximaParaDependenteValido)
                    quantidadeDeDependentesValidos++;
            }

            return quantidadeDeDependentesValidos;
        }

        private int CalcularIdadeDoDependente(Pessoa pessoa)
        {
            var dataDeHoje = DateTime.Today;
            var dataDeNascimento = pessoa.DataDeNascimento;
            var idade = dataDeHoje.Year - dataDeNascimento.Year;

            if (dataDeNascimento.Date > dataDeHoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
