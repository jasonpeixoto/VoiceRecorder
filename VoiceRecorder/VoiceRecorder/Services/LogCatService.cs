/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    public class LogCatService : BaseService, ILogCatService
    {
        public LogCatService()
        {
        }

        private LogCatService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// Push the specified message.
        /// </summary>
        /// <returns>The push.</returns>
        /// <param name="message">Message.</param>
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void Print(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

