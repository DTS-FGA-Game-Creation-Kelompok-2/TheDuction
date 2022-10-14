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

        private FinishConditionManager _triggerObject;

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

        private void OnEnable() {
            SetFinishCondition();
        }

        public virtual void OnEventFinish(){}
        
        public virtual void Reset(){
            _eventData = null;
            _isFinished = false;
            _canBeInteracted = false;
            _eventState = EventState.NotStarted;
            _triggerObject = null;

            Destroy(GetComponent<FinishConditionManager>());
        }

        private void SetFinishCondition(){
            switch(_eventData.FinishCondition){
                case FinishCondition.DialogueFinished:
                    gameObject.AddComponent<DialogueFinishedCondition>();
                    break;
                case FinishCondition.CameraDurationFinished:
                    gameObject.AddComponent<CameraFinishedCondition>();
                    break;
            }

            _triggerObject = GetComponent<FinishConditionManager>();
        }
    }
}