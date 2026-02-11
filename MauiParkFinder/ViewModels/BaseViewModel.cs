using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiParkFinder.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task OpenMapsAsync(string link)
        {
            if (string.IsNullOrWhiteSpace(link)) return;

            try
            {
                await Launcher.Default.OpenAsync(link);
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Fehler", "Maps konnte nicht geöffnet werden", "OK");
            }
        }

        public async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                
                PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                }

                if (status != PermissionStatus.Granted)
                    return null; 

                
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                Location location = await Geolocation.Default.GetLocationAsync(request);

                return location;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
    }
}
