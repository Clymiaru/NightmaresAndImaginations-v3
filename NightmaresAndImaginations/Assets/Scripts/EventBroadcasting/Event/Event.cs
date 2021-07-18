
using System;

namespace TDS
{
    public enum EventType
    {
        None = 0,
        Damage
    }
    
    public class Event
    {
        public Event(EventType type)
        {
            Type = type;
        }
        public EventType Type { get; }
    }
}