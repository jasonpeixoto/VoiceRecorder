/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Threading.Tasks;
using VoiceRecorder.Database.Repository;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Helpers;
using VoiceRecorder.Models;
using Xamarin.Forms;

namespace VoiceRecorder.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private IRecordingLogRepository dbRepo;

        private bool isStartRecordngEnabled;
        public bool IsStartRecordngEnabled
        {
            get => isStartRecordngEnabled;
            set => OnPropertyChanged(isStartRecordngEnabled = value);
        }

        private bool isStopRecordngEnabled;
        public bool IsStopRecordngEnabled
        {
            get => isStopRecordngEnabled;
            set => OnPropertyChanged(isStopRecordngEnabled = value);
        }

        private bool isPlayRecordngEnabled;
        public bool IsPlayRecordngEnabled
        {
            get => isPlayRecordngEnabled;
            set => OnPropertyChanged(isPlayRecordngEnabled = value);
        }

        private RangeObservableCollection<RecordingLog> recordings;
        public RangeObservableCollection<RecordingLog> Recordings
        {
            get => this.recordings;
            set => OnPropertyChanged(recordings = value);
        }

        public Command StartRecordingCommand { get; }
        public Command PlayRecordingCommand { get; }
        public Command StopRecordingCommand { get; }

        public DashboardViewModel()
        {
            // get object o repo
            dbRepo = Services.Database.RecordingLogRepo;

            // create our funstions for our commands
            StartRecordingCommand = new Command(async () => await ExecuteStartRecordingCommand());
            PlayRecordingCommand = new Command(async () => await ExecutePlayRecordingCommand());
            StopRecordingCommand = new Command(async () => await ExecuteStopRecordingCommand());

            // we need our obserable list
            recordings = new RangeObservableCollection<RecordingLog>();

            // set defaults for buttons
            IsStartRecordngEnabled = true;
            IsPlayRecordngEnabled = false;
            IsStopRecordngEnabled = false;

            // ok now load recordings from database into list
            LoadRecordingsFromDatabase();

            Services.Recorder.StartRecording(); ;
        }

        public override void InitlizeModel()
        {
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;


        }

        public void LoadRecordingsFromDatabase()
        {

        }

        public async Task ExecuteStartRecordingCommand()
        {

        }

        public async Task ExecutePlayRecordingCommand()
        {

        }

        public async Task ExecuteStopRecordingCommand()
        {

        }
    }
}
