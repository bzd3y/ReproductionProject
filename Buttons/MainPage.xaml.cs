namespace Buttons
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;

			if (count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";

			CounterBtn.Text = "dot net bot in a race car number eight dot net bot in a race car number eight dot net bot in a race car number eight dot net bot in a race car number eight";

			SemanticScreenReader.Announce(CounterBtn.Text);
		}
	}

}
