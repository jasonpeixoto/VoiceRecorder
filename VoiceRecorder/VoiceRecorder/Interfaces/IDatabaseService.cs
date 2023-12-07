/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using LiteDB;
using VoiceRecorder.Database.Repository.Interfaces;

namespace VoiceRecorder.Interfaces
{
    public interface IDatabaseService
    {
        ILiteDatabase DB { get; }
        IRecordingLogRepository RecordingLogRepo { get; }
    }
}
