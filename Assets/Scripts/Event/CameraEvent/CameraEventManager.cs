using System.Collections;
using System.Collections.Generic;
using TheDuction.Dialogue;
using TheDuction.Global;
using UnityEngine;

namespace TheDuction.Event.CameraEvent{
    public class CameraEventManager: SingletonBaseClass<CameraEventManager>, IEventManager{
        [SerializeField] private CameraEventRunner _eventRunnerPrefab;

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
            CameraEventRunner eventRunner = GetOrCreateEventRunner();
            eventRunner.eventData = eventData as CameraEventData;
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
            eventRunner.canStartEvent = true;
        }
        
        /// <summary>
        /// Event runner object pooling
        /// </summary>
        /// <returns>Return inactive or new event runner</returns>
        private CameraEventRunner GetOrCreateEventRunner()
        {
            CameraEventRunner eventRunner = _eventRunnerPool.Find(runner =>
                runner.eventData.eventState == EventState.Finish &&
                !runner.gameObject.activeInHierarchy);

            if (eventRunner == null)
            {
                eventRunner = Instantiate(_eventRunnerPrefab, transform).GetComponent<CameraEventRunner>();
                
                _eventRunnerPool.Add(eventRunner);
            }
            
            eventRunner.gameObject.SetActive(true);
            return eventRunner;
        }
    }
}