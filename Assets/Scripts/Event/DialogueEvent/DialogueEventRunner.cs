using TheDuction.Dialogue;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Items;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventRunner : MonoBehaviour, IEventRunner {
        public DialogueEventData eventData;
        public bool canStartEvent;
        private DialogueManager _dialogueManager;
        private bool _hasSetFinishCondition, _canSetNextEvent;

        private void Awake()
        {
            _dialogueManager = DialogueManager.Instance;
        }

        private void OnEnable() {
            _canSetNextEvent = false;
            canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update()
        {
            switch (eventData.eventState)
            {
                case EventState.NotStarted:
                    if(canStartEvent)
                        OnEventStart();
                    break;
                
                case EventState.Start:
                    OnEventActive();
                    break;
                
                case EventState.Active:
                    // Add ending condition to object
                    // Call on event finish when ending condition is met
                    if(!_hasSetFinishCondition)
                    {
                        switch (eventData.finishCondition)
                        {
                            case FinishCondition.DialogueFinished:
                                eventData.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                _canSetNextEvent = true;
                                break;
                            case FinishCondition.CameraDurationFinished:
                                _hasSetFinishCondition = true;
                                break;
                        }
                    }
                    
                    if (eventData.isFinished)
                    {
                        OnEventFinish();
                    }
                    break;
                case EventState.Finish:
                    if(_dialogueManager.DialogueIsPlaying || _canSetNextEvent)
                        SetNextEvent();
                    break;
            }
        }

        public void OnEventStart()
        {
            if(eventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventData.DialogueAffectedItems){
                    TextAsset waitDialogueAsset = dialogueAffectedItem.DialogueAsset.WaitDialogueAsset;

                    if(waitDialogueAsset){
                        // Set actor's dialogue to dialogue manager
                        // Wait dialogue
                        dialogueAffectedItem.AffectedItem.itemMode = ItemData.ItemMode.DialogueMode;
                        dialogueAffectedItem.AffectedItem.currentDialogue = waitDialogueAsset;
                    }
                }
            }
            
            // Start the event
            // Set event state
            eventData.eventState = EventState.Start;
        }

        public void OnEventActive()
        {
            // Set event state
            eventData.eventState = EventState.Active;
            eventData.canBeInteracted = true;
            eventData.ItemData.itemMode = ItemData.ItemMode.DialogueMode;
            
            // Set branch state
            if(eventData.UseBranchEvent){
                eventData.BranchRunner.UpdateBranchPartState(eventData, BranchState.Active);
            }
        }

        public void OnEventFinish()
        {
            if(eventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventData.DialogueAffectedItems){
                    TextAsset finishDialogueAsset = dialogueAffectedItem.DialogueAsset.FinishDialogueAsset;

                    if(finishDialogueAsset){
                        // Set actor's dialogue to dialogue manager
                        // Finish dialogue
                        dialogueAffectedItem.AffectedItem.currentDialogue = finishDialogueAsset;
                    }
                }
            }
            
            // Set event state
            eventData.eventState = EventState.Finish;
            // Set branch state
            if(eventData.UseBranchEvent){
                eventData.BranchRunner.UpdateBranchPartState(eventData, BranchState.Finish);
            }
            // Deactivate event data renderer
            eventData.OnEventFinish();
        }

        public void SetNextEvent()
        {
            if(eventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventData.DialogueAffectedItems){
                    DialogueAsset dialogueAsset = dialogueAffectedItem.DialogueAsset;
                    
                    if (dialogueAsset.NextEventDialogueAsset ||
                        dialogueAsset.DefaultDialogueAsset){
                        // Set next dialogue to affected actor
                        dialogueAffectedItem.AffectedItem.currentDialogue = dialogueAsset.NextEventDialogueAsset != null 
                            ? dialogueAsset.NextEventDialogueAsset
                            : dialogueAsset.DefaultDialogueAsset;
                    }
                }
            }
            
            // Deactivate game object
            eventData.gameObject.SetActive(eventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}