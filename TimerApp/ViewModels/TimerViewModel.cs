using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin;
using System.ComponentModel;

namespace TimerApp.ViewModels
{
    internal class TimerViewModel : INotifyPropertyChanged
    {

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
            get;
            set;
        }

        public string Interval {
            get;
            set;
        }

        public bool Start {
            get; 
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public TimerViewModel()
        {
            Title = "Trigger Timer!";
        }
    }
}
