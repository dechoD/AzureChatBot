using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace IrisBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        // POST: api/Messages
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity != null && activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}