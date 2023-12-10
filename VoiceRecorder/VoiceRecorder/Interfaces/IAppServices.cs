

using Xamarin.Essentials;

/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------


namespace VoiceRecorder.Interfaces
{
    public interface IAppServices
    {
        ICrashReportingService CrashReporting { get; set; }
        IDatabaseService Database { get; set; }
        IDependencyService Dependency { get; set; }
        IGeocodingService Geocoding { get; set; }
        ILogCatService LogCat { get; set; }
        INavigationService Navigation { get; set; }
        IRecordingFilesService RecordingFiles { get; set; }
        IRecorderService Recorder { get; set; }
        ISettings Settings { get; set; }
    }
}
