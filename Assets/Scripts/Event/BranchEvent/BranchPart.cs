using System;
using System.Collections.Generic;
using TheDuction.Event.DialogueEvent;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    [Serializable]
    public class BranchPart{
        [SerializeField] private string _name;
        public BranchState branchPartState = BranchState.NotStarted;
        [SerializeField] private DialogueEventData _eventToFinish;
        [SerializeField] private List<DialogueEventData> _eventDatas;

        public List<DialogueEventData> EventDatas => _eventDatas;
        public DialogueEventData EventToFinish => _eventToFinish;
    }
}