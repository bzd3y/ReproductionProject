namespace Toolbars
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new AppShell();
			MainPage = new FlyoutPage()
			{
				Flyout = new ContentPage() { Title = "Flyout" },
				Detail = new NavigationPage(new MainPage()) { Title = "Detail" }
			};
		}
	}
}
