using MAUI.GPT.Services.Interfaces;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;

namespace MAUI.GPT.Services;
public class GptService : IGptService
{
    private readonly IOpenAIAPI _api;
    private readonly Conversation _chat;

    public GptService(IOpenAIAPI api, Conversation chat)
    {
        _api = api;
        _chat = chat;
    }

    public async Task<string> SendChatMessage(string msg)
    {
        _chat.AppendUserInput(msg);
        return await _chat.GetResponseFromChatbotAsync();
    }

    public async Task<CompletionResult> SendMessage(string msg)
    {
        var completion = new CompletionRequest
        {
            Prompt = msg,
            MaxTokens = 4000
        };
        return await _api.Completions.CreateCompletionAsync(completion);
    }
}
