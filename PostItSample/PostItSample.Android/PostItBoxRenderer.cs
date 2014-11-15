using Android.Graphics;
using PostItSample.Droid;
using Xamarin.Forms.Platform.Android;
using PostItSample;
using Xamarin.Forms;


[assembly: ExportRenderer(typeof(PostItBox), typeof(PostItBoxRenderer))]
namespace PostItSample.Droid {
    internal class PostItBoxRenderer : BoxRenderer {

        public override void Draw(Canvas canvas) {

            //デフォルトの描画を無効にする
            //base.Draw(canvas);

            //モデルオブジェクトの取得
            var postItBox = (PostItBox)Element;

            using (var paint = new Paint()){

                var expand = Width/postItBox.Width;
                var w = postItBox.Width * expand;
                var h = postItBox.Height * expand;
                var t = postItBox.Turned * expand;

                //ボーダの幅を指定
                paint.StrokeWidth = 0;
                //アンチエイリアス有効
                paint.AntiAlias = true;


                //多角形
                paint.Color = postItBox.Color.ToAndroid();
                var path = new Path();
                path.MoveTo(0, 0);
                path.LineTo((float)w, 0);
                path.LineTo((float)w, (float)(h - t));
                path.LineTo((float)(w - t * 1.5), (float)h);
                path.LineTo(0, (float)h);
                canvas.DrawPath(path, paint);

                //めくれ部分
                paint.Color = postItBox.TurnedColor.ToAndroid();
                path = new Path();
                path.MoveTo((float)w, (float)(h - t));
                path.LineTo((float)(w - t), (float)(h - t * 1.5));
                path.LineTo((float)(w - t * 1.5), (float)h);
                canvas.DrawPath(path, paint);

            }
        }
    }
}
