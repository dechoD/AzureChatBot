using System.Threading.Tasks;
using System;
using IrisBot.Services.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace IrisBot.Services
{
    public class ConversationWrapper : IConversationWrapper
    {
        public async Task SendAsync(IMessageActivity toBot, Func<IDialog<object>> dialogFactoryFunc)
        {
            await Conversation.SendAsync(toBot, dialogFactoryFunc);
        }
    }
}
