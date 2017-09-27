using Microsoft.Bot.Builder.Dialogs;

namespace IrisBot.Services.Interfaces
{
    public interface IDialogFactory
    {
        IDialog<object> CreateDialog<DialogType>();
    }
}
