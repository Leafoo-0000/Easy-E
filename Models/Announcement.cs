using System;

namespace EasyEv3.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public int? CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}