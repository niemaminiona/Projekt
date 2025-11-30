namespace Projekt.Views.Settings;

public partial class LanguageSettingsPage : ContentPage
{
	public LanguageSettingsPage()
	{
		InitializeComponent();
	}

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }
}