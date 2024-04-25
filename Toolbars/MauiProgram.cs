using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

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
					PageHandler.Mapper.PrependToMapping("ToolbarItems", (h, t) =>
					{
						h.PlatformView.Superview.LayoutSubviews();
					});

					ToolbarHandler.Mapper.PrependToMapping("ToolbarItems", (h, t) =>
					{
						h.PlatformView.Superview.LayoutSubviews();
					});

					ToolbarHandler.Mapper.AppendToMapping("ToolbarItems", (h, t) =>
					{
						h.PlatformView.Superview.LayoutSubviews();
					});

					NavigationViewHandler.Mapper.AppendToMapping("ToolbarItems", (h, t) =>
					{
						h.PlatformView.Superview.LayoutSubviews();
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
