using UnityEngine;

namespace TheDuction.Quest{
    public class QuestController : MonoBehaviour {
        [SerializeField] private QuestModel _questModel;
        [SerializeField] private int _currentDefinitionOfDone;
        [SerializeField] private QuestState _questState = QuestState.NotStarted;
        
        public delegate void OnQuestStateChange();
        public event OnQuestStateChange OnStateChange;

        public int CurrentDefinitionOfDone => _currentDefinitionOfDone;
        public QuestState State => _questState;

        public QuestModel QuestObject{
            set{
                _questModel = value;
            }

            get{ return _questModel; }
        }

        /// <summary>
        /// Update definition of done for the quest
        /// </summary>
        public void UpdateDefinitionOfDone(){
            _currentDefinitionOfDone += 1;
            if(_currentDefinitionOfDone == _questModel.DefinitionOfDone){
                UpdateQuestState(QuestState.Finish);
            }
        }

        public void UpdateQuestState(QuestState newState){
            _questState = newState;
            OnStateChange?.Invoke();
        }
    }
}