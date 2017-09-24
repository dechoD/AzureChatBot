using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace IrisBot.Dialogs
{
    [Serializable]
    public class ChoosePullRequestDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task OnOptionSelected(IDialogContext context, IAwaitable<Option> result)
        {
            try
            {

                Option optionSelected = await result;

                switch (optionSelected.Text)
                {
                    case "A":
                        break;
                    default: { break; }
                }
            }
            catch (TooManyAttemptsException ex)
            {
                await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

                context.Wait(this.MessageReceivedAsync);
            }
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            List<Option> ListOptions = Option.CreateListOption();
            PromptDialog.Choice(context, this.OnOptionSelected, ListOptions, "Are you looking for a flight or a hotel?", "Not a valid option", 3);
        }
    }

    [Serializable]

    public class Option
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public Option()
        {
            ID = 0;
            Text = "";
        }
        public static List<Option> CreateListOption()
        {
            List<Option> list = new List<Option>();
            Option A = new Option();
            A.ID = 1;
            A.Text = "A";
            Option B = new Option();
            B.ID = 2;
            B.Text = "B";
            list.Add(A);
            list.Add(B);
            return list;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}