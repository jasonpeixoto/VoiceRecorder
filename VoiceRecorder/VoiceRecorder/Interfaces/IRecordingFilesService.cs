/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.IO;
using System.Threading.Tasks;

namespace VoiceRecorder.Interfaces
{
    public interface IRecordingFilesService
    {
        Task Save(string filename, Stream audio);
        Task<Stream> Load(string filename);
    }
}
