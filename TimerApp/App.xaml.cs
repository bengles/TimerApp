using System;
using Xamarin.Forms;

namespace TimerApp
{
    public partial class App : Application
    {
        private readonly Models.TimerModel timerModel;
        private readonly ViewModels.TimerInputViewModel inputViewModel;
        private readonly Views.TimerInputPage inputPage;
        private readonly ViewModels.CounterViewModel counterViewModel;
        private readonly Views.CounterPage counterPage;

        private int repetitions;

        private enum State
        {
            Starting,
            Excentric,
            Concentric,
            Pause
        }
        private State state;
        private State postPauseState;

        private const float UPDATE_FREQUENCY = 0.1f;

        public App()
        {
            InitializeComponent();

            timerModel = new Models.TimerModel();

            inputViewModel = new ViewModels.TimerInputViewModel(
                "Trigger time!",
                timerModel,
                OnStartTimer);
            inputPage = new Views.TimerInputPage(inputViewModel);

            counterViewModel = new ViewModels.CounterViewModel();
            counterPage = new Views.CounterPage(counterViewModel);

            MainPage = inputPage;
        }

        private async void OnStartTimer()
        {
            counterViewModel.Title = "Starts in..";
            counterViewModel.Counter = 5f;
            repetitions = timerModel.repetitions;
            state = State.Starting;
            await MainPage.Navigation.PushModalAsync(counterPage);
            Device.StartTimer(TimeSpan.FromSeconds(UPDATE_FREQUENCY), Update);
        }

        private bool Update()
        {
            Console.WriteLine($"[App::Update] {state}");
            float counter = counterViewModel.Counter;
            counter -= 0.1f;
            counterViewModel.Counter = counter;
            if (counter < 0)
            {
                switch (state)
                {
                    case State.Starting:
                        state = timerModel.startWithExcentric ? State.Excentric : State.Concentric;
                        counterViewModel.Title = timerModel.startWithExcentric ? "Excentric" : "Concentric";
                        counterViewModel.Counter = timerModel.startWithExcentric ? timerModel.excentricDuration : timerModel.concentricDuration;
                        break;
                    case State.Pause:
                        state = postPauseState;
                        counterViewModel.Title = state.ToString();
                        counterViewModel.Counter = (state == State.Excentric ? (int)timerModel.excentricDuration : (int)timerModel.concentricDuration);
                        break;
                    case State.Concentric:
                    case State.Excentric:
                        if (timerModel.startWithExcentric && state == State.Concentric || !timerModel.startWithExcentric && state == State.Excentric)
                        {
                            repetitions -= 1;
                        }
                        if (repetitions == 0)
                        {
                            MainPage.Navigation.PopModalAsync();
                            return false;
                        }
                        if (timerModel.startWithExcentric && state == State.Excentric || !timerModel.startWithExcentric && state == State.Concentric)
                        {
                            postPauseState = state == State.Concentric ? State.Excentric : State.Concentric;
                            counterViewModel.Title = "Pause";
                            counterViewModel.Counter = timerModel.pauseDuration;
                            state = State.Pause;
                        }
                        else
                        {
                            state = state == State.Concentric ? State.Excentric : State.Concentric;
                            counterViewModel.Title = state.ToString();
                            counterViewModel.Counter = state == State.Concentric ? timerModel.concentricDuration : timerModel.excentricDuration;
                        }
                        break;
                }
            }
            return true;
        }
    }
}
