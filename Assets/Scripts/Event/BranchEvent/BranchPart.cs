using System;
using System.Collections.Generic;
using TheDuction.Event.DialogueEvent;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    [Serializable] 
    public class BranchEvent {
        [SerializeField] private BranchState _branchEventState = BranchState.NotStarted;
        [SerializeField] private DialogueEventData _dialogueEventData;
        [SerializeField] private bool _requiredToFinish;

        public BranchState BranchEventState{
            set { _branchEventState = value; }
            get { return _branchEventState; }
        }

        public DialogueEventData DialogueEventData {
            set { _dialogueEventData = value; }
            get { return _dialogueEventData; }
        }
        public bool RequiredToFinish => _requiredToFinish;
    }

    [Serializable]
    public class BranchPart{
        [SerializeField] private string _name;
        [SerializeField] private BranchState _branchPartState = BranchState.NotStarted;
        [SerializeField] private List<BranchEvent> _branchEvents;
        [SerializeField] private TextAsset _finishedEventDialogue;

        public BranchState BranchPartState{
            set { _branchPartState = value; }
            get { return _branchPartState; }
        }
        public List<BranchEvent> BranchEvents => _branchEvents;
        public TextAsset FinishedEventDialogue => _finishedEventDialogue;
    }
}