using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUI.GPT.Models;
using MAUI.GPT.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MAUI.GPT.ViewModels;
public partial class MainViewModel : ObservableObject
{
    private readonly IGptService _gptService;

    public MainViewModel(IGptService gptService)
    {
        _gptService = gptService;
    }

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
            var result = await _gptService.SendChatMessage(Text);

            Text = string.Empty;
            if (result is not null)
                Messages.Insert(0, new() { IsSender = false, MessageText = result });
        }
        catch (Exception e)
        {
            Messages.Insert(0, new() { IsSender = true, MessageText = $"Error. {e.Message}" });
        }
        finally
        {
            IsBusy = false;
        }
    }
}
