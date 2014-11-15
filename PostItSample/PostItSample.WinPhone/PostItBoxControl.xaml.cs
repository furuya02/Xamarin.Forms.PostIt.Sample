using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace PostItSample.WinPhone {
    public partial class PostItBoxControl : UserControl {
        private readonly PostItBox _postItBox;
        public PostItBoxControl(PostItBox balloonBox) {
            InitializeComponent();
            _postItBox = balloonBox;
        }

        public void Draw(){
            var w = _postItBox.Width;
            var h = _postItBox.Height;
            var t = _postItBox.Turned;

            var color = Color.FromArgb(
                (byte) (_postItBox.Color.A*255),
                (byte) (_postItBox.Color.R*255),
                (byte) (_postItBox.Color.G*255),
                (byte) (_postItBox.Color.B*255));

            //多角形
            var triangle = new Polygon();
            triangle.Fill = new SolidColorBrush(color);
            var points = new PointCollection();
            points.Add(new Point(0, 0));
            points.Add(new Point(w, 0));
            points.Add(new Point(w, h - t));
            points.Add(new Point(w - t*1.5, h));
            points.Add(new Point(0, h));

            triangle.Points = points;
            PostItBoxCanvas.Children.Add(triangle);

            //めくれ部分
            color = Color.FromArgb(
                (byte) (_postItBox.TurnedColor.A*255),
                (byte) (_postItBox.TurnedColor.R*255),
                (byte) (_postItBox.TurnedColor.G*255),
                (byte) (_postItBox.TurnedColor.B*255));
            triangle = new Polygon();
            triangle.Fill = new SolidColorBrush(color);
            points = new PointCollection();
            points.Add(new Point(w, h - t));
            points.Add(new Point(w - t, h - t*1.5));
            points.Add(new Point(w - t*1.5, h));

            triangle.Points = points;
            PostItBoxCanvas.Children.Add(triangle);
        }
    }
}
