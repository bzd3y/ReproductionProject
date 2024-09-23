using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace PickerUnfocused
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
				}).ConfigureMauiHandlers(handlers =>
				{
#if ANDROID

					//PickerHandler.Mapper.ModifyMapping(nameof(Picker.SelectedIndex), (h, p, m) =>
					//{
					//	if (p is Picker picker)
					//	{
					//		picker.SelectedItem

					//		m?.Invoke(h, p);

					//		if (picker.IsFocused)
					//		{
					//			picker.Unfocus();
					//		}
					//	}
					//});

					Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("UnfocusedFix", (h, p) =>
					{
						if (p is Picker picker)
						{
							picker.SelectedIndexChanged += (s, e) =>
							{
								if (picker.IsFocused)
								{
									picker.Unfocus();
								}
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
