using System.Collections.Generic;
using TheDuction.Global;
using UnityEditor;
using UnityEngine;

namespace TheDuction.Event{
    public class EventContainer: SingletonBaseClass<EventContainer>{
        [SerializeField] private List<EventData> _eventDatas;

        public List<EventData> EventDatas => _eventDatas;

        [ContextMenu("Load Event Data")]
        public void LoadEventData(){
            // AssetDatabase.FindAssets()
        }
    }
}