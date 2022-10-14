using TheDuction.Event.FinishConditionScripts;
using TheDuction.Quest;
using UnityEngine;

namespace TheDuction.Event{
    public class EventData: ScriptableObject {
        [Header("Event Data")]
        [SerializeField] private string _eventId;
        [TextArea(3,5)]
        [SerializeField] private string _eventDescription;

        [Header("Quest")]
        [SerializeField] private QuestModel _relatedQuest;

        [Header("Finish Condition")]
        [SerializeField] private FinishCondition _finishCondition;
        [SerializeField] private bool _keepObjectAfterFinish;

        // Properties
        public string EventId => _eventId;
        public bool KeepObjectAfterFinish => _keepObjectAfterFinish;
        public FinishCondition FinishCondition => _finishCondition;
        public QuestModel RelatedQuest => _relatedQuest;
    }
}