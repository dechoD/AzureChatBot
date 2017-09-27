using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using IrisBot.Services.Interfaces;
using IrisBot.Dialogs;

namespace IrisBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly IConversationWrapper conversationWrapper;
        private readonly IDialogFactory dialogFactory;

        public MessagesController(IConversationWrapper conversationWrapper,
                                  IDialogFactory dialogFactory)
        {
            this.conversationWrapper = conversationWrapper;
            this.dialogFactory = dialogFactory;
        }

        // POST: api/Messages
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await conversationWrapper.SendAsync(activity, () => dialogFactory.CreateDialog<PullRequestsDialog>());
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}