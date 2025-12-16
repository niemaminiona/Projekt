using Android.App;              // Dostęp do aplikacji Android
using Android.Content;          // Intent (co zrobić po kliknięciu)
using AndroidX.Core.App;
using Application = Android.App.Application;        // NotificationCompat

namespace Projekt.Platforms.Android;

// Klasa pomocnicza do wysyłania powiadomień
public static class NotificationService
{
    // Metoda pokazująca powiadomienie
    public static void Show(string title, string message)
    {
        // Pobieramy kontekst aplikacji (Android go wymaga)
        var context = Application.Context;

        // Intent mówi: "po kliknięciu otwórz aplikację"
        var intent = new Intent(context, typeof(MainActivity));

        // Flagi: nie otwieraj nowej instancji aplikacji
        intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);

        // PendingIntent = Android pozwala użyć intent później
        var pendingIntent = PendingIntent.GetActivity(
            context,                 // kontekst aplikacji
            0,                       // ID
            intent,                  // co ma się stać po kliknięciu
            PendingIntentFlags.Immutable // wymagane od Android 12
        );

        // Budujemy powiadomienie
        var notification = new NotificationCompat.Builder(context, "default_channel")
    .SetContentTitle(title)
    .SetContentText(message)
    .SetSmallIcon(Resource.Drawable.notification) // <- Własna ikona
    .SetAutoCancel(true)
    .SetContentIntent(pendingIntent)
    .Build();           // tworzymy obiekt

        // Systemowy manager wyświetla powiadomienie
        NotificationManagerCompat
            .From(context)
            .Notify(1, notification); // 1 = ID powiadomienia
    }
}
