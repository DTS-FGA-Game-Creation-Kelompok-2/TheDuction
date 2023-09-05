using System.Collections.Generic;
using TheDuction.Global.Attributes;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [CreateAssetMenu(fileName = "New Dialogue Event Data", menuName = "Scriptable Objects/Event Data/Dialogue")]
    public class DialogueEventData: EventData{
        [Header("Dialogue Asset")]
        [SerializeField] private List<DialogueAffectedItem> _dialogueAffectedItems;
        [SerializeField] private InteractableData _interactable;

        [Header("Branching")]
        [SerializeField] private bool _useBranchEvent;
        [DrawIf("_useBranchEvent", true)]
        [SerializeField] private string _branchID;

        [Header("Clue Reward")]
        [SerializeField] private bool _useReward;
        [DrawIf("_useReward", true)]
        [SerializeField] private ClueData _clueReward;

        public bool UseBranchEvent => _useBranchEvent;
        public bool UseReward => _useReward;
        public string BranchID => _branchID;
        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;
        public InteractableData InteractableObject => _interactable;
        public ClueData ClueReward => _clueReward;
    }
}