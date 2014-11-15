using System;

using Xamarin.Forms;

namespace PostItSample {
    public class App {
        public static Page GetMainPage() {
            return new MyPage();
        }
    }

    public class MyPage : ContentPage {


        //Azure モバイルサービス
        private MobileService _mobileService;

        //ボード（スクロールビュー）
        private readonly Board _board = new Board();

        public MyPage() {
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            BackgroundColor = Color.White;

            //テキストボックス
            var entry = new Entry {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            //送信ボタン
            var button = new Button() {
                Text = "Write"
            };
            button.Clicked += async (sender, args) => {
                if (!String.IsNullOrEmpty(entry.Text)){
                    var item = new PostItItem() { Text = entry.Text, CreateAt = DateTime.Now ,DeleteFlg = false};
                    await _mobileService.Insert(item);
                    var index = _mobileService.Items.FindIndex(m => m.Id == item.Id);
                    _board.Insert(index, item);

                    entry.Text = "";
                }
            };

            //長押し（WindowsPhoneでは、ダブルタップ）で削除
            _board.LongTap += async item => {
                if (await DisplayAlert("削除してよろしいですか？", item.Text, "OK", "Cancel")){
                    var index = _mobileService.Items.FindIndex(m => m.Id == item.Id);
                    await _mobileService.Delete(item);
                    _board.Delete(index);
                }
            };

            //画面構成
            Content = new StackLayout {
                Spacing = 0,
                Children ={
                    //上段のタイムライン
                    _board.View,
                    
                    //下段の入力欄
                    new StackLayout{
                        BackgroundColor = Color.FromRgb(169, 206, 152),
                        Padding = 5,
                        Spacing = 10,
                        Orientation = StackOrientation.Horizontal,
                        Children ={entry, button}
                    },
                }
            };

            //サイズが変化した時だけ呼ばれるので、OnSizeAllocatedより優れている
            SizeChanged += async (sender, args) => {
                
                if (Width > 0){
                    //画面横幅の80%の大きさの付箋紙を表示する
                    _board.PostItWidth = (int)(Width * 0.95);
                    //初期化
                    if (_mobileService == null) {
                        Initialize();
                    }
                }

            };
        }

        async void Initialize() {
            IsBusy = true; //インジケータのON

            _mobileService = new MobileService();
            await _mobileService.Init(20);

            for (var i = 0; i < _mobileService.Items.Count; i++) {
                _board.Insert(i, _mobileService.Items[i]);
            }

            IsBusy = false; //インジケータのOFF
        }
    }
}
