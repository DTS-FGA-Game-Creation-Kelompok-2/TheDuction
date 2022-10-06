using System;
using UnityEngine;

namespace TheDuction.Quest{
    public enum QuestState{
        NotStarted,
        Active,
        Finish
    }

    [Serializable]
    public class QuestModel{
        [SerializeField] private string _questId;
        [SerializeField] private string _questName;
        [TextArea(3, 5)] [SerializeField] private string _questDescription;
        public QuestState questState = QuestState.NotStarted;

        public string QuestId => _questId;
        public string QuestName => _questName;
        public string QuestDescription => _questDescription;
    }
}