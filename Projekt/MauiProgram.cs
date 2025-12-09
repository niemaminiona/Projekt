using Microsoft.Extensions.Logging;
using Projekt.DataHandling;

namespace Projekt
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // zmusza do odswierzania bazy za kazdym odpaleniem aplikacji
            Task.Run(async () => await DatabaseService.ForceFreshDatabase()).Wait(); // USUN POZNIEJ (TESTY)

            // kopiuje baze danych
            Task.Run(async () => await DatabaseService.CopyDatabaseIfNeeded()).Wait();
            // Laduje suplementy z bazy do listy
            Task.Run(async () => await DataService.Suplements.LoadSupplements());
            


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
