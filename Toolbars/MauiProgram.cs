using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Handlers;
using FlyoutPage = Microsoft.Maui.Controls.FlyoutPage;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;
using UIKit;

namespace Toolbars
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.ConfigureMauiHandlers(h =>
				{
#if IOS
					NavigationRenderer.Mapper.PrependToMapping(nameof(NavigationPage.CurrentPage), (h, n) =>
					{
						if (n.Parent is FlyoutPage)
						{
							n.CurrentPage.On<iOS>().SetUseSafeArea(true);
						}
				});
#endif
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
