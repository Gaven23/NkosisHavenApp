using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data;
using NkosisHavenAppApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class AppointmentService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<AppointmentService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public AppointmentService(IDataStore dataStore, ILogger<AppointmentService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<List<Appointment>> GetAppointmentsAsync(int appointmentId , CancellationToken cancellationToken = default)
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                _logger.LogTrace("Retrieving appointments...");
                appointments = (await _dataStore.GetEntitiesAsync<Appointment>(cancellationToken)).ToList();
                _logger.LogInformation($"{appointments.Count} appointments retrieved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving appointments.");
            }

            return appointments;
        }

        public async Task<bool> AddAppointmentAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogTrace("Adding a new appointment...");
                await _dataStore.InsertEntityAsync<Appointment>(appointment);
                _logger.LogInformation("Appointment added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an appointment.");
                return false;
            }
        }

        public async Task<bool> UpdateAppointmentAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogTrace("Updating an appointment...");
                await _dataStore.UpdateEntityAsync<Appointment>(appointment);
                _logger.LogInformation("Appointment updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the appointment.");
                return false;
            }
        }
    }
}
