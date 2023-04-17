using CommunityToolkit.Maui;
using MAUI.GPT.Services;
using MAUI.GPT.Services.Interfaces;
using MAUI.GPT.ViewModels;
using MAUI.GPT.Views;
using OpenAI_API;

namespace MAUI.GPT;

public static class MauiProgram
{
    private const string API_KEY = "YOUR-API-KEY";
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

		// REGISTER PAGES
		builder.Services.AddScopedWithShellRoute<MainView, MainViewModel>(nameof(MainView));

		// REGISTER SERVICES
		builder.Services.AddScoped<IOpenAIAPI>(x => new OpenAIAPI(API_KEY));
		builder.Services.AddScoped(x => x.GetService<IOpenAIAPI>().Chat.CreateConversation());
		builder.Services.AddScoped<IGptService, GptService>();

		return builder.Build();
	}
}
