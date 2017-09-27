using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using IrisBot.Services.Interfaces.Common;
using IrisBot.Models.Request;
using System.Text;
using System.Linq;

namespace IrisBot.Dialogs
{
    [Serializable]
    public class PullRequestsDialog : IDialog<object>
    {
        private readonly IJsonConverter jsonConverter;

        public PullRequestsDialog(IJsonConverter jsonConverter)
        {
            this.jsonConverter = jsonConverter;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var data = await argument;
            var message = jsonConverter.DeserializeObject<RunMessage>(data.Text);

            // Testing
            var builder = new StringBuilder();

            builder.AppendLine("Merged pull request:");
            builder.AppendLine($"    {message.MergeMessage}");
            builder.AppendLine("Updated pull request:");
            builder.AppendLine($"    {message.UpdateMessage}");
            builder.AppendLine("Conflicting pull requests:");
            builder.AppendLine(string.Join(message.ConflictMessages.Max(x => $"    {x}"), Environment.NewLine));

            await context.PostAsync(builder.ToString());
            context.Wait(MessageReceivedAsync);
        }
    }
}