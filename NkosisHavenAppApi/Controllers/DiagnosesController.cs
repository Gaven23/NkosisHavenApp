using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly DiagnosesService _diagnosesService;

        DiagnosesController(DiagnosesService diagnosesService)
        {
            _diagnosesService = diagnosesService;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Diagnosis>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _diagnosesService.GetDiagnosisAsync(cancellationToken));
        }

        /// <summary>
        /// Adds Diagnosis        
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpPost("PostDiagnosis")]
        public async Task<IActionResult> Create(Diagnosis diagnosis)
        {

            if (diagnosis is null)
                return BadRequest("A Diagnosis details must be present");

            await _diagnosesService.AddDiagnosisAsync(diagnosis);

            return Ok();
        }
    }
}
