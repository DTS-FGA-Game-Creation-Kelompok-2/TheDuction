using System.Linq;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Event.CameraEvent;
using TheDuction.Event.DialogueEvent;
using TheDuction.Event.MovementEvent;
using TheDuction.Global;
using TheDuction.Global.SaveLoad;
using UnityEngine;

namespace TheDuction.Event{
    public class EventContainer: SingletonBaseClass<EventContainer>{
        [SerializeField] private List<EventData> _eventDatas;

        public List<EventData> EventDatas => _eventDatas;

        private void Start() {
            LoadEvents();
        }

        private void LoadEvents()
        {
            if(!SaveLoadData.Instance) return;
            
            List<string> eventIds = SaveLoadData.Instance.CurrentEvents;
            if(eventIds.Count == 0) return;
            Debug.Log(eventIds);

            foreach(string eventId in eventIds){
                string eventIdTrim = eventId.Trim();
                // Find event data in list
                foreach (EventData eventData in _eventDatas.Where(
                    eventData => eventData.EventId == eventIdTrim))
                {
                    // Set event data
                    switch(eventData){
                        case DialogueEventData _:
                            Debug.Log("Set dialogue event");
                            DialogueEventManager.Instance.SetEventData(eventData);
                            break;
                        case CameraEventData _:
                            Debug.Log("Set camera event");
                            DialogueManager.Instance.PauseStoryForEvent();
                            CameraEventManager.Instance.SetEventData(eventData);
                            break;
                        case MovementEventData _:
                            DialogueManager.Instance.PauseStoryForEvent();
                            MovementEventManager.Instance.SetEventData(eventData);
                            break;
                        default:
                            Debug.LogError($"Event: {eventId} can't be set. Check the event data class");
                            break;
                    }
                    break;
                }
            }
        }
    }
}