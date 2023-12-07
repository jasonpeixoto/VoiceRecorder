/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using VoiceRecorder.Interfaces;
using VoiceRecorder.Services;

namespace VoiceRecorder
{
    public static class IOC
    {
        /// ------------------------------------------------------------------------------------------
        /// <summary>
		/// Setup this instance.
		/// </summary>
        /// ------------------------------------------------------------------------------------------
        public static void Setup()
        {
            Container.Register<IAppServices, AppServices>().AsSingleton();
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
		/// Gets the container.
		/// </summary>
		/// <value>The container.</value>
        /// ------------------------------------------------------------------------------------------
        public static TinyIoC.TinyIoCContainer Container
        {
            get { return TinyIoC.TinyIoCContainer.Current; }
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
		/// The services.
		/// </summary>
        /// ------------------------------------------------------------------------------------------
        private static IAppServices _Services;
        public static IAppServices Services
        {
            get
            {
                if (_Services == null)
                {
                    IOC.Setup();
                    _Services = Container.Resolve<IAppServices>();
                }
                return _Services;
            }
        }
    }
}
