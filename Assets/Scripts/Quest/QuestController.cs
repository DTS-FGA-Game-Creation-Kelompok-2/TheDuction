using UnityEngine;

namespace TheDuction.Quest{
    public class QuestController : MonoBehaviour {
        [SerializeField] private QuestModel _questModel;
        [SerializeField] private QuestState _questState = QuestState.NotStarted;
        
        public delegate void OnQuestStateChange();
        public event OnQuestStateChange OnStateChange;

        public QuestState State => _questState;

        public QuestModel QuestObject{
            set{
                _questModel = value;
            }

            get{ return _questModel; }
        }

        public void UpdateQuestState(QuestState newState){
            _questState = newState;
            OnStateChange?.Invoke();
        }
    }
}