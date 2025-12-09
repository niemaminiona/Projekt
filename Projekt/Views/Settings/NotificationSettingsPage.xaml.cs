using Projekt.DataHandling;

namespace Projekt.Views.Settings;

public partial class NotificationSettingsPage : ContentPage
{
	public NotificationSettingsPage()
	{
		InitializeComponent();

        NotificationEnableSwitch.IsToggled = DataService.Settings.NotificationEnabled; 

    }

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

    private void NotificationEnableSwitchToggled(object sender, ToggledEventArgs e)
    {
        DataService.Settings.NotificationEnabled = e.Value;
    }
}