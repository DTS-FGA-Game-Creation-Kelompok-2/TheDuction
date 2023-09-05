using TheDuction.Event.FinishConditionScripts;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Event.MovementEvent{
    public class MovementEventRunner : MonoBehaviour, IEventRunner
    {
        [SerializeField] private MovementEventController _eventController;
        [SerializeField] private bool _canStartEvent;
        private bool _hasSetFinishCondition;

        public bool CanStartEvent{
            set { _canStartEvent = value; }
            get { return _canStartEvent; }
        }

        public MovementEventController EventController{
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
                            case FinishCondition.TeleportFinished:
                                _eventController.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                break;
                            case FinishCondition.CameraDurationFinished:
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
            StartCoroutine(AlphaFadingEffect.FadeIn(_eventController.BlackScreen, 
                afterEffect: () => {
                    _eventController.TargetCharacter.Move(_eventController.TargetTransform);
                }
            ));

            _eventController.EventState = EventState.Active;
            _eventController.CanBeInteracted = true;
        }

        public void OnEventFinish()
        {
            _eventController.EventState = EventState.Finish;
        }

        public void SetNextEvent()
        {
            StartCoroutine(AlphaFadingEffect.FadeOut(_eventController.BlackScreen, 
                afterEffect: () => {
                    Debug.Log("set false");
                    _eventController.gameObject.SetActive(_eventController.EventData.KeepObjectAfterFinish);
                    gameObject.SetActive(false);
                }
            ));
        }
    }
}