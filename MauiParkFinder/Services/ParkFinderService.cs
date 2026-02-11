using MauiParkFinder.Models;
using System.Net.Http.Json;
using System.Diagnostics;

namespace MauiParkFinder.Services
{
    public class ParkFinderService
    {
        private readonly HttpClient _httpClient;
        
        
        private static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android 
            ? "http://10.0.2.2:60002/api/" 
            : "http://localhost:60002/api/";

        public ParkFinderService()
        {
            
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl),
                //Timeout = TimeSpan.FromSeconds(10) 
            };
        }

        public async Task<List<ParkHaus>> GetParkHaeuserAsync()
        {
            try
            {
                // Ensure the casing matches your Controller name exactly
                var response = await _httpClient.GetAsync("ParkHaus");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ParkHaus>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API ERROR: {ex.Message}");
            }
            return new List<ParkHaus>();
        }

    }
}