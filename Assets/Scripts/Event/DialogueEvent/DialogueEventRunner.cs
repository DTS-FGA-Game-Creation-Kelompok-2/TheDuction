using TheDuction.Dialogue;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Interaction;
using TheDuction.Quest;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventRunner : MonoBehaviour, IEventRunner {
        public DialogueEventController eventController;
        public bool canStartEvent;
        private DialogueManager _dialogueManager;
        private QuestManager _questManager;
        private QuestController _questController;
        private bool _hasSetFinishCondition, _canSetNextEvent;

        private void Awake()
        {
            _dialogueManager = DialogueManager.Instance;
            _questManager = QuestManager.Instance;
        }

        private void Start() {
            if(eventController.EventData.RelatedQuest)
                _questController = _questManager.GetQuestController(eventController.EventData.RelatedQuest);
        }

        private void OnEnable() {
            _canSetNextEvent = false;
            canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update()
        {
            switch (eventController.EventState)
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
                        switch (eventController.EventData.FinishCondition)
                        {
                            case FinishCondition.DialogueFinished:
                                eventController.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                _canSetNextEvent = true;
                                break;
                            case FinishCondition.CameraDurationFinished:
                                _hasSetFinishCondition = true;
                                break;
                        }
                    }
                    
                    if (eventController.IsFinished)
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
            if(eventController.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventController.DialogueAffectedItems){
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
            eventController.EventState = EventState.Start;
        }

        public void OnEventActive()
        {
            // Set event state
            if(_questController){
                _questController.UpdateQuestState(QuestState.Active);
            }
            eventController.EventState = EventState.Active;
            eventController.CanBeInteracted = true;
            eventController.InteractableObject.Mode = InteractableMode.DialogueMode;
            
            // Set branch state
            if(eventController.UseBranchEvent){
                eventController.BranchRunner.UpdateBranchEventState(eventController, BranchState.Active);
            }
        }

        public void OnEventFinish()
        {
            if(eventController.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventController.DialogueAffectedItems){
                    TextAsset finishDialogueAsset = dialogueAffectedItem.DialogueAsset.FinishDialogueAsset;

                    if(finishDialogueAsset){
                        // Set actor's dialogue to dialogue manager
                        // Finish dialogue
                        dialogueAffectedItem.AffectedInteractable.CurrentDialogue = finishDialogueAsset;
                    }
                }
            }
            
            // Set event state
            if(_questController){
                _questController.UpdateDefinitionOfDone();
                QuestManager.Instance.UpdateQuestNameText(_questController);
            }
            eventController.EventState = EventState.Finish;
            // Set branch state
            if(eventController.UseBranchEvent){
                eventController.BranchRunner.UpdateBranchEventState(eventController, BranchState.Finish);
            }
            // Deactivate event data renderer
            eventController.OnEventFinish();
        }

        public void SetNextEvent()
        {
            if(eventController.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in eventController.DialogueAffectedItems){
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
            // eventData.gameObject.SetActive(eventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}