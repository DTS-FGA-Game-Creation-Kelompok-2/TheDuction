using System.Collections.Generic;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [CreateAssetMenu(fileName = "New Dialogue Event Data", menuName = "Scriptable Objects/Event Data/Dialogue")]
    public class DialogueEventData: EventData{
        [Header("Dialogue Asset")]
        [SerializeField] private List<DialogueAffectedItem> _dialogueAffectedItems;

        public List<DialogueAffectedItem> DialogueAffectedItems => _dialogueAffectedItems;
    }
}