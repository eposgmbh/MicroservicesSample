using Epos.Eventing;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi.IntegrationEvents
{
    public class NoteAddedIntegrationEvent : IntegrationEvent
    {
        public Note AddedNote { get; set; }
    }
}
