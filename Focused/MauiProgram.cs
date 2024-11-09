using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

#if ANDROID
using Android.Views;
#endif

namespace Focused
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
#if ANDROID
					ViewHandler.ViewMapper.AppendToMapping("UnfocusFix", (h, v) =>
					{
						if (v is not ScrollView && h.PlatformView is Android.Views.View view && view.Focusable && (view.FocusableInTouchMode == false))
						{
							view.Touch += (s, e) =>
							{
								if (e.Event?.Action == MotionEventActions.Down)
								{
									view.Context?.GetActivity()?.CurrentFocus?.ClearFocus();
								}

								e.Handled = false;
							};
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
