using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Choices{
    public class DialogueChoicePrefab : MonoBehaviour, IDialoguePropertiesPrefab
    {
        private int _choiceIndex;
        [SerializeField] private Button _choiceButton;
        [SerializeField] private Text _choiceText;

        public int ChoiceIndex{
            set { _choiceIndex = value; }
        }

        public void SetChoiceText(string choiceValue){
            _choiceText.text = choiceValue;
        }

        public void PrefabSetup()
        {
            _choiceButton.onClick.RemoveAllListeners();
            _choiceButton.onClick.AddListener(() =>
            {
                DialogueChoiceManager.Instance.Decide(_choiceIndex);
            });
        }
    }
}