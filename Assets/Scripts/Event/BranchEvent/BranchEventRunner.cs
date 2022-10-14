using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Event.DialogueEvent;
using TheDuction.Interaction;
using UnityEngine;
using System.Linq;

namespace TheDuction.Event.BranchEvent{
    public class BranchEventRunner : MonoBehaviour {
        [SerializeField] private BranchEventData _branchEventData;

        private BranchPart _activeBranchPart;
        private bool _canObserveActive, _observeInUpdate;

        public BranchEventData BranchEventData => _branchEventData;

        private void Start() {
            StartCoroutine(ObserveActive());
            StartCoroutine(ObserveFinish());
        }

        private void Update() {
            if(_observeInUpdate){
                for (int i = 0; i < _branchEventData.BranchParts.Count; i++){
                    if(_branchEventData.BranchParts[i].BranchPartState == BranchState.Active) continue;

                    _branchEventData.BranchParts[i].BranchEvents.ForEach(branchEvent =>
                    {
                        DialogueEventController eventController = DialogueEventManager.Instance.GetDialogueEventController(branchEvent.DialogueEventData);
                        if(eventController.InteractableObject)
                            eventController.InteractableObject.Mode = InteractableMode.NormalMode;
                    });
                }

                _observeInUpdate = false;
            }
        }

        /// <summary>
        /// Update branch event's state
        /// </summary>
        /// <param name="eventData">Event data</param>
        /// <param name="newState">New state</param>
        public void UpdateBranchEventState(DialogueEventData eventData, BranchState newState){
            foreach (BranchPart branchPart in _branchEventData.BranchParts)
            {
                foreach (BranchEvent branchEvent in branchPart.BranchEvents)
                {
                    if (branchEvent.DialogueEventData == eventData)
                    {
                        branchEvent.BranchEventState = newState;
                        UpdateBranchPartState(branchPart, newState);

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Update branch part's event state
        /// </summary>
        /// <param name="branchPart">Branch Part</param>
        /// <param name="newState">New state</param>
        private void UpdateBranchPartState(BranchPart branchPart, BranchState newState){
            switch(newState){
                case BranchState.NotStarted:
                    break;
                case BranchState.Active:
                    branchPart.BranchPartState = newState;
                    _activeBranchPart = branchPart;
                    _canObserveActive = true;
                    break;
                case BranchState.Finish:
                    foreach(BranchEvent branchEvent in branchPart.BranchEvents.Where(branchEvent => branchEvent.RequiredToFinish)){
                        if(branchEvent.BranchEventState != newState) return;
                    }
                    branchPart.BranchPartState = newState;
                    break;
            }
        }

        /// <summary>
        /// Observe active branch after there is active branch part and 0.5s
        /// </summary>
        /// <returns></returns>
        private IEnumerator ObserveActive(){
            yield return new WaitUntil(() => _canObserveActive);
            yield return new WaitForSeconds(0.5f);
            _observeInUpdate = true;
        }

        /// <summary>
        /// Observe finish branch after event to finish is finished
        /// </summary>
        /// <returns></returns>
        private IEnumerator ObserveFinish(){
            yield return new WaitUntil(() => _activeBranchPart != null);
            yield return new WaitUntil(() => {
                // Check branch event that is required to finish only
                foreach(BranchEvent branchEvent in _activeBranchPart.BranchEvents.Where(branchEvent => branchEvent.RequiredToFinish)){
                    DialogueEventController eventController = DialogueEventManager.Instance.GetDialogueEventController(branchEvent.DialogueEventData);
                    if(!eventController.IsFinished) return false;
                }

                return true;
            });

            _activeBranchPart.BranchEvents.ForEach(branchEvent =>{
                DialogueEventController eventController = DialogueEventManager.Instance.GetDialogueEventController(branchEvent.DialogueEventData);
                eventController.InteractableObject.Mode = InteractableMode.NormalMode;
                eventController.CanBeInteracted = false;
            });
            
            DialogueManager.Instance.SetDialogue(_activeBranchPart.FinishedEventDialogue);

            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !DialogueManager.Instance.DialogueIsPlaying);

            _activeBranchPart.BranchEvents.ForEach(branchEvent =>{
                DialogueEventController eventController = DialogueEventManager.Instance.GetDialogueEventController(branchEvent.DialogueEventData);
                eventController.gameObject.SetActive(false);
            });
            Destroy(gameObject);
        }
    }
}