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
	



}