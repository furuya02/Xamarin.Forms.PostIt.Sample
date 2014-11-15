using System.ComponentModel;
using PostItSample;
using PostItSample.WinPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(PostItBox), typeof(PostItBoxRenderer))] 
namespace PostItSample.WinPhone {
    class PostItBoxRenderer : ViewRenderer<PostItBox, PostItBoxControl> {
        protected override void OnElementChanged(ElementChangedEventArgs<PostItBox> e) {
            base.OnElementChanged(e);

            //独自のユーザコントロールをセットする
            SetNativeControl(new PostItBoxControl(Element));//パラメータにFormsのコントロールも渡しておく
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Height") { //プロパティHeight若しくはWidthが変更された時、再描画する
                Control.Draw();//再描画メソッド
            }
        }
    }
}