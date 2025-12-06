namespace Projekt.Views.Settings;

public partial class DataSettingsPage : ContentPage
{
	public DataSettingsPage()
	{
		InitializeComponent();
	}
    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

}