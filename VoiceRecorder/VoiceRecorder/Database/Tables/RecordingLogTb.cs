/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace VoiceRecorder.Database.Tables
{
    public class RecordingLogTb : IEqualityComparer<RecordingLogTb>, IComparable<RecordingLogTb>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AudioFile { get; set; }
        public DateTime DateRecorded { get; set; }
        public double Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RecordingLogTb()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(RecordingLogTb other)
        {
            return this.Id.CompareTo(other.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(RecordingLogTb x, RecordingLogTb y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(RecordingLogTb obj)
        {
            return obj.Id.GetHashCode();
        }

    }
}