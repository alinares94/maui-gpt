using OpenAI_API.Completions;

namespace MAUI.GPT.Services.Interfaces;
public interface IGptService
{
    Task<string> SendChatMessage(string msg);
    Task<CompletionResult> SendMessage(string msg);
}
