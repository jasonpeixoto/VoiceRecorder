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

        public Task<Stream> Load(string filename)
        {
            throw new NotImplementedException();
        }

        public Task Save(string filename, Stream audio)
        {
            throw new NotImplementedException();
        }
    }
}
