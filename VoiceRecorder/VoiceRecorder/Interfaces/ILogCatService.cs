/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;

namespace VoiceRecorder.Interfaces
{
    public interface ILogCatService
    {
        void Print(string message);
        void Print(Exception ex);
    }
}
