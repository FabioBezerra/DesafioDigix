using System;
using System.Collections.Generic;
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

        [HttpGet("GetFamiliasComBeneficio")]
        public List<FamiliaComBeneficioVerificadoDto> GetFamiliasComBeneficio()
        {
            try
            {
                return _verificadorDeBeneficioPorFamilia.Verificar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("PostFamiliasComBeneficio")]
        public IActionResult PostFamiliasComBeneficio([FromBody] List<FamiliaComBeneficioVerificadoDto> dto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
