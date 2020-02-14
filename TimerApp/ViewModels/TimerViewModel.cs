using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin;
using System.ComponentModel;
using TimerApp.Models;
using System.Windows.Input;

namespace TimerApp.ViewModels
{
    internal class TimerInputViewModel : INotifyPropertyChanged
    {
        private TimerModel timerModel;

        public ICommand StartCommand { private set; get; }

        public TimerInputViewModel(
            string title,
            TimerModel timerModel,
            Action onStartTimer
        ) {
            this.timerModel = timerModel;

            Title = title;

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
