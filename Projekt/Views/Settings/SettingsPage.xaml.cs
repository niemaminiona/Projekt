namespace Projekt.Views.Settings;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}
    private async void GoToNotificationSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("NotificationSettings");
    }

    private async void GoToViewSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ViewSettings");
    }

    private async void GoToLanguageSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LanguageSettings");
    }
    private async void GoToDataSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("DataSettings");
    }
}