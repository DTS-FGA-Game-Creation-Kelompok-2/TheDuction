using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Logs
{
    public class DialogueLogPrefab : MonoBehaviour, IDialoguePropertiesPrefab
    {
        [SerializeField] private Text _speakerNameText;
        [SerializeField] private Text _dialogueLineText;

        private string _speakerName, _dialogueLine;

        /// <summary>
        /// Setup speaker name and dialogue line
        /// </summary>
        /// <param name="speakerName">Speaker name</param>
        /// <param name="dialogueLine">Dialogue line</param>
        public void SetupLog(string speakerName, string dialogueLine){
            _speakerName = speakerName;
            _dialogueLine = dialogueLine;
        }

        /// <summary>
        /// Set dialogue log with speaker name and dialogue text
        /// </summary>
        public void PrefabSetup(){
            // Deactivate speaker name if none is talking
            if(string.IsNullOrWhiteSpace(_speakerName)){
                _speakerNameText.gameObject.SetActive(false);
            } else {
                _speakerNameText.text = _speakerName;
            }
            _dialogueLineText.text = $"\"{_dialogueLine.Trim()}\"";
        }
    }
}