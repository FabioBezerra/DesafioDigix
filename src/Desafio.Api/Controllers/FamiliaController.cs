using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Domain.FamiliaDomain.Dtos;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        private readonly IVerificadorDeBeneficioPorFamilia _verificadorDeBeneficioPorFamilia;

        public FamiliaController(IVerificadorDeBeneficioPorFamilia verificadorDeBeneficioPorFamilia)
        {
            _verificadorDeBeneficioPorFamilia = verificadorDeBeneficioPorFamilia;
        }

        [HttpGet("ObterFamiliasComBeneficio")]
        public List<FamiliaComBeneficioVerificadoDto> ObterFamiliasComBeneficio()
        {
            if (_verificadorDeBeneficioPorFamilia.Verificar())
                return new List<FamiliaComBeneficioVerificadoDto>();

            return null;
        }
    }
}
