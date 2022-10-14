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
        [SerializeField] private bool _useBranchEvent;
        [DrawIf("_useBranchEvent", true)]
        [SerializeField] private string _branchID;

        public bool UseBranchEvent => _useBranchEvent;
        public string BranchID => _branchID;
        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;
        public InteractableData InteractableObject => _interactable;
    }
}