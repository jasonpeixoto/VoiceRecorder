/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using LiteDB;
using VoiceRecorder.Database.Repository.Interfaces;
using VoiceRecorder.Interfaces;

namespace VoiceRecorder.Database.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected IDatabaseService Database => services?.Database;
        protected IAppServices services;
        protected ILiteDatabase db;
        private string _TblName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_db"></param>
        public GenericRepository(string tblName, LiteDatabase _db)
        {
            _TblName = tblName;
            db = _db;
            services = IOC.Services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_services"></param>
        /// <param name="_db"></param>
        public GenericRepository(string tblName, IAppServices _services, LiteDatabase _db)
        {
            _TblName = tblName;
            services = _services;
            db = _db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_services"></param>
        public GenericRepository(string tblName, IAppServices _services)
        {
            _TblName = tblName;
            services = _services;
            db = services.Database.DB;
        }

        /// <summary>
        /// 
        /// </summary>
        public GenericRepository(string tblName)
        {
            _TblName = tblName;
            services = IOC.Services;
            db = services.Database.DB;
        }

        public ILiteCollection<T> Collection => db.GetCollection<T>(_TblName);
    }
}