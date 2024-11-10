using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
using System.Threading;
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
            return Ok(await _appointmentService.GetAppointmentAsync(cancellationToken));
        }

        /// <summary>
        /// Adds Appointment        
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpPost("PostAppointment")]
        public async Task<IActionResult> Create(Appointment appointment)
        {

            if (appointment is null)
                return BadRequest("A appointment details must be present");

            await _appointmentService.AddAppointmentAsync(appointment);

            return Ok();
        }
    }
}