using System.Collections;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Global;
using TheDuction.Global.SaveLoad;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventManager: SingletonBaseClass<CameraEventManager>, IEventManager{
        [Header("Event Controller")]
        [SerializeField] private List<CameraEventController> _eventControllers;

        [Header("Event Runner")]
        [SerializeField] private CameraEventRunner _eventRunnerPrefab;
        [SerializeField] private Transform _eventRunnerParent;

        private List<CameraEventRunner> _eventRunnerPool;

        private void Awake() {
            _eventRunnerPool = new List<CameraEventRunner>(); 
        }

        /// <summary>
        /// Set event data to run the event
        /// </summary>
        /// <param name="eventData">Event data</param>
        public void SetEventData(EventData eventData)
        {
            CameraEventController eventController = GetEventController(eventData);
            if(SaveLoadData.Instance)
                SaveLoadData.Instance.SaveEvent(eventData);
            CameraEventRunner eventRunner = GetOrCreateEventRunner();
            eventRunner.EventController = eventController;
            StartCoroutine(StartEvent(eventRunner));
        }
        
        /// <summary>
        /// Start event when dialogue is finished
        /// </summary>
        /// <param name="eventRunner"></param>
        /// <returns></returns>
        private static IEnumerator StartEvent(CameraEventRunner eventRunner)
        {
            yield return new WaitUntil(() => !DialogueManager.Instance.DialogueIsPlaying);
            yield return new WaitForSeconds(1f);
            eventRunner.CanStartEvent = true;
        }
        
        /// <summary>
        /// Event runner object pooling
        /// </summary>
        /// <returns>Return inactive or new event runner</returns>
        private CameraEventRunner GetOrCreateEventRunner()
        {
            CameraEventRunner eventRunner = _eventRunnerPool.Find(runner =>
                runner.EventController.EventState == EventState.Finish &&
                !runner.gameObject.activeInHierarchy);

            if (eventRunner == null)
            {
                eventRunner = Instantiate(_eventRunnerPrefab, _eventRunnerParent).GetComponent<CameraEventRunner>();
                
                _eventRunnerPool.Add(eventRunner);
            }
            
            eventRunner.gameObject.SetActive(true);
            return eventRunner;
        }

        /// <summary>
        /// Event controller object pooling
        /// </summary>
        /// <returns>Return inactive or new event controller</returns>
        private CameraEventController GetEventController(EventData eventData)
        {
            foreach(CameraEventController eventController in _eventControllers){
                if(eventController.EventData == eventData){
                    return eventController;
                }
            }

            Debug.LogError($"Camera event controller with ID: {eventData.EventId} not found");
            return null;
        }
    }
}