using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi.Hubs
{
    public class MessageBroadcastHub : Hub
    {
        public async Task Message(string message) {
            await Clients.All.SendAsync(nameof(Message), message);
        }
    }
}
