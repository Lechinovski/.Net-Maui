using Microsoft.Extensions.Logging;

using SportsDB.Service;

namespace SportsDB
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontello.ttf", "Icons");
                });

            builder.Services.AddSingleton<ApiFootballService,FootballService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<LeaguesApiFootballService,LeaguesFootballService>();
            builder.Services.AddTransient<PaisDetails>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
