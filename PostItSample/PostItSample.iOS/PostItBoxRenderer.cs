using System.Drawing;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using PostItSample;
using PostItSample.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(PostItBox), typeof(PostItBoxRenderer))] 

namespace PostItSample.iOS {
    internal class PostItBoxRenderer : BoxRenderer{
        public override void Draw(RectangleF rect){

            //デフォルトの描画を無効にする
            //base.Draw(rect); 

            //モデルオブジェクトの取得
            var postItBox = (PostItBox)Element;

            using (var context = UIGraphics.GetCurrentContext()){
                var w = postItBox.Width;
                var h = postItBox.Height;
                var t = postItBox.Turned;

                //ボーダの幅を指定
                context.SetLineWidth(0);

                //多角形
                context.SetFillColor(postItBox.Color.ToCGColor());
                var path = new CGPath();
                path.MoveToPoint(0,0);
                path.AddLineToPoint((float)w, 0);
                path.AddLineToPoint((float)w, (float)(h-t));
                path.AddLineToPoint((float)(w-t*1.5), (float)h);
                path.AddLineToPoint(0,(float)h);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);
                
                //めくれ部分
                context.SetFillColor(postItBox.TurnedColor.ToCGColor());
                path = new CGPath();
                path.MoveToPoint((float)w, (float)(h-t));
                path.AddLineToPoint((float)(w - t), (float)(h - t * 1.5));
                path.AddLineToPoint((float)(w - t * 1.5), (float)h);
                context.AddPath(path);
                context.DrawPath(CGPathDrawingMode.FillStroke);

            }
        }
    }
}
