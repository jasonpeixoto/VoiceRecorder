/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using LiteDB.Engine;
using LiteDB;
using VoiceRecorder.Interfaces;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Database.Repository;
using System;
using System.IO;

namespace VoiceRecorder.Services
{
    public class DatabaseService : BaseService, IDatabaseService
    {
        public static string DbName = "database.db";

        private ILiteDatabase _db;
        public ILiteDatabase DB
        {
            get
            {
                if (_db == null)
                {
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DbName);
                    var dbSettings = new EngineSettings()
                    {
                        Filename = fileName
                    };
                    Services.LogCat.Print(fileName);
                    var dbEngine = new LiteEngine(dbSettings);
                    _db = new LiteDatabase(dbEngine);
                }
                return _db;
            }
        }

        // access repo from database services
        private IRecordingLogRepository _RecordingLogRepo;
        public IRecordingLogRepository RecordingLogRepo { get { return (_RecordingLogRepo == null) ? _RecordingLogRepo = new RecordingLogRepository() : _RecordingLogRepo; } }

        /// <summary>
        ///
        /// </summary>
        public DatabaseService()
        {
        }
    }
}

