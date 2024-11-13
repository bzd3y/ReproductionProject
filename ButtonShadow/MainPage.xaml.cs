using Microsoft.Maui.Controls.Shapes;

namespace ButtonShadow
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
			VerticalStackLayout views = [];

			for (int i = 0; i < 50; i++)
			{
				Picker picker = new()
				{
					Title = "Placeholder"
				};

				Button clearButton = new()
				{
					Padding = 0,
					FontSize = 20,
					Text = "\x00D7"
				};

				clearButton.SizeChanged += (s, e) =>
				{
					clearButton.WidthRequest = clearButton.Height;
				};

				clearButton.Clicked += async (s, e) =>
				{
					//picker.SelectedIndex = -1;

					await Navigation.PushAsync(new MainPage());
				};

				Grid view = new()
				{
					ColumnDefinitions = [new ColumnDefinition(GridLength.Star), new ColumnDefinition(GridLength.Auto)]
				};

				view.Add(picker, 0);
				view.Add(clearButton, 1);

				views.Add(new Border()
				{
					StrokeShape = new RoundRectangle()
					{

					},
					StyleClass = ["UIBorder"],
					Content = view
				});
			}

			Content = new ScrollView()
			{
				Content = views
			};
		}
	}
}
