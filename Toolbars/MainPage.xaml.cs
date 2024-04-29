
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

			ToolbarItems.Add(new("Detail/Route", null, async() =>
			{
				if (Application.Current?.MainPage is FlyoutPage flyoutPage)
				{
					flyoutPage.Detail = new NavigationPage(new ToolbarPage(this) { Title = "Toolbar Page" });
				}
				else if (Application.Current?.MainPage is AppShell appShell)
				{
					await appShell.GoToAsync(new ShellNavigationState(nameof(ToolbarPage)));
				}
			}));
			ToolbarItems.Add(new("Push", null, async () =>
			{
				await Navigation.PushAsync(new ToolbarPage(this));
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
