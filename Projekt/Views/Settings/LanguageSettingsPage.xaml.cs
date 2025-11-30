namespace Projekt.Views.Settings;

public partial class LanguageSettingsPage : ContentPage
{
	public LanguageSettingsPage()
	{
		InitializeComponent();

        LanguagePicker.SelectedIndex = 0;
	}

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }
}