using System.ComponentModel;

namespace TimerApp.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title {
            get { return title; }
            set { 
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public string CounterText {
            get { return ((int)(counter + 0.75)).ToString(); }
        }

        private float counter;
        public float Counter {
            get { return counter; }
            set
            {
                counter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CounterText"));
            }
        }
    }
}
