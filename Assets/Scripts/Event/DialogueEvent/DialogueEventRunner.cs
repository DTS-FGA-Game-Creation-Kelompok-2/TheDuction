using TheDuction.Dialogue;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Interaction;
using TheDuction.Quest;
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
                        dialogueAffectedItem.AffectedInteractable.Mode = InteractableMode.DialogueMode;
                        dialogueAffectedItem.AffectedInteractable.CurrentDialogue = waitDialogueAsset;
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
            if(eventData.RelatedQuest)
                eventData.RelatedQuest.UpdateQuestState(QuestState.Active);
            eventData.eventState = EventState.Active;
            eventData.canBeInteracted = true;
            eventData.InteractableObject.Mode = InteractableMode.DialogueMode;
            
            // Set branch state
            if(eventData.UseBranchEvent){
                eventData.BranchRunner.UpdateBranchEventState(eventData, BranchState.Active);
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
                        dialogueAffectedItem.AffectedInteractable.CurrentDialogue = finishDialogueAsset;
                    }
                }
            }
            
            // Set event state
            if(eventData.RelatedQuest){
                eventData.RelatedQuest.UpdateDefinitionOfDone();
                QuestManager.Instance.UpdateQuestNameText(eventData.RelatedQuest);
            }
            eventData.eventState = EventState.Finish;
            // Set branch state
            if(eventData.UseBranchEvent){
                eventData.BranchRunner.UpdateBranchEventState(eventData, BranchState.Finish);
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
                        dialogueAffectedItem.AffectedInteractable.CurrentDialogue = dialogueAsset.NextEventDialogueAsset != null 
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