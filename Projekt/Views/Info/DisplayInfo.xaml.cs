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
        Suplement wybranySuplement = SuplementData.list.ElementAt(SuplementData.SelectedInfoIndex);
        Title.Text = wybranySuplement.name;
        DescriptionLabel.Text = wybranySuplement.description;
    }

    private async void GoToInfo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Info");
    }
}