using Desafio.Domain.FamiliaDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Domain.FamiliaDomain.Dtos
{
    public class FamiliaComBeneficioVerificadoDto
    {
        public string FamiliaId { get; set; }
        public string NomeDoPretendente { get; set; }
        public int TotalDePontosFeitos { get => PontosPorDependentes.GetHashCode() + PontosPorIdade.GetHashCode() + PontosPorRendaTotalFamilia.GetHashCode(); }
        public PontosPorDependentesEnum PontosPorDependentes { get; set; }
        public PontosPorIdadeEnum PontosPorIdade { get; set; }
        public PontosPorRendaTotalFamiliaEnum PontosPorRendaTotalFamilia { get; set; }
    }
}
