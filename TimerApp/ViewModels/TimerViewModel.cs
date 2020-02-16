using System;
using Xamarin.Forms;
using System.ComponentModel;
using TimerApp.Models;
using System.Windows.Input;

namespace TimerApp.ViewModels
{
    public class TimerInputViewModel : INotifyPropertyChanged
    {
        private readonly TimerModel timerModel;
        public ICommand StartCommand { private set; get; }

        public TimerInputViewModel(
            string title,
            TimerModel timerModel,
            Action onStartTimer
        ) {
            Title = title;
            this.timerModel = timerModel;

            StartCommand = new Command(onStartTimer);
        }

        #region Properties
        private string title;
        public string Title {
            get { return title; }
            set {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public string Times {
            get { return timerModel.times.ToString(); }
            set { timerModel.times = float.TryParse(value, out float fValue) ? fValue : 0f; }
        }

        public string Interval {
            get { return timerModel.interval.ToString(); }
            set { timerModel.interval = float.TryParse(value, out float fValue) ? fValue : 0f; }
        }

        public bool Start {
            get; 
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
