namespace Projekt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            GoToAsync("//Home"); // strona z routem "Home" otworzy sie pierwsza


            //to wszystko tutaj rejestruje routy
            Routing.RegisterRoute("Info", typeof(Projekt.Views.Info.InfoPage)); // rejestruje Info route
            Routing.RegisterRoute("DisplayInfo", typeof(Projekt.Views.Info.DisplayInfo)); // rejestruje DisplayInfo route

            Routing.RegisterRoute("Settings", typeof(Projekt.Views.Settings.SettingsPage)); // rejestruje Settings route
            Routing.RegisterRoute("NotificationSettings", typeof(Projekt.Views.Settings.NotificationSettingsPage)); // rejestruje NotificationSettings route
            Routing.RegisterRoute("ViewSettings", typeof(Projekt.Views.Settings.ViewSettingsPage)); // rejestruje ViewSettings route
            Routing.RegisterRoute("LanguageSettings", typeof(Projekt.Views.Settings.LanguageSettingsPage)); // rejestruje LanguageSettings route

            Routing.RegisterRoute("AddingNotification", typeof(Projekt.Views.Home.AddingNotificationPage)); // rejestruje AddingNotification route
        }
    }
}
