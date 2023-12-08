/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------

namespace VoiceRecorder.Interfaces
{
    public interface ISettings
    {
        float SilenceThreshold { get; }
        int AudioSilenceTimeout { get;  }
        double RecordingSeconds { get;  }
    }
}
