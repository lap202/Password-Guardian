using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Password_Guardian.Views;

namespace Password_Guardian;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();


        builder.Services.AddTransient<SignUp>();
        builder.Services.AddTransient<AddNewPassword>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<Login>();
        builder.Services.AddTransient<SignUpSuccess>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}