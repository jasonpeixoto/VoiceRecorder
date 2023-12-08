/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VoiceRecorder.Database.Tables;
using VoiceRecorder.Models;

namespace VoiceRecorder.Database.Repository.Interfaces
{
    public interface IRecordingLogRepository
    {
        // insert by title only
        Task Insert(string title);
        // insert a model
        Task Insert(RecordingLog record);
        // update record
        Task<bool> Update(RecordingLog record);
        // delete record
        Task<bool> Delete(RecordingLog record);
        // get RecordingLog by id
        Task<RecordingLog> Select(string id);
        // get list of logs and can pass a search predicate function
        Task<List<RecordingLog>> Select(Expression<Func<RecordingLogTb, bool>> predicate = null);
    }
}
