using TheDuction.Dialogue;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Interaction;
using TheDuction.Quest;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventRunner : MonoBehaviour, IEventRunner {
        [SerializeField] private DialogueEventController _eventController;
        [SerializeField] private bool _canStartEvent;

        public DialogueEventController EventController {
            set { _eventController = value; }
            get { return _eventController; }
        }

        public bool CanStartEvent{
            set { _canStartEvent = value; }
            get { return _canStartEvent; }
        }

        private DialogueEventData _dialogueEventData;
        private DialogueManager _dialogueManager;
        private InteractableManager _interactableManager;
        private QuestManager _questManager;
        private QuestController _questController;
        private bool _hasSetFinishCondition, _canSetNextEvent;

        private void Awake()
        {
            _dialogueManager = DialogueManager.Instance;
            _interactableManager = InteractableManager.Instance;
            _questManager = QuestManager.Instance;
        }

        private void Start() {
            if(_eventController.EventData.RelatedQuest)
                _questController = _questManager.GetQuestController(_eventController.EventData.RelatedQuest);

            _dialogueEventData = _eventController.EventData as DialogueEventData;
        }

        private void OnDisable() {
            _canSetNextEvent = false;
            _canStartEvent = false;
            _hasSetFinishCondition = false;
        }

        private void Update()
        {
            switch (_eventController.EventState)
            {
                case EventState.NotStarted:
                    if(_canStartEvent)
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
                        switch (_eventController.EventData.FinishCondition)
                        {
                            case FinishCondition.DialogueFinished:
                                _eventController.TriggerObject.SetEndingCondition();
                                _hasSetFinishCondition = true;
                                _canSetNextEvent = true;
                                break;
                            case FinishCondition.CameraDurationFinished:
                                _hasSetFinishCondition = true;
                                break;
                        }
                    }
                    
                    if (_eventController.IsFinished)
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
            if(_dialogueEventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in _dialogueEventData.DialogueAffectedItems){
                    TextAsset waitDialogueAsset = dialogueAffectedItem.DialogueAsset.WaitDialogueAsset;

                    if(waitDialogueAsset){
                        // Set actor's dialogue to dialogue manager
                        // Wait dialogue
                        Interactable interactable = _interactableManager.GetInteractable(dialogueAffectedItem.AffectedInteractable);

                        Debug.Log($"{interactable.Data.InteractableName} wait {waitDialogueAsset.name}");

                        interactable.Mode = InteractableMode.DialogueMode;
                        interactable.CurrentDialogue = waitDialogueAsset;
                    }
                }
            }

            // Start the event
            // Set event state
            _eventController.EventState = EventState.Start;
        }

        public void OnEventActive()
        {
            // Set event state
            if(_questController){
                _questController.UpdateQuestState(QuestState.Active);
            }
            _eventController.EventState = EventState.Active;
            _eventController.CanBeInteracted = true;
            _eventController.InteractableObject.Mode = InteractableMode.DialogueMode;
            
            // Set branch state
            if(_dialogueEventData.UseBranchEvent){
                _eventController.BranchRunner.UpdateBranchEventState(_dialogueEventData, BranchState.Active);
            }
        }

        public void OnEventFinish()
        {
            if(_dialogueEventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in _dialogueEventData.DialogueAffectedItems){
                    TextAsset finishDialogueAsset = dialogueAffectedItem.DialogueAsset.FinishDialogueAsset;

                    if(finishDialogueAsset){
                        // Set actor's dialogue to dialogue manager
                        // Finish dialogue
                        Interactable interactable = _interactableManager.GetInteractable(dialogueAffectedItem.AffectedInteractable);

                        interactable.CurrentDialogue = finishDialogueAsset;
                    }
                }
            }
            
            // Set event state
            if(_questController){
                _questController.UpdateDefinitionOfDone();
                QuestManager.Instance.UpdateQuestNameText(_questController);
            }
            _eventController.EventState = EventState.Finish;
            // Set branch state
            if(_dialogueEventData.UseBranchEvent){
                _eventController.BranchRunner.UpdateBranchEventState(_dialogueEventData, BranchState.Finish);
            }
            // Deactivate event data renderer
            _eventController.OnEventFinish();
        }

        public void SetNextEvent()
        {
            if(_dialogueEventData.DialogueAffectedItems.Count > 0){
                foreach(DialogueAffectedItem dialogueAffectedItem in _dialogueEventData.DialogueAffectedItems){
                    DialogueAsset dialogueAsset = dialogueAffectedItem.DialogueAsset;
                    
                    if (dialogueAsset.NextEventDialogueAsset ||
                        dialogueAsset.DefaultDialogueAsset){
                        // Set next dialogue to affected actor
                        Interactable interactable = _interactableManager.GetInteractable(dialogueAffectedItem.AffectedInteractable);

                        interactable.CurrentDialogue = dialogueAsset.NextEventDialogueAsset != null 
                            ? dialogueAsset.NextEventDialogueAsset
                            : dialogueAsset.DefaultDialogueAsset;
                    }
                }
            }
            
            // Deactivate game object
            _eventController.gameObject.SetActive(_eventController.EventData.KeepObjectAfterFinish);
            gameObject.SetActive(false);
        }
    }
}