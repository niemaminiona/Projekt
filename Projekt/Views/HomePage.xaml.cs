using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Projekt.Views
{
    public partial class HomePage : ContentPage
    {
        List<Notification> listOfActiveNotifications = new List<Notification>();

        public HomePage()
        {
            InitializeComponent();

            for (int i = 0; i < 15; i++)
            {
                listOfActiveNotifications.Add(new Notification(new Suplement("Magnesium"), 1, new DateTime(2025, 8, 25)));
            }

            CreateMainMenu();
        }

        //metoda ktora tworzy glowny ekran z powiadomieniami
        private void CreateMainMenu()
        {
            NotificationLayout.Children.Clear();// czysci poprzednie powiadomienia
            //jesli lista popwiadomien jest pusta to pokazuje napis
            if (!listOfActiveNotifications.Any())
            {
                NotificationLayout.Children.Add(new Label
                {
                    Text = "You have no notifications.",
                    HorizontalOptions = LayoutOptions.Center,
                    Margin = new Thickness(0, 40, 0, 0),
                    TextColor = Colors.Gray,
                    FontSize = 15
                });
            }
            //jesli nie to wypisuje powiadomienia
            else
            {
                //wyswietla te powiadomienia z listy
                foreach (Notification item in listOfActiveNotifications)
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
                    deleteButton.Clicked += (sender, e) =>
                    {
                        listOfActiveNotifications.Remove(item);
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
                }


            }
        }

        //klasa powiadomienia
        private class Notification
        {
            private static int numberofInstances = 0;
            public int id;
            public Suplement suplement;
            public int amount;
            public DateTime date;
            public Boolean toggled;
            public Notification(Suplement suplement, int amount, DateTime date, Boolean toggled = true)
            {
                this.id = numberofInstances;
                this.suplement = suplement;
                this.amount = amount;
                this.date = date;
                this.toggled = toggled;
                numberofInstances++;
            }
        }
        private class Suplement
        {
            public String name;
            public Suplement(String name)
            {
                this.name = name;
            }
        }
    }
}
