using System.Collections.Generic;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Event{
    public class EventContainer: SingletonBaseClass<EventContainer>{
        [SerializeField] private List<EventData> _eventDatas;

        public List<EventData> EventDatas => _eventDatas;
    }
}