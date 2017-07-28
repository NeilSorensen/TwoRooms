﻿using System;
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
        public GamePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            rules = e.Parameter as GameRules;
            
            base.OnNavigatedTo(e);
        }

        private void StartRound()
        {
            var round = rules.GetCurrentRound();
            var announcementText = $"{round.RoundLength.TotalMinutes} minute round.  You must exchange {round.HostageCount} hostages at the end.";
            
        }
    }
}