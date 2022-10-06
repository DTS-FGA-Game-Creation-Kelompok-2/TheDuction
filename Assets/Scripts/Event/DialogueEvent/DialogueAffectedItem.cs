using System;
using TheDuction.Items;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [Serializable]
    public struct DialogueAffectedItem{
        [SerializeField] private string name;
        [SerializeField] private ItemData affectedItem;
        [SerializeField] private DialogueAsset _dialogueAsset;

        // Properties
        public ItemData AffectedItem => affectedItem;
        public DialogueAsset DialogueAsset => _dialogueAsset;
    }
}