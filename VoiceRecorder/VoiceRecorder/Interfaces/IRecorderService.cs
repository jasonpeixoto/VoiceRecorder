/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using VoiceRecorder.Models;

namespace VoiceRecorder.Interfaces
{
    public interface IRecorderService
    {
        event EventHandler<RecordingLog> RecordComplete;
        bool IsRecording { get; }
        bool IsPlaying { get; }
        Task<bool> StartRecording();
        Task<string> StopRecording();
        Task<bool> StartPlayRecording(string filename);
        Task<bool> StartPlayRecording(RecordingLog recordingLog);
        Task<bool> StopPlayRecording();
    }
}
