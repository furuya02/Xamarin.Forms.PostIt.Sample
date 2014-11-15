using PostItSample;
using PostItSample.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(ExButton),typeof(ExButtonRenderer))]
namespace PostItSample.Droid {
  public class ExButtonRenderer : ButtonRenderer 
  {
    protected override void OnElementChanged(ElementChangedEventArgs<Button> e) 
    {
      base.OnElementChanged(e);

      var exButton = e.NewElement as ExButton; 
      Control.LongClick += (sender, _) => exButton.OnLongTap();  
    }
  }
}