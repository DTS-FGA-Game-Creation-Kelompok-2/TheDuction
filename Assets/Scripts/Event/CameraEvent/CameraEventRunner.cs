using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventRunner : MonoBehaviour, IEventRunner {
        [SerializeField] private CameraEventController _eventController;
        private bool _hasSetFinishCondition;
        [SerializeField] private bool _canStartEvent;

        public bool CanStartEvent{
            set { _canStartEvent = value; }
            get { return _canStartEvent; }
        }

        public CameraEventController EventController{
            set { _eventController = value; }
            get { return _eventController; }
        }

        private void OnEnable() {
            _canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update() {
            switch(_eventController.EventState){
                case EventState.NotStarted:
                    if(_canStartEvent)
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
            _eventController.gameObject.SetActive(_eventController.EventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}