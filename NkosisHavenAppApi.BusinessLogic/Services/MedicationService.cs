using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data.Entities;
using NkosisHavenAppApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class MedicationService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<MedicationService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public MedicationService(IDataStore dataStore, ILogger<MedicationService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Medication>> GetMedicationAsync(CancellationToken cancellationToken = default)
        {
            var medication = Enumerable.Empty<Medication>();

            try
            {
                _logger.LogTrace("Retrieving medication data...");
                medication = await _dataStore.GetEntitiesAsync<Data.Entities.Medication>(cancellationToken);
                _logger.LogInformation($"{medication.Count()} medication retrieved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving medication data.");
                return Enumerable.Empty<Medication>();
            }

            return medication;

        }

        public async Task AddMedicationAsync(Medication medication)
        {
            try
            {
                _logger.LogTrace("Adding new medication...");

                if (medication == null)
                {
                    _logger.LogWarning("Cannot add a null medication.");
                    throw new ArgumentNullException(nameof(medication), "medication cannot be null.");
                }

                await _dataStore.InsertEntityAsync(medication);

                _logger.LogInformation($"medication {medication.MedicationId} {medication.MedicationName} added successfully.");
            }
            catch (ArgumentNullException ex)
            {

                _logger.LogError(ex, "medication data is null.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding the medication.");
            }
        }
    }
}
