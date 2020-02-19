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

        public string Repetitions {
            get { 
                if (timerModel.repetitions == 0)
                {
                    return null;
                }
                return timerModel.repetitions.ToString(); 
            }
            set { timerModel.repetitions = int.TryParse(value, out int intValue) ? intValue : 0; }
        }

        public string ExcentricDuration {
            get {
                if (timerModel.excentricDuration == 0.0)
                {
                    return null;
                }
                return timerModel.excentricDuration.ToString(); 
            }
            set { timerModel.excentricDuration = float.TryParse(value, out float fValue) ? fValue : 0f; }
        }

        public string ConcentricDuration {
            get {
                if (timerModel.concentricDuration == 0.0)
                {
                    return null;
                }
                return timerModel.concentricDuration.ToString(); 
            }
            set { timerModel.concentricDuration = float.TryParse(value, out float fValue) ? fValue : 0f; }
        }

        public string PauseDuration
        {
            get {
                if (timerModel.pauseDuration == 0.0)
                {
                    return null;
                }
                return timerModel.pauseDuration.ToString(); 
            }
            set { timerModel.pauseDuration = float.TryParse(value, out float fValue) ? fValue : 0f; }
        }

        public bool StartWithExcentric {
            get { return timerModel.startWithExcentric; }
            set { timerModel.startWithExcentric = value; }
        }

        public bool Start {
            get; 
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
