using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Projekt.DataHandling; //Korzystanie w klas oraz danych z folderu Data

namespace Projekt.Views
{
    public partial class HomePage : ContentPage
    {



        //Glowny kod tutaj
        public HomePage()
        {
            InitializeComponent();

            CreateMainMenu();

            NotifData.list.CollectionChanged += (s, e) =>
            {
                // Za kazdym razem gdy dodasz lub usuniesz element odswiezy menu
                CreateMainMenu();
            };
        }
        //---------------




        //metoda ktora tworzy glowny ekran z powiadomieniami
        public void CreateMainMenu()
        {
            NotificationLayout.Children.Clear();// czysci poprzednie powiadomienia
            //jesli lista popwiadomien jest pusta to pokazuje napis
            //NotifData.Refresh();
            if (!NotifData.list.Any())
            {
                NotificationLayout.Children.Add(new Label
                {
                    Text = "You have no notifications.",
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 40, 0, 40),
                    TextColor = Colors.Gray,
                    FontSize = 15
                });
            }
            //jesli nie to wypisuje powiadomienia
            else
            {
                //wyswietla te powiadomienia z listy
                foreach (Notif item in NotifData.list)
                {
                    //budowa powiadomienia pojedynczego
                    Grid notifGrid = new Grid()
                    {
                        ColumnDefinitions =
                        {
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },  // *
                            new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },  // 2*
                            new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },  // 2*
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },  // *
                        }
                    };

                    var switcher = new Switch()
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        OnColor = Color.FromArgb("#E0FDFF"),
                        ThumbColor = Colors.Black,
                        Shadow = new Shadow
                        {
                            Brush = Colors.Black,
                            Opacity = 0.25f
                        }
                    };
                    if (item.toggled)
                    {
                        switcher.IsToggled = true;
                    }
                    switcher.Toggled += (sender, e) =>
                    {
                        if (e.Value)
                        {
                            item.toggled = true;
                        }
                        else
                        {
                            item.toggled = false;
                        }
                    };

                    var nameLabel = new Label()
                    {
                        Text = item.suplement.name,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        TextColor = Colors.Black
                    };

                    var dateLabel = new Label()
                    {
                        Text = item.date.ToString(),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        TextColor = Colors.Black
                    };

                    var deleteButton = new ImageButton()
                    {
                        HorizontalOptions = LayoutOptions.End,
                        BackgroundColor = Color.FromArgb("#D62929"),
                        WidthRequest = 50,
                        HeightRequest = 50,
                        CornerRadius = 15,
                        Source = "delete.svg",
                        Aspect = Aspect.AspectFit,
                        //Padding = 0
                    };
                    deleteButton.Clicked += async (sender, e) =>
                    {
                        NotifData.list.Remove(item);
                        //await NotifData.Save();
                        CreateMainMenu();
                    };

                    //pakuje wszystkie kontrolki do bordera ktory tworzy tlo
                    Border border = new Border
                    {
                        StrokeShape = new RoundRectangle
                        {
                            CornerRadius = 15
                        },
                        BackgroundColor = Colors.LightGrey,
                        Padding = 10,
                        Shadow = new Shadow
                        {
                            Brush = Colors.Black,
                            Opacity = 0.25f,
                            Offset = new Point(5, 5),
                            Radius = 10
                        },
                        Content = notifGrid
                    };



                    //dodaje wszystko
                    notifGrid.Children.Add(switcher);
                    notifGrid.Children.Add(nameLabel);
                    notifGrid.Children.Add(dateLabel);
                    notifGrid.Children.Add(deleteButton);
                    notifGrid.SetColumn(switcher, 0);
                    notifGrid.SetColumn(nameLabel, 1);
                    notifGrid.SetColumn(dateLabel, 2);
                    notifGrid.SetColumn(deleteButton, 3);

                    NotificationLayout.Children.Add(border);
                } // <--------- koniec foreach
            }
            Button btn = new()
            {
                Text = "Add",
                BackgroundColor = Color.FromArgb("#1a1a1a")
            };

            btn.Clicked += GoToAddingNotification!;

            NotificationLayout.Children.Add(btn);
        }
        private async void GoToAddingNotification(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AddingNotification");
        }
    }
        
}
