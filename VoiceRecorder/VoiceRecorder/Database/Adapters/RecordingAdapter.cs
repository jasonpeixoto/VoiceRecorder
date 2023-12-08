/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using VoiceRecorder.Database.Tables;
using VoiceRecorder.Extensions;
using VoiceRecorder.Models;

namespace VoiceRecorder.Database.Adapters
{
    public static class RecordingAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static RecordingLog Convert(this RecordingLogTb input)
        {
            if (input == null) return null;
            RecordingLog recordingLog = new RecordingLog() {
                Id = input.Id,
                Title = input.Title,
                AudioFile = input.AudioFile,
                DateRecorded = input.DateRecorded,
            };
            return recordingLog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static RecordingLogTb Convert(this RecordingLog input)
        {
            if (input == null) return null;
            RecordingLogTb recordingLogTb = new RecordingLogTb() {
                Id = input.Id,
                Title = input.Title,
                AudioFile = input.AudioFile,
                DateRecorded = input.DateRecorded,
            };
            return recordingLogTb;
        }
    }
}
