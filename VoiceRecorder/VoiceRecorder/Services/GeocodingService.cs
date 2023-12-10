/// ---------------------------------------------------------------------------------------
/// Author: Jason Peixoto
/// This code is for demo only, can not be reused without writtern permission.
/// ---------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoiceRecorder.Interfaces;
using Xamarin.Essentials;

namespace VoiceRecorder.Services
{
    public class GeocodingService : BaseService, IGeocodingService
    {
        private CancellationTokenSource cts;

        public GeocodingService()
        {
        }

        private GeocodingService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAddress()
        {
            string address = "";
            Location location = await GetCurrentLocation();
            if(location != null)
            {
                address = await GetAddress(location.Latitude, location.Longitude);
            }
            return address;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAddress(double lat, double lon)
        {
            string geocodeAddress = $"";
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    geocodeAddress =
                        $"{placemark.AdminArea} {placemark.CountryCode} {placemark.Locality} {placemark.PostalCode}";
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
            }
            return geocodeAddress;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Location> GetCurrentLocation()
        {
            Location location = null;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                location = await Geolocation.GetLocationAsync(request, cts.Token);           
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
            return location;
        }

    }
}
