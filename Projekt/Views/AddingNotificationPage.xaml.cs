using Projekt.DataHandling;

namespace Projekt.Views;

public partial class AddingNotificationPage : ContentPage
{
    public AddingNotificationPage()
    {
        InitializeComponent();
    }

    private async void GoToHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
    }
    private void SuplementPickerChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (picker.SelectedIndex == -1) return; // nic nie zaznaczono
        //SettingsData.Language = (short)picker.SelectedIndex;
    }
}