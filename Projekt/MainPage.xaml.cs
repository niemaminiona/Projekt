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

        private void CreateMainMenu()
        {
            //Main grid troche logiczne
            Grid mainGrid = new Grid()
            {
                Padding = 5,
                RowSpacing = 10,
                RowDefinitions =
                {
                    new RowDefinition { Height = 50 }, //Header
                    new RowDefinition { Height = 1 }, //Line
                    new RowDefinition { Height = GridLength.Star } //scrollView
                },
                BackgroundColor = Colors.White
            };

            //Header 
            Grid header = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star }, //button 1
                    new ColumnDefinition { Width = GridLength.Star }, //label
                    new ColumnDefinition { Width = GridLength.Star }  //button 2
                }
            };

            //te przyciski do headeru
            Button idkButton = new Button { 
                Text = "M", 
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Colors.Black,
                CornerRadius = 15,
                FontAttributes = FontAttributes.Bold
            };
            idkButton.Clicked += (sender, e) => { Content = null; };//usuwa strone, wsm nwm po co

            Button addButton = new Button { 
                Text = "+", 
                WidthRequest = 50,
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Colors.Black,
                CornerRadius = 15,
                FontAttributes = FontAttributes.Bold
            };
            addButton.Clicked += (sender, e) => { 
                listOfActiveNotifications.Add(new Notification(new Suplement("Magnesium"), 1, new DateTime(2020, 1, 1))); //na szybko dodane
                CreateMainMenu();
            };

            Label titleLabel = new Label
            {
                Text = "Aplikacja",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Colors.Black,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold
            };

            //dodaje przyciski do headeru
            header.Add(idkButton, 0, 0);
            header.Add(titleLabel, 1, 0);
            header.Add(addButton, 2, 0);


            //definiuje ten panel z ustawionymi powiadomieniami
            VerticalStackLayout notificationsLayout = new VerticalStackLayout
            {
                Spacing = 10,
            };

            //wyswietla te powiadomienia z listy
            foreach(Notification item in listOfActiveNotifications)
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
                    IsToggled = true,
                    OnColor = Colors.White,
                    ThumbColor = Colors.Black,

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
                deleteButton.Clicked += (sender, e) => { 
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
                    HasShadow = false,
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

            // Scrollable content
            ScrollView scroll = new ScrollView
            {
                Content = notificationsLayout
            };

            //dodaje wszystko
            mainGrid.Add(header);
            Grid.SetRow(header, 0);

            Label line = new Label() 
            {
                BackgroundColor = Colors.Black,
            };

            mainGrid.Add(line);
            Grid.SetRow(line, 1);

            mainGrid.Add(scroll);
            Grid.SetRow(scroll, 2);

            Content = null; //Czysci poprzednia strone
            Content = mainGrid;
        }

        //klasa powiadomienia
        private class Notification
        {
            private static int numberofInstances = 0;
            public int id;
            public Suplement suplement;
            public int amount;
            public DateTime date;
            public Notification(Suplement suplement, int amount, DateTime date)
            {
                this.id = numberofInstances;
                this.suplement = suplement;
                this.amount = amount;
                this.date = date;
                numberofInstances++;
            }
        }
        private class Suplement
        {
            public int id;
            public String name;
            public Suplement(String name)
            {
                this.name = name;
            }
        }
    }
}
