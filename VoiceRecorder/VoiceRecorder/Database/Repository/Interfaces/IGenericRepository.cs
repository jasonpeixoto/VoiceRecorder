/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using LiteDB;

namespace VoiceRecorder.Database.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        ILiteCollection<T> Collection { get; }
    }
}

