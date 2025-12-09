using Projekt.DataHandling;

namespace Projekt.Views.Info;

public partial class DisplayInfo : ContentPage
{
	public DisplayInfo()
	{
		InitializeComponent();

        CreateInfo();
	}

    private void CreateInfo()
    {
        Suplement wybranySuplement = DataService.Suplements.list.ElementAt(DataService.Suplements.SelectedInfoIndex);
        Title.Text = wybranySuplement.name;
        DescriptionLabel.Text = wybranySuplement.description;
    }

    private async void GoToInfo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Info");
    }
}