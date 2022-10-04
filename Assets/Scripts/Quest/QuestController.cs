using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Quest{
    public class QuestController : MonoBehaviour {
        [SerializeField] private QuestModel _questModel;

        public QuestModel QuestObject{
            set{
                _questModel = value;
            }

            get{ return _questModel; }
        }

        public void UpdateQuestState(QuestState newState){
            _questModel.questState = newState;
        }
    }
}