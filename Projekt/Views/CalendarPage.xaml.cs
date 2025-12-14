using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;
using Projekt.DataHandling;

namespace Projekt.Views;

public partial class CalendarPage : ContentPage
{
    public CalendarPage()
    {
        InitializeComponent();
        CreateCalendarLayout();
    }


    private DateTime currentDate = DateTime.Now; // zmienna ktora przechowuje aktualna date
    private DateTime selectedDate = DateTime.Now; // data ktora jest aktualnie wyswietlana w kalendarzu

    public List<Notif> NotificationList = new List<Notif>();//lista na powiadomienia

    private void CreateCalendarLayout()
    {
        CalendarGrid.Children.Clear();
        NotificationList = new List<Notif>(DataService.Notifications.list); // pobiera liste

        var notifDates = NotificationList.Select(n => n.date.Date).ToHashSet(); // pobiera same daty z listy 

        //tworzenie okienek kalendarza
        monthLabel.Text = selectedDate.ToString("MMMM");
        yearLabel.Text = selectedDate.ToString("yyyy");

        int dayCounter = 1;
        for (int rowsCounter = 0; rowsCounter <= 6; rowsCounter++)
        {
            for (int columnCounter = 0; columnCounter < 7; columnCounter++)
            {
                //jesli licznik dni przekroczy liczbe dni miesiaca petla sie konczy
                if (dayCounter > DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month))
                {
                    break;
                }
                //stworzenie wygladu jednego okienka kalendarza
                var dayWindow = new Border
                {
                    Stroke = Colors.Black,
                    HeightRequest = 75,
                    StrokeThickness = 2,
                    Padding = 5,
                    StrokeShape = new RoundRectangle 
                    { 
                        CornerRadius = 6,
                    },

                    Content = new Label
                    {
                        Text = dayCounter.ToString(),
                        FontSize = 18,
                        HorizontalTextAlignment = TextAlignment.End,
                        VerticalTextAlignment = TextAlignment.Start,
                        TextColor = Colors.Black,
                        FontAttributes = FontAttributes.Bold
                    }
                };
                

                //dodawanie powiadomien do kalendarza
                var currentDay = new DateTime(selectedDate.Year, selectedDate.Month, dayCounter);
                if (notifDates.Any())
                {
                    foreach (var notif in notifDates)
                    {
                        if (notifDates.Contains(currentDay))
                        {
                            dayWindow.BackgroundColor = Color.FromArgb("#afffa1");
                        }
                        else
                        {
                            dayWindow.BackgroundColor = Colors.LightGrey;
                        }
                    }
                }
                else
                {
                    dayWindow.BackgroundColor = Colors.LightGrey;
                }

                if (currentDay == currentDate.Date)
                {
                    dayWindow.Stroke = Colors.Blue;
                }


                CalendarGrid.SetRow(dayWindow, rowsCounter);
                CalendarGrid.SetColumn(dayWindow, columnCounter);
                CalendarGrid.Children.Add(dayWindow);

                dayCounter++;
            }
        }
        calendarBorder.Content = CalendarGrid;
    }

    //Funkcja oblsugujaca przycisk prze³¹czania miesiêcy w prawo
    private void RightSwitchButton_Clicked(object? sender, EventArgs e) 
    {
        selectedDate = selectedDate.AddMonths(1);

        //po zmianie miesiaca cala zawartosc znika i generuje sie na nowo z nowym miesiacem
        CreateCalendarLayout();
    }

    //Funkcja oblsugujaca przycisk prze³¹czania miesiêcy w lewo
    private void LeftSwitchButton_Clicked(object? sender, EventArgs e) 
    {
        selectedDate = selectedDate.AddMonths(-1);
        CreateCalendarLayout();
    }

    //metoda wywolujaca odswiezenie za kazdym wczytaniem strony
    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        selectedDate = currentDate;
        CreateCalendarLayout();
    }

}