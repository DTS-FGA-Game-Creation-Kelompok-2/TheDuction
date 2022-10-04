using System.Collections.Generic;
using TheDuction.Event.BranchEvent;
using TheDuction.Event.FinishConditionScripts;
using TheDuction.Global.Attributes;
using TheDuction.Items;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    public class DialogueEventData: EventData{
        [Header("Dialogue Asset")]
        [SerializeField] private List<DialogueAffectedItem> _dialogueAffectedItems;

        [Header("Branching")]
        [SerializeField] private bool _useBranchEvent;
        [DrawIf("useBranchEvent", true)]
        [SerializeField] private BranchEventRunner _branchRunner;

        // Properties
        public bool UseBranchEvent => _useBranchEvent;
        public BranchEventRunner BranchRunner => _branchRunner;
        public ItemData ItemData { get; private set; }
        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;

        private void Awake()
        {
            ItemData = GetComponent<ItemData>();
            if(!ItemData){
                ItemData = GetComponentInParent<ItemData>();
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
                    ItemData.itemMode = ItemData.ItemMode.NormalMode;
                    break;
                default:
                    Debug.Log($"Finish condition: {finishCondition} is not set in switch case");
                    break;
            }
        }
    }
}