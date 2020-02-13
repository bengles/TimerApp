using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TimerViewModel();
        }
    }
}