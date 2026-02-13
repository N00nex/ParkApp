// Dieses Programm wurde ausschliesslcih von Stefano Milone entwickelt. Alle Rechte vorbehalten.
using CommunityToolkit.Maui; 
using MauiParkFinder.Services;
using MauiParkFinder.ViewModels;
using Microsoft.Extensions.Logging;
using MauiParkFinder.Views;

namespace MauiParkFinder
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
           
            builder.Services.AddSingleton<ParkFinderService>();
            builder.Services.AddTransient<ParkFinderViewModel>();
            builder.Services.AddTransient<ParkDetailsViewModel>();
            builder.Services.AddTransient<ParkDetailPage>();
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();

        }
    }
}
