using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CounterPage : ContentPage
    {
        public CounterPage(
            ViewModels.CounterViewModel viewModel
        ) {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}