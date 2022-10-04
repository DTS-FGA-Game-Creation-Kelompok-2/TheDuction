using TheDuction.Event.FinishConditionScripts;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventRunner : MonoBehaviour, IEventRunner {
        public CameraEventData eventData;
        private bool _hasSetFinishCondition;
        public bool canStartEvent;

        private void OnEnable() {
            canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update() {
            switch(eventData.eventState){
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
                        switch (eventData.finishCondition)
                        {
                            case FinishCondition.CameraDurationFinished:
                                eventData.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                break;
                            case FinishCondition.DialogueFinished:
                                _hasSetFinishCondition = true;
                                break;
                        }
                    }
                    if(eventData.isFinished)
                        OnEventFinish();
                    break;

                case EventState.Finish:
                    SetNextEvent();
                    break;
            }
        }

        public void OnEventStart()
        {
            eventData.eventState = EventState.Start;
        }
        
        public void OnEventActive()
        {
            eventData.eventState = EventState.Active;
            eventData.canBeInteracted = true;
        }

        public void OnEventFinish()
        {
            eventData.eventState = EventState.Finish;
        }

        public void SetNextEvent()
        {
            eventData.gameObject.SetActive(eventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}