using Desafio.Domain.FamiliaDomain.Dtos;

namespace Desafio.Domain.FamiliaDomain.Interfaces.Services
{
    public interface IVerificadorDeDenpendentesPorFamilia
    {
        void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto);
    }
}
