using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;

[assembly: UnsupportedOSPlatform("maccatalyst")]

namespace OSVersion
{
	public static class MauiProgram
	{
		[SupportedOSPlatform("ios")]
		[SupportedOSPlatform("android")]
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
