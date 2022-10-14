using System.Collections.Generic;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Global.Attributes;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventController : EventController {
        [Header("Dialogue Asset")]
        [SerializeField] private List<DialogueAffectedItem> _dialogueAffectedItems;

        [Header("Branching")]
        [SerializeField] private bool _useBranchEvent;
        [DrawIf("_useBranchEvent", true)]
        [SerializeField] private BranchEventRunner _branchRunner;

        // Properties
        public bool UseBranchEvent => _useBranchEvent;
        public BranchEventRunner BranchRunner => _branchRunner;
        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;
        public Interactable InteractableObject { get; private set; }
        
        private void Awake()
        {
            InteractableObject = GetComponent<Interactable>();
            if(!InteractableObject){
                InteractableObject = GetComponentInParent<Interactable>();
            }
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