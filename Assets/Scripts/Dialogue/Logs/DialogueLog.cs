using UnityEngine;
using UnityEngine.UI;

namespace TheDuction.Dialogue.Logs
{
    public class DialogueLog : MonoBehaviour, IDialoguePropertiesPrefab
    {
        [SerializeField] private Text speakerNameText;
        [SerializeField] private Text dialogueLineText;

        private string speakerName, dialogueLine;

        /// <summary>
        /// Setup speaker name and dialogue line
        /// </summary>
        /// <param name="speakerName">Speaker name</param>
        /// <param name="dialogueLine">Dialogue line</param>
        public void SetupLog(string speakerName, string dialogueLine){
            this.speakerName = speakerName;
            this.dialogueLine = dialogueLine;
        }

        /// <summary>
        /// Set dialogue log with speaker name and dialogue text
        /// </summary>
        public void PrefabSetup(){
            // Deactivate speaker name if none is talking
            if(string.IsNullOrWhiteSpace(speakerName)){
                speakerNameText.gameObject.SetActive(false);
            } else {
                speakerNameText.text = speakerName;
            }
            dialogueLineText.text = $"\"{dialogueLine.Trim()}\"";
        }
    }
}