using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Choices{
    public class DialogueChoicePrefab : MonoBehaviour, IDialoguePropertiesPrefab
    {
        public int choiceIndex;
        [SerializeField] private Button choiceButton;
        [SerializeField] private Text choiceText;

        public void SetChoiceText(string choiceValue){
            choiceText.text = choiceValue;
        }

        public void PrefabSetup()
        {
            choiceButton.onClick.RemoveAllListeners();
            choiceButton.onClick.AddListener(() =>
            {
                DialogueChoiceManager.Instance.Decide(choiceIndex);
            });
        }
    }
}