/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Threading.Tasks;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Helpers;
using VoiceRecorder.Models;
using Xamarin.Forms;

namespace VoiceRecorder.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private IRecordingLogRepository dbRepo;

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

        // play 
        public Command PlayRecordingCommand { get; }
        public Command StopRecordingCommand { get; }

        public DashboardViewModel()
        {
            // get object o repo
            dbRepo = Services.Database.RecordingLogRepo;

            // create our funstions for our commands
            PlayRecordingCommand = new Command(async () => await ExecutePlayRecordingCommand());
            StopRecordingCommand = new Command(async () => await ExecuteStopRecordingCommand());

            // we need our obserable list
            recordings = new RangeObservableCollection<RecordingLog>();

            // set defaults for buttons
            IsPlayRecordngEnabled = false;
            IsStopRecordngEnabled = false;

            // ok now load recordings from database into list
            LoadRecordingsFromDatabase();

            Services.Recorder.RecordComplete += Recorder_RecordComplete;
            Services.Recorder.StartRecording();
        }

        /// <summary>
        /// when recording is complete insert record into obserable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recorder_RecordComplete(object sender, RecordingLog e)
        {
            // push to the top of the queue
            Recordings.Insert(0, e);
        }

        public override void InitlizeModel()
        {
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;
        }

        public async Task LoadRecordingsFromDatabase()
        {
            // get list of all records
            var records = await dbRepo.Select();
            Recordings.ClearAddRange(records);
        }

        public async Task ExecutePlayRecordingCommand()
        {

        }

        public async Task ExecuteStopRecordingCommand()
        {
            
        }
    }
}
