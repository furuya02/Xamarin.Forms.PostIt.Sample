
using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms.Platform.Android;

namespace PostItSample.Droid {
    [Activity(Label = "PostItSample", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            //初期化処理を追加
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            SetPage(App.GetMainPage());
        }
    }
}

