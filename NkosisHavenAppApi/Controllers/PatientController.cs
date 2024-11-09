using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;

namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly PatientService _patientService;

        PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok (await  _patientService.GetArtefactsAsync(cancellationToken));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return null;
        }

        [HttpPut()]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit(CancellationToken cancellationToken)
        {
            return null;
        }


        [HttpDelete()]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            return null;
        }

    }
}
