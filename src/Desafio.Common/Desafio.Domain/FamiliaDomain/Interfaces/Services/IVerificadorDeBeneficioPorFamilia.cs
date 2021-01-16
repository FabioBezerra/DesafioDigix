using Desafio.Domain.FamiliaDomain.Dtos;
using System.Collections.Generic;

namespace Desafio.Domain.FamiliaDomain.Interfaces.Services
{
    public interface IVerificadorDeBeneficioPorFamilia
    {
        List<FamiliaComBeneficioVerificadoDto> Verificar();
    }
}
