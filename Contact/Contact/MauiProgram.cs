using Microsoft.Extensions.Logging;

using Contact.service;

namespace Contact
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
                    fonts.AddFont("Teko-Light.ttf", "Teko");
                    fonts.AddFont("Outfit-Regular.ttf", "Outfit");
                    fonts.AddFont("Outfit-Light.ttf", "OutfitLight");
                });

            builder.Services.AddSingleton<RandomUserService,UsersService>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
