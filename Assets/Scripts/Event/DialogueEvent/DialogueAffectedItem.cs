using System;
using TheDuction.Interaction;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [Serializable]
    public struct DialogueAffectedItem{
        [SerializeField] private string name;
        [SerializeField] private Interactable _affectedInteractable;
        [SerializeField] private DialogueAsset _dialogueAsset;

        // Properties
        public Interactable AffectedInteractable => _affectedInteractable;
        public DialogueAsset DialogueAsset => _dialogueAsset;
    }
}