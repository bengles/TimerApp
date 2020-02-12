using System;
using Xamarin.Forms;

namespace TimerApp
{
    public class TimerPage : ContentPage
    {
        private readonly Label label;
        private readonly Entry triggerCountEntry;
        private readonly Entry secondsEntry;
        private int triggerCounter;
        private int triggerTimes;

        public TimerPage()
        {
            label = new Label
            {
                Text = "Trigger timer!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Padding = new Thickness(10, 10),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            triggerCountEntry = new Entry
            {
                Text = "How many times?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Entry)),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            triggerCountEntry.Focused += OnFocusedEntry;

            secondsEntry = new Entry
            {
                Text = "Every second?",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Entry)),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            secondsEntry.Focused += OnFocusedEntry;

            Button button = new Button
            {
                Text = "Start",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            button.Clicked += OnButtonClicked;

            Content = new StackLayout
            {
                Children =
                {
                    label,
                    triggerCountEntry,
                    secondsEntry,
                    button
                }
            };
        }

        private void OnFocusedEntry(object sender, EventArgs e) {
            Entry entry = (Entry)sender;
            entry.Text = "";
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(triggerCountEntry.Text, out triggerTimes)
                || !float.TryParse(secondsEntry.Text, out float seconds))
            {
                label.Text = "Please enter only numbers.";
                return;
            }

            triggerCounter = 0;
            Device.StartTimer(TimeSpan.FromSeconds(seconds), OnTimerDone);
        }

        private bool OnTimerDone()
        {
            triggerCounter++;
            label.Text = $"Triggered {triggerCounter} times.";
            return triggerCounter != triggerTimes;
        }
    }
}
