using System;

#pragma warning disable 1591

namespace MessageBroadcast.WebApi.IntegrationEvents
{
    public class Note
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime Updated { get; set; }
    }
}
