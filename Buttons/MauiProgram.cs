using CoreGraphics;
using Foundation;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using UIKit;

namespace Buttons
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
				});

#if IOS
			ButtonHandler.Mapper.PrependToMapping("ButtonSizing", (h, b) =>
			{
				if (b is Button button)
				{
					UIView super = h.PlatformView.Superview;

					super.AddConstraint(NSLayoutConstraint.Create(h.PlatformView.TitleLabel, NSLayoutAttribute.Width, NSLayoutRelation.LessThanOrEqual, h.PlatformView.TitleLabel, NSLayoutAttribute.Width, 1, 0));
					super.AddConstraint(NSLayoutConstraint.Create(h.PlatformView, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, h.PlatformView.TitleLabel, NSLayoutAttribute.Height, 1, 0));
				}
			});

			//ButtonHandler.Mapper.AppendToMapping(nameof(Button.Text), (h, b) =>
			//{
			//	try
			//	{
			//		if (b is Button button && h.PlatformView.CurrentTitle != null && h.PlatformView.TitleLabel.LineBreakMode == UILineBreakMode.WordWrap)
			//		{
			//			//UIStringAttributes attributes = new()
			//			//{
			//			//	Font = h.PlatformView.TitleLabel.Font
			//			//};
			//			//NSStringDrawingOptions drawingOptions = NSStringDrawingOptions.UsesLineFragmentOrigin | NSStringDrawingOptions.UsesFontLeading;
			//			//NSAttributedString title = h.PlatformView.CurrentAttributedTitle ?? new NSAttributedString(h.PlatformView.CurrentTitle, attributes);
			//			//CGRect unconstrainedBounds = title.GetBoundingRect(new CGSize(double.MaxValue, double.MaxValue), drawingOptions, null);
			//			//CGRect constrainedBounds = title.GetBoundingRect(new CGSize(button.Width - button.Padding.HorizontalThickness, double.MaxValue), drawingOptions, null);
			//			//double difference = constrainedBounds.Height - unconstrainedBounds.Height;

			//			//if (button.Height < constrainedBounds.Height)
			//			//{
			//			//	button.MinimumHeightRequest = button.Height + difference;
			//			//}

			//			//h.PlatformView.RemoveConstraint(

			//			//if (string.IsNullOrEmpty(h.PlatformView.TitleLabel.Text) == false)
			//			//{
			//			//	//UIStringAttributes? attributes = h.PlatformView.TitleLabel.AttributedText?.GetUIKitAttributes(0, out NSRange effectiveRangs);
			//			//	//CGRect unconstrainedBounds = ((NSString)h.PlatformView.TitleLabel.Text).GetBoundingRect(new CGSize(double.MaxValue, double.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, attributes ?? new(), null);
			//			//	//CGRect constrainedBounds = ((NSString)h.PlatformView.TitleLabel.Text).GetBoundingRect(new CGSize(button.Width - button.Padding.HorizontalThickness, double.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, attributes ?? new(), null);
			//			//	//double difference = button.Height - unconstrainedBounds.Height;

			//			//	//button.HeightRequest = Math.Max(button.Height, constrainedBounds.Height + difference);

			//			//	CGSize size = h.PlatformView.SizeThatFits(h.PlatformView.TitleLabel.Bounds.Size);
			//			//}
			//		}
			//	}
			//	catch (Exception ex)
			//	{

			//	}
			//});
#endif

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
