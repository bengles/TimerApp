using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using TimerApp;
using TimerApp.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TimerApp.iOS {
    public class CustomEntryRenderer : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if(Control != null) {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.TextColor = UIColor.White;
            }
        }
    }
}