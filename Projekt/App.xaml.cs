using Projekt.DataHandling;

namespace Projekt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
        protected override void OnSleep()
        {
            base.OnSleep();
            // zapisuje ustawienia przy usypianiu/zamknieciu aplikacji
            Task.Run(async () => await DatabaseService.JSON.SaveSettingsAsync());
        }

        protected override void OnStart()
        {
            base.OnStart();
            // laduje ustawienia przy starcie aplikacji
            Task.Run(async () => await DatabaseService.JSON.LoadSettingsAsync());
        }
    }
}