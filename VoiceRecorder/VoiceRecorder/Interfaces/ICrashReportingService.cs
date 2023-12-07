/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;

namespace VoiceRecorder.Interfaces
{
    public interface ICrashReportingService
    {
        Task Crash(Exception ex);
        Task Crash(string message);
    }
}
