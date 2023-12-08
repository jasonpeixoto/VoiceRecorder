/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    public class Settings : BaseService, ISettings
    {
        public Settings()
        {
        }

        private Settings(IAppServices services) : base(services)
        {
        }

        // defaults for now, normally I would add my enviroment archeticure here
        public float SilenceThreshold => 0.02f;                // set silince threshold here
        public int AudioSilenceTimeout => 2;                         // set for silence then stop recording
        public double RecordingSeconds => AudioSilenceTimeout + 2;        // set to silence and add X seconds
    }
}
