/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Threading.Tasks;
using VoiceRecorder.Models;

namespace VoiceRecorder.Interfaces
{
    public interface INavigationService
    {
        Task Dashboard();
        Task PlayRecording(RecordingLog model);
    }
}
