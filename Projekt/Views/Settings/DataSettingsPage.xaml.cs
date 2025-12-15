using Projekt.DataHandling;

namespace Projekt.Views.Settings;

public partial class DataSettingsPage : ContentPage
{
	public DataSettingsPage()
	{
		InitializeComponent();

        DatabaseService.JSON.Settings.QuickLoad(); // odswieza dane (pobiera z pliku)
    }
    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

    private void ClearData(object sender, EventArgs e)
    {
        Task.Run(async () => await DatabaseService.SQLite.ForceFreshDatabase()).Wait();
        Task.Run(async () => await DataService.Suplements.LoadSupplements());
        
    }

}