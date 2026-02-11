using MauiParkFinder.ViewModels; // Fügen Sie diese using-Direktive hinzu
namespace MauiParkFinder.Views
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ParkDetailPage), typeof(ParkDetailPage));
        }
    }
}
