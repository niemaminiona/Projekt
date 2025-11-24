using Windows.Security.Cryptography.Core;

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
    }
    private void CreateCalendarLayout()
	{
		currentMonth = Months[0];
        Grid CalendarGrid = new Grid();//utworzenie grida

		for (int i = 0; i < 7; i++)
			CalendarGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
		for (int i = 0; i < 8; i++)
			CalendarGrid.RowDefinitions.Add(new RowDefinition(GridLength.Star));

		var LeftSwitchButton = new Button
		{
			Text = "<",
			FontSize = 40,
            BackgroundColor = Colors.White,
			TextColor = Colors.Black,
        };

        var RightSwitchButton = new Button
        {
            Text = ">",
            FontSize = 40,
			BackgroundColor = Colors.White,
            TextColor = Colors.Black,
        };

	    SelectMonthBox = new Label
		{
			Text = currentMonth.Name,
			FontSize = 30,
			HorizontalTextAlignment = TextAlignment.Center,
			VerticalTextAlignment = TextAlignment.Center,
		};


        var dayWindow = new Label
		{
			Text = currentMonth.Days.ToString(),
			FontSize = 20,
			HorizontalTextAlignment = TextAlignment.End,
			VerticalTextAlignment = TextAlignment.Start,
		}; //stworzenie wygladu jednego okienka kalendarza

		//ustawienie bloku odpowiedzialnego za wybranie miesiaca
		CalendarGrid.SetRow(LeftSwitchButton, 0);
		CalendarGrid.SetColumn(LeftSwitchButton, 2);

		CalendarGrid.SetRow(RightSwitchButton, 0);
		CalendarGrid.SetColumn(RightSwitchButton, 4);

		CalendarGrid.SetRow(SelectMonthBox, 0);
		CalendarGrid.SetColumn(SelectMonthBox, 3);

        LeftSwitchButton.Clicked += SwitchLeftCurrentMonth;
        RightSwitchButton.Clicked += RightSwitchButton_Clicked;

		CalendarGrid.Children.Add(LeftSwitchButton);
        CalendarGrid.Children.Add(RightSwitchButton);
        CalendarGrid.Children.Add(SelectMonthBox);
		this.Content = CalendarGrid;
    }

    private void RightSwitchButton_Clicked(object? sender, EventArgs e)
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
    }

    private void SwitchLeftCurrentMonth(object? sender, EventArgs e)
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
    }
}