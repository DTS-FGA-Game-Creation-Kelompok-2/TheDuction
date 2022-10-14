using System.Collections;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventManager : 
        SingletonBaseClass<DialogueEventManager>, IEventManager{
        [SerializeField] private DialogueEventController _eventControllerPrefab;
        [SerializeField] private DialogueEventRunner _eventRunnerPrefab;

        private List<DialogueEventController> _eventControllerPool;
        private List<DialogueEventRunner> _eventRunnerPool;

        private void Awake() {
            _eventControllerPool = new List<DialogueEventController>();
            _eventRunnerPool = new List<DialogueEventRunner>(); 
        }

        /// <summary>
        /// Set event data to run the event
        /// </summary>
        /// <param name="eventData">Event data</param>
        public void SetEventData(EventData eventData)
        {
            DialogueEventController eventController = GetOrCreateEventController();
            eventController.EventData = eventData as DialogueEventData;

            DialogueEventRunner eventRunner = GetOrCreateEventRunner();
            eventRunner.eventController = eventController;
            StartCoroutine(StartEvent(eventRunner));
        }
        
        /// <summary>
        /// Start event when dialogue is finished
        /// </summary>
        /// <param name="eventRunner"></param>
        /// <returns></returns>
        private static IEnumerator StartEvent(DialogueEventRunner eventRunner)
        {
            yield return new WaitUntil(() => !DialogueManager.Instance.DialogueIsPlaying);
            yield return new WaitForSeconds(1f);
            eventRunner.canStartEvent = true;
        }
        
        /// <summary>
        /// Event runner object pooling
        /// </summary>
        /// <returns>Return inactive or new event runner</returns>
        private DialogueEventRunner GetOrCreateEventRunner()
        {
            DialogueEventRunner eventRunner = _eventRunnerPool.Find(runner =>
                runner.eventController.EventState == EventState.Finish &&
                !runner.gameObject.activeInHierarchy);

            if (eventRunner == null)
            {
                eventRunner = Instantiate(_eventRunnerPrefab, transform).GetComponent<DialogueEventRunner>();
                
                _eventRunnerPool.Add(eventRunner);
            }
            
            eventRunner.gameObject.SetActive(true);
            return eventRunner;
        }

        /// <summary>
        /// Event controller object pooling
        /// </summary>
        /// <returns>Return inactive or new event controller</returns>
        private DialogueEventController GetOrCreateEventController()
        {
            DialogueEventController eventController = _eventControllerPool.Find(controller =>
                controller.EventState == EventState.Finish &&
                !controller.gameObject.activeInHierarchy);

            if (eventController == null)
            {
                eventController = Instantiate(_eventControllerPrefab, transform).GetComponent<DialogueEventController>();
                
                _eventControllerPool.Add(eventController);
            }
            
            eventController.gameObject.SetActive(true);
            return eventController;
        }
    }
}