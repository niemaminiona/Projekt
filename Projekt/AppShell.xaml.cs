namespace Projekt
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            GoToAsync("//Home"); // strona z routem "Home" otworzy sie pierwsza

            Routing.RegisterRoute("Settings", typeof(Projekt.Views.Settings.SettingsPage)); // rejestruje Settings route
            Routing.RegisterRoute("NotificationSettings", typeof(Projekt.Views.Settings.NotificationSettingsPage)); // rejestruje NotificationSettings route
        }
    }
}
