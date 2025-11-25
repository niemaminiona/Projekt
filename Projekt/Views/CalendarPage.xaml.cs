

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

		for (int i = 0; i < 7; i++)
			CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
		for (int i = 0; i < 8; i++)
			CalendarGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

		var LeftSwitchButton = new Button //przycisk do prze³¹czania miesiêcy w lewo
        {
			Text = "<",
			FontSize = 30,
            BackgroundColor = Colors.White,
			TextColor = Colors.Black,
        };

        var RightSwitchButton = new Button //przycisk do prze³¹czania miesiêcy w prawo
        {
            Text = ">",
            FontSize = 30,
			BackgroundColor = Colors.White,
            TextColor = Colors.Black,
        };

	    SelectMonthBox = new Label //blok wyœwietlaj¹cy aktualny miesi¹c
        {
			Text = currentMonth.Name,
			FontSize = 20,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
		};


        


		//ustawienie pe³nego bloku bloku odpowiedzialnego za wybranie miesiaca <---
		CalendarGrid.SetRow(LeftSwitchButton, 0);
		CalendarGrid.SetColumn(LeftSwitchButton, 1);

		CalendarGrid.SetRow(RightSwitchButton, 0);
		CalendarGrid.SetColumn(RightSwitchButton, 5);

		CalendarGrid.SetRow(SelectMonthBox, 0);
		CalendarGrid.SetColumn(SelectMonthBox, 2);
        CalendarGrid.SetColumnSpan(SelectMonthBox, 3);
        LeftSwitchButton.Clicked += SwitchLeftCurrentMonth;
        RightSwitchButton.Clicked += RightSwitchButton_Clicked;
        //------>


        //tworzenie okienek kalendarza
		int dayCounter = 1;

		for(int rowsCounter = 1; rowsCounter <= 8; rowsCounter++)
		{
			

			for(int columnCounter = 0; columnCounter < 7; columnCounter++)
			{
                //jesli licznik dni przekroczy liczbe dni miesiaca petla sie konczy
                if (dayCounter > currentMonth.Days)
                {
                    break;
                }
                var dayWindow = new Label //okienko dnia
                {
                    FontSize = 20,
                    HorizontalTextAlignment = TextAlignment.End,
                    VerticalTextAlignment = TextAlignment.Start,
                }; //stworzenie wygladu jednego okienka kalendarza


                dayWindow.Text = dayCounter.ToString();
                CalendarGrid.SetRow(dayWindow, rowsCounter);
				CalendarGrid.SetColumn(dayWindow, columnCounter);
				dayCounter++;
                CalendarGrid.Children.Add(dayWindow);
            }
        }

        CalendarGrid.Children.Add(LeftSwitchButton);
        CalendarGrid.Children.Add(RightSwitchButton);
        CalendarGrid.Children.Add(SelectMonthBox);	
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