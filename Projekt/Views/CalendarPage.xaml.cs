

using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;

namespace Projekt.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
		CreateMonthsList();
        CreateCalendarLayout();
	}

	private class Month
	{
		public string? Name { get; set; }
		public int Days { get; set; }

        public Month(string Name, int Days)
        {
            this.Name = Name;
			this.Days = Days;
        }
    }

	List<Month> Months = new List<Month>();
	private Month currentMonth;
	private Label SelectMonthBox;
    private void CreateMonthsList()
	{
		Months.Add(new Month("Styczeñ", 31));
		Months.Add(new Month("Luty", 28));
		Months.Add(new Month("Marzec", 31));
		Months.Add(new Month("Kwiecieñ", 30));
		Months.Add(new Month("Maj", 31));
		Months.Add(new Month("Czerwiec", 30));
		Months.Add(new Month("Lipiec", 31));
		Months.Add(new Month("Sierpieñ", 31));
		Months.Add(new Month("Wrzeœieñ", 30));
		Months.Add(new Month("PaŸdziernik", 31));
		Months.Add(new Month("Listopad", 30));
		Months.Add(new Month("Grudzieñ", 31));
        currentMonth = Months[0];
    }
    private void CreateCalendarLayout()
	{
        Grid CalendarGrid = new Grid();//utworzenie grida

        //style Girda
        CalendarGrid.RowSpacing = 1;
        CalendarGrid.ColumnSpacing = 1;
        CalendarGrid.BackgroundColor = Colors.LightSlateGrey;

		for (int i = 0; i < 7; i++)
			CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
		for (int i = 0; i < 9; i++)
			CalendarGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

        var CalendarHeader = new Label
        {
            Text = "kalendarz",
            FontSize = 40,
            TextColor = Colors.Tomato,
            FontAttributes = FontAttributes.Bold,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
        };
		var LeftSwitchButton = new Button //przycisk do prze³¹czania miesiêcy w lewo
        {
			Text = "<",
			FontSize = 30,
            FontAttributes = FontAttributes.Bold,
            BackgroundColor = Colors.LightSlateGrey,
			TextColor = Colors.Black,
        };

        var RightSwitchButton = new Button //przycisk do prze³¹czania miesiêcy w prawo
        {
            Text = ">",
            FontSize = 30,
            FontAttributes = FontAttributes.Bold,
            BackgroundColor = Colors.LightSlateGrey,
            TextColor = Colors.Black,
        };

        SelectMonthBox = new Label //blok wyœwietlaj¹cy aktualny miesi¹c
        {
            Text = currentMonth.Name,
            FontSize = 25,
            FontAttributes = FontAttributes.Italic,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center,
        };



        //ustawienie nag³ówka kalendarza
        CalendarGrid.SetRow(CalendarHeader, 0);
        CalendarGrid.SetColumn(CalendarHeader, 0);
        CalendarGrid.SetColumnSpan(CalendarHeader, 7);
		//ustawienie pe³nego bloku bloku odpowiedzialnego za wybranie miesiaca <---
		CalendarGrid.SetRow(LeftSwitchButton, 1);
		CalendarGrid.SetColumn(LeftSwitchButton, 1);

		CalendarGrid.SetRow(RightSwitchButton, 1);
		CalendarGrid.SetColumn(RightSwitchButton, 5);

		CalendarGrid.SetRow(SelectMonthBox, 1);
		CalendarGrid.SetColumn(SelectMonthBox, 2);
        CalendarGrid.SetColumnSpan(SelectMonthBox, 3);
        LeftSwitchButton.Clicked += SwitchLeftCurrentMonth;
        RightSwitchButton.Clicked += RightSwitchButton_Clicked;
        //------>


        //tworzenie okienek kalendarza
		int dayCounter = 1;

		for(int rowsCounter = 2; rowsCounter <= 10; rowsCounter++)
		{
			

			for(int columnCounter = 0; columnCounter < 7; columnCounter++)
			{
                //jesli licznik dni przekroczy liczbe dni miesiaca petla sie konczy
                if (dayCounter > currentMonth.Days)
                {
                    break;
                }
                var dayWindow = new Border
                {
                    Background = Colors.LightGray,
                    Stroke = Colors.Red,
                    StrokeThickness = 1,
                    Padding = new Thickness(3),
                    Margin = new Thickness(1),
                    StrokeShape = new RoundRectangle { CornerRadius = 6 },

                    Content = new Label
                    {
                        Text = dayCounter.ToString(),
                        FontSize = 18,
                        HorizontalTextAlignment = TextAlignment.End,
                        VerticalTextAlignment = TextAlignment.Start,
                        TextColor = Colors.Black,
                    }
                }; //stworzenie wygladu jednego okienka kalendarza

                
                CalendarGrid.SetRow(dayWindow, rowsCounter);
				CalendarGrid.SetColumn(dayWindow, columnCounter);
				dayCounter++;
                CalendarGrid.Children.Add(dayWindow);
            }
        }

        CalendarGrid.Children.Add(LeftSwitchButton);
        CalendarGrid.Children.Add(RightSwitchButton);
        CalendarGrid.Children.Add(SelectMonthBox);
        CalendarGrid.Children.Add(CalendarHeader);
        this.Content = CalendarGrid;
    }

    private void RightSwitchButton_Clicked(object? sender, EventArgs e) //Funkcja oblsugujaca przycisk prze³¹czania miesiêcy w prawo
    {
        if (currentMonth == Months[Months.Count - 1])
        {
            return;
        }
        else
        {
            int currentIndex = Months.IndexOf(currentMonth);
            currentMonth = Months[currentIndex + 1];
			SelectMonthBox.Text = currentMonth.Name;
        }

        //po zmianie miesiaca cala zawartosc znika i generuje sie na nowo z nowym miesiacem
        this.Content = null;
        CreateCalendarLayout();
    }

    private void SwitchLeftCurrentMonth(object? sender, EventArgs e) //Funkcja oblsugujaca przycisk prze³¹czania miesiêcy w lewo
    {
        if (currentMonth == Months[0])
        {
            return;
        }
        else
        {
            int currentIndex = Months.IndexOf(currentMonth);
            currentMonth = Months[currentIndex - 1];
            SelectMonthBox.Text = currentMonth.Name;
        }

        //po zmianie miesiaca cala zawartosc znika i generuje sie na nowo z nowym miesiacem
        this.Content = null;
        CreateCalendarLayout();
    }
}