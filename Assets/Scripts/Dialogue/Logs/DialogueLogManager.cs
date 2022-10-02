using TheDuction.Global;
using TheDuction.Global.Effects;
using UnityEngine;

namespace TheDuction.Dialogue.Logs{
    public class DialogueLogManager : 
        SingletonBaseClass<DialogueLogManager>, IDialoguePropertiesManager {
        [SerializeField] private CanvasGroup dialogueLogCanvasGroup;
        [SerializeField] private DialogueLog dialogueLogPrefab;
        [SerializeField] private Transform dialogueLogParent;

        private DialogueManager dialogueManager;

        private void Awake() {
            dialogueManager = DialogueManager.Instance;
        }

        /// <summary>
        /// Add dialogue log
        /// </summary>
        public void AddDialogueLog(string speakerNameValue, string dialogueTextValue){
            DialogueLog dialogueLogObject = Instantiate(dialogueLogPrefab, dialogueLogParent);
            dialogueLogObject.SetupLog(speakerNameValue, dialogueTextValue);
            dialogueLogObject.PrefabSetup();
        }
        
        public void Display(){
            StartCoroutine(AlphaFadingEffect.FadeIn(dialogueLogCanvasGroup,
                beforeEffect: () => dialogueManager.PushDialogueMode(DialogueMode.ViewLog))
            );
        }

        public void Hide(){ 
            StartCoroutine(AlphaFadingEffect.FadeOut(dialogueLogCanvasGroup,
                afterEffect: () => dialogueManager.PopDialogueMode(DialogueMode.ViewLog))
            );
        }
    }
}