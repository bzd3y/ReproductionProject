
namespace Toolbars
{
	public partial class ToolbarPage : ContentPage
	{
		public ToolbarPage(Page? page)
		{
			InitializeComponent();

			ListView listView = new(ListViewCachingStrategy.RecycleElement)
			{
				ItemsSource = new[] { "One", "Two", "Three" }
			};

			Content = listView;

			ToolbarItems.Add(new("Test", null, async () =>
			{
				if (Application.Current?.MainPage is FlyoutPage flyoutPage && page != null)
				{
					flyoutPage.Detail = new NavigationPage(page);
				}
				else if (Application.Current?.MainPage is AppShell appShell)
				{
					await appShell.GoToAsync(nameof(MainPage));
				}
				else
				{
					await Navigation.PopAsync();
				}
			}));

			ToolbarItems.Add(new("One 1", null, () => { }, ToolbarItemOrder.Secondary));
			ToolbarItems.Add(new("Two 2 ", null, () => { }, ToolbarItemOrder.Secondary));
			ToolbarItems.Add(new("Three 3", null, () => { }, ToolbarItemOrder.Secondary));
		}

		public ToolbarPage() : this(null)
		{

		}
	}

}
