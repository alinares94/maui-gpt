using MAUI.GPT.Models;

namespace MAUI.GPT.Views.Templates;
public class MessageTemplateSelector : DataTemplateSelector
{
    public DataTemplate ReceiverTemplate { get; set; }
    public DataTemplate SenderTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var msg = (Message)item;
        return msg.IsSender ? SenderTemplate : ReceiverTemplate;
    }
}
