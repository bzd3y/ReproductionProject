using System.Collections.ObjectModel;

namespace Toolbars
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();

			ListView listView = new(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = new[] { "One", "Two", "Three" }
			};

			Content = listView;

			ToolbarItems.Add(new("Test", null, async () =>
			{
				await Navigation.PushAsync(new NavigationPage(new MainPage()));
			}));

			ToolbarItems.Add(new("One", null, () => { }, ToolbarItemOrder.Secondary));
			ToolbarItems.Add(new("Two", null, () => { }, ToolbarItemOrder.Secondary));
			ToolbarItems.Add(new("Three", null, () => { }, ToolbarItemOrder.Secondary));
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
