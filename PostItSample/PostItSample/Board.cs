using System.Threading.Tasks;
using Xamarin.Forms;

namespace PostItSample {
    class Board {

        public delegate void LongTapHandler(PostItItem item);
        public event LongTapHandler LongTap;

        readonly StackLayout _layout = new StackLayout();

        public Board() {

            _layout.Spacing = 0;
            View = new ExtendedScrollView();
            View.VerticalOptions = LayoutOptions.FillAndExpand;
            View.Content = _layout;

        }

        public ExtendedScrollView View { get; private set; }
        public int PostItWidth { private get; set; }

        public void Insert(int index, PostItItem item){
            var postItView = new PostItView(item, PostItWidth);
            postItView.HorizontalOptions = LayoutOptions.Start;
            postItView.LongTap += i =>{
                if (LongTap != null){
                    LongTap(i);
                }
            };
            _layout.Children.Insert(index, postItView);


            //Androidの場合、Delayがないとスクロールできない?
            Task.Delay(1).ContinueWith(t => Device.BeginInvokeOnMainThread(() =>{
                //一番下までスクロール
                //View.Position = new Point(0, View.ContentSize.Height - View.Bounds.Height);
                //一番上までスクロール
                View.Position = new Point(0, 0);
            }));
        }

        public void Delete(int index){
            _layout.Children[index].HeightRequest = 0;
            _layout.Children.RemoveAt(index);
        }

    }
}
