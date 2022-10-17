using System;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [Serializable]
    public struct DialogueAffectedItem{
        [SerializeField] private string _name;
        [SerializeField] private InteractableData _affectedInteractable;
        [SerializeField] private DialogueAsset _dialogueAsset;

        // Properties
        public string Name => _name;
        public InteractableData AffectedInteractable => _affectedInteractable;
        public DialogueAsset DialogueAsset => _dialogueAsset;
    }
}