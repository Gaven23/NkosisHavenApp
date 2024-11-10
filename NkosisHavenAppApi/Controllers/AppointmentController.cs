using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly AppointmentService _appointmentService;

        AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _appointmentService.GetArtefactsAsync(cancellationToken));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return null;
        }

        [HttpPut()]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit(CancellationToken cancellationToken)
        {
            return null;
        }


        [HttpDelete()]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
