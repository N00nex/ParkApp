using System.Collections.ObjectModel;
using MauiParkFinder.Services;
using CommunityToolkit.Mvvm.ComponentModel; //Für ObservableObject
using CommunityToolkit.Mvvm.Input;
using MauiParkFinder.Models; //Für RelayCommand führt dazu dass weniger Boilerplate Code geschrieben wird (Empfehlung von KI)

namespace MauiParkFinder.ViewModels;
public partial class ParkFinderViewModel : ObservableObject
{
    private readonly ParkFinderService _service;

    
    public ObservableCollection<ParkHaus> ParkHaeuser { get; } = new();
    public ObservableCollection<PreisKlasse> PreisKlassen { get; } = new();

    public ParkFinderViewModel(ParkFinderService service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        var items = await _service.GetParkHaeuserAsync();
        ParkHaeuser.Clear();
        foreach (var item in items) ParkHaeuser.Add(item);
    }
}