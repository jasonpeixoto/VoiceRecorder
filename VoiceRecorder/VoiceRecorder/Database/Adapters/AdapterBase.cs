/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Linq;

namespace VoiceRecorder.Database.Adapters
{
    public abstract class AdapterBase<Tout, Tin>
    {
        public abstract Tout ConvertFrom(Tin input);

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual IEnumerable<Tout> Convert(IEnumerable<Tin> list)
        {
            return list.Select(tn => ConvertFrom(tn));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual IList<Tout> Convert(IList<Tin> list)
        {
            return list.Select(tn => ConvertFrom(tn)).ToList();
        }
    }
}


