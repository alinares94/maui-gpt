using CommunityToolkit.Maui;
using MAUI.GPT.Views;
using MAUI.GPT.ViewModels;

namespace MAUI.GPT;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingletonWithShellRoute<MainView, MainViewModel>(nameof(MainView));

		return builder.Build();
	}
}
