using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventRunner : MonoBehaviour, IEventRunner {
        [SerializeField] private CameraEventController _eventController;
        private bool _hasSetFinishCondition;
        public bool canStartEvent;

        public CameraEventController EventController{
            set { _eventController = value; }
            get { return _eventController; }
        }

        private void OnEnable() {
            canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update() {
            switch(_eventController.EventState){
                case EventState.NotStarted:
                    if(canStartEvent)
                        OnEventStart();
                    break;

                case EventState.Start:
                    OnEventActive();
                    break;

                case EventState.Active:
                    if(!_hasSetFinishCondition)
                    {
                        switch (_eventController.EventData.FinishCondition)
                        {
                            case FinishCondition.CameraDurationFinished:
                                _eventController.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                break;
                            case FinishCondition.DialogueFinished:
                                _hasSetFinishCondition = true;
                                break;
                        }
                    }
                    if(_eventController.IsFinished)
                        OnEventFinish();
                    break;

                case EventState.Finish:
                    SetNextEvent();
                    break;
            }
        }

        public void OnEventStart()
        {
            _eventController.EventState = EventState.Start;
        }
        
        public void OnEventActive()
        {
            _eventController.EventState = EventState.Active;
            _eventController.CanBeInteracted = true;
        }

        public void OnEventFinish()
        {
            _eventController.EventState = EventState.Finish;
        }

        public void SetNextEvent()
        {
            // eventData.gameObject.SetActive(eventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}