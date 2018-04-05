using Epos.Eventing;

using Notes.Model;

namespace Notes.WebApi.IntegrationEvents
{
    /// <summary> Integration event for added notes. </summary>
    public class NoteAddedIntegrationEvent : IntegrationEvent
    {
        /// <summary> Added note. </summary>
        /// <returns>Added note</returns>
        public Note AddedNote { get; set; }
    }
}
