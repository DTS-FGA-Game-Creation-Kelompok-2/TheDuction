using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event{
    public class EventData : MonoBehaviour {
        [Header("Event Data")]
        [SerializeField] private string _eventId;
        [TextArea(3,5)]
        [SerializeField] private string _eventDescription;
        public bool isFinished;
        public EventState eventState = EventState.NotStarted;
        
        [Header("Finish Condition")]
        public FinishCondition finishCondition;
        [SerializeField] private FinishConditionManager _triggerObject;
        public bool canBeInteracted;
        [SerializeField] private bool _keepObjectAfterFinish;

        // Properties
        public string EventId => _eventId;
        public bool KeepObjectAfterFinish => _keepObjectAfterFinish;
        public FinishConditionManager TriggerObject => _triggerObject;

        public virtual void OnEventFinish(){}
    }
}