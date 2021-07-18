using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class EventBroadcaster
    {
        private Dictionary<EventType, List<Action<Event>>> eventObservers;
           
        public static EventBroadcaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventBroadcaster();
                }

                return instance;
            }
        }
        private static EventBroadcaster instance;

        private EventBroadcaster()
        {
            eventObservers = new Dictionary<EventType, List<Action<Event>>>();
        }

        public void RegisterObserver(EventType eventType, Action<Event> onExecute)
        {
            if (!eventObservers.ContainsKey(eventType))
            {
                eventObservers[eventType] = new List<Action<Event>>();
            }
            
            var eventObserverOfTypeList = eventObservers[eventType];
            if (!eventObserverOfTypeList.Contains(onExecute))
            {
                eventObserverOfTypeList.Add(onExecute);
                return; 
            }
            
            Debug.LogWarning("Attempting to register a callback that exists!");
        }

        public void DeregisterObserver(EventType eventType, Action<Event> onExecute)
        {
            var eventObserverOfTypeList = eventObservers[eventType];
            if (eventObserverOfTypeList.Contains(onExecute))
            {
                eventObserverOfTypeList.Remove(onExecute);
                return;
            }
            Debug.LogWarning("Attempting to deregister a non-existent callback!");
        }

        public void Broadcast(Event e)
        {
            foreach (var observerAction in eventObservers[e.Type])
            {
                observerAction?.Invoke(e);
            }
        }

        public void RemoveAllObservers()
        {
            eventObservers.Clear();
        }
    }
    
}