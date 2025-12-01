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
        Title.Text = SuplementData.list.ElementAt(SuplementData.SelectedInfoIndex).name;
    }

    private async void GoToInfo(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Info");
    }
}