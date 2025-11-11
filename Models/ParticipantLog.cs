using System;

namespace EasyEv3.Models
{
    public class ParticipantLog
    {
        public int Id { get; set; } // participants_log.id
        public int EventLogId { get; set; }
        public int OriginalParticipantId { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}