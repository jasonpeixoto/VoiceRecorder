/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Runtime;
using TinyIoC;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    public class AppServices : IAppServices
    {
        public AppServices()
        {
            try
            {
                Container.Register<ICrashReportingService, CrashReportingService>().AsSingleton();
                Container.Register<IDatabaseService, DatabaseService>().AsSingleton();
                Container.Register<IDependencyService, DependencyService>().AsSingleton();
                Container.Register<IGeocodingService, GeocodingService>().AsSingleton();
                Container.Register<ILogCatService, LogCatService>().AsSingleton();
                Container.Register<INavigationService, NavigationService>().AsSingleton();
                Container.Register<IRecordingFilesService, RecordingFilesService>().AsSingleton();
                Container.Register<IRecorderService, RecorderService>().AsSingleton();
                Container.Register<ISettings, Settings>().AsSingleton();
            }
            catch (Exception ex)
            {
                CrashReporting?.Crash(ex);
            }
        }

        public static TinyIoCContainer Container
        {
            get { return TinyIoCContainer.Current; }
        }

        protected ICrashReportingService _CrashReporting;
        public ICrashReportingService CrashReporting
        {
            get { return _CrashReporting ?? (_CrashReporting = Container.Resolve<ICrashReportingService>()); }
            set { _CrashReporting = value; }
        }

        protected IDatabaseService _Database;
        public IDatabaseService Database
        {
            get { return _Database ?? (_Database = Container.Resolve<IDatabaseService>()); }
            set { _Database = value; }
        }

        protected IDependencyService _Dependency;
        public IDependencyService Dependency
        {
            get { return _Dependency ?? (_Dependency = Container.Resolve<IDependencyService>()); }
            set { _Dependency = value; }
        }

        protected IGeocodingService _Geocoding;
        public IGeocodingService Geocoding
        {
            get { return _Geocoding ?? (_Geocoding = Container.Resolve<IGeocodingService>()); }
            set { _Geocoding = value; }
        }

        protected INavigationService _Navigation;
        public INavigationService Navigation
        {
            get { return _Navigation ?? (_Navigation = Container.Resolve<INavigationService>()); }
            set { _Navigation = value; }
        }

        protected ILogCatService _LogCat;
        public ILogCatService LogCat
        {
            get { return _LogCat ?? (_LogCat = Container.Resolve<ILogCatService>()); }
            set { _LogCat = value; }
        }

        protected IRecordingFilesService _RecordingFiles;
        public IRecordingFilesService RecordingFiles
        {
            get { return _RecordingFiles ?? (_RecordingFiles = Container.Resolve<IRecordingFilesService>()); }
            set { _RecordingFiles = value; }
        }

        protected IRecorderService _Recorder;
        public IRecorderService Recorder
        {
            get { return _Recorder ?? (_Recorder = Container.Resolve<IRecorderService>()); }
            set { _Recorder = value; }
        }

        protected ISettings _Settings;
        public ISettings Settings
        {
            get { return _Settings ?? (_Settings = Container.Resolve<ISettings>()); }
            set { _Settings = value; }
        }

    }
}