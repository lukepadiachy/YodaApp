﻿using Microsoft.Extensions.Logging;
using YodaApp.Configuration;
using YodaApp.Services;
using YodaApp.ViewModels;
using YodaApp.Views;

namespace YodaApp
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
                });

            builder .RegisterServices()
                   .RegisterViewModels()
                   .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            // AI Assistant??

            mauiAppBuilder.Services.AddTransient<IYodaResponse, YodaResponse>();

            mauiAppBuilder.Services.AddTransient<ISettings, ConstantSettings>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FunFactsPageViewModel>();
           // mauiAppBuilder.Services.AddSingleton<LoadsheddingAnswerViewModel>();

            // More view-models registered here.

            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FunFactsPageView>();
           // mauiAppBuilder.Services.AddSingleton<LoadsheddingAnswerPage>();

            // More views registered here.

            return mauiAppBuilder;
        }
    }
}
