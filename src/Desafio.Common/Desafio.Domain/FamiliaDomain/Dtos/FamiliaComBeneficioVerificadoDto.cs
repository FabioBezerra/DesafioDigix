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

        public bool FamiliaSelecionada { get; set; }

        public int TotalDePontosFeitos { get => PontosPorDependentes.GetHashCode() + PontosPorIdade.GetHashCode() + PontosPorRendaTotalFamilia.GetHashCode(); }

        public PontosPorDependentesEnum PontosPorDependentes { get; set; }
        public bool TemIgualOuAcimaDeTresDependentes { get => PontosPorDependentes == PontosPorDependentesEnum.IgualOuAcimaDeTres; }
        public bool TemDeUmAteDoisDependentes { get => PontosPorDependentes == PontosPorDependentesEnum.DeUmAteDois; }
        public bool NaoTemNenhumDependente { get => PontosPorDependentes == PontosPorDependentesEnum.Nenhum; }

        public PontosPorIdadeEnum PontosPorIdade { get; set; }
        public bool TemIdadeIgualOuAcimaDeQuarentaECinco { get => PontosPorIdade == PontosPorIdadeEnum.IgualOuAcimaDeQuarentaECinco; }
        public bool TemIdadeDeTrintaAteQuarentaEQuatro { get => PontosPorIdade == PontosPorIdadeEnum.DeTrintaAteQuarentaEQuatro; }
        public bool TemIdadeAbaixoDeTrinta { get => PontosPorIdade == PontosPorIdadeEnum.AbaixoDeTrinta; }

        public PontosPorRendaTotalFamiliaEnum PontosPorRendaTotalFamilia { get; set; }
        public bool TemRendaAteNovecentos { get => PontosPorRendaTotalFamilia == PontosPorRendaTotalFamiliaEnum.AteNovecentos; }
        public bool TemRendaDeNovecentosEUmAteMilEQuinhentos { get => PontosPorRendaTotalFamilia == PontosPorRendaTotalFamiliaEnum.DeNovecentosEUmAteMilEQuinhentos; }
        public bool TemRendaDeMilEQuinhentosEUmAteDoisMil { get => PontosPorRendaTotalFamilia == PontosPorRendaTotalFamiliaEnum.DeMilEQuinhentosEUmAteDoisMil; }
        public bool TemRendaAcimaDeDoisMil { get => PontosPorRendaTotalFamilia == PontosPorRendaTotalFamiliaEnum.AcimaDeDoisMil; }

    }
}
