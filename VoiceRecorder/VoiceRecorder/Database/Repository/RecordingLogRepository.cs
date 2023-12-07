/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VoiceRecorder.Database.Adapters;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Database.Tables;
using VoiceRecorder.Interfaces;
using VoiceRecorder.Models;

namespace VoiceRecorder.Database.Repository
{
    public class RecordingLogRepository : GenericRepository<RecordingLogTb>, IRecordingLogRepository
    {
        private static string TblName = "recording";

        public RecordingLogRepository() : base(TblName)
        {
        }

        public RecordingLogRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public RecordingLogRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public RecordingLogRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerLineNumber"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        public async Task Insert(string title)
        {
            await Insert(new RecordingLog(title));
        }

        /// <summary>
        /// Insert new recordLog
        /// </summary>
        /// <param name="recordLog"></param>
        /// <returns></returns>
        public async Task Insert(RecordingLog recordingLog)
        {
            RecordingLogTb recordingLogTb = recordingLog.Convert();
            try
            {
                if (recordingLogTb != null)
                {
                    this.Collection.Insert(recordingLogTb);
                }
            }
            catch (Exception ex)
            {
                IOC.Services.LogCat.Print(ex);
            }
        }

        /// <summary>
        /// return null if none found, now adaptor will return null model if table is null as well.
        /// </summary>
        /// <returns></returns>
        public async Task<RecordingLogTb> Select(string id)
        {
            RecordingLogTb recordingLogTb = this.Collection.FindOne(sr => sr.Id == id);
            return await Task.FromResult<RecordingLogTb>(recordingLogTb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<RecordingLogTb>> Select(Expression<Func<RecordingLogTb, bool>> predicate = null)
        {
            List<RecordingLogTb> recordingLogTb = new List<RecordingLogTb>();
            IEnumerable<RecordingLogTb> recordingLogTbs = (predicate != null) ?
                this.Collection.Find(predicate) :
                this.Collection.FindAll();
            if (recordingLogTbs != null)
            {
                foreach (RecordingLogTb record in recordingLogTbs)
                {
                    recordingLogTb.Add(record);
                }
            }
            return await Task.FromResult<List<RecordingLogTb>>(recordingLogTb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordLogTb"></param>
        /// <returns></returns>
        public async Task<bool> Update(RecordingLog recordLog)
        {
            RecordingLogTb recordingLogTb = recordLog.Convert();
            return await Update(recordingLogTb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordLogTb"></param>
        /// <returns></returns>
        public async Task<bool> Update(RecordingLogTb recordLogTb)
        {
            bool result = false;
            if (recordLogTb != null)
            {
                result = this.Collection.Update(recordLogTb);
            }
            return await Task.FromResult<bool>(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordLogTb"></param>
        /// <returns></returns>
        public async Task<bool> Delete(RecordingLogTb recordLogTb)
        {
            bool result = false;
            if (recordLogTb != null)
            {
                result = this.Collection.Delete(recordLogTb.Id);
            }
            return await Task.FromResult<bool>(result);
        }
    }
}