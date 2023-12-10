using Xamarin.Essentials;

namespace VoiceRecorder.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            Platform.MapServiceToken = "AgoM3zdIaw-UeACok0N_wNoDU5kCXaJRSUCmpeKe-lhwL98OZRhogMAqQ4AfqQhz";
            LoadApplication(new VoiceRecorder.App());
        }
    }
}
