using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueFinishedCondition: FinishConditionManager{
        private DialogueManager _dialogueManager;
        private Interactable _interactable;
        
        private void Awake()
        {
            _dialogueManager = DialogueManager.Instance;
            eventController = GetComponent<DialogueEventController>();
        }

        private void OnEnable() {
            DialogueEventData dialogueEventData = eventController.EventData as DialogueEventData;
            _interactable = InteractableManager.Instance.GetInteractable(dialogueEventData.InteractableObject);
        }

        public override void SetEndingCondition()
        {
            StartCoroutine(WaitUntilDialogueFinished());
        }
        
        /// <summary>
        /// Wait until dialogue finished or is not playing anymore
        /// The moment dialogue is not playing anymore, call on ending condition
        /// </summary>
        /// <returns></returns>
        private IEnumerator WaitUntilDialogueFinished()
        {
            Debug.Log("Wait for dialogue finished");
            yield return new WaitUntil(() => 
                _dialogueManager.DialogueModeStackList.Count == 0 &&
                _dialogueManager.CurrentDialogueAsset == _interactable.CurrentDialogue);
            Debug.Log("Dialogue finished");
            OnEndingCondition();
        }
    }
}