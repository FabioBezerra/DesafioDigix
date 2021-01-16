using Desafio.Domain.FamiliaDomain.Dtos;

namespace Desafio.Domain.FamiliaDomain.Interfaces.Services
{
    public interface IVerificadorDeIdadeDoPretendente
    {
        void Verificar(Familia familia, FamiliaComBeneficioVerificadoDto familiaComBeneficioVerificadoDto);
    }
}
