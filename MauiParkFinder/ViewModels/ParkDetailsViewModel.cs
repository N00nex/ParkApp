using CommunityToolkit.Mvvm.ComponentModel;
using MauiParkFinder.Models;



namespace MauiParkFinder.ViewModels;


[QueryProperty(nameof(TargetParkingGarage), "SelectedParkingGarage")]
public partial class ParkDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ParkingGarage _targetParkingGarage;

}