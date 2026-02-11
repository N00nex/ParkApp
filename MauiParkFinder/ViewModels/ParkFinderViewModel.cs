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
    private List<ParkHaus> _datenSätzeParkFinder = new();

    public ObservableCollection<ParkHaus> ParkHaeuser { get; } = new();

    [ObservableProperty]
    private ParkHaus _selectedParkHaus;
    
    [ObservableProperty]
    private SortOption _chosenSort = SortOption.Distanz;

    public int MinDistance { get; } = 0;
    public int MaxDistance { get; } = 50000;


    partial void OnChosenSortChanged(SortOption value) => Filtern();

    public List<SortOption> SortOptions { get; } = Enum.GetValues<SortOption>().ToList();

    public ParkFinderViewModel(ParkFinderService service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        _datenSätzeParkFinder = await _service.GetParkHaeuserAsync();
        Filtern();
    }

    [ObservableProperty]
    private int _maxErlaubteDistanzInMeter = 15000;

    [ObservableProperty]
    private bool _nurFreiePlätze;

    [ObservableProperty]    
    private bool _onlyOpen;

    partial void OnNurFreiePlätzeChanged(bool value) => Filtern();
    partial void OnMaxErlaubteDistanzInMeterChanged(int value)
    {
        // Wert auf gültigen Bereich begrenzen
        if (value > MaxDistance)
        {
            MaxErlaubteDistanzInMeter = MaxDistance;
            return;
        }
        if (value < MinDistance)
        {
            MaxErlaubteDistanzInMeter = MinDistance;
            return;
        }

        Filtern();
    }

    private void Filtern()
    {
        var sortierenResultat = _datenSätzeParkFinder.Where(p => p.Distanz <= _maxErlaubteDistanzInMeter);

        if (_nurFreiePlätze == true)
        {
            sortierenResultat = sortierenResultat.Where(p => p.VerfuegbarePlaetze > 0);
        }

        
        var sortedList = _chosenSort switch
        {
            SortOption.StartPreis => sortierenResultat.OrderBy(x => x.PreisKlasse?.StartPreis ?? decimal.MaxValue),
            SortOption.PreisProStunde => sortierenResultat.OrderBy(x => x.PreisKlasse?.PreisProStunde ?? decimal.MaxValue),
            SortOption.MaximalPreis => sortierenResultat.OrderBy(x => x.PreisKlasse?.MaximalPreis ?? decimal.MaxValue),
            _ => sortierenResultat.OrderBy(x => x.Distanz)
        };

        ParkHaeuser.Clear();
        foreach (var p in sortedList)  
            ParkHaeuser.Add(p);
    }

    [RelayCommand]
    private async Task GoToParkDetail()
    {
        if (SelectedParkHaus == null)
            return;

        await Shell.Current.GoToAsync(nameof(ParkDetailPage), new Dictionary<string, object>
        {
            ["SelectedParkHaus"] = SelectedParkHaus
        });

        SelectedParkHaus = null;
    }
}