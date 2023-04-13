using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.GPT.Models;
using OpenAI_API;
using OpenAI_API.Completions;
using System.Collections.ObjectModel;

namespace MAUI.GPT.ViewModels;
public partial class MainViewModel : ObservableObject
{
    private const string API_KEY = "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";

    [ObservableProperty]
    private ObservableCollection<Message> _messages = new();

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _text;

    [RelayCommand]
    private async Task SendMessage()
    {
        try
        {
            IsBusy = true;

            Messages.Insert(0, new() { IsSender = true, MessageText = Text });
            var api = new OpenAIAPI(API_KEY);
            var completion = new CompletionRequest
            {
                Prompt = Text,
                MaxTokens = 4000
            };
            Text = string.Empty;
            var result = await api.Completions.CreateCompletionAsync(completion);
            if (result is not null)
                Messages.Insert(0, new() { IsSender = false, MessageText = string.Join("\n", result.Completions.Select(x => x.Text)) });
        }
        finally
        {
            IsBusy = false;
        }
    }
}
