using SpaceXHistory.Services;
using SpaceXHistory.ViewModels;
using SpaceXHistory.Views;

namespace SpaceXHistory;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("GemunuLibre-Bold.ttf", "Bold");
                fonts.AddFont("GemunuLibre-ExtraBold.ttf", "ExtraBold");
                fonts.AddFont("GemunuLibre-ExtraLight.ttf", "ExtraLight");
                fonts.AddFont("GemunuLibre-Light.ttf", "Light");
                fonts.AddFont("GemunuLibre-Medium.ttf", "Medium");
                fonts.AddFont("GemunuLibre-Regular.ttf", "Regular");
                fonts.AddFont("GemunuLibre-SemiBold.ttf", "SemiBold");
            });

        return builder.Build();
	}
}
