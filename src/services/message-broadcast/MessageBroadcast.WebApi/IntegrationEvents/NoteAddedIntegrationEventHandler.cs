using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

using Epos.Eventing;

using MessageBroadcast.WebApi.Hubs;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi.IntegrationEvents
{
    public class NoteAddedIntegrationEventHandler : IntegrationEventHandler<NoteAddedIntegrationEvent>
    {
        private readonly IHubContext<MessageBroadcastHub> myMessageBroadcastHub;

        public NoteAddedIntegrationEventHandler(IHubContext<MessageBroadcastHub> messageBroadcastHub) {
            myMessageBroadcastHub = messageBroadcastHub ?? throw new ArgumentNullException(nameof(messageBroadcastHub));
        }

        public override Task Handle(NoteAddedIntegrationEvent e, MessagingHelper h) {
            var theMessage = $"Added note '{e.AddedNote.Text}' by {e.AddedNote.Author}.";
            System.Console.WriteLine(theMessage);

            myMessageBroadcastHub.Clients.All.SendAsync("Send", theMessage);
            h.Ack();

            return Task.CompletedTask;
        }
    }
}
