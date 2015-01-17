using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SimplePlayer
{
    public sealed partial class MainPage : Page
    {
        SystemMediaTransportControls systemControls;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            systemControls = SystemMediaTransportControls.GetForCurrentView();
            systemControls.ButtonPressed += systemControls_ButtonPressed;

            systemControls.IsPlayEnabled = true;
            systemControls.IsPauseEnabled = true;
        }

        void systemControls_ButtonPressed(SystemMediaTransportControls sender, SystemMediaTransportControlsButtonPressedEventArgs args)
        {
            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    PlayMedia();
                    break;

                case SystemMediaTransportControlsButton.Pause:
                    PauseMedia();
                    break;
                default:
                    break;
            }
        }

        async void PauseMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    media.Pause();
                });
        }

        async void PlayMedia()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                media.Play();
            });
        }

        


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            PlayMedia();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (media.CanPause) 
            {
                PauseMedia();
            }
        }
    }
}
