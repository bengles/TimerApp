using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerInputPage : ContentPage
    {
        public TimerInputPage(
            ViewModels.TimerInputViewModel viewModel
        )
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}