using MauiParkFinder.ViewModels;

namespace MauiParkFinder
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly ParkFinderViewModel _viewModel;

        // 1. Add ViewModel to constructor (Dependency Injection)
        public MainPage(ParkFinderViewModel viewModel)
        {
            InitializeComponent();
            
            // 2. Set the BindingContext so XAML can see the properties like 'ParkHaeuser'
            BindingContext = _viewModel = viewModel;
        }

        // 3. Load data when the page appears on screen
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadDataAsync();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
