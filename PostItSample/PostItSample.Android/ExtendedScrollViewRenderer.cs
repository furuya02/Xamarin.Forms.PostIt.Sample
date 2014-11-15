using System;
using System.ComponentModel;
using PostItSample;
using PostItSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//Xamarin-Forms-Labs より
//https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Xamarin.Forms.Labs/Xamarin.Forms.Labs/Controls/ExtendedScrollView.cs

[assembly: ExportRenderer(typeof(ExtendedScrollView), typeof(ExtendedScrollViewRenderer))]
namespace PostItSample.Droid {
	public class ExtendedScrollViewRenderer:ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			ViewTreeObserver.ScrollChanged += (sender, ev) => {
				var scrollView = (ExtendedScrollView)Element;
				if(scrollView == null)
					return;

				var bounds = new Rectangle(ScrollX, ScrollY, GetChildAt(0).Width, GetChildAt(0).Height);
				scrollView.UpdateBounds(bounds);
			};

			if(e.OldElement != null)
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

				if (Math.Abs(ScrollY - position.Y) < EPSILON
					&& Math.Abs(ScrollX - position.X) < EPSILON)
					return;

				ScrollTo((int)position.X,(int)position.Y);
				UpdateLayout();
			}
		}
	}

}
