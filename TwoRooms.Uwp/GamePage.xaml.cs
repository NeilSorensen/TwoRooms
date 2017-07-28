using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechSynthesis;

using TwoRooms.Domain;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TwoRooms.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        GameRules rules;
        DispatcherTimer roundTimer;
        SpeechSynthesizer speechSynth;
        RoundStage currentAnnouncement;
        DateTimeOffset roundStart;
        TimedRound round;
        bool gameFinished;

        public GamePage()
        {
            this.InitializeComponent();
            speechSynth = new SpeechSynthesizer();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rules = e.Parameter as GameRules;
            gameFinished = false;
            base.OnNavigatedTo(e);
            Voice.MediaEnded += AnnouncementFinished;
            roundTimer = new DispatcherTimer();
            roundTimer.Interval = TimeSpan.FromSeconds(1);
            roundTimer.Tick += RoundTimerTick;
        }

        private async void StartRound()
        {
            round = rules.GetCurrentRound();
            var announcementText = $"{round.RoundLength.TotalMinutes} minute round.  You must exchange {GetHostageText(round.HostageCount)} at the end.";
            currentAnnouncement = RoundStage.RoundStart;
            var speech = await speechSynth.SynthesizeTextToStreamAsync(announcementText);
            Voice.SetSource(speech, speech.ContentType);
            Voice.Play();
        }

        private void AnnouncementFinished(object sender, RoutedEventArgs e)
        {
            if(currentAnnouncement == RoundStage.RoundStart)
            {
                StartRoundTimer();
            }
        }

        private void RoundTimerTick(object sender, object args)
        {
            var elapsedTime = DateTimeOffset.Now - roundStart;
            var secondsRemaining = round.RoundLength.TotalSeconds - elapsedTime.TotalSeconds;
            if (secondsRemaining <= 30 && currentAnnouncement == RoundStage.RoundStart)
            {
                AnnounceThirtySecondsLeft();
            }
            else if(secondsRemaining <= 0)
            {
                roundTimer.Stop();
                EndRound();
            }
        }

        private void StartRoundTimer()
        {
            roundStart = DateTimeOffset.Now;
            roundTimer.Start();
        }

        private async void AnnounceThirtySecondsLeft()
        {
            currentAnnouncement = RoundStage.ThirtySecondsLeft;
            var speech = await speechSynth.SynthesizeTextToStreamAsync("Thirty seconds remaining.");
            Voice.SetSource(speech, speech.ContentType);
            Voice.Play();
        }

        private async void EndRound()
        {
            currentAnnouncement = RoundStage.RoundEnd;
            var announcementText = $"Round End! Leaders come to the meeting point. This round you must exchange {GetHostageText(round.HostageCount)}";
            var speech = await speechSynth.SynthesizeTextToStreamAsync(announcementText);
            Voice.SetSource(speech, speech.ContentType);
            Voice.Play();            
            if (rules.IsFinalRound())
            {
                RoundStartButton.Content = "Finish Game!";
                gameFinished = true;
            }
            else
            {
                rules.Advance();
            }
            RoundStartButton.Visibility = Visibility.Visible;
        }

        private void RoundStartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!gameFinished)
            {
                StartRound();
                RoundStartButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        private string GetHostageText(int hostageCount)
        {
            if(hostageCount == 1)
            {
                return "1 hostage";
            }
            return hostageCount + " hostages";
        }
    }

    enum RoundStage
    {
        RoundStart,
        ThirtySecondsLeft,
        RoundEnd
    }
}
