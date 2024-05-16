using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Platform;

#if IOS
using UIKit;
using Foundation;
using CoreGraphics;
#endif

namespace Buttons
{
	public static class MauiProgram
	{
#if IOS
		public class WordWrapButtonHandler : ButtonHandler
		{
			public override Size GetDesiredSize(double widthConstraint, double heightConstraint)
			{
				Size desiredSize = base.GetDesiredSize(widthConstraint, heightConstraint);

				if (VirtualView is Button button && button.HeightRequest == -1 && (button.LineBreakMode == LineBreakMode.WordWrap || button.LineBreakMode == LineBreakMode.CharacterWrap))
				{
					double width = widthConstraint - button.Padding.HorizontalThickness;

					//if (PlatformView.ImageView.Bounds.Width > 0 && (button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Left || button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Right))
					//{
					//	width -= PlatformView.ImageView.Bounds.Width - button.ContentLayout.Spacing;
					//}

					CGSize size = new(width, heightConstraint);
					NSAttributedString title = PlatformView.CurrentAttributedTitle ?? new NSAttributedString(PlatformView.CurrentTitle, new UIStringAttributes()
					{
						Font = PlatformView.TitleLabel.Font
					});
					CGRect bounds = title.GetBoundingRect(size, NSStringDrawingOptions.UsesLineFragmentOrigin | NSStringDrawingOptions.UsesFontLeading, null);
					double height = bounds.Height;

					//if (PlatformView.ImageView.Bounds.Height > 0)
					//{
					//	if (button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Top || button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Bottom)
					//	{
					//		height = PlatformView.ImageView.Bounds.Height + button.ContentLayout.Spacing + height;
					//	}
					//	else if (button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Left || button.ContentLayout.Position == Button.ButtonContentLayout.ImagePosition.Right)
					//	{
					//		height = Math.Max(PlatformView.ImageView.Bounds.Height, height);
					//	}
					//}

					desiredSize.Height = height + button.Padding.VerticalThickness;
				}

				return desiredSize;
			}
		}
#endif

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
					h.AddHandler(typeof(Button), typeof(WordWrapButtonHandler));

					//ButtonHandler.CommandMapper.AppendToMapping(nameof(IView.InvalidateMeasure), (h, b, o) =>
					//{

					//});
#endif
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
