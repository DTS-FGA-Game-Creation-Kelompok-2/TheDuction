using UnityEngine;

namespace TheDuction.Quest{
    public enum QuestState{
        NotStarted,
        Active,
        Finish
    }

    [CreateAssetMenu(fileName = "New Quest", menuName = "Scriptable Objects/Quest")]
    public class QuestModel: ScriptableObject{
        [SerializeField] private string _questId;
        [SerializeField] private string _questName;
        [SerializeField] private int _definitionOfDone = 1;
        [TextArea(3, 5)] [SerializeField] private string _questDescription;

        public string QuestId => _questId;
        public string QuestName => _questName;
        public int DefinitionOfDone => _definitionOfDone;
        public string QuestDescription => _questDescription;
    }
}