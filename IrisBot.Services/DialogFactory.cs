using System;
using IrisBot.Services.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using IrisBot.Services.Interfaces.Common;

namespace IrisBot.Services
{
    public class DialogFactory : IDialogFactory
    {
        private readonly IJsonConverter jsonConverter;

        public DialogFactory(IJsonConverter jsonConverter)
        {
            this.jsonConverter = jsonConverter;
        }

        public IDialog<object> CreateDialog<DialogType>()
        {
            var dialog = Activator.CreateInstance(typeof(DialogType), jsonConverter) as IDialog<object>;
            return dialog;
        }
    }
}
