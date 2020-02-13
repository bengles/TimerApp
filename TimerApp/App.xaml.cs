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

            MainPage = new Views.TimerPage();
        }
    }
}
