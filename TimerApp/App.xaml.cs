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

        private enum State { 
            Starting,
            Excentric,
            Concentric,
            Pause
        }
        private State state;
        private State postPauseState;

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

        private async void OnStartTimer() {
            counterViewModel.Title = "Starts in..";
            counterViewModel.Counter = "5";
            repetitions = timerModel.repetitions;
            state = State.Starting;
            await MainPage.Navigation.PushModalAsync(counterPage);
            Device.StartTimer(TimeSpan.FromSeconds(1), Update);
        }

        private bool Update()
        {
            Console.WriteLine($"[App::Update] {state}");
            switch (state)
            {
                case State.Starting:
                    {
                        int counter = int.Parse(counterViewModel.Counter);
                        counter -= 1;
                        counterViewModel.Counter = counter.ToString();
                        if (counter == -1)
                        {
                            state = State.Excentric;
                            counterViewModel.Title = "Excentric";
                            counterViewModel.Counter = $"{timerModel.excentricDuration}";
                            Device.StartTimer(TimeSpan.FromSeconds(0.1), Update);
                            return false;
                        }
                    }
                    return true;
                case State.Pause:
                    state = postPauseState;
                    counterViewModel.Title = state.ToString();
                    counterViewModel.Counter = $"{(state == State.Excentric ? (int)timerModel.excentricDuration : (int)timerModel.concentricDuration)}";
                    Device.StartTimer(TimeSpan.FromSeconds(0.1), Update);
                    return false;
                case State.Concentric:
                case State.Excentric:
                    {
                        float counter = float.Parse(counterViewModel.Counter);
                        counter -= 0.1f;
                        counterViewModel.Counter = counter.ToString();
                        if (counter < 0)
                        {
                            postPauseState = state == State.Concentric ? State.Excentric : State.Concentric;
                            counterViewModel.Title = "Pause";
                            counterViewModel.Counter = "";
                            repetitions -= state == State.Concentric ? 1 : 0;
                            if (repetitions == 0)
                            {
                                MainPage.Navigation.PopModalAsync();
                                return false;
                            }
                            state = State.Pause;
                            Device.StartTimer(TimeSpan.FromSeconds(timerModel.pauseDuration), Update);
                            return false;
                        }
                    }
                    return true;
            }
            return false;
        }
    }
}
