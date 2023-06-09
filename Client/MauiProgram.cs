﻿using Client.Views;
using Client.ViewsModels;
using InputKit.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UraniumUI;
using CommunityToolkit.Maui;
using Mopups.Interfaces;
using Mopups.Services;
using Client.DataService;

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

            builder.Services.AddSingleton<BaseVM>();
            builder.Services.AddTransient<HomeView>();
            builder.Services.AddTransient<FavoritesView>();

            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

#if DEBUG
            builder.Logging.AddDebug();

#endif

            return builder.Build();
        }
    }
}