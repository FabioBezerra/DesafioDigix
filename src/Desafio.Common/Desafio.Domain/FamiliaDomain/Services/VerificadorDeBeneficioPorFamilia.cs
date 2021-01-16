using Desafio.Domain.FamiliaDomain.Dtos;
using Desafio.Domain.FamiliaDomain.Enums;
using Desafio.Domain.FamiliaDomain.Interfaces.Repository;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Desafio.Domain.FamiliaDomain.Services
{
    public class VerificadorDeBeneficioPorFamilia : IVerificadorDeBeneficioPorFamilia
    {
        private readonly IFamiliaRepository _familiaRepository;
        private readonly IVerificadorDeDenpendentesPorFamilia _verificadorDeDenpendentesPorFamilia;
        private readonly IVerificadorDeIdadeDoPretendente _verificadorDeIdadeDoPretendente;
        private readonly IVerificadorDeRendaPorFamilia _verificadorDeRendaPorFamilia;

        public VerificadorDeBeneficioPorFamilia(
            IFamiliaRepository familiaRepository,
            IVerificadorDeDenpendentesPorFamilia verificadorDeDenpendentesPorFamilia,
            IVerificadorDeIdadeDoPretendente verificadorDeIdadeDoPretendente,
            IVerificadorDeRendaPorFamilia verificadorDeRendaPorFamilia)
        {
            _familiaRepository = familiaRepository;
            _verificadorDeDenpendentesPorFamilia = verificadorDeDenpendentesPorFamilia;
            _verificadorDeIdadeDoPretendente = verificadorDeIdadeDoPretendente;
            _verificadorDeRendaPorFamilia = verificadorDeRendaPorFamilia;
        }

        public List<FamiliaComBeneficioVerificadoDto> Verificar()
        {
            var familiasComBeneficioVerificadoDto = new List<FamiliaComBeneficioVerificadoDto>();
            var familias = _familiaRepository
                .BuscarComExpression(f => f.Status == StatusDaFamiliaEnum.CadastroValido);

            foreach (var familia in familias)
            {
                var familiaComBeneficioVerificadoDto = new FamiliaComBeneficioVerificadoDto
                {
                    FamiliaId = familia.Id,
                    NomeDoPretendente = ObterNomeDoPretendente(familia)
                };

                _verificadorDeDenpendentesPorFamilia.Verificar(familia, familiaComBeneficioVerificadoDto);
                _verificadorDeIdadeDoPretendente.Verificar(familia, familiaComBeneficioVerificadoDto);
                _verificadorDeRendaPorFamilia.Verificar(familia, familiaComBeneficioVerificadoDto);

                familiasComBeneficioVerificadoDto.Add(familiaComBeneficioVerificadoDto);
            }

            return familiasComBeneficioVerificadoDto
                .OrderBy(f => f.TotalDePontosFeitos).ToList();
        }

        private string ObterNomeDoPretendente(Familia familia)
        {
            return familia.Pessoas
                .FirstOrDefault(p => p.Tipo == TipoDePessoaEnum.Pretendente)
                .Nome;
        }
    }
}
