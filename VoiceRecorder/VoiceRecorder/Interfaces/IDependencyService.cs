﻿/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------

namespace VoiceRecorder.Interfaces
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
