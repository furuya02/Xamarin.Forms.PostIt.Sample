using PostItSample;
using PostItSample.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly:ExportRenderer(typeof(ExButton),typeof(ExButtonRenderer))]
namespace PostItSample.WinPhone {
  public class ExButtonRenderer : ButtonRenderer 
  {
    protected override void OnElementChanged(ElementChangedEventArgs<Button> e) 
    {
      base.OnElementChanged(e);

      var exButton = e.NewElement as ExButton; 
      //WindowsPhoneだけダブルタップ
      Control.DoubleTap += (sender, _) => exButton.OnLongTap();  
    }
  }
}
