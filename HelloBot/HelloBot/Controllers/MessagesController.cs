// <copyright file="MessagesController.cs" company="Microsoft">
//     Copyright (c) Microsoft All rights reserved.
// </copyright>
namespace HelloBot
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Microsoft.Bot.Connector;

    [BotAuthentication]

    /// <summary>
    /// Receive a message from a user and reply to it with "Hello World"
    /// </summary>
    public class MessagesController : ApiController
    {
        /// <summary>    
        /// Receive a message from a user and reply to it
        /// </summary>
        /// <param name="activity">activity passed as parameter</param>
        /// <returns>message as response</returns>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply($"Hello World");
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                this.HandleSystemMessage(activity);
            }

            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            return response;
        }

        /// <summary>
        /// Handles activity message
        /// </summary>
        /// <param name="message">message passed as parameter</param>
        /// <returns>Activity message</returns>
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.Typing)
            {
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}