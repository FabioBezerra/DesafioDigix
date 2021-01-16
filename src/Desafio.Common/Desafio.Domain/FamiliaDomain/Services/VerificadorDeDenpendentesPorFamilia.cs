using Desafio.Domain.FamiliaDomain.Dtos;
using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using System;
using System.Linq;

namespace Desafio.Domain.FamiliaDomain.Services
{
    public class VerificadorDeDenpendentesPorFamilia : IVerificadorDeDenpendentesPorFamilia
    {
        private readonly decimal _novecentos = 900;
        private readonly decimal _milEQuinhentos = 1500;
        private readonly decimal _doisMil = 2000;

        public void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto)
        {
            var rendaDaFamilia = familia.Rendas.Sum(r => r.Valor);

            if (rendaDaFamilia <= _novecentos)
                familiaComBeneficioVerificadoDto.PontosPorRendaTotalFamilia = PontosPorRendaTotalFamiliaEnum.AteNovecentos;
            else if (rendaDaFamilia > _novecentos && rendaDaFamilia <= _milEQuinhentos)
                familiaComBeneficioVerificadoDto.PontosPorRendaTotalFamilia = PontosPorRendaTotalFamiliaEnum.DeNovecentosEUmAteMilEQuinhentos;
            else if (rendaDaFamilia > _milEQuinhentos && rendaDaFamilia <= _doisMil)
                familiaComBeneficioVerificadoDto.PontosPorRendaTotalFamilia = PontosPorRendaTotalFamiliaEnum.DeMilEQuinhentosEUmAteDoisMil;
            else
                familiaComBeneficioVerificadoDto.PontosPorRendaTotalFamilia = PontosPorRendaTotalFamiliaEnum.AcimaDeDoisMil;
        }
    }
}
