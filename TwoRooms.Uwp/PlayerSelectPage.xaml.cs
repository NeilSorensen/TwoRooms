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
using TwoRooms.Domain;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TwoRooms.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerSelectPage : Page
    {
        public PlayerSelectPage()
        {
            this.InitializeComponent();
        }

        private void SixToTenPlayers(object sender, RoutedEventArgs e)
        {
            PlayerCountSelected(PlayerCount.SixToTen);
        }

        private void ElevenToThirteenPlayers(object sender, RoutedEventArgs e)
        {
            PlayerCountSelected(PlayerCount.ElevenToThirteen);
        }

        private void FourteenToSeventeenPlayers(object sender, RoutedEventArgs e)
        {
            PlayerCountSelected(PlayerCount.FourteenToSeventeen);
        }

        private void EighteenToTwentyOnePlayers(object sender, RoutedEventArgs e)
        {
            PlayerCountSelected(PlayerCount.EighteenToTwentyOne);
        }

        private void TwentyTwoPlusPlayers(object sender, RoutedEventArgs e)
        {
            PlayerCountSelected(PlayerCount.TwentyTwoPlus);
        }

        private void PlayerCountSelected(PlayerCount count)
        {
            var gameTypes = RuleFactory.GetSupportedGameTypes(count);
            if (gameTypes.Count() == 1)
            {
                var rules = RuleFactory.GetGameRules(count, gameTypes.First());
                Frame.Navigate(typeof(GamePage), rules);
            }
            else
            {
                Frame.Navigate(typeof(GameTypeSelectPage), new GameTypeSelectViewModel { Player = count, GameTypes = gameTypes });
            }
        }
    }
}
