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
		BMIFrame.FontSize = 15;
		BMIFrame.Text = BMILevel;
    }

	private void BMI()
	{
		double BMI = bodyWeight / (bodyHeight/100);

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
	}

	private void BMR()
	{

	}
	
}