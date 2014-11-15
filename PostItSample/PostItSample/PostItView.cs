using Xamarin.Forms;

namespace PostItSample {
    public class PostItView : ContentView {

        public delegate void LongTapHandler(PostItItem item);
        public event LongTapHandler LongTap;
        private readonly PostItItem _item;


        public PostItView(PostItItem item,int width){
            _item = item;

            var absoluteLayout = new AbsoluteLayout();
            
            var margin = width/50;

            //フォントのサイズが基準値となる
            var fontSize = width / 20;//フォントサイズ
            const int shadow = 5; //影の幅

            //文字が表示できる幅の計算
            var col = width - margin * 2 - fontSize;
            //必要行数
            var row = (item.Text.Length * fontSize) / col + 1;
            var height = (int)((row + 2) * (fontSize * 1.2) + margin*2)+fontSize/2;

            //影（塗りつぶし）の描画
            var color = Color.FromRgba(0, 0, 0,0.2);
            var turnedColor = Color.FromRgba(0, 0, 0, 0);//全透過
            var shadowBox = new PostItBox(width - margin * 2, height - margin * 2, color, turnedColor);
            absoluteLayout.Children.Add(shadowBox, new Point(margin + shadow, margin + shadow));

            //本体（塗りつぶし）の描画
            color = Color.FromRgb(255,200,200);
            turnedColor = Color.FromRgb(255, 220,220);
            var postItBox = new PostItBox(width - margin * 2, height - margin * 2, color, turnedColor);
            absoluteLayout.Children.Add(postItBox, new Point(margin,margin));
            //ラベル(本文)の描画
            var labelText = new Label {
                Text = item.Text,
                Font = Font.SystemFontOfSize(fontSize),
                TextColor = Color.Black,
                WidthRequest = col,
            };
            absoluteLayout.Children.Add(labelText, new Point(fontSize / 2 + margin, fontSize / 2 + margin));

            //ラベル(日付)の描画
            var labelDate = new Label {
                Text = string.Format("CreateAt {0}",item.CreateAt.ToString("g")),
                Font = Font.SystemFontOfSize(fontSize*0.7),
                TextColor = Color.Black,
                WidthRequest = col,
            };
            absoluteLayout.Children.Add(labelDate, new Point(fontSize / 2 + margin, height-margin-fontSize*1.5));


            //透過ボタン(長押しを取得するため透明のボタンを置く)
            var exButton = new ExButton{
                WidthRequest = width,
                HeightRequest = height,

            };
            absoluteLayout.Children.Add(exButton, new Point(0, 0));
            exButton.LongTap += (sender, args) => {
                if (LongTap != null){
                    LongTap(_item);
                }
            };

            Content = absoluteLayout;
        }
    }

}