using System.Collections;
using TheDuction.Event.DialogueEvent;
using TheDuction.Interaction;
using UnityEngine;

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
                    if(_branchEventData.BranchParts[i].branchPartState == BranchState.Active) continue;

                    _branchEventData.BranchParts[i].EventDatas.ForEach(eventData =>
                    {
                        if(eventData.InteractableObject)
                            eventData.InteractableObject.Mode = InteractableMode.NormalMode;
                    });
                }

                _observeInUpdate = false;
            }
        }

        /// <summary>
        /// Update branch event state
        /// If finish update all item in event data to normal mode, 
        /// so it doesn't trigger the dialogue
        /// </summary>
        /// <param name="newState"></param>
        public void UpdateBranchPartState(DialogueEventData dialogueEventData, BranchState newState){
            foreach (BranchPart branchPart in _branchEventData.BranchParts)
            {
                foreach (DialogueEventData eventData in branchPart.EventDatas){
                    // Check which dialogue event data
                    if(eventData == dialogueEventData){
                        branchPart.branchPartState = newState;

                        // Look at new state
                        if(newState == BranchState.Active){
                            _activeBranchPart = branchPart;
                            _canObserveActive = true;
                        }

                        break;
                    }
                }
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
            yield return new WaitUntil(() => _activeBranchPart.EventToFinish.isFinished);

            _activeBranchPart.EventDatas.ForEach(eventData =>{
                eventData.InteractableObject.Mode = InteractableMode.NormalMode;
                eventData.canBeInteracted = false;
            });

            Destroy(gameObject);
        }
    }
}