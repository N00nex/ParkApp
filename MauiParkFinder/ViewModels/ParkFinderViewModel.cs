using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiParkFinder.Models;
using MauiParkFinder.Services;
using System.Collections.ObjectModel;
using MauiParkFinder.Views;

namespace MauiParkFinder.ViewModels;
public partial class ParkFinderViewModel : BaseViewModel
{
    private readonly ParkFinderService _service;
    private List<ParkingGarage> _allParkingGarages = new();

    public ObservableCollection<ParkingGarage> ParkingGarages { get; } = new();

    [ObservableProperty]
    private ParkingGarage _selectedParkingGarage;
    
    [ObservableProperty]
    private SortOption _chosenSort = SortOption.Distanz;

    public int MinDistance { get; } = 0;
    public int MaxDistance { get; } = 50000;


    partial void OnChosenSortChanged(SortOption value) => Filter();

    public List<SortOption> SortOptions { get; } = Enum.GetValues<SortOption>().ToList();

    public ParkFinderViewModel(ParkFinderService service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        _allParkingGarages = await _service.GetParkingGarageAsync();
        Filter();
    }

    [ObservableProperty]
    private int _maxAllowedDistanceInMeters = 15000;

    [ObservableProperty]
    private bool _onlyAvailableSpaces;

    [ObservableProperty]    
    private bool _onlyOpen;

    partial void OnOnlyAvailableSpacesChanged(bool value) => Filter();
    partial void OnMaxAllowedDistanceInMetersChanged(int value)
    {
        // Wert auf gültigen Bereich begrenzen
        if (value > MaxDistance)
        {
            MaxAllowedDistanceInMeters = MaxDistance;
            return;
        }
        if (value < MinDistance)
        {
            MaxAllowedDistanceInMeters = MinDistance;
            return;
        }

        Filter();
    }

    private void Filter()
    {
        var filteredResult = _allParkingGarages.Where(p => p.Distance <= _maxAllowedDistanceInMeters);

        if (_onlyAvailableSpaces == true)
        {
            filteredResult = filteredResult.Where(p => p.AvailableSpaces > 0);
        }

        
        var sortedList = _chosenSort switch
        {
            SortOption.Einfahrtstarif => filteredResult.OrderBy(x => x.Price?.Entrance ?? decimal.MaxValue),
            SortOption.Stundentarif => filteredResult.OrderBy(x => x.Price?.PerHour ?? decimal.MaxValue),
            SortOption.TagesPauschale => filteredResult.OrderBy(x => x.Price?.MaxDaily ?? decimal.MaxValue),
            _ => filteredResult.OrderBy(x => x.Distance)
        };

        ParkingGarages.Clear();
        foreach (var p in sortedList)  
            ParkingGarages.Add(p);
    }

    [RelayCommand]
    private async Task GoToParkDetail()
    {
        if (SelectedParkingGarage == null)
            return;

        await Shell.Current.GoToAsync(nameof(ParkDetailPage), new Dictionary<string, object>
        {
            ["SelectedParkingGarage"] = SelectedParkingGarage
        });

        SelectedParkingGarage = null;
    }
}