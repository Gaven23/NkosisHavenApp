﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NkosisHavenAppApi.BusinessLogic.Services;
using NkosisHavenAppApi.Data.Entities;
namespace NkosisHavenAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MadicationController : ControllerBase
    {
        private readonly MedicationService _medicationService;

        MadicationController(MedicationService appointmentService)
        {
            _medicationService = appointmentService;
        }


        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _medicationService.GetMedicationAsync( cancellationToken));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(CancellationToken cancellationToken)
        {
            return null;
        }

        [HttpPut()]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit(CancellationToken cancellationToken)
        {
            return null;
        }


        [HttpDelete()]
        [ProducesResponseType(typeof(IEnumerable<Medication>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
