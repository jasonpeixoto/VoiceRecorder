/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using VoiceRecorder.Database.Tables;

namespace VoiceRecorder.Models
{
    public class RecordingLog : RecordingLogTb
    {
        public RecordingLog() 
        {
            Create("");
        }

        public RecordingLog(string title)
        {
            Create(title);
        }

        /// <summary>
        /// create defaults for model including Id
        /// </summary>
        /// <param name="title"></param>
        public void Create(string title)
        {
            this.Title = title;
            this.DateRecorded = DateTime.Now;
        }
    }
}