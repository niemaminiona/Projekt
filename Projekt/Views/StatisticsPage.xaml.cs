namespace Projekt.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();
	}

	private double bodyWeight;
	private double bodyHeight;

	private string BMILevel = "";
	private string BMRLevel = "";

	private string BenchPress = "";
	private string Squat1 = "";
	private string Deadlift = "";


    private void Button_Clicked(object sender, EventArgs e)
    {
		 bodyWeight = Convert.ToDouble(Weight.Text);
		 bodyHeight = Convert.ToDouble(Height.Text);

		BMI();
		RM1Weight();
		
    }

	private void BMI()
	{
		double BMI = Math.Round(bodyWeight / Math.Pow((bodyHeight/100),2), 1);
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
        BMIFrame.FontSize = 11;
        BMIFrame.Text = BMILevel;
    }

	private void BMR()
	{

	}

	private void RM1Weight()
	{
		BenchPress = Convert.ToString(bodyWeight * 1 + "kg");
		Deadlift = Convert.ToString(bodyWeight * 1.5 + "kg");
		Squat1 = Convert.ToString(bodyWeight * 2.0 + "kg");

		BenchPress1RM.Text = BenchPress;
		Deadlift1RM.Text = Deadlift;
		Squat1RM.Text = Squat1;

		BenchPress1RM.FontSize = 15;
		Deadlift1RM.FontSize = 15;
		Squat1RM.FontSize = 15;


	}

}