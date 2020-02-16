using System;
using Xamarin.Forms;

namespace TimerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var inputViewModel = new ViewModels.TimerInputViewModel(
                "Trigger time!",
                new Models.TimerModel
                {
                    times = 10,
                    interval = 0.2f
                },
                OnStartTimer);

            MainPage = new Views.TimerInputPage(inputViewModel);
        }

        private void OnStartTimer() {
            Console.WriteLine("Start timer");
        }
    }
}
