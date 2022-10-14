using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventController : EventController {
        [Header("Branching")]
        [SerializeField] private BranchEventRunner _branchRunner;

        private DialogueEventData _dialogueEventData;

        // Properties
        public BranchEventRunner BranchRunner => _branchRunner;
        public Interactable InteractableObject { get; private set; }
        
        private void Start()
        {
            SetFinishCondition();
            _dialogueEventData = EventData as DialogueEventData;
            InteractableObject = InteractableManager.Instance.GetInteractable(_dialogueEventData.InteractableObject);

            if(_dialogueEventData.UseBranchEvent)
                _branchRunner = BranchEventManager.Instance.GetBranchEventRunner(_dialogueEventData.BranchID);
        }

        public override void OnReset()
        {
            base.OnReset();
            _branchRunner = null;
        }
        
        /// <summary>
        /// Actions on event finish depends on finish condition
        /// </summary>
        public override void OnEventFinish()
        {
            switch (EventData.FinishCondition)
            {
                case FinishCondition.CameraDurationFinished:
                    break;
                case FinishCondition.DialogueFinished:
                    CanBeInteracted = false;
                    InteractableObject.Mode = InteractableMode.NormalMode;
                    break;
                default:
                    break;
            }
        }
    }
}