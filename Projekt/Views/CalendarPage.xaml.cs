namespace Projekt.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage()
	{
		InitializeComponent();
		CreateMonthsList();
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

	private void CreateMonthsList()
	{
		Months.Add(new Month("January", 31));
		Months.Add(new Month("February", 28));
		Months.Add(new Month("March", 31));
		Months.Add(new Month("April", 30));
		Months.Add(new Month("May", 31));
		Months.Add(new Month("June", 30));
		Months.Add(new Month("July", 31));
		Months.Add(new Month("August", 31));
		Months.Add(new Month("September", 30));
		Months.Add(new Month("October", 31));
		Months.Add(new Month("November", 30));
		Months.Add(new Month("December", 31));
    }
	



}