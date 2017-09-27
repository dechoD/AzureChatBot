using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;

namespace IrisBot.Services.Interfaces
{
    public interface IConversationWrapper
    {
        Task SendAsync(IMessageActivity toBot, Func<IDialog<object>> dialogFactoryFunc);
    }
}
