/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using Newtonsoft.Json;
using System;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Extensions
{
    public static class ObjectExtentions
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T GetObject<T>()
        {
            if (typeof(T).IsValueType || typeof(T) == typeof(string))
            {
                return default(T);
            }
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
