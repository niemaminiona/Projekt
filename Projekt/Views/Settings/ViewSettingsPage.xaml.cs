using Projekt.DataHandling;

namespace Projekt.Views.Settings;


public partial class ViewSettingsPage : ContentPage
{
	public ViewSettingsPage()
	{
		InitializeComponent();

        ThemePicker.SelectedIndex = SettingsData.Theme;
	}
    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

    private void ThemePickerChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex == -1) return; // nic nie zaznaczono
        SettingsData.Theme = (short)picker.SelectedIndex;
    }
}