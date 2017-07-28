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
    public sealed partial class GameTypeSelectPage : Page
    {
        private GameTypeSelectViewModel viewModel;

        public GameTypeSelectPage()
        {
            this.InitializeComponent();
        }

        private void BasicGame(object sender, RoutedEventArgs e)
        {

        }

        private void AdvancedGame(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = e.Parameter as GameTypeSelectViewModel;
            if(viewModel == null)
            {
                viewModel = new GameTypeSelectViewModel
                {
                    Player = PlayerCount.ElevenToThirteen,
                    GameTypes = new List<GameType> { GameType.Basic, GameType.Advanced}
                };
            }
            base.OnNavigatedTo(e);
        }
    }
}
