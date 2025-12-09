namespace Projekt.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
	}

    //Stworzenie zmiennych globalnych do przechowywania danych
    private double bodyWeight;
	private double bodyHeight;

	private string BMILevel = "";
	private string BMRLevel = "";

	private string BenchPress = "";
	private string Squat1 = "";
	private string Deadlift = "";


    private void Button_Clicked(object sender, EventArgs e)
    {
        //Pobranie danych od uzyytkownika
        bodyWeight = Convert.ToDouble(Weight.Text);
		 bodyHeight = Convert.ToDouble(Height.Text);

		//Wywo³ywanie metod
		BMI();
		RM1Weight();
		
    }

	private void BMI()
	{
        //obliczanie BMI
        double BMI = Math.Round(bodyWeight / Math.Pow((bodyHeight/100),2), 1);

        //Okreœlenie poziomu BMI
        if (BMI < 18.5)
		{
			BMILevel = $"{BMI} niedowaga!";
			BMIFrame.TextColor = Colors.Red;
		}

		if (BMI > 18.5 && BMI < 24.9)
		{
			BMILevel = $"{BMI}  waga prawid³owa!";
            BMIFrame.TextColor = Colors.Green;
        }

		if(BMI > 24.9)
		{
            BMILevel = $"{BMI}  nadwaga!";
            BMIFrame.TextColor = Colors.Red;
		}

        //Wypisywanie wyniku na ekran
        BMIFrame.FontSize = 11;
        BMIFrame.Text = BMILevel;
    }

	private void BMR()
	{

	}

	private void RM1Weight()
	{
		//obliczanie
		BenchPress = Convert.ToString(bodyWeight * 1 + "kg");
		Deadlift = Convert.ToString(bodyWeight * 1.5 + "kg");
		Squat1 = Convert.ToString(bodyWeight * 2.0 + "kg");

        //Wypisywanie wyników na ekran
        BenchPress1RM.Text = BenchPress;
		Deadlift1RM.Text = Deadlift;
		Squat1RM.Text = Squat1;

        //zmiany wielkoœci czcionki
        BenchPress1RM.FontSize = 15;
		Deadlift1RM.FontSize = 15;
		Squat1RM.FontSize = 15;
	}

}