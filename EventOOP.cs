using System;
using System.Collections.Generic;

namespace EasyEv3
{
    public class EventOOP
    {
        // 🧠 Inner class to represent a single Event
        public class EventData
        {
            public int ID { get; set; }                    // Unique event ID
            public string Title { get; set; }              // Event name
            public DateTime Date { get; set; }             // Event date/time
            public string Description { get; set; }        // Event details
            public string Organizer { get; set; }          // Created by / host
        }

        // 🗂️ List to store events in memory
        private List<EventData> events = new List<EventData>();

        private int nextId = 1; // Auto-increment ID tracker

        // ➕ Add a new event
        public void AddEvent(string title, DateTime date, string description, string organizer)
        {
            EventData newEvent = new EventData
            {
                ID = nextId++,
                Title = title,
                Date = date,
                Description = description,
                Organizer = organizer
            };

            events.Add(newEvent);
        }

        // 📋 Return all events
        public List<EventData> GetAllEvents()
        {
            return events;
        }

        // 🔍 Search for an event by title
        public EventData FindEventByTitle(string title)
        {
            return events.Find(e => e.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // ❌ Remove event by ID
        public bool DeleteEvent(int id)
        {
            EventData ev = events.Find(e => e.ID == id);
            if (ev != null)
            {
                events.Remove(ev);
                return true;
            }
            return false;
        }

        // 📝 Edit event details
        public bool EditEvent(int id, string newTitle, DateTime newDate, string newDescription)
        {
            EventData ev = events.Find(e => e.ID == id);
            if (ev != null)
            {
                ev.Title = newTitle;
                ev.Date = newDate;
                ev.Description = newDescription;
                return true;
            }
            return false;
        }
    }
}
