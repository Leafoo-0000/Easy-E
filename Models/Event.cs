using System;
using System.Collections.Generic;

namespace EasyEv3.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string Location { get; set; } = "";
        public int OwnerUserId { get; set; }
        public EventStatus Status { get; set; } = EventStatus.PendingApproval;
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public DateTime CreatedAt { get; set; }
    }
}