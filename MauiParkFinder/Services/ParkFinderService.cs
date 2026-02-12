using MauiParkFinder.Models;
using System.Net.Http.Json;
using System.Diagnostics;

namespace MauiParkFinder.Services
{
    public class ParkFinderService
    {
        private readonly HttpClient _httpClient;
        
        
        private static readonly string _BaseUrl = DeviceInfo.Platform == DevicePlatform.Android 
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
                BaseAddress = new Uri(_BaseUrl),
            };
        }

        public async Task<List<ParkingGarage>> GetParkingGarageAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("ParkingGarage");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<ParkingGarage>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"API ERROR: {ex.Message}");
            }
            return new List<ParkingGarage>();
        }

    }
}