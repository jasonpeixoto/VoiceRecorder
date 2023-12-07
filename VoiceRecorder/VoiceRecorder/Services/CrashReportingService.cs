/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    public class CrashReportingService : BaseService, ICrashReportingService
    {
        public CrashReportingService()
        {
        }

        private CrashReportingService(IAppServices services) : base(services)
        {
        }

        /// ----------------------------------------------------------------------------------------
		/// <summary>
        /// Push the specified className, methodName and ex.
        /// </summary>
        /// <returns>The push.</returns>
        /// ----------------------------------------------------------------------------------------
		public async Task Crash(Exception ex)
        {
            Services.LogCat.Print(ex.ToString());
        }

        /// ----------------------------------------------------------------------------------------
		/// <summary>
        /// Push the specified className, methodName and message.
        /// </summary>
        /// <returns>The push.</returns>
        /// ----------------------------------------------------------------------------------------
		public async Task Crash(string message)
        {
            Services.LogCat.Print(message);
        }
    }
}
