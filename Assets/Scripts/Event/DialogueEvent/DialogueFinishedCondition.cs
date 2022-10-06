using System.Collections;
using TheDuction.Dialogue;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Items;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueFinishedCondition: FinishConditionManager{
        private DialogueManager _dialogueManager;
        private ItemData _itemData;
        
        private void Awake()
        {
            _itemData = GetComponent<ItemData>();
            if(_itemData == null){
                _itemData = GetComponentInParent<ItemData>();

                if(_itemData == null){
                    Debug.LogError($"Item data in {gameObject.name} is not found!");
                }
            }

            _dialogueManager = DialogueManager.Instance;
            eventData = GetComponent<DialogueEventData>();
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
                _dialogueManager.CurrentDialogueAsset == _itemData.currentDialogue);
            Debug.Log("Dialogue finished");
            OnEndingCondition();
        }
    }
}