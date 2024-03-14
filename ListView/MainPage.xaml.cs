
namespace ListView
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();

			if (OperatingSystem.IsOSPlatform("iOS"))
			{
				listView.BackgroundColor = Colors.White;
			}

			listView.ItemsSource = new List<string>() { "One", "Two", "Three" };
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;

			if (count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";

			SemanticScreenReader.Announce(CounterBtn.Text);
		}
	}

}
