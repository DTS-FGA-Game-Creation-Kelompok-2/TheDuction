using TheDuction.Global.Effects;
using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Quest{
    public class QuestView : MonoBehaviour {
        [SerializeField] private QuestController _questController;
        [SerializeField] private CanvasGroup _questCanvasGroup;
        [SerializeField] private Text _questNameText;

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
            string questName = $"{_questController.QuestObject.QuestName} ({_questController.CurrentDefinitionOfDone}/{_questController.QuestObject.DefinitionOfDone})";
            UpdateQuestNameText(questName);
        }

        public void UpdateQuestNameText(string text){
            _questNameText.text = text;
        }

        private void OnStateChange(){
            switch(_questController.State){
                case QuestState.NotStarted:
                    break;
                case QuestState.Active:
                    gameObject.SetActive(true);
                    StartCoroutine(AlphaFadingEffect.FadeIn(_questCanvasGroup));
                    break;
                case QuestState.Finish:
                    StartCoroutine(AlphaFadingEffect.FadeOut(_questCanvasGroup, afterEffect: () =>
                    {
                        gameObject.SetActive(false);
                    }));
                    break;
            }
        }
    }
}