/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace VoiceRecorder.Interfaces
{
    public interface IGeocodingService
    {
        Task<string> GetAddress();
        Task<string> GetAddress(double lat, double lon);
        Task<Location> GetCurrentLocation();
    }
}
