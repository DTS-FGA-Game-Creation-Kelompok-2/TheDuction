using System;
using UnityEngine;

namespace TheDuction.Event.DialogueEvent{
    [Serializable]
    public struct DialogueAsset{
        [SerializeField] private TextAsset _waitDialogueAsset;
        [SerializeField] private TextAsset _finishDialogueAsset;
        [SerializeField] private TextAsset _nextEventDialogueAsset;
        [SerializeField] private TextAsset _defaultDialogueAsset;

        public TextAsset WaitDialogueAsset => _waitDialogueAsset;
        public TextAsset NextEventDialogueAsset => _nextEventDialogueAsset;
        public TextAsset DefaultDialogueAsset => _defaultDialogueAsset;
        public TextAsset FinishDialogueAsset => _finishDialogueAsset;
    }
}