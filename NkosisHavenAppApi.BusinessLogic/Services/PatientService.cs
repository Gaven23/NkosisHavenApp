using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NkosisHavenAppApi.Common;
using NkosisHavenAppApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }

}
