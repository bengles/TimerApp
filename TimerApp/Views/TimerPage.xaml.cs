using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerInputPage : ContentPage
    {
        public TimerInputPage(
            string title, 
            Models.TimerModel timerModel,
            System.Action onStartTimer
        )
        {
            InitializeComponent();
            BindingContext = new ViewModels.TimerInputViewModel(title, timerModel, onStartTimer);
        }
    }
}