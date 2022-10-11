using System;
using System.Collections.Generic;
using TheDuction.Event.DialogueEvent;
using UnityEngine;

namespace TheDuction.Event.BranchEvent{
    [Serializable]
    public class BranchPart{
        [SerializeField] private string _name;
        public BranchState branchPartState = BranchState.NotStarted;
        [SerializeField] private List<DialogueEventData> _eventsToFinish;
        [SerializeField] private List<DialogueEventData> _eventDatas;
        [SerializeField] private TextAsset _finishedEventDialogue;

        public List<DialogueEventData> EventDatas => _eventDatas;
        public List<DialogueEventData> EventsToFinish => _eventsToFinish;
        public TextAsset FinishedEventDialogue => _finishedEventDialogue;
    }
}