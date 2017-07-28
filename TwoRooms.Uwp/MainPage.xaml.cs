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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TwoRooms.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SpeechSynthesizer speechSynth;
        public MainPage()
        {
            this.InitializeComponent();
            speechSynth = new SpeechSynthesizer();
        }

        private async void ButtonPressed(object sender, RoutedEventArgs e)
        {
            //var stream = await speechSynth.SynthesizeTextToStreamAsync("10 9 8 7 6 5 4 3 2 1");
            //Voice.SetSource(stream, stream.ContentType);
            //Voice.Play();
            Frame.Navigate(typeof(PlayerSelectPage));
        }
    }
}
