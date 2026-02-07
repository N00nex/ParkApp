using MauiParkFinder.Models;
using System.Net.Http.Json;
using System.Diagnostics;

namespace MauiParkFinder.Services
{
    public class ParkFinderService
    {
        private readonly HttpClient _httpClient;
        
        // Use 10.0.2.2 for Android and match your Docker port 60002
        private static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android 
            ? "http://10.0.2.2:60002/api/" 
            : "http://localhost:60002/api/";

        public ParkFinderService()
        {
            // Use the native Android handler for better compatibility with 10.0.2.2
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl),
                Timeout = TimeSpan.FromSeconds(10) // Prevents the app from hanging if the API is slow
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

        public async Task<List<PreisKlasse>> GetPreisKlasseAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("PreisKlasse");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<PreisKlasse>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API ERROR: {ex.Message}");
            }
            return new List<PreisKlasse>();
        }
    }
}