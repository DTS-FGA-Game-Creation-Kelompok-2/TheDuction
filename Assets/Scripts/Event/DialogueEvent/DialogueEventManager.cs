using System.Collections;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventManager : 
        SingletonBaseClass<DialogueEventManager>, IEventManager{
        [Header("Event Controller")]
        [SerializeField] private DialogueEventController _eventControllerPrefab;
        [SerializeField] private Transform _eventControllerParent;

        [Header("Event Runner")]
        [SerializeField] private DialogueEventRunner _eventRunnerPrefab;
        [SerializeField] private Transform _eventRunnerParent;

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
            DialogueEventController eventController = Instantiate(_eventControllerPrefab, _eventControllerParent).GetComponent<DialogueEventController>();;
            _eventControllerPool.Add(eventController);
            eventController.EventData = eventData as DialogueEventData;
            Debug.Log("Set event data");

            DialogueEventRunner eventRunner = GetOrCreateEventRunner();
            eventRunner.EventController = eventController;

            eventController.gameObject.name = eventController.EventData.EventId;
            eventRunner.gameObject.name = eventRunner.EventController.EventData.EventId;
            
            eventController.gameObject.SetActive(true);
            eventRunner.gameObject.SetActive(true);
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
            eventRunner.CanStartEvent = true;
        }
        
        /// <summary>
        /// Event runner object pooling
        /// </summary>
        /// <returns>Return inactive or new event runner</returns>
        private DialogueEventRunner GetOrCreateEventRunner()
        {
            DialogueEventRunner eventRunner = _eventRunnerPool.Find(runner => !runner.gameObject.activeInHierarchy);

            if (eventRunner == null)
            {
                eventRunner = Instantiate(_eventRunnerPrefab, _eventRunnerParent).GetComponent<DialogueEventRunner>();
                
                _eventRunnerPool.Add(eventRunner);
            }

            return eventRunner;
        }

        /// <summary>
        /// Event controller object pooling
        /// </summary>
        /// <returns>Return inactive or new event controller</returns>
        private DialogueEventController GetOrCreateEventController()
        {
            DialogueEventController eventController = _eventControllerPool.Find(controller => !controller.gameObject.activeInHierarchy);

            if (eventController == null)
            {
                eventController = Instantiate(_eventControllerPrefab, _eventControllerParent).GetComponent<DialogueEventController>();
                Debug.Log("Instantiate");
                _eventControllerPool.Add(eventController);
            }
            
            return eventController;
        }

        public DialogueEventController GetDialogueEventController(DialogueEventData eventData){
            foreach(DialogueEventController eventController in _eventControllerPool){
                if(!eventController.gameObject.activeInHierarchy) continue;

                if(eventController.EventData == eventData){
                    return eventController;
                }
            }

            Debug.LogError($"Event controller with ID: {eventData.EventId} not found");
            return null;
        }
    }
}