using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PlayMusic
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            volSlider.Value = 10;
        }

        async void PlayMusic()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                Uri pathUri = new Uri("ms-appx:///Assets/Music/tailtoddle_lo.mp3");

                song.Source = pathUri;
                song.Play();
            });
        }

        async void PauseMusic()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                song.Pause();
            });
        }

        async void StopMusic()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                song.Stop();
            });
        }
        async void volChanged(double vol)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                song.Volume = vol;
            });
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayMusic();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            PauseMusic();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopMusic();
        }
        private void volSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            volChanged(volSlider.Value/100);
        }
    }
}
