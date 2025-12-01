using Microsoft.Maui.Controls.Shapes;
using Projekt.DataHandling;

namespace Projekt.Views;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();

		CreateInfo();
	}

	private void CreateInfo()
	{
        InfoLayout.Children.Clear();
		if (!SuplementData.list.Any())
		{
			InfoLayout.Children.Add(new Label
			{
				Text = "No suplements found in database!"
			});

		}
		else
		{
			foreach (Suplement item in SuplementData.list)
			{
                Grid mainGrid = new()
                {
                    ColumnDefinitions =
					{
						new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					},
                    RowDefinitions =
					{
						new RowDefinition { Height = new GridLength(5, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					}
                };
				var titleLabel = new Label()
				{
					Text = item.name,
					FontSize = 30,
					FontAttributes = FontAttributes.Bold,
                    //BackgroundColor = Colors.Green
				};
                var descriptionLabel = new Label()
                {
                    Text = item.description,
                    LineBreakMode = LineBreakMode.TailTruncation // dodaje "..."

                };

				var ContinueImage = new Image
				{
					Source = "continue_icon.svg",
					HeightRequest = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    //BackgroundColor = Colors.Lime
                };

                mainGrid.Children.Add(titleLabel);
                Grid.SetColumn(titleLabel, 0);
                Grid.SetColumnSpan(titleLabel, 1);
                Grid.SetRow(titleLabel, 0);

                mainGrid.Children.Add(descriptionLabel);
                Grid.SetColumn(descriptionLabel, 0);
                Grid.SetRow(descriptionLabel, 1);

                mainGrid.Children.Add(ContinueImage);
                Grid.SetColumn(ContinueImage, 1);
                Grid.SetRowSpan(ContinueImage, 2);
                Grid.SetRow(ContinueImage, 0);

                Border border = new Border
                {
                    StrokeShape = new RoundRectangle
                    {
                        CornerRadius = 15
                    },
                    BackgroundColor = Colors.LightGrey,
					Padding = 10,
                    //Shadow = new Shadow
                    //{
                    //    Brush = Colors.Black,
                    //    Opacity = 0.25f,
                    //    Offset = new Point(5, 5),
                    //    Radius = 10
                    //},
                    Content = mainGrid
                };


				InfoLayout.Children.Add(border);
            }
        }
	}
}