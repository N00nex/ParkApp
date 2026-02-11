using MauiParkFinder.ViewModels;

namespace MauiParkFinder.Views;

public partial class ParkDetailPage : ContentPage
{
	public ParkDetailPage(ParkDetailsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}