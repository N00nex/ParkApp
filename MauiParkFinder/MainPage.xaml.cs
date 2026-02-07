using MauiParkFinder.ViewModels;

namespace MauiParkFinder
{
    public partial class MainPage : ContentPage
    {
        private readonly ParkFinderViewModel _viewModel;

        
        public MainPage(ParkFinderViewModel viewModel)
        {
            InitializeComponent();
           
            BindingContext = _viewModel = viewModel;
        }

     
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadDataAsync();
        }
    }
}
