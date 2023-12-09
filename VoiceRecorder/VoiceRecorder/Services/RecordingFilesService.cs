/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.IO;
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Services
{
    internal class RecordingFilesService : BaseService, IRecordingFilesService
    {
        public RecordingFilesService()
        {
        }

        private RecordingFilesService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// copy new audio file to target file
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task Copy(string from, string to)
        {
            File.Copy(from, to, true);
        }
    }
}
