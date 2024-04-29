namespace Toolbars
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(ToolbarPage), typeof(ToolbarPage));
		}
	}
}
