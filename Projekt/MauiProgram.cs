using Microsoft.Extensions.Logging;
using Projekt.DataHandling;

namespace Projekt
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // zmusza do odswierzania bazy za kazdym odpaleniem aplikacji
            //Task.Run(async () => await DatabaseService.SQLite.ForceFreshDatabase()).Wait(); // USUN POZNIEJ (TESTY)


            Task.Run(async () => await DatabaseService.SQLite.CopyDatabaseIfNeeded()).Wait(); // kopiuje baze danych jesli nie ma

            Task.Run(async () => await DatabaseService.JSON.CopyDatabaseIfNeeded()).Wait(); // kopiuje plik json jesli nie ma

            Task.Run(async () => await DataService.Suplements.LoadSupplements()); // Laduje suplementy z bazy do listy

            Task.Run(async () => await DatabaseService.JSON.LoadSettingsAsync()); // Laduje ustawienia z jsona

            
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
