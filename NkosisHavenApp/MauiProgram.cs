using Microsoft.Extensions.Logging;
using NkosisHavenApp.Data;

namespace NkosisHavenApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Set up the main app, fonts, and Blazor WebView
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register services here
            builder.Services.AddSingleton<IDataStore, DataService>(); // Make sure DataService implements IDataStore
            builder.Services.AddSingleton<AppointmentDataService>(); // Make sure AppointmentDataService implements IAppointment
            builder.Services.AddSingleton<DoctorDataService>(); // Make sure AppointmentDataService implements IAppointment

            // Register Blazor WebView services
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            // Add Blazor Developer tools and debugging
            builder.Services.AddBlazorWebViewDeveloperTools();
            
            // Configure logging to output to debug window
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
