using System;

namespace Notes.Model
{
    public class Note
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
