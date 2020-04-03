using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using Xamarin.Forms.Internals;
using NativeSize = System.Windows.Size;
using Label = Xamarin.Forms.Label;
using Xamarin.Forms;
using System.Windows;
using System.Windows.Media;
using System;

namespace Sapin.CPDT.WPF
{
	internal static class TextBlockExtensions
	{

		public static double FindDefaultLineHeight(this TextBlock control, Inline inline)
		{
			control.Inlines.Add(inline);

			control.Measure(new NativeSize(double.PositiveInfinity, double.PositiveInfinity));

			var height = control.DesiredSize.Height;

			control.Inlines.Remove(inline);
			control = null;

			return height;
		}

		public static void RecalculateSpanPositions(this TextBlock control, Label element, IList<double> inlineHeights)
		{
			if (element?.FormattedText?.Spans == null
				|| element.FormattedText.Spans.Count == 0)
				return;

			var labelWidth = control.ActualWidth;

			if (labelWidth <= 0 || control.Height <= 0)
				return;

			for (int i = 0; i < element.FormattedText.Spans.Count; i++)
			{
				var span = element.FormattedText.Spans[i];

				var inline = control.Inlines.ElementAt(i);
				var rect = inline.ContentStart.GetCharacterRect(LogicalDirection.Forward);
				var endRect = inline.ContentEnd.GetCharacterRect(LogicalDirection.Forward);

				var positions = new List<Rectangle>();


				var defaultLineHeight = inlineHeights[i];

				if (defaultLineHeight == 0) defaultLineHeight = 19.5;

				var yaxis = rect.Top;
				var lineHeights = new List<double>();
				while (yaxis < endRect.Bottom)
				{
					double lineHeight;
					if (yaxis == rect.Top) // First Line
					{
						lineHeight = rect.Bottom - rect.Top;
					}
					else if (yaxis != endRect.Top) // Middle Line(s)
					{
						lineHeight = defaultLineHeight;
					}
					else // Bottom Line
					{
						lineHeight = endRect.Bottom - endRect.Top;
					}
					lineHeights.Add(lineHeight);
					yaxis += lineHeight;
				}

				((ISpatialElement)span).Region = Region.FromLines(lineHeights.ToArray(), labelWidth, rect.X, endRect.X + endRect.Width, rect.Top).Inflate(10);

			}
		}
	}


	internal static class AlignmentExtensions
	{
		internal static System.Windows.TextAlignment ToNativeTextAlignment(this Xamarin.Forms.TextAlignment alignment)
		{
			switch (alignment)
			{
				case Xamarin.Forms.TextAlignment.Center:
					return System.Windows.TextAlignment.Center;
				case Xamarin.Forms.TextAlignment.End:
					return System.Windows.TextAlignment.Right;
				default:
					return System.Windows.TextAlignment.Left;
			}
		}

		internal static VerticalAlignment ToNativeVerticalAlignment(this Xamarin.Forms.TextAlignment alignment)
		{
			switch (alignment)
			{
				case Xamarin.Forms.TextAlignment.Start:
					return VerticalAlignment.Top;
				case Xamarin.Forms.TextAlignment.Center:
					return VerticalAlignment.Center;
				case Xamarin.Forms.TextAlignment.End:
					return VerticalAlignment.Bottom;
				default:
					return VerticalAlignment.Top;
			}
		}

		internal static VerticalAlignment ToNativeVerticalAlignment(this LayoutOptions alignment)
		{
			switch (alignment.Alignment)
			{
				case LayoutAlignment.Start:
					return VerticalAlignment.Top;
				case LayoutAlignment.Center:
					return VerticalAlignment.Center;
				case LayoutAlignment.End:
					return VerticalAlignment.Bottom;
				case LayoutAlignment.Fill:
					return VerticalAlignment.Stretch;
				default:
					return VerticalAlignment.Stretch;
			}
		}

		internal static HorizontalAlignment ToNativeHorizontalAlignment(this LayoutOptions alignment)
		{
			switch (alignment.Alignment)
			{
				case LayoutAlignment.Start:
					return HorizontalAlignment.Left;
				case LayoutAlignment.Center:
					return HorizontalAlignment.Center;
				case LayoutAlignment.End:
					return HorizontalAlignment.Right;
				case LayoutAlignment.Fill:
					return HorizontalAlignment.Stretch;
				default:
					return HorizontalAlignment.Stretch;
			}
		}
	}

	public static class FontExtensions
	{
		internal static void ApplyFont(this Control self, IFontElement element)
		{
			self.FontSize = element.FontSize;

			if (!string.IsNullOrEmpty(element.FontFamily))
				self.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), element.FontFamily);
			else
				self.FontFamily = (FontFamily)System.Windows.Application.Current.Resources["FontFamilySemiBold"];

			if (element.FontAttributes.HasFlag(FontAttributes.Italic))
				self.FontStyle = FontStyles.Italic;
			else
				self.FontStyle = FontStyles.Normal;

			if (element.FontAttributes.HasFlag(FontAttributes.Bold))
				self.FontWeight = FontWeights.Bold;
			else
				self.FontWeight = FontWeights.Normal;
		}

		internal static double GetFontSize(this NamedSize size)
		{
			switch (size)
			{
				case NamedSize.Default:
					return (double)System.Windows.Application.Current.Resources["ControlContentThemeFontSize"];
				case NamedSize.Micro:
					return (double)System.Windows.Application.Current.Resources["FontSizeSmall"] - 3;
				case NamedSize.Small:
					return (double)System.Windows.Application.Current.Resources["FontSizeSmall"];
				case NamedSize.Medium:
					return (double)System.Windows.Application.Current.Resources["FontSizeNormal"];
				// use normal instead of medium as this is the default
				case NamedSize.Large:
					return (double)System.Windows.Application.Current.Resources["FontSizeLarge"];
				default:
					throw new ArgumentOutOfRangeException("size");
			}
		}

		internal static bool IsDefault(this IFontElement self)
		{
			return self.FontFamily == null && self.FontSize == Device.GetNamedSize(NamedSize.Default, typeof(Label), true) && self.FontAttributes == FontAttributes.None;
		}
	}
}