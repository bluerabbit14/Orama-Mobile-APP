using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Syncfusion.Licensing;
using Syncfusion.Maui.Charts;
using Syncfusion.Maui.Core.Hosting;

namespace Orama
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            SyncfusionLicenseProvider.RegisterLicense("MzkzNDgzNEAzMzMwMmUzMDJlMzAzYjMzMzAzYk51Z2dPQURxcFYzeUhTSW9HL0NNSTQ2RmtKZ1FTNWdNZVZyUHJHWWNhNGM9");
            var builder = MauiApp.CreateBuilder();

            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
     }
}