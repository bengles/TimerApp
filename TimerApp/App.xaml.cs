using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.TimerInputPage(
                "Trigger timer!",
                new Models.TimerModel {
                    times = 10,
                    interval = 0.2f
                },
                OnStartTimer
            );
        }

        private async void OnStartTimer() {
            await MainPage.Navigation.PushModalAsync(
                new Views.TimerInputPage(
                    "Second trigger timer!",
                    new Models.TimerModel { 
                        times = 1,
                        interval = 1
                    },
                    OnStartTimer
                )
            );
        }
    }
}
