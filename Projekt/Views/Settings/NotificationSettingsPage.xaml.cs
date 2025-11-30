using Projekt.DataHandling;

namespace Projekt.Views.Settings;

public partial class NotificationSettingsPage : ContentPage
{
	public NotificationSettingsPage()
	{
		InitializeComponent();

        NotificationEnableSwitch.IsToggled = SettingsData.NotificationEnabled; 

    }

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

    private void NotificationEnableSwitchToggled(object sender, ToggledEventArgs e)
    {
        SettingsData.NotificationEnabled = e.Value;
    }
}