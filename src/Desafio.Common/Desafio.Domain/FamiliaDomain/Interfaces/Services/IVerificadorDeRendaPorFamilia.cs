using Desafio.Domain.FamiliaDomain.Dtos;

namespace Desafio.Domain.FamiliaDomain.Interfaces.Services
{
    public interface IVerificadorDeRendaPorFamilia
    {
        void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto);
    }
}
