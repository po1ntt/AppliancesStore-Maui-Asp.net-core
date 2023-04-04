using CommunityToolkit.Maui;
using InputKit.Handlers;
using Microsoft.Extensions.Logging;
using UraniumUI;

namespace Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureMauiHandlers(handlers =>
                {
                    // Add following line:
                    handlers.AddInputKitHandlers(); // 👈
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("18vagRounded.ttf", "OpenSansRegular");
                    fonts.AddFont("18vagRounded.ttf", "OpenSansSemibold");
                    fonts.AddFontAwesomeIconFonts();
                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}