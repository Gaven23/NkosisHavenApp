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
            return Ok (await  _patientService.GetPatientsAsync(cancellationToken));
        }

        /// <summary>
        /// Adds Patients.        
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpPost("PostPatients")]
        public async Task<IActionResult> Create(Patient patient)
        {

            if (patient is null)
                return BadRequest("A patient details must be present");

            await _patientService.AddPatientAsync(patient);

            return RedirectToAction(nameof(Index));
        }
    }
}
