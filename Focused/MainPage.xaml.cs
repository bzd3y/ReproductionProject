namespace Focused
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

			SemanticScreenReader.Announce(CounterBtn.Text);
		}

		private void TimePicker_Focused(object sender, FocusEventArgs e)
		{

		}

		private void TimePicker_Unfocused(object sender, FocusEventArgs e)
		{

		}

		private void DatePicker_Focused(object sender, FocusEventArgs e)
		{

		}

		private void DatePicker_Unfocused(object sender, FocusEventArgs e)
		{

		}

		private void Entry_Unfocused(object sender, FocusEventArgs e)
		{

		}
	}

}
