using Microsoft.Extensions.Logging;
using Contact.service;
using Microsoft.Maui.Handlers;

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

            builder.Services.AddSingleton<RandomUserService, UsersService>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Add the EntryHandler.Mapper code here
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });

            return builder.Build();
        }
    }
}
