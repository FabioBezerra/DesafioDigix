using Desafio.Domain.FamiliaDomain.Dtos;
using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using System;
using System.Linq;

namespace Desafio.Domain.FamiliaDomain.Services
{
    public class VerificadorDeIdadeDoPretendente : IVerificadorDeIdadeDoPretendente
    {
        private readonly int _quarentaECindo = 45;
        private readonly int _trinta = 30;

        public void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto)
        {
            var idadeDoPretendente = CalcularIdadeDoPretendente(familia);

            if (idadeDoPretendente >= _quarentaECindo)
                familiaComBeneficioVerificadoDto.PontosPorIdade = PontosPorIdadeEnum.IgualOuAcimaDeQuarentaECinco;
            else if (idadeDoPretendente < _quarentaECindo && idadeDoPretendente >= _trinta)
                familiaComBeneficioVerificadoDto.PontosPorIdade = PontosPorIdadeEnum.DeTrintaAteQuarentaEQuatro;
            else
                familiaComBeneficioVerificadoDto.PontosPorIdade = PontosPorIdadeEnum.AbaixoDeTrinta;
        }

        private int CalcularIdadeDoPretendente(Familia familia)
        {
            var dataDeHoje = DateTime.Today;

            var dataDeNascimento = familia.Pessoas
               .FirstOrDefault(p => p.Tipo == TipoDePessoaEnum.Pretendente)
               .DataDeNascimento;

            var idade = dataDeHoje.Year - dataDeNascimento.Year;

            if (dataDeNascimento.Date > dataDeHoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
