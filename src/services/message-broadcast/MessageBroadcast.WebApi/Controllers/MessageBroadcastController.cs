using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using MessageBroadcast.WebApi.Hubs;

namespace MessageBroadcast.WebApi.Controllers
{
    /// <summary> Message Broadcast V1 Controller </summary>
    [Route("api/v1/message-broadcast")]
    public class MessageBroadcastController : Controller
    {
        private readonly IHubContext<MessageBroadcastHub> myHubContext;

        /// <summary> Creates an instance of the <b>MessageBroadcastController</b> class. </summary>
        /// <param name="hubContext">Hub context</param>
        public MessageBroadcastController(IHubContext<MessageBroadcastHub> hubContext) {
            myHubContext = hubContext;
        }

        /// <summary> Broadcasts a message to all subscribers. </summary>
        /// <param name="message">Message</param>
        /// <response code="200">The message is broadcast.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult SendMessage([FromBody] string message) {
            myHubContext.Clients.All.SendAsync("Send", message);
            return Ok();
        }
    }
}
