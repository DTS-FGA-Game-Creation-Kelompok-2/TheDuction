using System.Collections.Generic;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Global.Attributes;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventData: EventData{
        [Header("Dialogue Asset")]
        [SerializeField] private List<DialogueAffectedItem> _dialogueAffectedItems;

        [Header("Branching")]
        [SerializeField] private bool _useBranchEvent;
        [DrawIf("_useBranchEvent", true)]
        [SerializeField] private BranchEventRunner _branchRunner;

        // Properties
        public bool UseBranchEvent => _useBranchEvent;
        public BranchEventRunner BranchRunner => _branchRunner;
        public Interactable InteractableObject { get; private set; }
        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;

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
            switch (finishCondition)
            {
                case FinishCondition.CameraDurationFinished:
                case FinishCondition.ItemInteracted:
                    break;
                case FinishCondition.DialogueFinished:
                    canBeInteracted = false;
                    InteractableObject.Mode = InteractableMode.NormalMode;
                    break;
                default:
                    Debug.Log($"Finish condition: {finishCondition} is not set in switch case");
                    break;
            }
        }
    }
}