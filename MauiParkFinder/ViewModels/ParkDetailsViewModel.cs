using CommunityToolkit.Mvvm.ComponentModel;
using MauiParkFinder.Models;
using MauiParkFinder.Helpers;

namespace MauiParkFinder.ViewModels;

[QueryProperty(nameof(TargetParkHaus), "SelectedParkHaus")]
public partial class ParkDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private ParkHaus _targetParkHaus;

    public string MoBisFrDisplay => GetTimeForRange(1, 5);
    public string SaBisSoDisplay => GetTimeForRange(6, 7);

    // Diese Methode wird automatisch aufgerufen, wenn TargetParkHaus gesetzt wird
    partial void OnTargetParkHausChanged(ParkHaus value)
    {
        OnPropertyChanged(nameof(MoBisFrDisplay));
        OnPropertyChanged(nameof(SaBisSoDisplay));
    }

    private string GetTimeForRange(int startTag, int endTag)
    {
        if (_targetParkHaus?.BetriebsZeit == null || _targetParkHaus.BetriebsZeit.Count == 0) 
            return "Geschlossen";

        var regel = _targetParkHaus.BetriebsZeit
            .FirstOrDefault(z => startTag >= z.TagVon && startTag <= z.TagBis);

        return regel.BetriebszeitFormattieren();
    }
}
