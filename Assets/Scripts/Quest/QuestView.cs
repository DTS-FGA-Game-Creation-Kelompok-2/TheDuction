using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Quest{
    public class QuestView : MonoBehaviour {
        [SerializeField] private QuestController _questController;
        [SerializeField] private Image _questImage;
        [SerializeField] private Text _questStatusText;
        [SerializeField] private Text _questNameText;
        [SerializeField] private Text _questDescription;

        public QuestController QuestController{
            set{
                _questController = value;
            }

            get{ return _questController; }
        }

        private void OnDisable() {
            _questController.OnStateChange -= OnStateChange;
        }

        public void SetupQuest(){
            _questController.OnStateChange += OnStateChange;
            _questController.UpdateQuestState(QuestState.NotStarted);
            _questNameText.text = _questController.QuestObject.QuestName;
            _questDescription.text = _questController.QuestObject.QuestDescription;
        }

        private void OnStateChange(){
            switch(_questController.State){
                case QuestState.NotStarted:
                case QuestState.Active:
                    _questStatusText.gameObject.SetActive(false);
                    break;
                case QuestState.Finish:
                    _questStatusText.gameObject.SetActive(true);
                    _questStatusText.text = "Selesai";
                    _questImage.color = new Color(0, 0, 0, 0.5f);
                    break;
            }
        }
    }
}