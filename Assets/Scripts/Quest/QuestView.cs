using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Quest{
    public class QuestView : MonoBehaviour {
        [SerializeField] private QuestController _questController;
        [SerializeField] private Text _questNameText;
        [SerializeField] private Text _questDescription;

        public QuestController QuestController{
            set{
                _questController = value;
            }

            get{ return _questController; }
        }

        private void OnEnable() {
            SetupQuest();
        }

        private void SetupQuest(){
            _questNameText.text = _questController.QuestObject.QuestName;
            _questDescription.text = _questController.QuestObject.QuestDescription;
        }
    }
}