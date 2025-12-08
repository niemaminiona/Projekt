using Projekt.DataHandling;

namespace Projekt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Load supplements when app starts
            Task.Run(async () =>
            {
                await SuplementData.LoadSupplements();
                Console.WriteLine("CODE THAT THIS TASK RUNS <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            });


        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}