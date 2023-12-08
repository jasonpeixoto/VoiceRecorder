/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using TinyIoC;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    public class BaseService
    {
        protected IAppServices Services;
        protected ISettings Settings => Services.Settings;

        public BaseService(IAppServices services)
        {
            this.Services = services;
        }

        public BaseService()
        {
            this.Services = IOC.Services;
        }

        public TinyIoCContainer Container
        {
            get { return TinyIoCContainer.Current; }
        }
    }
}
