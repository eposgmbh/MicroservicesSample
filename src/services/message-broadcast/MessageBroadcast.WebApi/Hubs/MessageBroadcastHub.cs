using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi.Hubs
{
    public class MessageBroadcastHub : Hub
    {
        public async Task Send(string message) {
            await Clients.All.SendAsync(nameof(Send), message);
        }
    }
}
