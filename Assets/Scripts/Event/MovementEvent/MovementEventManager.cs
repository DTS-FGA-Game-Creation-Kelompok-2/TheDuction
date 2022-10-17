using System.Collections;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Event.MovementEvent{
    public class MovementEventManager : SingletonBaseClass<MovementEventManager>, IEventManager
    {
        [SerializeField] private Image _blackScreen;

        [Header("Event Controller")]
        [SerializeField] private List<MovementEventController> _eventControllers;

        [Header("Event Runner")]
        [SerializeField] private MovementEventRunner _eventRunnerPrefab;
        [SerializeField] private Transform _eventRunnerParent;

        private List<MovementEventRunner> _eventRunnerPool;
        
        private void Awake() {
            _eventRunnerPool = new List<MovementEventRunner>(); 
        }

        public void SetEventData(EventData eventData)
        {
            MovementEventController eventController = GetEventController(eventData);
            eventController.BlackScreen = _blackScreen;
            
            MovementEventRunner eventRunner = GetOrCreateEventRunner();
            eventRunner.EventController = eventController;

            StartCoroutine(StartEvent(eventRunner));
        }

        /// <summary>
        /// Start event when dialogue is finished
        /// </summary>
        /// <param name="eventRunner"></param>
        /// <returns></returns>
        private IEnumerator StartEvent(MovementEventRunner eventRunner)
        {
            yield return new WaitUntil(() => !DialogueManager.Instance.DialogueIsPlaying);
            yield return new WaitForSeconds(1f);

            eventRunner.CanStartEvent = true;
        }

        /// <summary>
        /// Event runner object pooling
        /// </summary>
        /// <returns>Return inactive or new event runner</returns>
        private MovementEventRunner GetOrCreateEventRunner()
        {
            MovementEventRunner eventRunner = _eventRunnerPool.Find(runner =>
                runner.EventController.EventState == EventState.Finish &&
                !runner.gameObject.activeInHierarchy);

            if (eventRunner == null)
            {
                eventRunner = Instantiate(_eventRunnerPrefab, _eventRunnerParent).GetComponent<MovementEventRunner>();
                
                _eventRunnerPool.Add(eventRunner);
            }
            
            eventRunner.gameObject.SetActive(true);
            return eventRunner;
        }

        /// <summary>
        /// Event controller object pooling
        /// </summary>
        /// <returns>Return inactive or new event controller</returns>
        private MovementEventController GetEventController(EventData eventData)
        {
            foreach(MovementEventController eventController in _eventControllers){
                if(eventController.EventData == eventData){
                    return eventController;
                }
            }

            Debug.LogError($"Movement event controller with ID: {eventData.EventId} not found");
            return null;
        }
    }
}