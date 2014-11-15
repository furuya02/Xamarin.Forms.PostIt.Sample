using MonoTouch.UIKit;
using PostItSample;
using PostItSample.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly:ExportRenderer(typeof(ExButton), typeof(ExButtonRenderer))]
namespace PostItSample.iOS{
    public class ExButtonRenderer : ButtonRenderer{
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e){
            base.OnElementChanged(e);

            var exButton = e.NewElement as ExButton;
            Control.AddGestureRecognizer(new UILongPressGestureRecognizer(x => {
                if (x.State == UIGestureRecognizerState.Recognized){
                    exButton.OnLongTap();
                }
            }));
        }
    }
}
