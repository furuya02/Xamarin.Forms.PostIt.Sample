using System;
using Xamarin.Forms;

//Xamarin-Forms-Labs より
//https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Xamarin.Forms.Labs/Xamarin.Forms.Labs/Controls/ExtendedScrollView.cs

namespace PostItSample {
    public class ExtendedScrollView : ScrollView {
        public event Action<ScrollView, Rectangle> Scrolled;

        public void UpdateBounds(Rectangle bounds) {
            Position = bounds.Location;
            if (Scrolled != null)
                Scrolled(this, bounds);
        }

        public static readonly BindableProperty PositionProperty =
            BindableProperty.Create<ExtendedScrollView, Point>(
                p => p.Position, default(Point));

        public Point Position {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly BindableProperty AnimateScrollProperty =
            BindableProperty.Create<ExtendedScrollView, bool>(
                p => p.AnimateScroll, true);

        public bool AnimateScroll {
            get { return (bool)GetValue(AnimateScrollProperty); }
            set { SetValue(AnimateScrollProperty, value); }
        }

    }
}