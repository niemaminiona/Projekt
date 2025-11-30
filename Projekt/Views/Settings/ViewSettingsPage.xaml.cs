namespace Projekt.Views.Settings;

public partial class ViewSettingsPage : ContentPage
{
	public ViewSettingsPage()
	{
		InitializeComponent();

        ThemePicker.SelectedIndex = 0;
	}
    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }
}