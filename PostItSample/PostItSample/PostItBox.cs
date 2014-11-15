using Xamarin.Forms;

namespace PostItSample {
    public class PostItBox :BoxView{
        public float Turned { get; set; }//めくれ部分のサイズ
        public Color TurnedColor { get; set; }//めくれ部分の色

        public PostItBox(int width, int height, Color color, Color turnedColor) {
            WidthRequest = width;
            HeightRequest = height;
            Turned = 15;
            Color = color;
            TurnedColor = turnedColor;

        }
    }
}
