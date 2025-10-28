using Microsoft.Maui.Controls;

namespace Projekt
{
    public partial class MainPage : ContentPage
    {
        List<Notification> listOfActiveNotifications = new List<Notification>();

        public MainPage()
        {
            InitializeComponent();

            listOfActiveNotifications.Add(new Notification(new Suplement("Magnesium"), 1, new DateTime(2025, 8, 25)));
            listOfActiveNotifications.Add(new Notification(new Suplement("Potasium"), 3, new DateTime(2025, 8, 28)));
            listOfActiveNotifications.Add(new Notification(new Suplement("Creatine"), 1, new DateTime(2025, 8, 24)));

            CreateMainMenu();
        }

        //metoda ktora tworzy glowny ekran z powiadomieniami
        private void CreateMainMenu()
        {
            //definiuje ten panel z ustawionymi powiadomieniami
            VerticalStackLayout notificationsLayout = new VerticalStackLayout
            {
                Spacing = 10,
                Padding = 10
            };

            //jesli lista popwiadomien jest pusta to pokazuje napis
            if (!listOfActiveNotifications.Any())
            {
                notificationsLayout.Children.Add(new Label
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
                        OnColor = Colors.White,
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
                        VerticalOptions = LayoutOptions.Center
                    };

                    var dateLabel = new Label()
                    {
                        Text = item.date.ToString(),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    var deleteButton = new Button()
                    {
                        HorizontalOptions = LayoutOptions.End,
                        BackgroundColor = Colors.Crimson,
                        Text = "X",
                        WidthRequest = 50,
                        HeightRequest = 50,
                        CornerRadius = 15,
                        FontSize = 20
                    };
                    deleteButton.Clicked += (sender, e) =>
                    {
                        listOfActiveNotifications.Remove(item);
                        CreateMainMenu();
                    };

                    //pakuje wszystko w frame zeby ladnie to wygladalo
                    //wywala blad zeby uzyc "border" ale border nie ma corner radius wiec nie bardzo jest wybor
                    var frame = new Frame
                    {
                        CornerRadius = 15,
                        BackgroundColor = Colors.LightGrey,
                        Padding = 10,
                        HasShadow = true,
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

                    notificationsLayout.Children.Add(frame);
                }


            }

            // dodaje wszystko zeby bylo widac ladnie
            Content = null; // usuwa poprzedni stan jesli jakis byl
            Content = new ScrollView
            {
                Content = notificationsLayout
            };
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
