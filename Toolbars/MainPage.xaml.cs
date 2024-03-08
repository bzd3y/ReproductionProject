namespace Toolbars
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage() : this(false)
		{

		}

		public MainPage(bool useIcon)
		{
			InitializeComponent();

			ToolbarItems.Add(new("Test", useIcon ? "dotnet_bot.png" : null, async () =>
			{
				await Navigation.PushAsync(new NavigationPage(new MainPage(!useIcon)));
			}));

			if (useIcon == false)
			{
				ToolbarItems.Add(new("<- should be text", null, () => { }));
			}
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
