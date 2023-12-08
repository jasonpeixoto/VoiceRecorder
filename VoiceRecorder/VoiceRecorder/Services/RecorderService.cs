/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using Plugin.AudioRecorder;
using System;
using System.Text;
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;
using VoiceRecorder.Models;

namespace VoiceRecorder.Services
{
    public class RecorderService : BaseService, IRecorderService
    {
        private AudioRecorderService recorder;
        private AudioPlayer player;

        public bool IsRecording => recorder.IsRecording;
        private bool isPlaying { get; set; }
        public bool IsPlaying => isPlaying;

        public RecorderService()
        {
            Init();
        }

        private RecorderService(IAppServices services) : base(services)
        {
            Init();
        }

        private void Init()
        {
            recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                SilenceThreshold = 0.02f,
                AudioSilenceTimeout = TimeSpan.FromSeconds(2)
            };
            recorder.AudioInputReceived += Recorder_AudioInputReceived;

            isPlaying = false;
            player = new AudioPlayer();
            player.FinishedPlaying += Player_FinishedPlaying;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="audioFile"></param>
        private async void Recorder_AudioInputReceived(object sender, string audioFile)
        {
            // ok we need to analize the file here see if it is more than X seconds long
            if(audioFile != null)
            {
                // ok if we meet the time frame then we can create a new database record and copy the audio file over
                // TODO: 
            }
            // start recording again
            await StartRecording();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordingLog"></param>
        /// <returns></returns>
        public async Task<bool> StartPlayRecording(RecordingLog recordingLog)
        {
            return await StartPlayRecording(recordingLog.AudioFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StartRecording()
        {
            // first stop playing if playing
            player.Pause();

            // if not recording then start it
            if (!IsRecording)
            {
                var audioRecordTask = await recorder.StartRecording();
                await audioRecordTask;
            }
            return true;
        }

        /// <summary>
        /// Stop the recording
        /// </summary>
        /// <returns></returns>
        public async Task<string> StopRecording()
        {
            if (!IsRecording) return null;
            await recorder.StopRecording();
            return recorder.GetAudioFilePath();
        }

        /// <summary>
        /// Play audio file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<bool> StartPlayRecording(string filename)
        {
            // first stop recording
            await StopRecording();
            player.Play(filename);
            return true;
        }

        /// <summary>
        /// Stop play
        /// </summary>
        /// <returns></returns>
        public async Task<bool> StopPlayRecording()
        {
            if (IsPlaying)
            {
                // stop playing
                player.Pause();
                isPlaying = false;
            }

            // ok start recording that play is stopped
            return await StartRecording();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async void Player_FinishedPlaying(object sender, EventArgs e)
        {
            // time to start recording again
            await StartRecording();
        }
    }
}
