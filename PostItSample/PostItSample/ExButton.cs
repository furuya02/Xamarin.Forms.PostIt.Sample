using System;
using Xamarin.Forms;

namespace PostItSample {
    public class ExButton:Button {
        public ExButton(){
            if (Device.OS != TargetPlatform.iOS){
                Opacity = 0;//透明 iOSでこれを指定するとiOSではイベントが拾えなくなる
            }
        }
        
        public event EventHandler LongTap;

        public void OnLongTap() {
            if (LongTap != null) {
                LongTap(this, new EventArgs());
            }
        }
    }
}
