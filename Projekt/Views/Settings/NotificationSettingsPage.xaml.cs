namespace Projekt.Views.Settings;

public partial class NotificationSettingsPage : ContentPage
{
	public NotificationSettingsPage()
	{
		InitializeComponent();
	}

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}