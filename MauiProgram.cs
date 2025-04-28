using Microsoft.Extensions.Logging;
namespace Pawfect_Care;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Chewy-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("Chewy-Regular.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<local_db_service>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}