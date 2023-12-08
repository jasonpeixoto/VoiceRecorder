/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using Plugin.AudioRecorder;
using System;
using System.IO;
using System.Threading.Tasks;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Interfaces;
using VoiceRecorder.Models;

namespace VoiceRecorder.Services
{
    public class RecorderService : BaseService, IRecorderService
    {
        private AudioRecorderService recorder;
        private IRecordingLogRepository dbRepo;
        private AudioPlayer player;
        private DateTime startTime;

        public event EventHandler<RecordingLog> RecordComplete;

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
            // get object o repo
            dbRepo = Services.Database.RecordingLogRepo;

            // create recorder 
            recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                SilenceThreshold = Settings.SilenceThreshold,
                AudioSilenceTimeout = TimeSpan.FromSeconds(Settings.AudioSilenceTimeout)
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
                DateTime endTime = DateTime.Now;
                double diffInSeconds = endTime.Subtract(startTime).TotalSeconds;

                if (diffInSeconds > Settings.RecordingSeconds)
                {
                    // ok create record and save in database
                    RecordingLog recordComplete = new RecordingLog()
                    {
                        DateRecorded = DateTime.Now
                    };

                    // get location to save file
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), recordComplete.Id.ToString() + ".wav");

                    // update audio file location
                    recordComplete.AudioFile = fileName;

                    // insert into the database
                    await dbRepo.Insert(recordComplete);

                    // copy file from source to dest
                    await Services.RecordingFiles.Copy(audioFile, fileName);

                    // ok notify caller use a message in future
                    if (RecordComplete != null) RecordComplete.Invoke(this, recordComplete);
                }
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
            startTime = DateTime.Now;

            // if not recording then start it
            if (!IsRecording)
            {
                await recorder.StartRecording();
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
            await StopPlayRecording();
        }
    }
}
