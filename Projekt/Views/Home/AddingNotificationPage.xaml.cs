using Projekt.DataHandling;

namespace Projekt.Views.Home;

public partial class AddingNotificationPage : ContentPage
{
    public AddingNotificationPage()
    {
        InitializeComponent();

        foreach (Suplement item in DataService.Suplements.list)
        {
            SuplementPicker.Items.Add(item.name);
        }
    }

    private async void GoToHome(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Home");
    }
    private async void VerifyAdding(object sender, EventArgs e)
    {
        ErrorLayout.Children.Clear();

        bool isValid = true;

        if(SuplementPicker.SelectedIndex < 0)
        {
            AddError("Select Suplement.");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(AmountEntry.Text))
        {
            AddError("Enter amount.");
            isValid = false;
        }
        else if(!Int32.TryParse(AmountEntry.Text, out int x))
        {
            AddError("Enter number.");
            isValid = false;
        }

        if (isValid)
        {
            DataService.Notifications.list.Add(new Notif(new Suplement(SuplementPicker.SelectedIndex), int.Parse(AmountEntry.Text), DatePicker.Date + TimePicker.Time));
            await Shell.Current.GoToAsync("//Home");
        }
    }

    private void AddError(string message)
    {
        ErrorLayout.Children.Add(new Label
        {
            Text = message,
            TextColor = Colors.Red,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        });
    }

    private async void AddRandom(object sender, EventArgs e)
    {
        DataService.Notifications.AddRandomNotif();
        DataService.Notifications.AddRandomNotif();
        DataService.Notifications.AddRandomNotif();
        DataService.Notifications.AddRandomNotif();

        await Shell.Current.GoToAsync("//Home");
    }
}