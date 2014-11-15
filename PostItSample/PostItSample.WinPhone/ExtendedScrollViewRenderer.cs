using System;
using System.ComponentModel;
using PostItSample;
using PostItSample.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

//Xamarin-Forms-Labs より
//https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Xamarin.Forms.Labs/Xamarin.Forms.Labs/Controls/ExtendedScrollView.cs

[assembly: ExportRenderer(typeof(ExtendedScrollView), typeof(ExtendedScrollViewRenderer))]
namespace PostItSample.WinPhone
{
    public class ExtendedScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
        {
            base.OnElementChanged(e);

			LayoutUpdated += (sender, ev) =>
			{
				var scrollView = (ExtendedScrollView)Element;
				var bounds = new Rectangle(Control.HorizontalOffset, Control.VerticalOffset, Control.ScrollableWidth, Control.ScrollableHeight);
				scrollView.UpdateBounds(bounds);
			};

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += OnElementPropertyChanged;
        }


        double EPSILON = 0.1;

        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ExtendedScrollView.PositionProperty.PropertyName)
            {
                var scrollView = (ExtendedScrollView)Element;
                var position = scrollView.Position;

				if (Math.Abs(Control.VerticalOffset - position.Y) < EPSILON
					&& Math.Abs(Control.HorizontalOffset - position.X) < EPSILON)
                    return;

                Control.ScrollToVerticalOffset(position.Y);
                Control.UpdateLayout();
            }
        }

    }
}
