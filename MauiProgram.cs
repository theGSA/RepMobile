using Microsoft.Extensions.Logging;

namespace RepMobile
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
                    fonts.AddFont("fa_solid.ttf", "FontAwesome");
                    fonts.AddFont("Montserrat - Bold.ttf", "MontserratBold");
                    fonts.AddFont("Montserrat - Regular.ttf", "MontserratRegular");
                    fonts.AddFont("Montserrat - Medium.ttf", "MontserratMedium");


                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}