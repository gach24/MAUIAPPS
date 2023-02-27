using Microsoft.Extensions.Logging;
using ProsperDaily.MVVM.Models;
using ProsperDaily.Repositories;
using Syncfusion.Maui.Core.Hosting;

namespace ProsperDaily
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("LibreFranklin-Regular.ttf", "LibreFranklin");
                    fonts.AddFont("Roboto-Black.ttf", "Roboto");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BaseRepository<Transaction>>();
            return builder.Build();
        }
    }
}