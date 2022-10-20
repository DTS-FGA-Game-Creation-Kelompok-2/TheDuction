using TheDuction.Event.CameraEvent;
using TheDuction.Event.DialogueEvent;
using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event{
    public class EventController : MonoBehaviour {
        [SerializeField] private EventData _eventData;
        [SerializeField] private bool _isFinished;
        [SerializeField] private EventState _eventState = EventState.NotStarted;
        [SerializeField] private bool _canBeInteracted;
        [SerializeField] private FinishConditionManager _triggerObject;

        public bool IsFinished{
            set { _isFinished = value; }
            get { return _isFinished; }
        }

        public EventData EventData{
            set { _eventData = value; }
            get { return _eventData; }
        }

        public bool CanBeInteracted{
            set { _canBeInteracted = value; }
            get { return _canBeInteracted; }
        }

        public EventState EventState{
            set { _eventState = value; }
            get { return _eventState; }
        }
        
        public FinishConditionManager TriggerObject => _triggerObject;

        public virtual void OnEventFinish(){}

        private void OnEnable() {
            SetFinishCondition();
        }

        private void OnDisable() {
            OnReset();
        }
        
        public virtual void OnReset(){
            _eventData = null;
            _isFinished = false;
            _canBeInteracted = false;
            _eventState = EventState.NotStarted;
            _triggerObject = null;

            Destroy(GetComponent<FinishConditionManager>());
        }

        protected virtual void SetFinishCondition(){
            if(!_eventData) return;
            
            switch(_eventData.FinishCondition){
                case FinishCondition.DialogueFinished:
                    gameObject.AddComponent(typeof(DialogueFinishedCondition));
                    break;
                case FinishCondition.CameraDurationFinished:
                    gameObject.AddComponent(typeof(CameraFinishedCondition));
                    break;
            }

            _triggerObject = GetComponent<FinishConditionManager>();
        }
    }
}