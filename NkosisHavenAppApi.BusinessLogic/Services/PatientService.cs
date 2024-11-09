using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data.Entities;
using NkosisHavenAppApi.Data;
namespace NkosisHavenAppApi.BusinessLogic.Services
{
    public class PatientService
    {
        private readonly IDataStore _dataStore;
        private readonly ILogger<PatientService> _logger;
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public PatientService(IDataStore dataStore, ILogger<PatientService> logger, IOptionsSnapshot<AppSettings> appSettings)
        {
            _dataStore = dataStore;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<Patient>> GetArtefactsAsync(CancellationToken cancellationToken = default)
        {
            var artefacts = Enumerable.Empty<Patient>();

            try
            {
                _logger.LogTrace("Retrieving Artefact data...");
                artefacts = await _dataStore.GetEntitiesAsync<Data.Entities.Patient>(cancellationToken);
                _logger.LogInformation($"{artefacts.Count()} Artefacts retrieved.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving Artefact data.");
                return Enumerable.Empty<Patient>();
            }

            return artefacts;


        }
    }

}
