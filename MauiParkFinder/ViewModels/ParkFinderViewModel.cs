using CommunityToolkit.Mvvm.ComponentModel; //Für ObservableObject
using CommunityToolkit.Mvvm.Input;
//Für RelayCommand führt dazu dass weniger Boilerplate Code geschrieben wird (Empfehlung von KI)
using MauiParkFinder.Models;
using MauiParkFinder.Services;
using System.Collections.ObjectModel;
using MauiParkFinder.Helpers;

namespace MauiParkFinder.ViewModels;
public partial class ParkFinderViewModel : ObservableObject
{
    private readonly ParkFinderService _service;


    public ObservableCollection<ParkHaus> ParkHaeuser { get; } = new();
    

    public ParkFinderViewModel(ParkFinderService service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        await ParkHaeuser.LoadAsync(_service.GetParkHaeuserAsync);
        
    }
}