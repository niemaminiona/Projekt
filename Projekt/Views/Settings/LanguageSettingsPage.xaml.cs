using Projekt.DataHandling;

namespace Projekt.Views.Settings;

public partial class LanguageSettingsPage : ContentPage
{
	public LanguageSettingsPage()
	{
		InitializeComponent();

        DatabaseService.JSON.Settings.QuickLoad(); // odswieza dane (pobiera z pliku)

        LanguagePicker.SelectedIndex = DataService.Settings.Language;
	}

    private async void GoToSettings(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Settings");
    }

    private void LanguagePickerChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex == -1) return; // nic nie zaznaczono
        DataService.Settings.Language = (short)picker.SelectedIndex;

        DatabaseService.JSON.Settings.QuickSave(); // zapisuje dane
    }
}